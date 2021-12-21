using System.Security.Cryptography;

namespace MainWindow;

public class RandomKeyGenerator
{
    public string GenerateKey()
    {
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        byte[] keyBytes = new byte[32];
        rng.GetBytes(keyBytes);
        var key = string.Concat(Array.ConvertAll(keyBytes, b => b.ToString("X2"))).ToLower();
        return key;
    }
}