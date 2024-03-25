-- CREACION DE TABLAS ----------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS PERSONAL;
DROP TABLE IF EXISTS HIJOS;

CREATE TABLE PERSONAL(
	idPersonal INT PRIMARY KEY IDENTITY,
	TipoDoc VARCHAR(15) NOT NULL,
	NumeroDoc VARCHAR(15) NOT NULL,
	ApPaterno VARCHAR(15) NOT NULL,
	ApMaterno VARCHAR(15) NOT NULL,
	Nombre1 VARCHAR(15) NOT NULL,
	Nombre2 VARCHAR(15) NOT NULL,
	NombreCompleto VARCHAR(30) NOT NULL,
	FechaNac DATE NOT NULL,
	FechaIngreso DATE NOT NULL,
);


CREATE TABLE HIJOS(
	idHijo INT PRIMARY KEY IDENTITY,
	idPersonal INT NOT NULL REFERENCES PERSONAL(idPersonal),
	TipoDoc VARCHAR(15) NOT NULL,
	NumeroDoc VARCHAR(15) NOT NULL,
	ApPaterno VARCHAR(15) NOT NULL,
	ApMaterno VARCHAR(15) NOT NULL,
	Nombre1 VARCHAR(15) NOT NULL,
	Nombre2 VARCHAR(15) NOT NULL,
	NombreCompleto VARCHAR(30) NOT NULL,
	FechaNac DATE NOT NULL,
);



INSERT INTO PERSONAL 
(TipoDoc, NumeroDoc, ApPaterno, ApMaterno, Nombre1, Nombre2, NombreCompleto, FechaNac, FechaIngreso)
VALUES 
('DNI', '12345678', 'García', 'López', 'Juan', 'Carlos', 'Juan Carlos García López', '1990-05-15', '2010-03-20'),
('PASAPORTE', 'AB123456', 'Martínez', 'Gómez', 'María', 'Isabel', 'María Isabel Martínez Gómez', '1985-10-10', '2008-08-12');

INSERT INTO HIJOS 
(idPersonal, TipoDoc, NumeroDoc, ApPaterno, ApMaterno, Nombre1, Nombre2, NombreCompleto, FechaNac)
VALUES 
(1, 'DNI', '23456789', 'García', 'López', 'Pedro', 'Antonio', 'Pedro Antonio García López', '2015-02-28'),
(1, 'DNI', '34567890', 'García', 'López', 'Lucía', 'Fernanda', 'Lucía Fernanda García López', '2018-09-10'),
(2, 'PASAPORTE', 'BC234567', 'Martínez', 'Gómez', 'Carlos', 'José', 'Carlos José Martínez Gómez', '2012-07-03'),
(2, 'PASAPORTE', 'CD345678', 'Martínez', 'Gómez', 'Ana', 'María', 'Ana María Martínez Gómez', '2014-11-20');


-- PROCEDIMIENTOS ----------------------------------------------------------------------------------------------------

CREATE PROCEDURE InsertPersonal
    @TipoDoc VARCHAR(15),
    @NumeroDoc VARCHAR(15),
    @ApPaterno VARCHAR(15),
    @ApMaterno VARCHAR(15),
    @Nombre1 VARCHAR(15),
    @Nombre2 VARCHAR(15),
    @NombreCompleto VARCHAR(30),
    @FechaNac DATE,
    @FechaIngreso DATE
AS
BEGIN
    INSERT INTO PERSONAL (TipoDoc, NumeroDoc, ApPaterno, ApMaterno, Nombre1, Nombre2, NombreCompleto, FechaNac, FechaIngreso)
    VALUES (@TipoDoc, @NumeroDoc, @ApPaterno, @ApMaterno, @Nombre1, @Nombre2, @NombreCompleto, @FechaNac, @FechaIngreso);
END
------------------------------

CREATE PROCEDURE UpdatePersonal
    @idPersonal INT,
    @TipoDoc VARCHAR(15),
    @NumeroDoc VARCHAR(15),
    @ApPaterno VARCHAR(15),
    @ApMaterno VARCHAR(15),
    @Nombre1 VARCHAR(15),
    @Nombre2 VARCHAR(15),
    @NombreCompleto VARCHAR(30),
    @FechaNac DATE,
    @FechaIngreso DATE
AS
BEGIN
    UPDATE PERSONAL
    SET TipoDoc = @TipoDoc,
        NumeroDoc = @NumeroDoc,
        ApPaterno = @ApPaterno,
        ApMaterno = @ApMaterno,
        Nombre1 = @Nombre1,
        Nombre2 = @Nombre2,
        NombreCompleto = @NombreCompleto,
        FechaNac = @FechaNac,
        FechaIngreso = @FechaIngreso
    WHERE idPersonal = @idPersonal;
END
------------------------------

CREATE PROCEDURE DeletePersonal
    @idPersonal INT
AS
BEGIN
    DELETE FROM PERSONAL
    WHERE idPersonal = @idPersonal;
END
------------------------------

CREATE PROCEDURE SelectAllPersonal
as
begin

select * from PERSONAL
end
------------------------------

CREATE PROCEDURE QueryPersonal(@idPersonal int)
as
begin

select * from PERSONAL where idPersonal = @idPersonal
end
------------------------------


CREATE PROCEDURE InsertHijo
    @idPersonal INT,
    @TipoDoc VARCHAR(15),
    @NumeroDoc VARCHAR(15),
    @ApPaterno VARCHAR(15),
    @ApMaterno VARCHAR(15),
    @Nombre1 VARCHAR(15),
    @Nombre2 VARCHAR(15),
    @NombreCompleto VARCHAR(30),
    @FechaNac DATE
AS
BEGIN
    INSERT INTO HIJOS (idPersonal, TipoDoc, NumeroDoc, ApPaterno, ApMaterno, Nombre1, Nombre2, NombreCompleto, FechaNac)
    VALUES (@idPersonal, @TipoDoc, @NumeroDoc, @ApPaterno, @ApMaterno, @Nombre1, @Nombre2, @NombreCompleto, @FechaNac);
END
------------------------------

CREATE PROCEDURE UpdateHijo
    @idHijo INT,
    @idPersonal INT,
    @TipoDoc VARCHAR(15),
    @NumeroDoc VARCHAR(15),
    @ApPaterno VARCHAR(15),
    @ApMaterno VARCHAR(15),
    @Nombre1 VARCHAR(15),
    @Nombre2 VARCHAR(15),
    @NombreCompleto VARCHAR(30),
    @FechaNac DATE
AS
BEGIN
    UPDATE HIJOS
    SET idPersonal = @idPersonal,
        TipoDoc = @TipoDoc,
        NumeroDoc = @NumeroDoc,
        ApPaterno = @ApPaterno,
        ApMaterno = @ApMaterno,
        Nombre1 = @Nombre1,
        Nombre2 = @Nombre2,
        NombreCompleto = @NombreCompleto,
        FechaNac = @FechaNac
    WHERE idHijo = @idHijo;
END
------------------------------

CREATE PROCEDURE DeleteHijo
    @idHijo INT
AS
BEGIN
    DELETE FROM HIJOS
    WHERE idHijo = @idHijo;
END
------------------------------

CREATE PROCEDURE SelectAllHijos
as
begin

select * from HIJOS
end
------------------------------

CREATE PROCEDURE QueryHijos(@idHijo int)
as
begin

select * from HIJOS where idHijo = @idHijo
end