// See https://aka.ms/new-console-template for more information
using eCommerce.Console.Query;

var db = new eCommerceContext();
var usuarios = db.Usuarios!.ToList();

// Sobre consultas com ToList, ToArray, ToDictionary e ToHashSet

/*
    db.Usuarios!.{Methods > LING > EF > SQL > SGBD}.ToList().{Methods > LINQ > C# > Processador+Memória}
 
 */

Console.WriteLine("Listagem de usuários:");
foreach (var usuario in usuarios)
{
    Console.WriteLine($" - {usuario.Nome}");
}