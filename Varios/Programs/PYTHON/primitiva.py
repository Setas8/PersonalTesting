import random

def mostrar_menu():
    while True:
        print("\nMENÚ")
        print("1 - Generar combinaciones de la Primitiva")
        print("2 - Salir")
        opcion = input("Seleccione una opción: ")

        if opcion == "1":
            generar_combinaciones()
        elif opcion == "2":
            print("¡Hasta pronto!")
            break
        else:
            print("Opción no válida. Inténtelo de nuevo.")

def generar_combinaciones():
    participantes = int(input("Número de participantes: "))
    for i in range(1, participantes + 1):
        combinacion = calcular_combinacion_ganadora()
        print(f"\nParticipante {i}")
        print(f"Combinación: {combinacion}")

def calcular_combinacion_ganadora():
    primitiva = set()
    while len(primitiva) < 6:
        num = random.randint(1, 49)
        primitiva.add(num)
    return sorted(primitiva)

if __name__ == "__main__":
    mostrar_menu()
