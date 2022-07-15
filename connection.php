<?php

    $servername = "localhost";
    $username = "root";
    $password = "";
    $db = "unitydb";

    $conn = new mysqli($servername, $username, $password, $db);

    if (!$conn) {
        die("Connection failed. " . mysqli_connect_error());
    }

    $sql = "SELECT * FROM quadro";
    $result = mysqli_query($conn, $sql);

    if (mysqli_num_rows($result) > 0) {
        while ($row = mysqli_fetch_assoc($result)) {
            echo "ID" . $row['id'] . "|Titulo" . $row['titulo'] . "|Autor" . $row['autor'] . "|Descricao" . $row['descricao'] . "|AnoCriacao"
                . $row['ano_criacao'] . "|Materiais" . $row['materiais'] . "|HistoriaAutor" . $row['historia_autor'] . "|Interpretacoes" . $row['interpretacoes'] .
                "|Simbolismos" . $row['simbolismos'] . "|FrameNumber" . $row['frame_number'] . "|Imagem" . base64_encode($row['imagem']) . '$';
        }
    }
?>