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
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
            this.Compra = new HashSet<Compra>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "El código debe ser de 8  a 4 caracteres")]
        [Display(Name = "Código")]
        public string Cod_Proveedor { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(18, MinimumLength = 16, ErrorMessage = "La identificacion del cliente no debe sobrepasar los 18 caracteres")]
        [Display(Name = "Identificacion")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(16, MinimumLength = 14, ErrorMessage = "La identificacion del cliente no debe sobrepasar los 16 caracteres")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El Apellido del cliente no debe sobrepasar los 50 caracteres")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression(@"\d{8}", ErrorMessage = "Deve ingresar 8 digitos Numero de telefono inValido")]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Formato incorrecto.")]
        public string Correo { get; set; }
        public int RazonSocialId { get; set; }
    
        public virtual RazonSocial RazonSocial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }
    }
}
