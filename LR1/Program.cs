using LR1.Data;
using LR1.Services;
using LR1.Models;

namespace LR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new InMemoryUserRepositoryn();
            Service service = new Service(userRepository);

            IAccountRepository accountRepository = new InMemoryAccountRepository();
            ClientService client_service = new ClientService(accountRepository);

            while (true)
            {
                int choice;
                do
                {
                    Console.WriteLine(" ______________________________________________________ ");
                    Console.WriteLine("|      #--#--УПРАВЛЕНИЕ ФИНАНСОВОЙ СИСТЕМОЙ--#--#      |");
                    Console.WriteLine(" ______________________________________________________ ");
                    Console.WriteLine("|   Выберите одно из действий:                         |");
                    Console.WriteLine("| 1. Войти                                             |");
                    Console.WriteLine("| 2. Регистрация                                       |");
                    Console.WriteLine("| 0. Выйти                                             |");
                    Console.WriteLine(" ______________________________________________________ ");

                } while (!int.TryParse(Console.ReadLine(), out choice));
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите имя пользователя:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите пароль:");
                        string password = Console.ReadLine();
                        
                        User user = service.Login(name, password);
                        if (user != null)
                        {
                            Console.WriteLine("Вы успешно вошли в систему!");
                            Console.WriteLine($"Ваша роль {user.Role}");
                            if (user.Role == Enums.Role.Client)
                            {
                                ClientMenu((Client)user, client_service);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка! Не смогли войти в систему!");
                        }
                        
                        break;
                    case 2:
                        Console.WriteLine("Введите имя пользователя для регистрации:");
                        string name_reg = Console.ReadLine();
                        Console.WriteLine("Введите надежный пароль для регистрации:");
                        string password_reg = Console.ReadLine();

                        Client client = service.Registration(name_reg, password_reg);
                        if (client != null)
                        {
                            Console.WriteLine("Вы успешно создали аккаунт, теперь можете войти в систему!");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка регистрации!");
                        }
                        
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Введите число сугубо из списка!");
                        break;
                }
            }
        }

        static void ClientMenu(Client client, ClientService clientService)
        {
            while (true)
            {

                int choice;
                do
                {
                    Console.WriteLine(" ______________________________________________________ ");
                    Console.WriteLine($"|=== Личный кабинет === Имя: {client.Name}");
                    Console.WriteLine(" ______________________________________________________ ");
                    Console.WriteLine(" ______________________________________________________ ");
                    Console.WriteLine("|   Выберите одно из действий:                         |");
                    Console.WriteLine("| 0. Выход                                             |");
                    Console.WriteLine("| 1. Просмотр всех банковских систем                   |");
                    Console.WriteLine(" ______________________________________________________ ");
                    Console.WriteLine("|   Действия со счетами:                               |");
                    Console.WriteLine("| 2. Просмотр всех счетов                              |");
                    Console.WriteLine("| 3. Открыть счет                                      |");
                    Console.WriteLine("| 4. Закрыть счет                                      |");
                    Console.WriteLine("| 5. Перевод на счет                                   |");
                    Console.WriteLine("| 6. Просмотр истории движения средств                 |");
                    Console.WriteLine(" ______________________________________________________ ");
                    Console.WriteLine("|   Действия с вкладами:                               |");
                    Console.WriteLine("| 7. Создать вклад                                     |");
                    Console.WriteLine("| 8. Закрыть вклад                                     |");
                    Console.WriteLine("| 9. Перевод                                           |");
                    Console.WriteLine("| 10. Накопление                                        |");
                    Console.WriteLine(" ______________________________________________________ ");

                } while (!int.TryParse(Console.ReadLine(), out choice));
                switch (choice)
                {
                    case 1:
                        
                        break;
                    case 2:
                        var list_accounts = clientService.GetMyAccounts(client.Id);
                        if (list_accounts.Count() == 0)
                        {
                            Console.WriteLine("У Вас нет счетов.");
                            continue;
                        }
                        Console.WriteLine("Список всех Ваших счетов:");
                        int i = 1;
                        foreach(Account acc in list_accounts)
                        {
                            Console.WriteLine($"{i++}. Имя счета: {acc.Id}");
                            Console.WriteLine($"------Баланс на счету: { acc.Balance}");
                            Console.WriteLine();
                        }
                        int accIndex;
                        do
                        {
                            Console.WriteLine("Выберите счет, с которым дальше будем работать, либо введите 0 для выхода из раздела Список счетов");
                        } while (!int.TryParse(Console.ReadLine(), out accIndex) || accIndex > list_accounts.Count());
                        if (accIndex == 0) continue;
                        int choice_account;
                        do
                        {
                            Console.WriteLine(" ______________________________________________________ ");
                            Console.WriteLine("|   Выберите одно из действий:                         |");
                            Console.WriteLine("| 1. Пополнить                                         |");
                            Console.WriteLine("| 2. Снять                                             |");
                            Console.WriteLine("| 3. Закрыть счет                                      |");
                            Console.WriteLine(" ______________________________________________________ ");
                        } while (!int.TryParse(Console.ReadLine(), out choice_account));
                        switch (choice_account)
                        {
                            case 1:
                                Console.WriteLine("Введите сумму для пополнения.");
                                if (decimal.TryParse(Console.ReadLine(), out decimal sum))
                                { 
                                    Console.WriteLine(clientService.TransferToTheAccount(client.Id, list_accounts[accIndex - 1].Id, sum));
                                }
                                break;
                            case 2:
                                Console.WriteLine("Введите сумму для снятия.");
                                if (decimal.TryParse(Console.ReadLine(), out decimal sum_s))
                                {
                                    
                                    Console.WriteLine(clientService.WithdrawFromAccount(client.Id, list_accounts[accIndex - 1].Id, sum_s));
                                    
                                }
                                break;
                            case 3:
                                clientService.CloseAccount(client.Id, list_accounts[accIndex - 1].Id);
                                Console.WriteLine("Счет закрыт.");
                                break;
                        }
                        break;
                    case 3:
                        Account new_account = clientService.OpenAccount(client.Id);
                        Console.WriteLine($"Вы открыли счет {new_account.Id}");
                        break;

                    case 4:
                        //Console.WriteLine("Введите порядковый номер счета, который хотите закрыть");
                    
                        //if (int.TryParse(Console.ReadLine(), out int accIndex))
                        //{
                        //    if (accIndex > 0 && accIndex <= list_accounts.Count())
                        //}
                        //clientService.CloseAccount((Guid)str);

                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Введите число сугубо из списка!");
                        break;
                }
            }
        }
    }
}
