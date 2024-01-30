using Microsoft.AspNetCore.Mvc;
using MinhaApi.Data;
using MinhaApi.Models;

namespace MinhaApi.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    [Route("/{name}")]
    public string WelcomeMessage(string name)
    {
        return $"Olá, {name}!";
    }

    [HttpGet]
    [Route("/")]
    public List<TodoModel> GetTodos([FromServices] AppDbContext context, string name)
    {
        return context.Todos.ToList();
    }

    [HttpPost]
    [Route("/")]
    public TodoModel Post([FromServices] AppDbContext context, [FromBody] TodoModel model)
    {
        context.Todos.Add(model);
        context.SaveChanges();
        return model;
    }
}