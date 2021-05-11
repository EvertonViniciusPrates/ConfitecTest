Create Database Confitec;

--------

Use Confitec;

--------

Create Table Escolaridade(
	Id Integer Not Null Identity,
	Descricao Varchar(20) Not Null,

	Constraint Pk_escolaridade Primary Key(Id)
)

--------

Create Table Usuario(
	Id Integer Not Null Identity,
	Nome Varchar(100) Not Null,
	Sobrenome Varchar(100) Not Null,
	Email Varchar(100) Not Null,
	Datanascimento Date Not Null,
	Escolaridade_id Integer Not Null,

	Constraint Pk_usuario Primary Key(Id),
	Constraint Fk_escolaridade Foreign Key (Escolaridade_id) References Escolaridade(Id)
)

---------

Insert Into Escolaridade (Descricao)values('infantil');
Insert Into Escolaridade (Descricao)values('fundamental');
Insert Into Escolaridade (Descricao)values('médio');
Insert Into Escolaridade (Descricao)values('superior');