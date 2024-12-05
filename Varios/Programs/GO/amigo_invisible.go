package main

import (
	"fmt"
	"math/rand"
	"time"
)

func main() {
	
	var participantsNum int
	fmt.Print("Number of participants: ")
	fmt.Scan(&participantsNum)

	var participants []string

	for i := 0; i < participantsNum; i++ {
		var name string
		fmt.Printf("Name participant %d: ", i+1)
		fmt.Scan(&name)
		participants = append(participants, name)
	}
	
	rand.Seed(time.Now().UnixNano())
	rand.Shuffle(len(participants), func(i, j int) {
		participants[i], participants[j] = participants[j], participants[i]
	})

	secretSantas := make(map[string]string)

	for i := 0; i < participantsNum; i++ {
		secretSanta := participants[(i+1)%participantsNum]
		secretSantas[participants[i]] = secretSanta
	}

	fmt.Println("\nSECRET SANTA RESULT")
	for key, value := range secretSantas {
		fmt.Printf("%s --> %s\n", key, value)
	}
}
