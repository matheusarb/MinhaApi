using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public IActionResult GetTodos([FromServices] AppDbContext context)
    {
        var todo = context.Todos.AsNoTracking().ToList();
        if (todo == null)
            return NotFound();
        return Ok(todo);
    }

    [HttpGet]
    [Route("/{id}")]
    public IActionResult GetById(
        [FromServices] AppDbContext context,
        [FromRoute] int id
    )
        => Ok(context.Todos.AsNoTracking().FirstOrDefault(x => x.Id == id));

    [HttpPost]
    [Route("/")]
    public IActionResult Post(
        [FromServices] AppDbContext context,
        [FromBody] TodoModel todoItem)
    {
        context.Todos.Add(todoItem);
        context.SaveChanges();
        return Created($"/{todoItem.Id}", todoItem);
    }

    [HttpPut]
    [Route("/{id:int}")]
    public IActionResult Put(
        [FromBody] TodoModel model,
        [FromServices] AppDbContext context,
        [FromRoute] int id
    )
    {
        var todoItem = context.Todos.FirstOrDefault(x => x.Id == id);
        if (todoItem == null)
            return NotFound();

        todoItem.Title = model.Title ?? todoItem.Title;
        todoItem.Username = model.Username ?? todoItem.Title;
        todoItem.IsDone = model.IsDone;

        context.Todos.Update(todoItem);
        context.SaveChanges();

        return Ok(todoItem);
    }

    [HttpDelete]
    [Route("/{id:int}")]
    public IActionResult Delete(
        [FromServices] AppDbContext context,
        [FromRoute] int id
    )
    {
        var todoItem = context.Todos.FirstOrDefault(x => x.Id == id);
        if (todoItem == null)
            return NotFound();

        context.Todos.Remove(todoItem);
        context.SaveChanges();

        return Ok(new { message = "item deletado" });
    }
}