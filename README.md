# SteamAccountManager
Some type of people need a lot of accounts for steam, this app allows you to switch between accounts by clicking 2 buttons
The advantage of this program is that it uses encryption.

# Important
If you start the application for the first time use admin because it will need access to create a file in C:/
Also it might take time to log in to steam, it might look like the application stopped but due to steam updates for some reason it takes more time to log in

# How it works
This applicaton takes information about one of your drives and puts it into the string, the string gets hashed to get a fixed size string, then we strip the hash to the right amount of bytes and we get the key. In the future the program is going to use this key to encrypt and decrypt passwords that are being stored on your computer.

![image](https://github.com/IlliaParamosh/SteamAccountManager/assets/73321844/159f017a-de1b-401b-9ca5-8c770390a7cb)


# HOW TO USE ? 
1) Add your account in name(basically give your account a name) fill in the username/pass textboxes. It will save your credentials in the encrypted format at C:/someData.txt folder.

![image](https://github.com/IlliaParamosh/SteamAccountManager/assets/73321844/6eae7301-5cb4-4115-ba91-376402e0f11d)

3) and chose on what account you will login and click login

![image](https://github.com/IlliaParamosh/SteamAccountManager/assets/73321844/50de0b78-f4f0-4c50-9e6e-f42be2639bcc)

# How the passwords are getting stored
![image](https://github.com/IlliaParamosh/SteamAccountManager/assets/73321844/5b441226-aadd-44b1-86c7-9dac8a7e07a1)
