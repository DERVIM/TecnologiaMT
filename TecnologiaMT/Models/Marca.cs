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
    public partial class Marca
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Marca()
        {
            this.Producto = new HashSet<Producto>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "El código debe ser de 8  a 4 caracteres")]
        [Display(Name = "Código")]
        public string Cod_Marca { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El Nombre debe ser de 50 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
    }
}