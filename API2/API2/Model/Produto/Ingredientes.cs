namespace api.Model.PackgeProduto
{
    public class Ingredientes
    {
        public int Id { get; set; }
        public Produto produto { get; set; }
        public MateriaPrima materiaPrima { get; set; }
        public double valorEnergetico { get; set; }
        public double valorDiario { get; set; }
    }
}
