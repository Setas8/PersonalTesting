package primitiva

import (
	"fmt"
	"math/rand"
	"sort"
	"time"
)

func main() {
	mostrarMenu()
}

func mostrarMenu() {
	for {
		fmt.Println("\nMENÚ")
		fmt.Println("1 - Generar combinaciones de la Primitiva")
		fmt.Println("2 - Salir")
		fmt.Print("Seleccione una opción: ")
		var opcion int
		fmt.Scanln(&opcion)

		switch opcion {
		case 1:
			generarCombinaciones()
		case 2:
			fmt.Println("¡Hasta pronto!")
			return
		default:
			fmt.Println("Opción no válida. Inténtelo de nuevo.")
		}
	}
}

func generarCombinaciones() {
	fmt.Print("Número de participantes: ")
	var participantes int
	fmt.Scanln(&participantes)

	for i := 1; i <= participantes; i++ {
		combinacion := calcularCombinacionGanadora()
		fmt.Printf("\nParticipante %d\n", i)
		fmt.Printf("Combinación: %v\n", combinacion)
	}
}

func calcularCombinacionGanadora() []int {
	rand.Seed(time.Now().UnixNano())
	primitiva := make(map[int]struct{})
	for len(primitiva) < 6 {
		num := rand.Intn(49) + 1
		primitiva[num] = struct{}{}
	}

	combinacion := make([]int, 0, len(primitiva))
	for num := range primitiva {
		combinacion = append(combinacion, num)
	}
	sort.Ints(combinacion)
	return combinacion
}
