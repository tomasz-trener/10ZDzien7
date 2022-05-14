

select * from trenerzy 


select * from zawodnicy

update zawodnicy set id_trenera = 4 where id_zawodnika=1


insert into trenerzy OUTPUT Inserted.id_trenera values ('jan','kowalski',null)

ALTER TABLE zawodnicy
ADD FOREIGN KEY (id_trenera) REFERENCES trenerzy(id_trenera); 

delete trenerzy where id_trenera=1

delete zawodnicy where id_zawodnika > 17


select * from zawodnicy

select * from trenerzy


SELECT TABLE_NAME,
       CONSTRAINT_TYPE,CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME='skocznie';


select * from skocznie

delete skocznie where id_skoczni is null

