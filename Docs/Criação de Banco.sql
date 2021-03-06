CREATE DATABASE nuRotulo


CREATE TABLE Estado (
	Id INT IDENTITY PRIMARY KEY,
	Pais INT,
	Descricao VARCHAR(300),
	Sigla VARCHAR(2)
)

CREATE TABLE Cidade (
	Id INT IDENTITY PRIMARY KEY,
	Estado INT,
	Descricao VARCHAR(300)
)

-- N�O SER� MAIS UTILIZADA
--CREATE TABLE Bairro (
--	Id INT IDENTITY PRIMARY KEY,
--	Cidade INT,
--	Descricao VARCHAR(500)
--)

CREATE TABLE Endereco (
	Id INT IDENTITY PRIMARY KEY,
	Descricao VARCHAR(500),
	Bairro VARCHAR(500),
	Cidade INT,
)

CREATE TABLE Pessoa (
	Id INT IDENTITY PRIMARY KEY,
	Nome VARCHAR(500),
	Endereco INT
)

CREATE TABLE Fisico (
	Id INT IDENTITY PRIMARY KEY,
	Pessoa INT,
	dataNascimento DATETIME, 
	email VARCHAR(200),
	senha VARCHAR(6)
)

CREATE TABLE MateriaPrima (
	Id INT IDENTITY PRIMARY KEY,
	Descricao VARCHAR(800),
	CausaAlergia BIT
)

CREATE TABLE Ingredientes (
	Id INT IDENTITY PRIMARY KEY,
	Produto INT, 
	MateriaPrima INT,
	ValorEnergetico NUMERIC(18,5),
	ValorDiario NUMERIC(18,5)
)

CREATE TABLE Produto ( 
	Id INT IDENTITY PRIMARY KEY,
	codigoBarra VARCHAR(20),
	descricao VARCHAR(800),
	valorVenda NUMERIC(18,2),
	preparo VARCHAR(MAX),
	conservacao VARCHAR(1000)
)

CREATE TABLE Pais (
	Id INT IDENTITY PRIMARY KEY,
	Descricao VARCHAR(800),
)

CREATE TABLE Categoria(
	Id INT PRIMARY KEY,
	descricao VARCHAR(800)
)

drop table ArtigoUsuario
CREATE TABLE Artigo(
	Id INT,
	fk_Categoria INT,
	titulo VARCHAR(100),
	texto VARCHAR(MAX),
	PRIMARY KEY(fk_Categoria),
        CONSTRAINT FK_CATEGORIA FOREIGN KEY (fk_Categoria) REFERENCES Categoria(Id)
)


CREATE TABLE ArtigoUsuario(
	Id INT,
	fk_Artigo INT,
	dataPublicacao DATETIME,
	PRIMARY KEY (fk_Artigo),
	CONSTRAINT FK_ARTIGO FOREIGN KEY (fk_Artigo) REFERENCES Artigo(fk_Categoria)
)

SELECT * FROM Ingredientes

INSERT INTO MateriaPrima VALUES('CORANTE VERMELHO', 1)
INSERT INTO MateriaPrima VALUES('ESSENCIA DE MORANGO', 0)
INSERT INTO MateriaPrima VALUES('A�UCAR', 0)

INSERT INTO Ingredientes VALUES (1, 3, 1.00, 0.01)

INSERT INTO Pais VALUES('Brasil')

INSERT INTO Estado VALUES(1,'Sao Paulo','SP')
INSERT INTO Estado VALUES(1,'Parana','PR')

INSERT INTO Cidade VALUES(1,'Araraquara')
INSERT INTO Cidade VALUES(2,'Curitiba')

INSERT INTO Endereco VALUES(1,'Rua Carlos Gomes , 1631')
INSERT INTO Endereco VALUES(2,'Avenida Brasil')



select * FROM Pais