newList = [3, 1, 2, 5, 6, 4]
products1 = []
newInt = 1
products1.append(newInt)
for x in range(1, len(newList)):
    newInt *= newList[x-1]
    products1.append(newInt)
print(products1)

newInt = 1
for y in range(1, len(newList)):
    newInt *= newList[len(newList)-y]
    print(newInt)
    products1[len(products1)-y-1] *= newInt
print(products1)
