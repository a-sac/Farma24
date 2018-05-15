using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Web.Mvc;

namespace Farma24.Models
{
    [Table("Utilizador")]
    public class Utilizador
    {
        public Utilizador()
        {
            this.Encomendas = new HashSet<Encomenda>();
            this.Moradas = new HashSet<Morada>();
        }
        [Key]
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [StringLength(50)]
        public string nome { get; set; }
        public Nullable<int> iban { get; set; }
        public Nullable<int> contacto { get; set; }
        [StringLength(60)]
        public string role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encomenda> Encomendas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Morada> Moradas { get; set; }

        public void SetUser()
        {
            this.role = "user";
        }
        public void SetFuncionario()
        {
            this.role = "staff";
        }

        public Utilizador SetupAdmin()
        {
            Utilizador u = new Utilizador();
            u.email = "admin@farma24.com";
            u.role = "admin";
            u.nome = "admin";
            u.password = "admin";
            return u;
        }

    }


}