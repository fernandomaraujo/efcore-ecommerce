using eCommerce.Office;
using eCommerce.Office.Models;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceOfficeContext();

#region Many-to-Many for EF Core > 5

var resultadoTurma = db.Colaboradores!.Include(a => a.Turmas);

foreach(var colaborador in resultadoTurma)
{
    Console.WriteLine(colaborador.Nome);

    foreach(var turma in colaborador.Turmas)
    {
        Console.WriteLine("- " + turma.Nome);
    }
}

#endregion

#region many-to-many + dados da tabela intermediária (EF Core 5 >)

var colabVeiculo = db.Colaboradores!.Include(a => a.ColaboradoresVeiculo)!.ThenInclude(a => a.Veiculo);
foreach (var colab in colabVeiculo)
{
    Console.WriteLine(colab.Nome);
    foreach (var vinculo in colab.ColaboradoresVeiculo!)
    {
        Console.WriteLine($"- {vinculo.Veiculo.Nome}({vinculo.Veiculo.Placa}):{vinculo.DataInicioDeVinculo}");
    }
}

var primeiroVinculo = db.Set<ColaboradorVeiculo>().SingleOrDefault(a => a.ColaboradorId == 1 && a.VeiculoId == 1);
Console.WriteLine(primeiroVinculo!.DataDeInicioDoVinculo);

#endregion