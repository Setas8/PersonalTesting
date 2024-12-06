partial1 = float(input("Scored partial 1: "))
partial2 = float(input("Scored partial 2: "))
partial3 = float(input("Scored partial 3: "))
exam = float(input("Scored exam: "))
project = float(input("Scored project: "))
mark = ((partial1+partial2+partial3)/3) * 0.55 + 0.3 * exam + 0.15 * project

print("Final mark %.2f" %mark)