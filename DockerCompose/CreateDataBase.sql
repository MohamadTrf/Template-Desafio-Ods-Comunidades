create database Desafio_Ods_Comunidades


CREATE TABLE "Fonte" (
	"SiglaFonte" VARCHAR(20) PRIMARY KEY,
	"NomeFonte" VARCHAR (45) UNIQUE NOT NULL
);

CREATE TABLE "Contato_Fonte" (
	"EmailContato" VARCHAR(50) PRIMARY KEY,
	"NomeContato" VARCHAR(45) UNIQUE NOT NULL,
	"CelularContato"VARCHAR(45) UNIQUE NOT NULL,
	"SiglaFonte" VARCHAR(20) NOT NULL REFERENCES "Fonte"("SiglaFonte") ON DELETE CASCADE
);


CREATE TABLE "Ods" (
	"IdOds" SERIAL PRIMARY KEY,
	"DescricaoOds" VARCHAR(45) 
);


CREATE TABLE "Outlier" (
	"IdValorDigitado"  SERIAL PRIMARY KEY,
	"DataValorDigitado" DATE,
	"ValorDadoDigitado" INT,
	"UrlColetaValor" VARCHAR(45),
	"SiglaFonte" VARCHAR(20) NOT NULL REFERENCES "Fonte"("SiglaFonte") ON DELETE CASCADE
);
