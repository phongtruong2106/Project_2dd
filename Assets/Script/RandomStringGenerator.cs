
public class RandomStringGenerator
{
    private const string chars = "qwertyuiopasdfghjklzxcvbnm0123456789";

    public static string Generate(int lenght)
    {
        string randomString = "";
        for(int i = 0; i< lenght; i++)
        {
            randomString += chars[UnityEngine.Random.Range(0, chars.Length)];
        }
        return randomString;
    }
}