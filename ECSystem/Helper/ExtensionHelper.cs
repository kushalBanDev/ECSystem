namespace ECSytem.Helper
{
    public static class ExtensionHelper
    {
        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this string encryptedText)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(encryptedText);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
