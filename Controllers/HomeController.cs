using Microsoft.AspNetCore.Mvc;
using MinhaApi.Data;
using MinhaApi.Models;

namespace MinhaApi.Controllers;

[ApiController]
public class HomeController : ControllerBase
{


    [HttpGet]
    [Route("greeting/{name}")]
    public string WelcomeMessage(string name)
        => $"Olá, {name}!";

    [HttpGet]
    [Route("/alltodos")]
    public List<TodoModel> GetTodos([FromServices] AppDbContext context)
        => context.Todos.ToList();

    [HttpGet]
    [Route("/{id}")]
    public TodoModel GetById(
        [FromServices] AppDbContext context,
        [FromRoute] int id
    )
    {
        return context.Todos.FirstOrDefault(x => x.Id == id);
    }

    [HttpPost]
    [Route("/")]
    public TodoModel Post(
        [FromServices] AppDbContext context,
        [FromBody] TodoModel model)
    {
        context.Todos.Add(model);
        context.SaveChanges();
        return model;
    }

    [HttpPut]
    [Route("/{id:int}")]
    public TodoModel Put(
        [FromBody] TodoModel model,
        [FromServices] AppDbContext context,
        [FromRoute] int id
    )
    {
        var todoItem = context.Todos.FirstOrDefault(x => x.Id == id);


        todoItem.Title = model.Title ?? todoItem.Title;
        todoItem.Username = model.Username ?? todoItem.Title;
        todoItem.IsDone = model.IsDone;

        context.Todos.Update(todoItem);
        context.SaveChanges();

        return todoItem;
    }

    [HttpDelete]
    [Route("/{id:int}")]
    public IActionResult Delete(
        [FromServices] AppDbContext context,
        [FromRoute] int id
    )
    {
        var todoItem = context.Todos.FirstOrDefault(x => x.Id == id);
        
        context.Todos.Remove(todoItem);
        context.SaveChanges();

        return Ok(new { message = "item deletado" });
    }
}