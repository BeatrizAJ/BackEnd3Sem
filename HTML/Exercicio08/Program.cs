﻿using Exercicio8;

Usuario usuario = new Usuario("Felipe", "senha123");

Administrador administrador = new Administrador("Matheus", "admin456");

Console.WriteLine("Autenticando usuário:");
usuario.Autenticar("senha123");
Console.WriteLine($"");

Console.WriteLine("Autenticando usuário:");
usuario.Autenticar("12345");
Console.WriteLine($"");


Console.WriteLine("Autenticando administrador:");
administrador.Autenticar("admin456");
Console.WriteLine($"");


Console.WriteLine("Autenticando administrador:");
administrador.Autenticar("534567");