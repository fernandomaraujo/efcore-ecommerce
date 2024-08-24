using eCommerce.Console.Query;
using Microsoft.EntityFrameworkCore;

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

// - Single, Count, Min e Max

// Obtendo uma única informação, mediante a pasasgem de um filtro excludente (valores únicos para cada informação)
var user07 = db.Usuarios!.Single(a => a.Id == 3);

// Caso a informação não exista, retorna o valor padrão. Valor padrão depende do tipo. 
var user08 = db.Usuarios!.SingleOrDefault(a => a.Id == 3);

// Caso haja mais de um registro, uma exception é lançada.
var user09 = db.Usuarios!.SingleOrDefault(a => a.Nome.Contains('a'));

// Obtém a quantidade de registro encontrada na consulta.
var usersListWithLetterA = db.Usuarios.Where(a => a.Nome.Contains('a')).Count();

// Obtém o registro de menor valor.
var user10 = db.Usuarios.Min(a => a.DataCadastro);

// Obtém o registro de maior valor.
var user11 = db.Usuarios.Max(a => a.DataCadastro);

// - WHERE

var allUserList = db.Usuarios.Where(a => a.Nome.StartsWith('a')).ToList();
foreach(var user in allUserList)
{
    Console.WriteLine($"- {user.Nome}");
}

// - OrderBy, OrderByDescending, ThenBy, ThenByDescending

// Seguindo a ordem
var userList01 = db.Usuarios.OrderBy(a => a.Nome).ToList();

// Seguindo a ordem invertida
var userList02 = db.Usuarios.OrderByDescending(a => a.Nome).ToList();

// Ordenando informações dos usuários do sexo feminino
var userList03 = db.Usuarios.OrderBy(a => a.Sexo!.Equals('F')).ThenBy(a => a.Nome).ToList();

// Ordenando informações dos usuários pelo sexo, seguindo a ordem invertida
var userList04 = db.Usuarios.OrderBy(a => a.Sexo).ThenByDescending(a => a.Nome).ToList();


// - Eager Load - Carregamento Adiantado
// Trabalhando com relacionamentos

// Include (Nível 1) = Inclui um objeto relacionado a classe atual.
var userList05 = db.Usuarios.Include(a => a.Contato).ToList();

// ThenInclude (Nível 2) = Quando se precisa navegar pra outra tabela, e dentro dessa tabela há outros relacionamentos
// Contato -> Usuário -> EnderecoEntrega, Departamento

var contactsWithAdressList = db.Contatos!
    .Include(a => a.Usuario)
    .ThenInclude(u => u.EnderecosEntrega)
    .ToList();

foreach(var contact in contactsWithAdressList)
{
    Console.WriteLine(
        $"- {contact.Telefone}, {contact.Usuario!.Nome}, {contact.Usuario!.EnderecosEntrega!.Count}"
    );
}

// AutoInclude
// Incluindo um objeto automáticamente

// Limpando o que está sendo acompanhado na memória pelo EF.
db.ChangeTracker.Clear();

// Trazendo Usario com Contato
// Inclusão implementada no método "OnModelCreating" do eCommmerceContext
var usersWithContact = db.Usuarios.ToList();

foreach (var user in usersWithContact)
{
    Console.WriteLine(
        $"- {user.Nome}, {user.Contato!.Telefone}"   
    );
}

// Ignorando auto inclusão
var usersWithContactWithNoAutoIncludes = db.Usuarios.IgnoreAutoIncludes().ToList();

// Informação de contato virá vazia.
foreach (var user in usersWithContactWithNoAutoIncludes)
{
    Console.WriteLine(
        $"- {user.Nome}, {user.Contato?.Telefone}"
    );
}


// - Explicit Load - Carregamento Explicito

// Limpando o que está sendo acompanhado na memória pelo EF.
db.ChangeTracker.Clear();

var user12 = db.Usuarios.IgnoreAutoIncludes().FirstOrDefault(a => a.Id == 1);

db.Entry(user12).Reference(a => a.Contato).Load();
db.Entry(user12).Collection(a => a.EnderecosEntrega!).Load();

Console.WriteLine(
    $"- {user12.Nome}, {user12.Contato.Telefone}, {user12.EnderecosEntrega.Count}"
);

var rioAdressList = db.Entry(user12)
    .Collection(a => a.EnderecosEntrega!)
    .Query()
    .Where(a => a.Estado == "RJ")
    .ToList();

foreach(var adress in rioAdressList)
{
    Console.WriteLine(
        $"- {adress.NomeEndereco}: {adress.Estado}, {adress.Endereco}"
    );
}

// - Lazy Loadging - Carregamento Preguiçoso
// Entidades são carregadas de acordo com as necessidades
// Não é muito utilizado

// Proxies

// Limpando o que está sendo acompanhado na memória pelo EF.
db.ChangeTracker.Clear();

var user13 = db.Usuarios.Find(1);

// Informação de endereço está ausente
Console.WriteLine(
    $"- {user13.Nome}, {user13.EnderecosEntrega.Count}"
);


/*
 - Foi instalado o pacote "Microsoft.EntityFrameworkCore.Proxies"
 - Adicionado adicionado o virtual nas propriedades que serão navegadas
 - Foi ativado o UseLazyLoadingProxies() no OnConfiguring do eCommerceContext
 */

// Agora, a informação de endereço está presente
Console.WriteLine(
    $"- {user13.Nome}, {user13.EnderecosEntrega.Count}"
);
