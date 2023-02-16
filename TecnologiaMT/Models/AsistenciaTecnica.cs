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
    public partial class AsistenciaTecnica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AsistenciaTecnica()
        {
            this.DetallaAsistenciaTecnica = new HashSet<DetallaAsistenciaTecnica>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "El código debe ser de 3 caracteres")]
        [Display(Name = "Código")]
        public string Cod_AsisTec { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Direccion { get; set; }
        public double Total { get; set; }
        public string Descripcion { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public int TipoPagoId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallaAsistenciaTecnica> DetallaAsistenciaTecnica { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual TipoPago TipoPago { get; set; }
    }
}
