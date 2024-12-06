control = False
evenNumbers = ""
oddNumbers = ""

for var in range(1,6):
    num = int(input("Number: "))
    number = str(num)
    if num%2 == 0:
        control = True        
        evenNumbers += number + " "
    else:        
        oddNumbers += number + " "

if control == False:
    print("There is no even numbers")
else:
    print("Even numbers: ", evenNumbers)
print("Odd numbers: ", oddNumbers)