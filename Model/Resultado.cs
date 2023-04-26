using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Resultado
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; }

    [Required]
    public String Result { get; set; }
    public Operation operation { get; set; }
    public Guid OperationId { get; set; }
    public Resultado() { }

    public override string ToString()
    {
        return $"Id: {Id}, Result: {Result}, OperationId: {OperationId}";
    }

}