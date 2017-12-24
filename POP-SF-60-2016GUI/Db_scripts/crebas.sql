CREATE TABLE TipNamjestaja (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(80),
	Obrisan BIT
);
GO
CREATE TABLE Namjestaj (
	Id INT PRIMARY KEY IDENTITY(1,1),
	TipNamjestajaID INT, 
	Naziv VARCHAR(100),
	Sifra VARCHAR(20),
	Cijena NUMERIC(9,2),
	Kolicina INT,
	Obrisan BIT,
	FOREIGN KEY (TipNamjestajaID) REFERENCES TipNamjestaja(Id)
);

GO
CREATE TABLE DodatnaUsluga (
	Id INT PRIMARY KEY IDENTITY(1,1),
	NazivUsluge VARCHAR(80),
	CijenaUsluge NUMERIC(9,2),
	Obrisan BIT
);

GO 
CREATE TABLE Korisnik (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Ime VARCHAR (80),
	Prezime VARCHAR (80),
	KorisnickoIme VARCHAR (80),
	Lozinka VARCHAR (80),
	TipKorisnika VARCHAR(50),
	Obrisan BIT
);

GO
CREATE TABLE Akcija (
	Id INT PRIMARY KEY IDENTITY(1,1),
	PocetakAkcije DATETIME, 
	ZavrsetakAkcije DATETIME,
	Popust INT,
	Obrisan BIT
);

GO
CREATE TABLE NaAkciji (
	Id INT PRIMARY KEY IDENTITY(1,1),
	AkId INT,
	NId INT,
	FOREIGN KEY (AkId) REFERENCES Akcija(Id),
	FOREIGN KEY (NId) REFERENCES Namjestaj(Id),
	Obrisan BIT
);
