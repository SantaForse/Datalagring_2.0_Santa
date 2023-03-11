
CREATE TABLE Customers (

	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) not null unique,
	PhoneNumber char(13) null,
)
GO

CREATE TABLE Errands (
	Id uniqueidentifier not null primary key,
	Title nvarchar(50) not null,
	ErrandDescription text not null,
	ErrandDate date not null,
	ErrandStatus int not null,

	CustomerId int not null references Customers(Id)
)
GO

INSERT INTO Customers VALUES
	('Santa','Forsell','santaforsell@domain.com','073-123 45 67'),
	('Olof','Oloffsson','olof@gmail.com','073-574 58 99'),
	('Maria','Mariasson','mariamaria@gmail.com','070-555 68 91')
GO

INSERT INTO Errands VALUES 
	('b273e263-7543-4efb-8898-c44e123580dd', 'Nr.One errand', 'Bla bla bla bla Bla bla bla bla Bla bla bla bla Bla bla bla bla ', '2022.05.03', 1, 1),
	('6c0bc120-5b04-4507-9f4b-7d3e73831667', 'Nr.Two errand', 'kva kva kva kva kva kva kva kva kva kva kva kva kva kva kva kva kva kva kva kva', '2022.07.06', 3, 2),
	('0830bada-bda0-4c85-9beb-1506edea4ac6', 'Nr.Three errand', 'no no no no no no no no no no no no no no no no no no no no', '2022.04.07', 2, 3)
GO

