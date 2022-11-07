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

    public async Task Save(User user)
    {
        context.Add(user);

        await context.SaveChangesAsync();
    }

    public async Task Update(int id, User user)
    {
        var currentUser = context.Users.Find(id);
        if (currentUser != null)
        {
            currentUser.email = user.email;
            currentUser.results = user.results;

        }

        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var currentUser = context.Users.Find(id);
        if (currentUser != null)
        {
            context.Remove(currentUser);
        }

        await context.SaveChangesAsync();
    }
}

public interface IUserService
{
    IEnumerable<User> Get();
    Task Save(User user);
    Task Delete(int id);
    Task Update(int id, User user);
}
