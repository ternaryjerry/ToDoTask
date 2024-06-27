using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToDoTask;

public class Category
{
    [ForeignKey("CategoryId")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string CategoryId { get; set; } = null!;
    public string Name { get; set; } = null!;
}
