using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Roca")]
public class RocaEntity
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Foto { get; set; }

    [MaxLength(50)]
    public string Nombre { get; set; }

    public int Precio { get; set; }
    

}
