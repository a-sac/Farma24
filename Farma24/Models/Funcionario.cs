using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Farma24.Models
{
    public class Funcionario
    {

        public Funcionario()
        {
            
        }
        public Funcionario(Encomenda encomenda)
        {
            this.encomenda = encomenda;
        }

        public Encomenda encomenda { get; set; }       


    }
}