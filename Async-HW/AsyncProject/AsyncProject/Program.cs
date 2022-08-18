using System.Collections;
using System.Runtime.CompilerServices;
using AsyncProject;

string a = "a";
var imageDownloader = new ImageDownloader();
imageDownloader.ImageStarted += StartMessage;
imageDownloader.ImageCompleted += EndMessage;
var download = imageDownloader.Download();
Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
while (true)
{
    
    var Buttom = Console.ReadKey().KeyChar;
    if (Buttom.ToString().ToLower() != a)
    {
        if (download.IsCompleted)
        {
            Console.WriteLine("Выполнение скачивания завершено");
        }
        else
            Console.WriteLine("Скачивание ещё не завершено");
    }
    else return;
    
}

void StartMessage()
{
    Console.WriteLine("Скачивание началось");
}

void EndMessage()
{
    Console.WriteLine("Скачивание завершено");
}




