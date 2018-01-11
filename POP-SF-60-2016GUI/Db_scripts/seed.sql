-- seed.sql

INSERT INTO TipNamjestaja (Naziv, Obrisan) VALUES ('Polica', 0);
INSERT INTO TipNamjestaja (Naziv, Obrisan) VALUES ('Regal', 0);
INSERT INTO TipNamjestaja (Naziv, Obrisan) VALUES ('Ugaona', 0);

INSERT INTO Namjestaj(TipNamjestajaID, Naziv, Sifra, Cijena, Kolicina,AkcijskaCijena , Obrisan) 
VALUES (1, 'Ultra polica', 'UL1PO', 123, 2, 0, 0);
INSERT INTO Namjestaj(TipNamjestajaID, Naziv, Sifra, Cijena, Kolicina, AkcijskaCijena, Obrisan) 
VALUES (2, 'Bijeli regal', 'BR1RE', 125, 5,0, 0);
INSERT INTO Namjestaj(TipNamjestajaID, Naziv, Sifra, Cijena, Kolicina,AkcijskaCijena, Obrisan) 
VALUES (3, 'Crna ugaona', 'CR1UG', 500, 10,0, 0);

INSERT INTO Korisnik(Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan)
VALUES ('Pera', 'Peric', 'pera', '12345', 'Administrator', 0);

INSERT INTO DodatnaUsluga(NazivUsluge, CijenaUsluge, Obrisan)
VALUES ('Prevoz', 2000, 0)

INSERT INTO Akcija(PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan) 
VALUES ('12.11.2017' , '1.12.2017', 20, 0);

INSERT INTO NaAkciji (AkId, NId, Obrisan) 
VALUES (1,1,0);




