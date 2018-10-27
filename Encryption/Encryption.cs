using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Encryption
    {
        private byte[] encrypted;
        private string publicKey;
        private string privateKey;

        public Encryption()
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                File.WriteAllText("PublicKey.xml", rsa.ToXmlString(false));
                File.WriteAllText("PrivateKey.xml", rsa.ToXmlString(true));
            }
            publicKey = File.ReadAllText("PublicKey.xml");
            privateKey = File.ReadAllText("PrivateKey.xml");
        }

        public byte[] Encrypt(byte[]data)
        {       
            using (var RSAEncrypt = new RSACryptoServiceProvider())
            {
                RSAEncrypt.FromXmlString(publicKey);
                encrypted = RSAEncrypt.Encrypt(data, false);
            }
            return encrypted;
        }

        public byte[] Decrypt(byte[] data)
        {
            byte[] decrypted;
            using (var RSADecrypt = new RSACryptoServiceProvider())
            {
                RSADecrypt.FromXmlString(privateKey);
                decrypted = RSADecrypt.Decrypt(encrypted, false);
            }
            return decrypted;
        }

    }
}
