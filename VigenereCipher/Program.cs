using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string cipherText0 = "UIF RVJDL CSPXO GPY KVNQT PWFS 13 MBAZ EPHT."; // 1
            Console.WriteLine("Test Cipher Text: " + CaesarCipher.decrypt(cipherText0, 1));

            //string cipherText1 = "KVXUAOGRRDRBGFTPDVWRMCDWTELUAWXILKNZGVXTYHPEMQVHVETIABPSMVHXYIGFMBNLLPOPDAENTAGNLRETMSTIABPHXVAEMSICSLKOGCTXNYTPDXNOJWEGVLRCNWER";
            //string cipherText1 = "ASTZHSSJNSBZFPSSJESNTBPZHNLREYUWCFWYUAXSJEGSTHDDCIPCBEVADINCCQYREYUBLFIDVWJOJOKDPOPQFKXHDPTWCASTZHMSOZZZLBZEVASSJDONPHKWRPSOPEVA";
            string cipherText1 = "FWURLERNWEAIFLXFNTIEUVCHDIGXMHIEIIOGFUGTEWRNWZTLVEFJTARTMYEREOPFPIFSXVAVYOMYEKFNXMEKPPKFPHJAEJNHNBTCLLVLHHUXECXRLEFWLYIFKOVFNMIO";
            Console.WriteLine("CipherText: " + cipherText1);
            Console.WriteLine("\nPlain Text: " + VigenereCipher.decrypt(cipherText1, 3));

            Console.ReadLine();
        }
    }
}
