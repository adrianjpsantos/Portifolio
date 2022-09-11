create database Portifolio;
use Portifolio;
create table if not exists Person(
	idPerson int auto_increment primary key,
    name varchar(60) not null,
    about varchar(1000) not null,
    urlLinkedin varchar(60),
    urlGithub varchar(60),
    emailAddress varchar(60)
);

create table if not exists Technology(
	idTechnology int auto_increment primary key,
    name varchar(30) not null unique,
    icon varchar(60) not null
);

create table if not exists Project(
	idProject int auto_increment primary key,
    title varchar(60) not null,
    subtitle varchar(60),
    description varchar(2000) not null,
    thumbnail varchar(2000) not null,
    finish bool default true,
    urlSource varchar(60),
    urlDemo varchar(60)
);

create table if not exists ProjectTechnology(
	idProject int not null,
    idTechnology int not null,
    primary key(idProject,idTechnology)
);

alter table ProjectTechnology add constraint FK_ProjectTechnology_Project
foreign key(idProject) references Project(idProject);

alter table ProjectTechnology add constraint FK_ProjectTechnology_Technology
foreign key(idTechnology) references Technology(idTechnology);