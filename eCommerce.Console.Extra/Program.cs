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