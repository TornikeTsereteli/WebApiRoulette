using Microsoft.AspNetCore.Mvc;

namespace WebApplication9.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly DataContextDapper _dataContextDapper;

    public UserController(IConfiguration configuration)
    {
        _dataContextDapper = new DataContextDapper(configuration);
    }

    [HttpGet("TestConnection")]
    public DateTime GetUserData(string sql)
    {
        return _dataContextDapper.LoadSingle<DateTime>(sql);
    }
    
    [HttpGet("",Name = "GenerateUsers")]
    public IList<string> GenerateUsers(string name)
    {
        return name.ToArray().Select(x =>
        {
            if (x == 'a') return "aaa";
            return "not a";
        }).ToList();
    }
    
    
    
}