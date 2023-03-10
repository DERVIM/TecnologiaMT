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
    public partial class Renta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Renta()
        {
            this.DetalleRenta = new HashSet<DetalleRenta>();
            this.Cuota = new HashSet<Cuota>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "El código debe ser de 3 caracteres")]
        [Display(Name = "Código")]
        public string Cod_Renta { get; set; }
        public double Total_Renta { get; set; }
        public System.DateTime Fecha_Inicio { get; set; }
        public System.DateTime Fecha_Final { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleRenta> DetalleRenta { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuota> Cuota { get; set; }
    }
}
