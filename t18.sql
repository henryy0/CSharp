create database t18_estoque
use t18_estoque

CREATE TABLE funcionario (
    ID_Funcionario int not null identity primary key,
    nome_Funcionario VARCHAR(50) NOT NULL,
    nasc_Funcionario DATE NOT NULL,
    data_Funcionario smalldatetime NOT NULL default getdate(),
    cpf_Funcionario CHAR(14) NOT NULL UNIQUE,
    logradouro_Funcionario VARCHAR(50) NOT NULL,
    numero_Funcionario INT NOT NULL,
    comp_funcionario VARCHAR(20) NULL,
    cep_Funcionario CHAR(10) NOT NULL,
    bairro_Funcionario VARCHAR(50) NOT NULL,
    cidade_Funcionario VARCHAR(50) NOT NULL,
    uf_Funcionario CHAR(2) NOT NULL,
    telefone1_Funcionario CHAR(16) NOT NULL,
    telefone2_Funcionario CHAR(16) NULL,
    telefone3_Funcionario CHAR(16) NULL,
    telefone4_Funcionario CHAR(16) NULL,
    obs_Funcionario VARCHAR(200) NULL,
    status_Funcionario VARCHAR(20) NOT NULL DEFAULT 'ATIVO'
);

select * from funcionario
delete from funcionario where ID_Funcionario = 4

drop table funcionario

CREATE TABLE usuario
(
    id_usuario INT NOT NULL IDENTITY PRIMARY KEY,
    nome_usuario VARCHAR(50) NOT NULL,
    login_usuario VARCHAR(30) NOT NULL UNIQUE,
    senha_usuario VARCHAR(30) NOT NULL,
    data_usuario SMALLDATETIME NOT NULL DEFAULT GETDATE(),
    obs_usuario VARCHAR(255) NULL,
    status_usuario VARCHAR(20) NOT NULL
);

select * from usuario
delete from usuario where id_usuario = 4

drop table usuario

CREATE TABLE produto (
    ID_Produto int not null identity primary key,
    nome_Produto VARCHAR(30) NOT NULL UNIQUE,
    data_Produto smalldatetime NOT NULL default getdate(),
    qtde_Produto INT NOT NULL,
    Vcusto_Produto DECIMAL(10, 2) NOT NULL,
    Vvenda_Produto DECIMAL(10, 2) NOT NULL,
    obs_Produto VARCHAR(200) NULL,
    status_Produto VARCHAR(20) NOT NULL
);

select * from produto
delete from produto where ID_Produto = 4

drop table produto;

CREATE TABLE movimentacao (
    id_mov int not null identity primary key,
    id_Produto_mov INT NOT NULL,
    id_Funcionario_mov INT NOT NULL,
    qtde_mov INT NOT NULL,
    data_mov smalldatetime NOT NULL default getdate(),
    tipo_mov VARCHAR(30) NOT NULL,
    obs_mov VARCHAR(200) NULL,
    status_mov VARCHAR(20) NOT NULL,

    FOREIGN KEY (id_Produto_mov) REFERENCES produto (ID_Produto),
    FOREIGN KEY (id_Funcionario_mov) REFERENCES funcionario (ID_Funcionario)
);


select * from movimentacao
delete from movimentacao where ID_mov = 4

drop table movimentacao;

CREATE TABLE Fornecedor (
    ID_Fornecedor int not null identity primary key,
    nome_Fornecedor VARCHAR(255) NOT NULL UNIQUE,
    nasc_Fornecedor date not null,
    data_Fornecedor smalldatetime NOT NULL default getdate(),
    cnpj_Fornecedor CHAR(18) NOT NULL UNIQUE,
    logradouro_Fornecedor VARCHAR(255) NOT NULL,
    numero_Fornecedor INT NOT NULL,
    cep_Fornecedor CHAR(10) NOT NULL,
    bairro_Fornecedor VARCHAR(255) NOT NULL,
    cidade_Fornecedor VARCHAR(255) NOT NULL,
    uf_Fornecedor CHAR(2) NOT NULL,
    telefone1_Fornecedor CHAR(15) NOT NULL,
    telefone2_Fornecedor CHAR(15) NULL,
    telefone3_Fornecedor CHAR(15) NULL,
    telefone4_Fornecedor CHAR(15) NULL,
    contato_Fornecedor CHAR(255) NOT NULL,
    obs_Fornecedor VARCHAR(200) NULL,
    status_Fornecedor VARCHAR(50) NOT NULL
);

select * from Fornecedor
delete from Fornecedor where ID_Fornecedor = 4

drop table Fornecedor;

CREATE TABLE LocalEstoque (
    id_LocalEstoque  int not null identity primary key,
    nome_LocalEstoque VARCHAR(255) NOT NULL,
    data_LocalEstoque smalldatetime NOT NULL default getdate(),
    obs_LocalEstoque VARCHAR(200) NULL,
    status_LocalEstoque VARCHAR(50) NOT NULL
);

select * from LocalEstoque
delete from LocalEstoque where id_LocalEstoque = 4

drop table LocalEstoque;

CREATE TABLE ItemEstoque (
    id_ItemEstoque int not null identity primary key,
    id_produto_ItemEstoque INT NOT NULL,
    id_localEstoque_ItemEstoque INT NOT NULL,
    data_ItemEstoque smalldatetime NOT NULL default getdate(),
    obs_os VARCHAR(200) NULL,
    status_os VARCHAR(50) NOT NULL

	FOREIGN KEY (id_produto_ItemEstoque) REFERENCES produto (ID_Produto),
    FOREIGN KEY (id_localEstoque_ItemEstoque) REFERENCES LocalEstoque (id_LocalEstoque)
);

select * from ItemEstoque
delete from ItemEstoque where id_ItemEstoque = 4

drop table ItemEstoque;

CREATE TABLE OS (
    id_os int not null identity primary key,
    id_produto_os INT NOT NULL,
    data_os smalldatetime NOT NULL default getdate(),
    qtde_os INT NOT NULL,
    obs_os VARCHAR(200) NULL,
    status_os VARCHAR(50) NOT NULL

	FOREIGN KEY (id_produto_os) REFERENCES produto (ID_Produto)
);

select * from OS
delete from OS where id_os = 4

drop table OS;