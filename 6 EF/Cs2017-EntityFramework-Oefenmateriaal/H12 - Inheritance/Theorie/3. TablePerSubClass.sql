use EFOpleidingen;
go
create table TPTCursussen (
  CursusNr int identity primary key,
  Naam varchar(50) not null,
);
create table TPTKlassikaleCursussen (
  CursusNr int primary key references TPTCursussen(CursusNr),
  Van datetime not null,
  Tot datetime not null
);
go
create table TPTZelfstudieCursussen (
  CursusNr int primary key references TPTCursussen(CursusNr),
  Duurtijd int not null
);
go

insert into TPTCursussen(Naam)
values ('Frans voor beginners');

insert into TPTKlassikaleCursussen(CursusNr,Van,Tot)
values (@@identity,'2009-6-8','2009-6-12');

insert into TPTCursussen(Naam)
values ('Engels voor beginners');

insert into TPTKlassikaleCursussen(CursusNr,Van,Tot)
values (@@identity,'2009-6-1','2009-6-5');

insert into TPTCursussen(Naam)
values ('Frans voor gevorderden');

insert into TPTKlassikaleCursussen(CursusNr,Van,Tot)
values (@@identity,'2009-6-8','2009-6-12');

insert into TPTCursussen(Naam)
values ('Engels voor gevorderden');

insert into TPTKlassikaleCursussen(CursusNr,Van,Tot)
values (@@identity,'2009-6-15','2009-6-19');

insert into TPTCursussen(Naam)
values ('Franse correspondentie')

insert into TPTZelfstudieCursussen(CursusNr,Duurtijd)
values (@@identity,5);

insert into TPTCursussen(Naam)
values ('Engelse correspondentie')

insert into TPTZelfstudieCursussen(CursusNr,Duurtijd)
values (@@identity,5);