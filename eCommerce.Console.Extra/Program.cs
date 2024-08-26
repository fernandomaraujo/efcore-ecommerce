using eCommerce.Console.Query;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceContext();

// Como um filtro global foi aplicado no OnModelCreating, apenas usuários ativos serão trazidos do banco de dados
var usuariosList = db.Usuarios!.ToList();

// Para ignorar o filtro global
var usuariosList02 = db.Usuarios!.IgnoreQueryFilters().ToList();