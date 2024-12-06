from random import randint
from math import pow

lista1 = []
lista2 = []
lista3 = []
for num in range(1,11):
    aleatorio = randint(1,100)
    lista1.append(aleatorio)
    lista2.append(pow(aleatorio,2))
    lista3.append(pow(aleatorio,3))
print(f"{'Número':<10}{'Cuadrado':<15}{'Cubo':<15}")
for num, cuadrado, cubo in zip(lista1, lista2, lista3):
    print(f"{num:<10}{cuadrado:<15}{cubo:<15}")