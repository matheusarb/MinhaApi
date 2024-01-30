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
    public List<TodoModel> GetTodos([FromServices] AppDbContext context)
    {
        return context.Todos.ToList();
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

    // [HttpPut]
    // [Route("/{id}?")]
    // public TodoModel Update([FromServices] AppDbContext context, [FromBody] TodoModel model, int id)
    // {
    //     var user = context.Todos.Where(x=>x.Id == id);

    // }
}