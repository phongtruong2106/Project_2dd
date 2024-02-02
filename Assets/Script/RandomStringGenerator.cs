using System;
using System.Text;

public class RandomStringGenerator
{
    private const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

    public static string Generate(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentException("Length must be greater than 0", nameof(length));
        }

        StringBuilder sb = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            sb.Append(chars[UnityEngine.Random.Range(0, chars.Length)]);
        }
        return sb.ToString();
    }
}
