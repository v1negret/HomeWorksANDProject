using System.Net;

namespace AsyncProject;

public class ImageDownloader
{
    public delegate void MethodContainer();

    public event MethodContainer ImageStarted;
    public event MethodContainer ImageCompleted;

    public async Task Download()
    {
        // Откуда будем качать
        string remoteUri = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
        // Как назовем файл на диске
        string fileName = "bigimage.jpg";

        // Качаем картинку в текущую директорию
        var myWebClient = new WebClient();
        ImageStarted();
        await myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
        ImageCompleted();
    }

}
