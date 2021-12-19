namespace MainWindow;

public class HmacGenerator
{
    public string GenerateHmac(string move, string key)
    {
        var signatureBytes = System.Text.Encoding.UTF8.GetBytes(move.ToString());
        var shaKeyBytes = System.Text.Encoding.UTF8.GetBytes(key);
        var shaAlgorithm = new System.Security.Cryptography.HMACSHA256(shaKeyBytes);
        var signatureHashBytes = shaAlgorithm.ComputeHash(signatureBytes);
        var signatureHashHex = string.Concat(Array.ConvertAll(signatureHashBytes, b => b.ToString("X2"))).ToLower();
        return signatureHashHex;
    }
}