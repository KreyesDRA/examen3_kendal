CREATE TABLE encuestas
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    edad INT NOT NULL CHECK(edad >= 18 AND edad <= 50),
    correo VARCHAR(100) NOT NULL CHECK(correo LIKE '%_@__%.%'),
    partido VARCHAR(50) NOT NULL CHECK(partido IN ('PLN', 'PUSC', 'PAC'))
);

CREATE PROCEDURE agregar_encuesta
    @nombre VARCHAR(100),
    @edad INT,
    @correo VARCHAR(100),
    @partido VARCHAR(50)
AS
BEGIN
    INSERT INTO encuestas(nombre, edad, correo, partido)
    VALUES(@nombre, @edad, @correo, @partido)
END;

CREATE PROCEDURE generar_informe
AS
BEGIN
    DECLARE @tablaHTML NVARCHAR(MAX);

SET @tablaHTML = N'<table border="1">';
SET @tablaHTML += N'<tr><th>Número de la encuesta</th><th>Nombre</th><th>Edad</th><th>Correo</th><th>Partido Político</th></tr>';

SELECT @tablaHTML += N'<tr><td>' + CAST(id AS NVARCHAR) +N'</td><td>' + nombre + N'</td><td>' + CAST(edad AS NVARCHAR) + N'</td><td>' + correo + N'</td><td>' + partido + N'</td></tr>'
    FROM encuestas;

SET @tablaHTML += N'</table>';

SELECT @tablaHTML AS InformeHTML;
END;