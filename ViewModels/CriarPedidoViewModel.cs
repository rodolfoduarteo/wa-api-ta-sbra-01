namespace wa_api_ta_azure_02.ViewModels
{
    public class CriarPedidoViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Numero { get; set; }
        public DateTime Data { get; set; }
        public string? Cliente { get; set; }
        public string? NomeProduto { get; set; }
        public decimal Preco { get; set; }
    }
}