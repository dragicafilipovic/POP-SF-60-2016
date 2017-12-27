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

CREATE TABLE Prodaja(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DatumProdaje DATETIME,
	BrRacuna INT,
	Kupac VARCHAR(40),
	UkupanIznos DECIMAL,
	Obrisan BIT
);

CREATE TABLE Stavka(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Kolicina INT,
	PId INT,
	NId INT,
	FOREIGN KEY (PId) REFERENCES Prodaja(Id),
	FOREIGN KEY (NId) REFERENCES Namjestaj(Id)
);

CREATE TABLE ProdateUsluge (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	PId INT,
	UslugaId INT,
	FOREIGN KEY (PId) REFERENCES Prodaja(Id),
	FOREIGN KEY (UslugaId) REFERENCES DodatnaUsluga(Id)
);
