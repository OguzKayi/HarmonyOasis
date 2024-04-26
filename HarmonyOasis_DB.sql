CREATE DATABASE HarmonyOasis_DB
Go
use HarmonyOasis_DB
Go
CREATE TABLE AdminTurler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(20),
	CONSTRAINT pk_AdminTurler PRIMARY KEY(ID)
)
Go
INSERT INTO AdminTurler(Isim) VALUES('Admin')
INSERT INTO AdminTurler(Isim) VALUES('Moderator')
Go
CREATE TABLE Adminler
(
	ID int IDENTITY(1,1),
	Tur_ID int,
	KullaniciAdi nvarchar(20),
	Isim nvarchar(75),
	SoyIsim nvarchar(75),
	Email nvarchar(254),
	Sifre nvarchar(30),
	Tarih datetime,
	Durum bit,
	CONSTRAINT pk_Adminler PRIMARY KEY(ID),
	CONSTRAINT fk_adminlerAdminTurler FOREIGN KEY(Tur_ID) REFERENCES AdminTurler(ID)
)
Go
INSERT INTO Adminler(Tur_ID, KullaniciAdi, Isim, SoyIsim, Email, Sifre, Tarih, Durum) VALUES(1,'O.K.','Oðuz','Kayý','o.k.@gmail.com','1234', 010101,1)
Go
CREATE TABLE Uyeler
(
	ID int IDENTITY(1,1),
	KullaniciAdi nvarchar(15),
	Email nvarchar(254),
	Sifre nvarchar(20),
	Kayit datetime,
	Durum bit,
	CONSTRAINT pk_Uyeler PRIMARY KEY(ID)
)
Go
CREATE TABLE Muzisyenler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(150),
	Ozet nvarchar(500),
	Biyografi ntext,
	Resim nvarchar(50),
	Durum bit,
	CONSTRAINT pk_Muzisyenler PRIMARY KEY(ID)
)
Go
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(20),
	Aciklama nvarchar(500),
	Durum bit,
	CONSTRAINT pk_Kategoriler PRIMARY KEY(ID)
)
Go
CREATE TABLE Parcalar
(
	ID int IDENTITY(1,1),
	Muzisyen_ID int,
	Kategori_ID int,
	Isim nvarchar(200),
	Nota ntext,
	Tarih datetime,
	Durum bit,
	CONSTRAINT pk_Parcalar PRIMARY KEY(ID),
	CONSTRAINT fk_parcalarMuzisyenler FOREIGN KEY(Muzisyen_ID) REFERENCES Muzisyenler(ID),
	CONSTRAINT fk_parcalarKategoriler FOREIGN KEY(Kategori_ID) REFERENCES Kategoriler(ID)
)
Go
CREATE TABLE Yorumlar
(
	ID int IDENTITY(1,1),
	Uye_ID int,
	Parca_ID int,
	Kategori_ID int,
	Muzisyen_ID int,
	Icerik nvarchar(500),
	Tarih datetime,
	Durum bit,
	Kontrol bit,
	CONSTRAINT pk_Yorumlar PRIMARY KEY(ID),
	CONSTRAINT fk_yorumlarUyeler FOREIGN KEY(Uye_ID) REFERENCES Uyeler(ID),
	CONSTRAINT fk_yorumlarParcalar FOREIGN KEY(Parca_ID) REFERENCES Parcalar(ID),
	CONSTRAINT fk_yorumlarKategoriler FOREIGN KEY(Kategori_ID) REFERENCES Kategoriler(ID),
	CONSTRAINT fk_yorumlarMuzizyenler FOREIGN KEY(Muzisyen_ID) REFERENCES Muzisyenler(ID)
)