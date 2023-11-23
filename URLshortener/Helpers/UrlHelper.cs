namespace URLshortener.Helpers
{
    public class UrlHelper
    {
        public string ShortenURL()
        {
            string randomString = GenerateRandomString(6);
            string shortUrl = $"https://surl.com/{randomString}";
            return shortUrl;
        }

        static string GenerateRandomString(int longitud)
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] randomArray = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                randomArray[i] = caracteres[random.Next(caracteres.Length)];
            }
            return new string(randomArray);
        }
    }
}
