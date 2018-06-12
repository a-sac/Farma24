using System.Collections;

namespace Farma24.Models
{
    public class EncomendaProdutoView : IEnumerable
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
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}