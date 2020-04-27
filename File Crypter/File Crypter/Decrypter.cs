using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace File_Crypter
{
    class Decrypter
    {

        public static string IV = "brk38bBeD6oyi3rp"; //16
        public static string key = "fmeldmhlrp3lg;6lgkrm7,3lg;oi7m3;"; //32

        public static void DecrpytFolder(string input, string output)
        {

            string inputFile = input;
            string outputFile = output;

            var aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = ASCIIEncoding.ASCII.GetBytes(key);
            aes.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform icrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            ICryptoTransform dcrypt = aes.CreateDecryptor(aes.Key, aes.IV);

          


            string[] files2 = Directory.GetFiles(input);

            foreach (var f in files2)
            {

                FileInfo fi = new FileInfo(f);
                using (FileStream fsOut = System.IO.File.OpenWrite(output + (@"\") + fi.Name))
                {
                    using (CryptoStream stream = new CryptoStream(fsOut, dcrypt, CryptoStreamMode.Write))
                    {
                        using (FileStream fsIn = System.IO.File.OpenRead(f))
                        {

                            //read in ~1 MB  chunks
                            int bufferLen = 1000000;
                            byte[] buffer = new byte[bufferLen];
                            int bytesRead;
                            do
                            {
                                bytesRead = fsIn.Read(buffer, 0, buffer.Length);
                                stream.Write(buffer, 0, bytesRead);
                            } while (bytesRead != 0);
                        }
                    }
                }



            }

        }

    }
}
