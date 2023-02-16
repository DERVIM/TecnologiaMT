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
    public partial class Compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compra()
        {
            this.DetalleCompra = new HashSet<DetalleCompra>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "El código debe ser de 8  a 4 caracteres")]
        [Display(Name = "Código")]
        public string Cod_Compra { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        [Display(Name = "Fecha")]
        public System.DateTime Fecha { get; set; }
        public double Total { get; set; }
        public int EmpleadoId { get; set; }
        public int ProveedorId { get; set; }
        public int RetencionId { get; set; }
        public int TipoPagoId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual Retencion Retencion { get; set; }
        public virtual TipoPago TipoPago { get; set; }
    }
}