using eCommerce.Console.Query;

var db = new eCommerceContext();
var usuarios = db.Usuarios!.ToList();

// - Sobre consultas com ToList, ToArray, ToDictionary e ToHashSet

/*
    db.Usuarios!.{Methods > LING > EF > SQL > SGBD}.ToList().{Methods > LINQ > C# > Processador+Memória}
 
 */

Console.WriteLine("Listagem de usuários:");
foreach (var usuario in usuarios)
{
    Console.WriteLine($" - {usuario.Nome}");
}

// - Find, First, Las e suas variações

Console.WriteLine("Usuário encontrado:");
var user01 = db.Usuarios!.Find(2); // Buscando por chave primária, que é o ID = 2.
Console.WriteLine($" - Código: {user01!.Id}, Nome:{user01.Nome}");

// Primeiro registro da tabela.
var user02 = db.Usuarios!.First();

// Caso a informação não exista, retorna o valor padrão. Valor padrão depende do tipo.
var user03 = db.Usuarios!.FirstOrDefault();

// Pode-se usar com parâmetro.
var user04 = db.Usuarios!.FirstOrDefault(a => a.Id == 2);

// Precisa de ordenação antes de pegar o último registro.
var user05 = db.Usuarios!.OrderBy(a => a.Id).Last();

// Caso a informação não exista, retorna o valor padrão. Valor padrão depende do tipo.
var user06 = db.Usuarios!.OrderBy(a => a.Id).LastOrDefault();