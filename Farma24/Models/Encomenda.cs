//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Farma24.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Encomenda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Encomenda()
        {
            this.Encomenda_has_Produto = new HashSet<Encomenda_has_Produto>();
        }
    
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encomenda_has_Produto> Encomenda_has_Produto { get; set; }
        public virtual Morada Morada1 { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}
