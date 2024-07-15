using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webapi;

namespace webapi2.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController :  ControllerBase
{

	IHelloWorldService helloWorldService;
	TareasContext dbcontext;
	private readonly ILogger<HelloWorldController> _logger;
	public HelloWorldController(ILogger<HelloWorldController> logger, IHelloWorldService helloWorld, TareasContext db)
	{
		_logger = logger;
		helloWorldService = helloWorld;
		dbcontext = db;
	}

	

	[HttpGet]
	public IActionResult Get()
	{
		_logger.LogInformation("Mostrando el Get de Hola mundo");
		return Ok(helloWorldService.GetHelloWorld());
	}

	
	[HttpGet]
	[Route("createdb")]
	public IActionResult CreateDataBase()
	{
		dbcontext.Database.EnsureCreated();
		return Ok();
	}
}