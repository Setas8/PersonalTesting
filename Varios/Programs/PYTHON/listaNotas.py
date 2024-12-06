lista = []

while len(lista) < 5: 
    try:
        nota = int(input("Mark (0-10): "))
        if 0 <= nota <= 10: 
            lista.append(nota)
        else:
            print("The mark must be between 0 and 10.")
    except ValueError: 
        print("Please enter a valid number.")

print("\nResults:")
print(f"Avg: {sum(lista)/5:.2f}")
print(f"Max: {max(lista)}")
print(f"Min: {min(lista)}")
print(f"List: {lista}")