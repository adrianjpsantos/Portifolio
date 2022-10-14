create database Portifolio;
use Portifolio;
create table if not exists Person(
	IdPerson int auto_increment primary key,
    Name varchar(60) not null,
    About varchar(1000) not null,
    UrlLinkedin varchar(60),
    UrlGithub varchar(60),
    Username varchar(30) not null,
    Password varchar(30) not null
);

create table if not exists Technology(
	IdTechnology int auto_increment primary key,
    Name varchar(30) not null unique,
    Icon varchar(60) not null
);

create table if not exists Project(
	IdProject int auto_increment primary key,
    Title varchar(60) not null,
    Subtitle varchar(200),
    Description varchar(2000) not null,
    Thumbnail varchar(200) ,
    Finish bool default false,
    UrlSource varchar(60),
    UrlDemo varchar(60)
);

create table if not exists ProjectTechnology(
	IdProject int not null,
    idTechnology int not null,
    primary key(idProject,idTechnology)
);

alter table ProjectTechnology add constraint FK_ProjectTechnology_Project
foreign key(idProject) references Project(idProject);

alter table ProjectTechnology add constraint FK_ProjectTechnology_Technology
foreign key(idTechnology) references Technology(idTechnology);