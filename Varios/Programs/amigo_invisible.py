import random

def main():

    participants_num = int(input("Number of participants: "))
    
    participants = []
    
    for i in range(participants_num):
        name = input(f"Name participant {i+1}: ")
        participants.append(name)

    random.shuffle(participants)

    secret_santas = {}

    for i in range(participants_num):
        secret_santa = participants[(i + 1) % participants_num]
        secret_santas[participants[i]] = secret_santa

    print("\nSECRET SANTA RESULT")
    for key, value in secret_santas.items():
        print(f"{key} --> {value}")

if __name__ == "__main__":
    main()