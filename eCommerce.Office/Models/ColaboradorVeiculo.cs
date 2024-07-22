namespace eCommerce.Office.Models
{
    /**
     * 
     * Classe intermediária:
     * 
     */
    public class ColaboradorVeiculo
    {
        public int ColaboradorId {  get; set; }
        public int VeiculoId {  get; set; }
        public DateTimeOffset DataDeInicioDoVinculo {  get; set; }


        // POO
        public Colaborador Colaborador { get; set; } = null!;
        public Veiculo Veiculo { get; set; } = null!;
    }
}
