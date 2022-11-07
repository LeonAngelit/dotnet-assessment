using apiNET.Models;

namespace apiNET.Services;

public class QuestionService : IQuestionService
{
    readonly QuestionaryContext context;

    public QuestionService(QuestionaryContext questionContext)
    {
        context = questionContext;
    }

    public IEnumerable<Question> Get()
    {
        return context.Questions;
    }

    public void Save(Question question)
    {
        context.Add(question);

        context.SaveChanges();

    }

    public void Update(int id, Question question)
    {
        var currentQuestion = context.Questions.Find(id);
        if (currentQuestion != null)
        {
            currentQuestion.Title = question.Title;
            currentQuestion.Subject = question.Subject;
            currentQuestion.Options = question.Options;

        }

        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var currentQuestion = context.Questions.Find(id);
        if (currentQuestion != null)
        {
            context.Remove(currentQuestion);
        }

        context.SaveChanges();
    }
}

public interface IQuestionService
{
    IEnumerable<Question> Get();
    void Save(Question question);
    void Delete(int id);
    void Update(int id, Question question);
}
