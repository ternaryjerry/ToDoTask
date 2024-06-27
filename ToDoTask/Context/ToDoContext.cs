using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoTask;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace ToDoTask;

public class ToDoContext : DbContext
{
    private readonly IConfiguration configuration;

    public ToDoContext(DbContextOptions<ToDoContext>
        options, IConfiguration configuration) : base(options)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlite(@"Data Source=/Users/evil/Desktop/WeCanCodeIt/ToDoTask/ToDoTask/Database/ToDoDB.db");
    
    }

    public DbSet<TaskModel> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Priority> Priorities { get; set; }

    //seed data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = "Work", Name = "Work" },
            new Category { CategoryId = "Home", Name = "Home" },
            new Category { CategoryId = "Excercise", Name = "Excercise" },
            new Category { CategoryId = "Shopping", Name = "Shopping" },
            new Category { CategoryId = "Meeting", Name = "Meeting" }
        );

        modelBuilder.Entity<Status>().HasData(
            new Status { StatusId = "Open", Name = "Open" },
            new Status { StatusId = "Completed", Name = "Completed" }
        );

        modelBuilder.Entity<Priority>().HasData(
            new Priority { PriorityId = "High", Name = "High" },
            new Priority { PriorityId = "Medium", Name = "Medium" },
            new Priority { PriorityId = "Low", Name = "Low" }
        );

        modelBuilder.Entity<TaskModel>().HasData(
            new TaskModel
            {
                Id = 1,
                Description = "Finish ToDo Task",
                StatusId = "Open",
                PriorityId = "High",
                DueDate = DateTime.Now.AddDays(3),
                CategoryId = "Work"
            },
            new TaskModel
            {
                Id = 2,
                Description = "Finish ToDo Task",
                StatusId = "Open",
                PriorityId = "High",
                DueDate = DateTime.Now.AddDays(3),
                CategoryId = "Work"
            },
            new TaskModel
            {
                Id = 3,
                Description = "Finish ToDo Task",
                StatusId = "Open",
                PriorityId = "High",
                DueDate = DateTime.Now.AddDays(3),
                CategoryId = "Work"
            }
        );

    }
}
