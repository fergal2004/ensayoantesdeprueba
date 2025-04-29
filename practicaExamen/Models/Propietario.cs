using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practicaExamen.Models;

public class Propietario
{
    [Key]
    [MaxLength(15)]
    public string identificaion { get; set; }

    [MaxLength(100)]
    public string nombre { get; set; }

    [MaxLength(10)]
    public string telefono { get; set; }

    [MaxLength(200)]
    public string direccion { get; set; }

    /*public int calculado
    {
        get
        {
            return 10;
        }
    }*/
}