use biblioteca;

CREATE TABLE statusLivro(
	id int IDENTITY(1,1) NOT NULL,
	status varchar(50) NULL,
 CONSTRAINT PK_statusLivro PRIMARY KEY (id) 
)

select * from statusLivro

insert into statusLivro (status)  values ('Disponível');
insert into statusLivro (status)  values ('Emprestado');
insert into statusLivro (status)  values ('Atraso Devolução');
insert into statusLivro (status)  values ('Uso Local');

------------------------------------------------------------------

CREATE TABLE livro(
	id binary(36) NOT NULL,
	nome varchar(300) NOT NULL,
	autor varchar(100) NOT NULL,
	editora varchar(300) NOT NULL,
	es_status int NOT NULL,
 CONSTRAINT pk_livro PRIMARY KEY (id)
);

ALTER TABLE livro
ADD CONSTRAINT FK_livro_statusLivro FOREIGN KEY (es_status)
REFERENCES statusLivro (id);


insert into livro (id, nome, autor, editora, es_status) values (CONVERT(binary(36),'27e205jh-2cf1-4e7e-bf16-9e9dfd26d77d'),	'Desenvolvimento em Android 2',	'Cristiane Yae Mi Ymamura 2','Editora FAE 2',1)
insert into livro (id, nome, autor, editora, es_status) values (CONVERT(binary(36),'27e208u9-2cf2-4e7e-bf16-9e9dfd26d77c'),	'Concetios de POO','Adriana Costa','Editora Van',1)
insert into livro (id, nome, autor, editora, es_status) values (CONVERT(binary(36),'27e20jj1-2cf3-4e7e-bf16-9e9dfd26d77b'),	'Desenvolvendo com C#','Matheus Magalhaes','Editora Abril',1)
insert into livro (id, nome, autor, editora, es_status) values (CONVERT(binary(36),'27e20jj1-2cf3-4e7e-bf16-9e9dfd26f78g'),	'Desenvolvendo com Python','Matheus Magalhaes','Editora Abril',1)
insert into livro (id, nome, autor, editora, es_status) values (CONVERT(binary(36),'27e20jj1-2cf3-4e7e-bf16-9e9dfd26h86t'),	'Desenvolvendo com Lua','Emerson Oleiveira','Editora Van',1)


--------------------------------------------------------------------

CREATE TABLE statusCliente(
	id int IDENTITY(1,1) NOT NULL,
	status varchar(50) NULL,
 CONSTRAINT PK_statusCliente PRIMARY KEY (id) 
)

select * from statusCliente

insert into statusCliente (status)  values ('Ativo');
insert into statusCliente (status)  values ('Inativo');
insert into statusCliente (status)  values ('Suspenso');

---------------------------------------------------------------------

CREATE TABLE cliente(
	id binary(36) NOT NULL,
	nome varchar(50) NOT NULL,
	cpf varchar(11) NOT NULL,
	email varchar(50) NOT NULL,
	telefone varchar(11) NOT NULL,
	es_status int NOT NULL,
 CONSTRAINT PK_cliente PRIMARY KEY (id) 
)

ALTER TABLE cliente
ADD CONSTRAINT FK_cliente_statusCliente FOREIGN KEY (es_status)
REFERENCES statusCliente (id);

insert into cliente (id,nome,cpf,email, telefone,es_status) 
values (CONVERT(binary(36),'28e205jh-2cf1-4e7e-bf16-9e8igd26d77d'), 'Mathias Feranandes', '43540038861','mathias@gmail.com', '19913356781', 1);

insert into cliente (id,nome,cpf,email, telefone,es_status) 
values (CONVERT(binary(36),'28e204ih-3cf2-8e1e-bf16-9e8igd26d88i'), 'Guilherme Rojas', '43141438860','guirojas@gmail.com', '11913356180', 1);

insert into cliente (id,nome,cpf,email, telefone,es_status) 
values (CONVERT(binary(36),'21e104jh-9cf1-3e5e-bf81-7e6igd51d14d'), 'Marta Agostin', '71580031860','martaago@gmail.com', '19913556782', 1);

-------------------------------------------------

CREATE TABLE usuario(
	id int IDENTITY(1,1) NOT NULL,
	login varchar(50) NOT NULL,
	senha varchar(50) NOT NULL,
 CONSTRAINT PK_usuario PRIMARY KEY (id) 
)

select * from cliente;

insert into usuario (login, senha) values ('admin', 'admin123');
insert into usuario (login, senha) values ('rita', 'rita123');

---------------------------------------------------------

CREATE TABLE emprestimoLivro(
	clienteId binary(36) NOT NULL,
	usuarioId int NOT NULL,
	livroId binary(36) NOT NULL,
	dataEmprestimo datetime NOT NULL,
	dataDevolucao datetime NOT NULL,
	dataDevolucaoEfetiva datetime NULL,
 CONSTRAINT PK_emprestimoLivro PRIMARY KEY (livroId, clienteId, usuarioId, dataEmprestimo)
 );

ALTER TABLE emprestimoLivro
ADD CONSTRAINT FK_cliente_emprestimoLivro FOREIGN KEY (clienteId)
REFERENCES cliente (id);

ALTER TABLE emprestimoLivro
ADD CONSTRAINT FK_usuario_emprestimoLivro FOREIGN KEY (usuarioId)
REFERENCES usuario (id);

ALTER TABLE emprestimoLivro
ADD CONSTRAINT FK_livro_emprestimoLivro FOREIGN KEY (livroId)
REFERENCES livro (id);


select * from usuario;

select * from livro;

select * from emprestimoLivro;

declare
  @clienteId binary(36)
, @usuarioId int
, @livroId binary(36)
, @dataEmprestimo datetime
, @dataDevolucao datetime
, @cliente varchar(36)
, @livro varchar(36)

set @cliente = '28e205jh-2cf1-4e7e-bf16-9e8igd26d77d'
set @usuarioId = 1
set @livro = '27e20jj1-2cf3-4e7e-bf16-9e9dfd26h86t'

set @clienteId = convert(binary(36), @cliente)
set @livroId = convert(binary(36), @livro)

set @dataEmprestimo = GETDATE()
set @dataDevolucao = DATEADD(day, 7, @dataEmprestimo)

insert into emprestimoLivro (clienteId, usuarioId, livroId, dataEmprestimo, dataDevolucao)
values (
	@clienteId
,	@usuarioId
,	@livroId
,	@dataEmprestimo
,	@dataDevolucao
);

update livro set es_status = 2 where id = @livroId;

--------------------------------------------------------------------------------------------