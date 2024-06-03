create database Desafio_Ods_Comunidades

CREATE TABLE oligarquia (
    id_oligarquia SERIAL PRIMARY KEY,
    tipo_base VARCHAR(255),
    sigla VARCHAR(255),
    nome VARCHAR(255),
    quantidade_bases INT,
    quantidade_registros INT,
    concluido BOOLEAN,
    interessante BOOLEAN
);