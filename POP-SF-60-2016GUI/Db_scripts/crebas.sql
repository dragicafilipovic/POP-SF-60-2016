CREATE TABLE TipNamjestaja (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(80),
	Obrisan BIT
);
GO
CREATE TABLE Namjestaj (
	NId INT PRIMARY KEY IDENTITY(1,1),
	TipNamjestajaID INT, 
	Naziv VARCHAR(100),
	Sifra VARCHAR(20),
	Cijena NUMERIC(9,2),
	Kolicina INT,
	AkcijskaCijena NUMERIC(9,2),
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
	Popust NUMERIC(9,2),
	Obrisan BIT
);

GO
CREATE TABLE NaAkciji (
	Id INT PRIMARY KEY IDENTITY(1,1),
	AkId INT,
	NId INT,
	FOREIGN KEY (AkId) REFERENCES Akcija(Id),
	FOREIGN KEY (NId) REFERENCES Namjestaj(NId),
	Obrisan BIT
);

CREATE TABLE Prodaja(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DatumProdaje DATETIME,
	BrojRacuna VARCHAR(50),
	Kupac VARCHAR(40),
	UkupanIznos DECIMAL,
	Obrisan BIT
);

CREATE TABLE Stavka(
	StId INT PRIMARY KEY IDENTITY(1, 1),
	PId INT,
	Kolicina INT,
	NId INT,
	FOREIGN KEY (PId) REFERENCES Prodaja(Id),
	FOREIGN KEY (NId) REFERENCES Namjestaj(NId),
	Obrisan BIT
);

CREATE TABLE ProdateUsluge (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	PId INT,
	UslugaId INT,
	FOREIGN KEY (PId) REFERENCES Prodaja(Id),
	FOREIGN KEY (UslugaId) REFERENCES DodatnaUsluga(Id),
	Obrisan BIT
);

CREATE TABLE Salon(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Naziv VARCHAR(50),
	Adresa VARCHAR(50),
	BrTelefona VARCHAR(30),
	Email VARCHAR(30),
	AdresaSajta VARCHAR(30),
	Pib VARCHAR(30),
	MaticniBr INT ,
	BrojZiroRacuna VARCHAR(30)
);
