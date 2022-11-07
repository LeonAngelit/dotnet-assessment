using Microsoft.AspNetCore.Mvc;
using apiNET.Models;
using apiNET.Services;


namespace apiNET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    IQuestionService questionService;

    public QuestionController(IQuestionService service)
    {
        questionService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(questionService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Question question)

    {

        questionService.Save(question);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Question question)
    {
        questionService.Update(id, question);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        questionService.Delete(id);
        return Ok();
    }
}
