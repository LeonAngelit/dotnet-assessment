using apiNET.Models;

namespace apiNET.Services;

public class QuestionService : IQuestionService
{
    QuestionaryContext context;

    public QuestionService(QuestionaryContext questionContext)
    {
        context = questionContext;
    }

    public IEnumerable<Question> Get()
    {
        return context.Questions;
    }

    public async Task Save(Question question)
    {
        context.Add(question);

        await context.SaveChangesAsync();
    }

    public async Task Update(int id, Question question)
    {
        var currentQuestion = context.Questions.Find(id);
        if (currentQuestion != null)
        {
            currentQuestion.Title = question.Title;
            currentQuestion.Subject = question.Subject;
            currentQuestion.Options = question.Options;

        }

        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var currentQuestion = context.Questions.Find(id);
        if (currentQuestion != null)
        {
            context.Remove(currentQuestion);
        }

        await context.SaveChangesAsync();
    }
}

public interface IQuestionService
{
    IEnumerable<Question> Get();
    Task Save(Question question);
    Task Delete(int id);
    Task Update(int id, Question question);
}
