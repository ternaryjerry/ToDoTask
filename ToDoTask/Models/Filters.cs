using System.ComponentModel.DataAnnotations;

namespace ToDoTask;

public class Filters
{
    public Filters(string filterString, string due, string priorityId)
    {
        FilterString = filterString ?? "all-all-all-all";
        string[] filters = FilterString.Split('-');
        CategoryId = filters[0];
        Due = filters[1];
        StatusId = filters[2];
        PriorityId = priorityId;
    }

    public string FilterString { get; }
    public string CategoryId { get; }
    public string Due { get; }
    public string StatusId { get; }
    public string PriorityId { get; }
    public bool HasCategory => CategoryId.ToLower() != "all";
    public bool HasStatus => StatusId.ToLower() != "all";
    public bool HasPriority => PriorityId.ToLower() != "all";
    public bool HasDue => Due.ToLower() != "all";
    public static Dictionary<string, string> DueFilterValues =>
        new Dictionary<string, string> {
                {"future", "Future"},
                {"past", "Past" },
                {"today", "Today" }
        };
    public bool IsPast => Due.Equals("past", StringComparison.CurrentCultureIgnoreCase);
    public bool IsFuture => Due.Equals("future", StringComparison.CurrentCultureIgnoreCase);
    public bool IsToday => Due.Equals("today", StringComparison.CurrentCultureIgnoreCase);
}
