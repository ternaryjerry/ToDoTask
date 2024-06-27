using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoTask;

public class Status
{
    [ForeignKey("StatusId")]
    public string Name { get; set; } = null!;
    public string StatusId { get; set; } = null!;

}
