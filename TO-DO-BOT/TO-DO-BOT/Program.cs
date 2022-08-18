using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TO_DO_BOT
{
    internal class Program
    {
        private static readonly string _botKey = System.IO.File.ReadAllText(@"C:\tgBot\BotKey.txt");
        public static Dictionary<string, UserState> Users = new();
        static async Task Main(string[] args)

        {

            var bot = new TelegramBotClient(_botKey);
            var allowedUpdates = new UpdateType[] { UpdateType.Message };
            var receiverOptions = new ReceiverOptions        

            {
                AllowedUpdates = allowedUpdates
            };


            bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, CancellationToken.None);

            Console.ReadLine();
            
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
        {
            var username = update.Message.Chat.Username;
            if (!Users.ContainsKey(username))
            {
                Users.Add(username, new UserState());
            }
            var state = Users[username];
            if (update.Type != Telegram.Bot.Types.Enums.UpdateType.Message)
                return;

            var message = update.Message;


            switch (message.Text.ToLower())
            {
                case "/start":

                    var AuthKeyboard = new ReplyKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                new KeyboardButton("Войти"),
                                new KeyboardButton("Зарегестрироваться")
                            }
                        });
                    AuthKeyboard.ResizeKeyboard = true;
                    await bot.SendTextMessageAsync(message.Chat, "Здравствуйте! Вас приветствует To-Do бот!");
                    await bot.SendTextMessageAsync(message.Chat.Id, "У вас уже есть аккаунт или вы хотите зарегестрироваться?", replyMarkup: AuthKeyboard);
                    break;

                case "зарегестрироваться":

                    Users[username].IsRegisterButtonClicked = true;
                    await bot.SendTextMessageAsync(message.Chat.Id, "Введите пароль следующим сообщением", replyMarkup: new ReplyKeyboardRemove());
                    break;

                case "войти":

                    Users[username].NeedsLogIn = true;
                    await bot.SendTextMessageAsync(message.Chat.Id, "Введите пароль следующим сообщением", replyMarkup: new ReplyKeyboardRemove());
                    break;

                default:

                    if (Users[username].IsRegisterButtonClicked)
                    {
                        AuthKeyboard = new ReplyKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                new KeyboardButton("Войти"),
                                new KeyboardButton("Зарегестрироваться")
                            }
                        });
                        AuthKeyboard.ResizeKeyboard = true;
                        var password = message.Text;
                        if (await UserRepository.Register(username, password))
                        {
                            Users[username].IsRegisterButtonClicked = false;
                            await bot.SendTextMessageAsync(message.Chat.Id, "Ура, вы успешно зарегестрировались! Осталось лишь войти в свой аккаунт!", replyMarkup: AuthKeyboard);
                        }
                        else
                        {
                            Users[username].IsRegisterButtonClicked = false;
                            await bot.SendTextMessageAsync(message.Chat.Id, "Пользователь с вашим именем пользователя уже зарегестрирован!", replyMarkup: AuthKeyboard);
                        }


                    }

                    if (Users[username].NeedsLogIn)
                    {

                        var password = message.Text;
                        var ToDoKeyboard = new ReplyKeyboardMarkup(new[]
                               {
                            new[]
                            {
                                new KeyboardButton("Добавить задачу"),
                                new KeyboardButton("Удалить задачу"),
                                new KeyboardButton("Доступные задачи")
                            }
                        });
                        ToDoKeyboard.ResizeKeyboard = true;
                        if (await UserRepository.Login(username, password))
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Вы успешно вошли в аккаунт!", replyMarkup: ToDoKeyboard);
                        }
                        else
                        {
                            AuthKeyboard = new ReplyKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                new KeyboardButton("Войти"),
                                new KeyboardButton("Зарегестрироваться")
                            }
                        });
                            AuthKeyboard.ResizeKeyboard = true;
                            await bot.SendTextMessageAsync(message.Chat.Id, "Вы ввели неверный пароль, либо вы ещё не зарегестрированы.", replyMarkup: AuthKeyboard);
                        }
                        Users[username].NeedsLogIn = false;
                        Users[username].IsActive = true;

                    }

                    if (Users[username].AddTask == true)
                    {

                        UserRepository.AddTaskAsync(UserRepository.GetUserId(username).Result, message.Text);
                        await bot.SendTextMessageAsync(message.Chat.Id, "Вы успешно дабавили задачу");
                        Users[username].AddTask = false;

                    }

                    if (Users[username].IsActive && message.Text == "Добавить задачу")
                    {

                        await bot.SendTextMessageAsync(message.Chat.Id, "Введите текст задачи, которую хотите добавить");
                        Users[username].AddTask = true;

                    }

                    if (Users[username].RemoveTask == true)
                    {

                        await UserRepository.RemoveTaskAsync(UserRepository.GetUserId(username).Result, message.Text);
                        Users[username].RemoveTask = false;

                    }

                    if (Users[username].IsActive && message.Text == "Удалить задачу")
                    {

                        Users[username].RemoveTask = true;
                        await bot.SendTextMessageAsync(message.Chat.Id, "Введите текст задачи, которую хотите удалить");

                    }
                    
                    if (Users[username].IsActive && message.Text == "Доступные задачи")
                    {

                        var tasks = await UserRepository.GetAllTasksAsync(UserRepository.GetUserId(username).Result);
                        string tasksString = "Вам доступны следующие задачи: \n";
                        foreach (var task in tasks)
                        {
                            tasksString += String.Concat(task, "\n");
                        }
                        await bot.SendTextMessageAsync(message.Chat.Id, tasksString);


                    }

                    break;
            }


        }

        private static async Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
        }
    }
    class UserState
    {
        public bool IsRegisterButtonClicked { get; set; }
        public bool NeedsLogIn { get; set; }
        public bool IsActive { get; set; }
        public bool AddTask { get; set; }
        public bool RemoveTask { get; set; }
    } 
}