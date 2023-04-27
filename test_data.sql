CREATE TABLE public.users (
	"Id" serial PRIMARY KEY,
	"FirstName" VARCHAR ( 50 ) NOT NULL,
	"LastName" VARCHAR ( 50 ) NOT NULL,
	"Age" SMALLINT NOT NULL,
	"Occupation" Varchar (100) NOT NULL 
);

INSERT INTO public.users("FirstName", "LastName", "Age", "Occupation")
VALUES ('Carlos Eduardo', 'Porras Carvajal', 25, 'Fullstack Developer')