using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoTask;

public class Priority
{
    [ForeignKey("PriorityId")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string PriorityId { get; set; } = null!;
    public string Name { get; set; } = null!;
}
