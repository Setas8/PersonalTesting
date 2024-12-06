user = input("User: ")
pswd = input("Password: ")

if user == "diego" and pswd == "1234":
    print("Login successful!")
elif user != "diego" and pswd == "1234":
    print("Incorrect username.")
elif user == "diego" and pswd != "1234":
    print("Incorrect password.")
else:
    print("Incorrect username and password.")