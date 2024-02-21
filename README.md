This is a Windows Application written in C# (WPF) allowing you to get Data from 
the official NASA API's and store them in a Database as your Favorites.

My DB:
DROP TABLE IF EXISTS Accounts, Favs;
CREATE TABLE Accounts
(
	Account_ID INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY,
    AccName VARCHAR(MAX),
	AccMail VARCHAR(MAX),
	AccPw VARCHAR(MAX)
);

CREATE TABLE Favs 
(
	AccID Int NOT NULL REFERENCES Accounts(Account_ID),
	FavLink VARCHAR(MAX)
);
