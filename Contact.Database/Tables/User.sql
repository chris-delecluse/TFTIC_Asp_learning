use tuto_asp;
go;

create table [User]
(
    id        int primary key not null identity (1,1),
    firstname nvarchar(50)    not null,
    lastname  nvarchar(50)    not null,
    email     nvarchar(100)   not null unique,
    password  binary(64)      not null,
);