using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            UnicodeEncoding Converter = new UnicodeEncoding();
            byte[] data = Converter.GetBytes(input);
            Encryption encryption = new Encryption();
            string encrypted = Converter.GetString(encryption.Encrypt(data));
            string decrypted = Converter.GetString(encryption.Decrypt(encryption.Encrypt(data)));
            Console.WriteLine(encrypted);
            Console.WriteLine(decrypted);
            Console.ReadLine();
        }
    }
}
