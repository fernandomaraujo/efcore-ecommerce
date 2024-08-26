﻿using eCommerce.Console.Extra.Models;
using eCommerce.Console.Query;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceContext();

// - GLOBAL FILTER

// Como um filtro global foi aplicado no OnModelCreating, apenas usuários ativos serão trazidos do banco de dados
var usuariosList = db.Usuarios!.ToList();

// Para ignorar o filtro global
var usuariosList02 = db.Usuarios!.IgnoreQueryFilters().ToList();

// - VALUE CONVERSION

var usuariosList03 = db.Usuarios!.ToList();

// - TABELAS TEMPORARIS (EFCORE > 6 && banco de dados ser da Microsoft)

/*
 - Habilitar tabela temporária para uma entidade, no Context
 - Add-Migration
 - Update-Database
 - Tabela temporária criada
 */

// Inserindo dados no histórico

var novoUsuario = new Usuario
{
    Nome = "Mahomes",
    Email = "mahomes@chiefs.com",
    Sexo = "M",
    CPF = "123.456.789-10",
    NomeMae = "Randi Martin",
    SituacaoCadastro = SituacaoCadastro.Ativo,
    DataCadastro = DateTimeOffset.Now,
};

db.Add(novoUsuario);
db.SaveChanges();

// Procura pelo mesmo usuário, o atualizando

// Assumindo que o Id do usuário cadastrado anteriormente é igual à 2
var usuarioAtualizado = db.Usuarios!.Find(2);
usuarioAtualizado!.Nome = "Patrick Mahomes";
db.SaveChanges();

/* 
 Agora a tabela de histórico registra a primeira versão do usuário, como ele
 era antes da atualização. Registra também o período em que aquela informação 
 permaneceu no banco (nas colunas PeriodoInicial e PeriodoFinal).

   Na tabela usuário estará atualizado.
*/