use tuto_asp;
go;

create table [Contact]
(
    id          int primary key not null identity (1,1),
    firstname   nvarchar(50)    not null,
    lastname    nvarchar(50)    not null,
    email       nvarchar(100)   not null unique,
    birthDate   date            not null,
    phoneNumber nvarchar(50)    not null,
    -- userId      int             null,

    -- constraint FK_Contact_User foreign key (userId) references [User] (id)
);
INSERT INTO [Contact] (firstname, lastname, email, birthDate, phoneNumber)
VALUES ('chris', 'delecluse', 'chris@gmail.com', '1990-01-25', '0477870150');
