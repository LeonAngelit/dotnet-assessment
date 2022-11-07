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
        return Ok(questionService.Save(question));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Question question)
    {
        return Ok(questionService.Update(id, question));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(questionService.Delete(id));
    }
}
