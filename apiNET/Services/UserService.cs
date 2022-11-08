using apiNET.Models;
using apiNET;

namespace apiNET.Services;

public class UserService : IUserService
{
    QuestionaryContext context;

    public UserService(QuestionaryContext questionContext)
    {
        context = questionContext;
    }

    public IEnumerable<User> Get()
    {
        return context.Users;
    }

    public void Save(User user)
    {
        context.Add(user);

        context.SaveChanges();
    }

    public void Update(int id, User user)
    {
        var currentUser = context.Users.Find(id);
        if (currentUser != null)
        {
            currentUser.email = user.email;
            currentUser.answers = user.answers;

        }

        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var currentUser = context.Users.Find(id);
        if (currentUser != null)
        {
            context.Remove(currentUser);
        }

        context.SaveChanges();
    }
}

public interface IUserService
{
    IEnumerable<User> Get();
    void Save(User user);
    void Delete(int id);
    void Update(int id, User user);
}
