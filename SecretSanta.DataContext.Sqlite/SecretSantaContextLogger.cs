using static System.Environment;
namespace SecretSanta.EntityModels;

public class SecretSantaContextLogger
{
    public static void WriteLine(string message)
    {
        string path = Path.Combine(GetFolderPath(
            SpecialFolder.DesktopDirectory), "SecretSantaLog.txt");
        StreamWriter textFile = File.AppendText(path);
        textFile.WriteLine(message);
        textFile.Close();
    }
}