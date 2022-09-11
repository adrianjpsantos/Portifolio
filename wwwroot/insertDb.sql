use portifolio;
insert into Technology(name,icon) values 
("Javascript","devicon-javascript-plain colored"),
("Ionic","devicon-ionic-original colored"),
("Bootstrap","devicon-bootstrap-plain colored");

insert into Person (name,about,urlLinkedin,urlGithub,emailAddress) values
("Adrian José","Muito prazer! Meu nome é Adrian.<br>Atualmente estou cursando desenvolvimento de sistemas na Etec 'Comendador João Rays '.<br>Sou apaixonado por desafios, tecnologia, viagens e cultura japonesa.<br>Estou sempre trabalhando para me superar a cada dia, pois tudo é possível com dedicação e resiliência.","https://www.linkedin.com/in/adrianjpsantos/","https://github.com/adrianjpsantos","adrianjpsantos@gmail.com");

update Person set about ="Muito prazer! Meu nome é Adrian.Atualmente estou cursando desenvolvimento de sistemas na Etec 'Comendador João Rays '.Sou apaixonado por desafios, tecnologia, viagens e cultura japonesa.Estou sempre trabalhando para me superar a cada dia, pois tudo é possível com dedicação e resiliência." where idPerson = 1;