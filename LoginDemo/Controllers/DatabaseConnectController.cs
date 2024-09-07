using LoginDemo.DatabaseServices;
using LoginDemo.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace LoginDemo.Controllers;

[Route("api/[controller]")]
[Controller]
public class DatabaseConnectController(UserService userService)
{
    [HttpGet]
    public void ConnectToDB()
    {
        MongoClient dbClient = new MongoClient("mongodb://localhost:27017/");

        var dbList = dbClient.ListDatabases().ToList();
        User? alex = userService.GetAsync("alex@gmail.com").Result;
        
    }
}