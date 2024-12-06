def es_anagrama(palabra1, palabra2):

    anagrama = False

    palabra1 = palabra1.replace(" ", "").lower()
    palabra2 = palabra2.replace(" ", "").lower()
    
    # +1 para incrementar las veces que aparece una letra y modificar su valor
    # Si lo dejo a 0, todos los caracteres(letra-clave) tienen el mismo valor
    dicc_palabra1 = {}
    for letra in palabra1:
        dicc_palabra1[letra] = dicc_palabra1.get(letra,0) + 1

    dicc_palabra2 = {}
    for letra in palabra2:
        dicc_palabra2[letra] = dicc_palabra2.get(letra,0) + 1

    if (sorted(palabra1) == sorted(palabra2)) and (len(palabra1) == len(palabra1)):
        anagrama = True
    
    return anagrama

# Prueba de la función
palabra1 = "Tom Marvolo Riddle"
palabra2 = "I am Lord Voldemort"

resultado = es_anagrama(palabra1, palabra2)
print(resultado)