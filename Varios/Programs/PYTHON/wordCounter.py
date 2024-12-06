sentence = input("Write a sentence: ").strip()

if not sentence: 
    counter = 0
else:
    words = sentence.split()
    counter = len(words)

print("Number of words:", counter)