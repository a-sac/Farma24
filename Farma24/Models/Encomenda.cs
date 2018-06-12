using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Farma24.Controllers;
using Microsoft.Ajax.Utilities;

namespace Farma24.Models
{
     using System;
     using System.Collections.Generic;
    
    public class Encomenda
    { 
      
        public Encomenda()
        {
            this.Encomenda_has_Produto = new List<Encomenda_has_Produto>();
        }
        [Key] 
        public int id { get; set; }
        public string estado { get; set; }
        public string email { get; set; }
        public int morada { get; set; }
        public System.DateTime inicio { get; set; }
        public Nullable<System.DateTime> fim { get; set; }
        public double custoTotal { get; set; }
        public string detalhes { get; set; }
        public Nullable<int> Fatura_referencia { get; set; }
    
        public virtual Fatura Fatura { get; set; }
        public virtual List<Encomenda_has_Produto> Encomenda_has_Produto { get; set; }
        public virtual Morada Morada1 { get; set; }
        public virtual Utilizador Utilizador { get; set; }


        private Encomenda getStandBy(Farma24DBEntities db, Utilizador user)
        {
            var encomenda = user.Encomendas.Where(x => x.estado.Equals("StandBy"));
            if (!encomenda.Any() )
            {
                Encomenda e = new Encomenda();
                db.Encomendas.Add(e);
                return e;
            }

            return encomenda.First();
        }


        public Encomenda GetUserEncomenda(Farma24DBEntities db, Utilizador utilizador)
        {
            return getStandBy(db, utilizador);
        }
    }
}