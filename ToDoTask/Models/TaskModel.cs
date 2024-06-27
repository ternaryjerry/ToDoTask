using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ToDoTask;

[Table("Tasks")]
public class TaskModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    private int id;
    private string description = null!;
    private string status = null!;
    private string priority = null!;
    private DateTime dueDate;
    private string category = null!;

    public int Id { get => id ; set => id = value; }

    [Required]
    [StringLength(255)]
    public string Description { get => description; set => description = value; }

    [ValidateNever]
    [BindProperty(SupportsGet = true)]
    public Status Status { get; set; } = null!;

    [Required]
    [StringLength(20)]
    public string StatusId { get => status; set => status = value; }

    [ValidateNever]
    [BindProperty(SupportsGet = true)]
    public Priority Priority { get; set; } = null!;

    [Required]
    [StringLength(20)]
    public string PriorityId { get => priority; set => priority = value; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DueDate { get => dueDate; set => dueDate = value; }

    [ValidateNever]
    [BindProperty(SupportsGet = true)]
    public Category Category { get ; set; } = null!;

    [Required]
    [StringLength(50)]
    public string CategoryId { get => category ; set => category = value; }

    public bool Overdue => StatusId == "open" && DueDate < DateTime.Today;
}