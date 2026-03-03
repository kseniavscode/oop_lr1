using LR1.Data;
using LR1.Services

namespace LR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new InMemoryUserRepositoryn();
            Service service = new Service(userRepository);


        }
    }
}
