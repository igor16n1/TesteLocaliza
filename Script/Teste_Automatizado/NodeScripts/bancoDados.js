'use strict';

const fs = require('fs');
let rawdata = fs.readFileSync('../nomesBR.json');
let usuariosNomes = JSON.parse(rawdata);

var stream = fs.createWriteStream('../InserirNomeTabelaUsuario.txt');
stream.once('open', function (fd) {
    stream.write("USE Localiza \n");
    for (var i = 0; i < usuariosNomes.length; i++) {
        stream.write("INSERT INTO Usuario (Usuario_Nome) VALUES ('" + usuariosNomes[i] + "') \n");
    }
    stream.end();
});

var stream2 = fs.createWriteStream('../InserirPosicoesTabelaPosicoes.txt');
stream2.once('open', function (fd) {
    stream2.write("USE Localiza \n");
    for (var i = 0; i < usuariosNomes.length; i++) {
        var Posicao_Latitude = Math.floor(-90 + Math.random() * (90 + 1 - (-90)));
        var Posicao_Longitude = Math.floor(-180 + Math.random() * (180 + 1 - (-180)));
        stream2.write("INSERT INTO Posicao (IDUsuario ,Posicao_Latitude ,Posicao_Longitude) VALUES (" + (i + 1).toString() + "," + Posicao_Latitude + "," + Posicao_Longitude + ") \n");
    }
    stream2.end();
});

var stream3 = fs.createWriteStream('../InserirAmigosTabelaAmigos.txt');
stream3.once('open', function (fd) {
    stream3.write("USE Localiza \n");
    for (var i = 0; i < usuariosNomes.length; i++) {
        var amigosTotal = Math.floor(0 + Math.random() * (200 + 1 - (0)));
        for (var j = 0; j < amigosTotal; j++) {
            stream3.write("INSERT INTO Amigo (IDUsuario , IDAmigo) VALUES (" + (i + 1).toString() + "," + (j + 1).toString() + ") \n");
        }
    }
    stream3.end();
});