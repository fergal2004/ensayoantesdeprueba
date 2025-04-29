using System.ComponentModel.DataAnnotations;

namespace practicaExamen.Models;

public class persona
{
    [Key]
    [MaxLength(15)]
    public string identificaion { get; set; }
}