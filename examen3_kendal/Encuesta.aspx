<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="examen3_kendal.Encuesta" %>

<!DOCTYPE html>
<html>
<head>
    <title>Encuesta</title>
    <link rel="stylesheet" type="text/css" href="estilo.css">
</head>
<body>
    <form id="encuestaForm">
        <label for="nombre">nombre:</label>
        <input type="text" id="nombre" name="nombre" required><br>

        <label for="edad">edad:</label>
        <input type="number" id="edad" name="edad" min="18" max="50" required><br>

        <label for="correo">correo:</label>
        <input type="email" id="correo" name="correo" required><br>

        <label for="partido">partido:</label>
        <select id="partido" name="partido" required>
            <option value="PLN">PLN</option>
            <option value="PUSC">PUSC</option>
            <option value="PAC">PAC</option>
        </select><br>

        <input type="submit" value="Enviar Encuesta">
    </form>

    <script src="script.js"></script>
</body>
</html>
