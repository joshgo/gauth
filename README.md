gauth
=====

Google Authenticator as command line tool in C#. Generates one-time-passwords for Google's 2 step verification.

When you don't have access to your smartphone (missing, left at home, or battery is dead), **gauth** is an alternative way of generating one-time-passwords. It's a simple program that you can install on your desktop or carry around on a USB stick.

Usage
=====

gauth is simple to use and only offers 3 commands: get, set, and delete.

> **gauth.exe get -n \<name\>**

Generates a one-time-password for the specified name (account). The password is automatically copied into your clipboard, so you can hit Ctrl+V or right-click + PASTE.

> gauth.exe set -n \<name\> -k \<key\>

Sets the key of the specified name. If the name already exists, then the key will be updated.

> gauth.exe del -n \<name\>

Deletes name and key from the local storage file (".gauth").

Note
====

Your keys are stored in a file called ".gauth".  Please keep this file safe and private as it contains your keys!!
