CREATE DATABASE ConnectPlus_Moura;
GO

USE ConnectPlus_Moura;
GO

CREATE TABLE TipoContato(
IdTipoContato    UNIQUEIDENTIFIER  PRIMARY KEY DEFAULT ((NEWID())),
Titulo           NVARCHAR(100)     NOT NULL,
);


CREATE TABLE Contato(
IdContato        UNIQUEIDENTIFIER  PRIMARY KEY DEFAULT ((NEWID())),
Nome             NVARCHAR (100)    NOT NULL,
FormaDeContato   VARCHAR  (250)    NOT NULL,
Imagem           NVARCHAR (400)            ,
IdTipoContato    UNIQUEIDENTIFIER  FOREIGN KEY REFERENCES TipoContato(IdTipoContato),
);

