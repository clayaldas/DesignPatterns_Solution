using System.ComponentModel.DataAnnotations;

namespace DesignPatterns_ASPNETCore.Models.ViewModels
{
  // Este View Model (Clase) es utilizado para capturar los datos del formulario
  // de un producto, que incluye los campos que se indican a continuación.
  public class FormProductViewModel
  {
    [Required] // Campo requerido.
    [Display(Name = "Nombre")] // Se muestra la etiqueta "Nombre" para  el campo "Name".
    public string Name { get; set; }

    [Required]
    [Display(Name = "Unidades en Stock")]
    public short UnitsInStock { get; set; }

    [Required]
    [Display(Name = "Precio Unitario")]
    public decimal UnitPrice { get; set; }

    public Guid? CategoryId { get; set; }//? Permitir nulos.

    [Display(Name = "Nueva Categoria")]
    public string? OtherCategory { get; set; }//? Permitir nulos.
  }
}
