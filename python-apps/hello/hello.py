pal = "racecard"
last = len(pal)
success = True
for x in range(len(pal)//2):
    last -= 1
    if(pal[x] != pal[last]):
        success = False
if(success == True):
    print(pal+" is a palindrome")
else:
    print(pal+" is not a palindrome")
