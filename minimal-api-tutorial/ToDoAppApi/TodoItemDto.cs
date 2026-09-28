namespace ToDoAppApi;

public class TodoItemDto
{
    public TodoItemDto()
    {
    }

    public TodoItemDto(Todo todoItem)
    {
        this.Id = todoItem.Id;
        this.Name = todoItem.Name;
        this.IsComplete = todoItem.IsComplete;
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public bool IsComplete { get; set; }
}
