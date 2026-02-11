CREATE DATABASE Exercicio6;

CREATE TABLE tb_Categoria(
CodigoCategoria INT IDENTITY(1,1) PRIMARY KEY 

,nome                           NVARCHAR(55) NULL
);


CREATE TABLE tb_poduto(
CodigoProduto INT IDENTITY(1,1) PRIMARY KEY

,nome                           NVARCHAR(55) NULL
,preco              INT                  NOT NULL
,CodigoCategoria    INT                  NOT NULL

FOREIGN KEY (CodigoCategoria) REFERENCES tb_Categoria (CodigoCategoria)
);



