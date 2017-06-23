namespace Common
{
    using System;
    using System.Text;

    public static class Helper
    {
        
        public static string ConvertBasicHeader(string clientId, string secret)
        {
            var encoding = Encoding.UTF8;

            var credentials = string.Format("{0}:{1}", clientId, secret);

            return Convert.ToBase64String(encoding.GetBytes(credentials));
        }
    }
}
