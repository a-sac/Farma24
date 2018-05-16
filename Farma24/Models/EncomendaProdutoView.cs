namespace Farma24.Models
{
    public class EncomendaProdutoView
    {
        public EncomendaProdutoView()
        {
        }

        public EncomendaProdutoView(Encomenda encomenda, Encomenda_has_Produto encomendaHasProduto, Produto produto)
        {
            this.encomenda = encomenda;
            this.encomendaHasProduto = encomendaHasProduto;
            this.produto = produto;
        }

        public Encomenda encomenda { get; set; }
        public Encomenda_has_Produto encomendaHasProduto { get; set; }
        public Produto produto { get; set; }
    }
}