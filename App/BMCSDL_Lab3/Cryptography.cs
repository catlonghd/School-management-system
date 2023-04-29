using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace BMCSDL_Lab3
{
    public class Cryptography
    {
        public static string HashMD5(string text)
        {
            MD5 md5 = MD5.Create(); //tạo cài đặt hash bằng md5
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));//doi tu string qua bytes va hash bang md5
            StringBuilder hashSb = new StringBuilder();
            foreach (byte b in hash)
            {
                hashSb.Append(b.ToString("X2")); //chuoi duoc viet duoi dang 2 ky tu hex
            }
            return hashSb.ToString();//chuoi duoc viet lai duoi dang dec
        }
        public static string HashSHA1(string text)
        {
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder hashSb = new StringBuilder();
            foreach (byte b in hash)
            {
                hashSb.Append(b.ToString("X2"));
            }
            return hashSb.ToString();
        }
        public static string RSA_Agl(string text,string privatekey, string publickey,bool IsEnc)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();//khoi tao dich vu rsa voi n,e,d duoc thu vien generate
            rsa.FromXmlString(privatekey+ publickey);// nhap vao nguon rsa vua duoc generate voi privatekey la gia tri cua rieng minh

            RSAParameters priv = rsa.ExportParameters(true);//xuat thu priv key va kiem tra
            RSAParameters publ = rsa.ExportParameters(false);//xuat thu public key va kiem tra
            if (IsEnc)//neu ta can ma hoa
            {
                string cipher = RSAEncrypt(text, rsa);
                return cipher;
            }
            string mess = RSADecrypt(text, rsa);
            return text;
        }
        public static string RSAEncrypt(string plaintext, RSACryptoServiceProvider rsa)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding(); // tao kieu du lieu de convert
            byte[] textBytes = ByteConverter.GetBytes(plaintext);// convert string to bytes
            byte[] ciphertext = rsa.Encrypt(textBytes, false);// ma hoa rsa
            return ByteConverter.GetString(ciphertext);
        }
        public static string RSADecrypt(string ciphertext, RSACryptoServiceProvider rsa)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] textBytes = ByteConverter.GetBytes(ciphertext);
            byte[] plaintext = rsa.Decrypt(textBytes, false);//giai ma rsa
            return ByteConverter.GetString(plaintext);
        }
        public static string AES256 (string text, string key,bool IsEnc)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] TextBytes = ByteConverter.GetBytes(text);
            byte[] keyBytes = ByteConverter.GetBytes(key);
            AesCryptoServiceProvider myAes = new AesCryptoServiceProvider();
            myAes.KeySize = 256;
            myAes.Key = keyBytes;
            if(IsEnc)
            {
                return ByteConverter.GetString(AESEnc(text, myAes.Key, myAes.IV));
            }
            return AESDec(TextBytes, myAes.Key, myAes.IV);
        }
        public static byte[] AESEnc (string plaintext, byte[] key,byte[] IV)
        {
            byte[] encrypted;
            AesCryptoServiceProvider enc = new AesCryptoServiceProvider();
            enc.Key = key;
            enc.IV = IV;
            ICryptoTransform encryptor = enc.CreateEncryptor(enc.Key, enc.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plaintext);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
        public static string AESDec(byte[] ciphertext, byte[] key, byte[] IV)
        {
            string decrypted;
            AesCryptoServiceProvider dec = new AesCryptoServiceProvider();
            dec.Key = key;
            dec.IV = IV;
            ICryptoTransform decryptor = dec.CreateDecryptor(dec.Key, dec.IV);
            using (MemoryStream msDecrypt = new MemoryStream(ciphertext))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        decrypted = srDecrypt.ReadToEnd();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return decrypted;
        }
    }
}
