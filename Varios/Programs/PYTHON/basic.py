print("===EJ1===")
# Escribir un programa que pregunte al usuario su nombre, y luego lo salude.
nombre = input("Nombre: ")
print("Hola",nombre)
print("===EJ2===")
#Calcular el perímetro y área de un rectángulo dada su base y su altura.
base = float(input("Base:"))
altura = float(input("Altura:"))
print("Área:",base*altura)
print("Perímetro:",base*2+altura*2)
print("===EJ3===")
# Dados los catetos de un triángulo rectángulo, calcular su hipotenusa.
import math
cateto1 = float(input("Cateto1:"))
cateto2 = float(input("Cateto2:"))
print("Hipotenusa:%.2f" % math.sqrt(cateto1 ** 2 + cateto2 ** 2))
print("===EJ4===")