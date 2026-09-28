using Microsoft.EntityFrameworkCore;
using ToDoAppApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDb>(options => options.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

var todoItems = app.MapGroup("/todoitems");

todoItems.MapGet("/", GetAllTodos);
todoItems.MapGet("/complete", GetCompleteTodos);
todoItems.MapGet("/{id}", GetTodo);
todoItems.MapPost("/", CreateTodo);
todoItems.MapPut("/{id}", UpdateTodo);
todoItems.MapDelete("/{id}", DeleteTodo);

app.Run();

static async Task<IResult> GetAllTodos(TodoDb db)
{
    return TypedResults.Ok(await db.Todos.Select(todo => new TodoItemDto(todo)).ToArrayAsync());
}

static async Task<IResult> GetCompleteTodos(TodoDb db)
{
    return TypedResults.Ok(await db.Todos.Where(todo => todo.IsComplete).Select(todo => new TodoItemDto(todo)).ToArrayAsync());
}

static async Task<IResult> GetTodo(int id, TodoDb db)
{
    return await db.Todos.FindAsync(id) is Todo todo
        ? TypedResults.Ok(new TodoItemDto(todo))
        : TypedResults.NotFound();
}

static async Task<IResult> CreateTodo(TodoItemDto todoItemDto, TodoDb db)
{
    var todoItem = new Todo
    {
        Name = todoItemDto.Name,
        IsComplete = todoItemDto.IsComplete,
    };

    db.Todos.Add(todoItem);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/todoitems/{todoItem.Id}", new TodoItemDto(todoItem));
}

static async Task<IResult> UpdateTodo(int id, TodoItemDto todoItemDto, TodoDb db)
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null)
    {
        return TypedResults.NotFound();
    }

    todo.Name = todoItemDto.Name;
    todo.IsComplete = todoItemDto.IsComplete;

    await db.SaveChangesAsync();

    return TypedResults.NoContent();
}

static async Task<IResult> DeleteTodo(int id, TodoDb db)
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}
