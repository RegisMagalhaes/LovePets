CREATE DATABASE lovePets_manha;
GO

USE lovePets_manha;
GO

CREATE TABLE clinica
(
	idClinica		INT PRIMARY KEY IDENTITY
	,razaoSocial	VARCHAR(200) NOT NULL UNIQUE
	,cnpj			CHAR(14) NOT NULL UNIQUE
	,endereco		VARCHAR(200) NOT NULL UNIQUE
);
GO

CREATE TABLE tipoPet
(
	idTipoPet		INT	PRIMARY KEY IDENTITY
	,nomeTipoPet	VARCHAR(200) NOT NULL UNIQUE
);
GO

CREATE TABLE raca
(
	idRaca			INT PRIMARY KEY IDENTITY
	,idTipoPet		INT FOREIGN KEY REFERENCES tipoPet(idTipoPet)
	,nomeRaca		VARCHAR(200) NOT NULL UNIQUE
);
GO

CREATE TABLE dono
(
	idDono			INT PRIMARY KEY IDENTITY
	,nomeDono		VARCHAR(200) NOT NULL
);
GO

CREATE TABLE tipoUsuario
(
	idTipoUsuario		INT PRIMARY KEY IDENTITY
	,nomeTipoUsuario	VARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE usuario
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,idTipoUsuario		INT FOREIGN KEY REFERENCES tipoUsuario (idTipoUsuario)
	,email				VARCHAR(100) NOT NULL UNIQUE
	,senha				VARCHAR(100) NOT NULL
);
GO

CREATE TABLE pet
(
	idPet			INT PRIMARY KEY IDENTITY
	,idRaca			INT FOREIGN KEY REFERENCES raca(idRaca)
	,idDono			INT FOREIGN KEY REFERENCES dono(idDono)
	,nomePet		VARCHAR(200) NOT NULL
	,dataNascimento	DATE NOT NULL
	,ra				CHAR(7) NOT NULL UNIQUE
	,idUsuario		INT FOREIGN KEY REFERENCES usuario(idUsuario)
);
GO

CREATE TABLE veterinario
(
	idVeterinario		INT PRIMARY KEY IDENTITY
	,idClinica			INT FOREIGN KEY REFERENCES clinica(idClinica)
	,CRMV				CHAR(6) NOT NULL UNIQUE
	,nomeVeterinario	VARCHAR(200) NOT NULL
	,idUsuario			INT FOREIGN KEY REFERENCES usuario(idUsuario)
);
GO

CREATE TABLE situacao
(
	idSituacao			INT PRIMARY KEY IDENTITY
	,nomeSituacao		VARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE atendimento
(
	idAtendimento		INT PRIMARY KEY IDENTITY
	,idVeterinario		INT FOREIGN KEY REFERENCES veterinario(idVeterinario)
	,idPet				INT FOREIGN KEY REFERENCES pet(idPet)
	,descricao			TEXT DEFAULT ('sem descrição informada')
	,dataAtendimento	DATETIME NOT NULL
	,idSituacao			INT FOREIGN KEY REFERENCES situacao(idSituacao) DEFAULT(2)
);
GO

-- deletar tabela
-- DROP TABLE pet;

-- outra forma de adicionar uma coluna
-- ALTER TABLE pet ADD dataNascimento DATE;