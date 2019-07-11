using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace signatureAnalysis
{
    class Program
    {

        static void enterToCSV(string file, string outFile, string type)
        {
            string newLine = "";
            string hashString = "";
            //We know that this is a file of the correct extension, so we will just read the whole thing in
            byte[] binaryFile = File.ReadAllBytes(file);

            //Using the MD5 dotnet class to create our hash
            MD5 md5Hash = System.Security.Cryptography.MD5.Create();
            byte[] newHash = md5Hash.ComputeHash(binaryFile);

            //Add it into a string so we can place it in the CSV nicely
            StringBuilder sb = new StringBuilder();
            foreach (byte newByte in newHash)
            {
                //Formatting the byte as a 2-digit hex string
                sb.Append(newByte.ToString("X2"));
            }
            hashString = sb.ToString();
            newLine = file + "," + type + "," + hashString + Environment.NewLine;
            try
            {
                //We cleared the file earlier, so we can just start appending new lines
                File.AppendAllText(outFile, newLine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static string checkValid(byte[] byteArray, string file)
        {
            string JPG = "FFD8";
            string PDF = "25504446";
            string concBytes = "";
            //Reading from a file can be dangerous, so we will wrap this in a try/catch
            try
            {
                FileStream streamy = new FileStream(file, FileMode.Open, FileAccess.Read);
                streamy.Read(byteArray, 0, byteArray.Length);
                streamy.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (byte newByte in byteArray)
            {
                //Cast the byte into a 2-digit hex string to compare
                concBytes += newByte.ToString("X2");
            }
            if (concBytes.Contains(JPG))
            {
                return "JPG";
            }
            else if (concBytes.Contains(PDF))
            {
                return "PDF";
            }
            else
            {
                return "None";
            }
        }

        static void Main(string[] args)
        {
            //Check for bad length, as we will know anything other than 3 args is invalid
            if (args.Length != 3)
            {
                Console.WriteLine("Please enter three arguments in the command line in the order of <String>Search Directory, <String>Output File, <Boolean>Recursive File Search");
                System.Environment.Exit(1);
            }

            bool recurse = false;
            string outFile = args[1];
            string scanDir = args[0];
            //Some regex in case the user likes or doesn't like caps
            string pattern = "[Tt]rue";
            Match result = Regex.Match(args[2], pattern);
            if (result.Success)
            {
                recurse = true;
            }
            else
            {
                pattern = "[Ff]alse";
                result = Regex.Match(args[2], pattern);
                if (!result.Success)
                {
                    //recurse is false by default, but if they put in an invalid paramater let's send them back to the command prompt to be sure the program does as expected
                    Console.WriteLine("Invalid third argument entered, please enter the third argument as either True or False");
                    System.Environment.Exit(1);
                }
            }

            //Clear out the out file for the new run of this program, this will also create the file if it does not already exist
            File.WriteAllText(outFile, "Full Path to the File, Actual File Type, File MD5 hash" + Environment.NewLine);
            if (!recurse)
            {
                string[] filePaths = Directory.GetFiles(@args[0]);
                foreach (string file in filePaths)
                {
                    string type = "";
                    byte[] byteArray = new byte[4];
                    type = checkValid(byteArray, file);
                    //CheckValid will return a value of None if the file is not a JPG or PDF, and then we will just skip over that file
                    if (type != "None")
                    {
                        enterToCSV(file, outFile, type);
                    }
                }
            }
            else
            {
                //Rather than do this the hard way, let's use a dotNet class to do the heavy lifting here
                DirectoryInfo objDirectoryInfo = new DirectoryInfo(scanDir);
                //This class has a recursive search option which is very nice, so we will look through all directories
                FileInfo[] allFiles = objDirectoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
                foreach (FileInfo file in allFiles)
                {
                    string type = "";
                    byte[] byteArray = new byte[4];
                    type = checkValid(byteArray, file.FullName);
                    if (type != "None")
                    {
                        enterToCSV(file.FullName, outFile, type);
                    }
                }
            }
        }
    }
}
