using System;

namespace WebApi.Business
{
    public class Encrypt
    {
        public static string DeCodeBase64(string str)
        {
            //Decodes any string in Base 64
            try
            {
                byte[] Buffer = Convert.FromBase64String(str);
                return System.Text.Encoding.UTF8.GetString(Buffer);
            }
            catch
            {
                return string.Empty;
            }
        }
    }


    


}
