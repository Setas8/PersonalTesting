# permita calcular la hora de llegada de un viaje, 
# dado el tiempo de partida en formato de 24 horas (horas, minutos y segundos) 
# y la duración del viaje en segundos.

departureHour = int(input("Departure Hour: "))
departureMin = int(input("Departure Min: "))
departureSecs = int(input("Departure Secs: "))
tripSecs =  int(input("Trip seconds: "))

initialSecs = departureHour*3600 + departureMin*60 + departureSecs
finalSecs = initialSecs + tripSecs
arrivalhour = (finalSecs // 3600) % 24
arrivalMin = (finalSecs % 3600) // 60
arrivalSecs = (finalSecs % 3600) % 60

print("Time of arrival:")
print(arrivalhour,":",arrivalMin,":",arrivalSecs)