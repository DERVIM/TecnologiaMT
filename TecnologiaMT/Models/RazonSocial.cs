//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TecnologiaMT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Clientes", Schema = "dbo")]
    public partial class RazonSocial
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RazonSocial()
        {
            this.Proveedor = new HashSet<Proveedor>();
            this.Cliente = new HashSet<Cliente>();
        }
       [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "El código debe ser de 3 caracteres")]
        [Display(Name = "Código")]
        public string Cod_RaSocial { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El Nombre debe ser de 50 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor> Proveedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
