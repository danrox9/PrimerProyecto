using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Puja")]
public class PujaEntity
{
    public int Id { get; set; }
    public int IdPiedra { get; set;}
    public int Precio { get; set; }
    

}
