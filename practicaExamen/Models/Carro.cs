using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practicaExamen.Models;

public class Carro
{
    [Key]
    [MaxLength(7)]
    public string matricula { get; set; }
    public double potencia { get; set; }
    [MaxLength(50)]
    public string modelo { get; set; }
    public string propietarioIdentificacion { get; set; }
    [ForeignKey("propietarioIdentificacion")]
    public Propietario? propietario { get; set; }
}