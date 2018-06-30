using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class VigenereCipher
    {
        enum pos { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };
        //Enum.GetName(typeof(pos), i) : get enum name based on value

        public static string decrypt (string cipherText, int keyLength)
        {
            string plainText = string.Empty;
            int lengthText = cipherText.Length;

            string[] cipherGroup = new string[keyLength];
            string cipher1 = string.Empty, cipher2 = string.Empty, cipher3 = string.Empty;

            //Sepearate the cipherText into 3 groups based on their modulo
            for (int i = 0; i < lengthText; i++)
            {
                if (i % keyLength == 0)
                    cipher1 += cipherText[i];
                if (i % keyLength == 1)
                    cipher2 += cipherText[i];
                if (i % keyLength == 2)
                    cipher3 += cipherText[i];
            }

            Console.WriteLine("Plain 1: " + cipher1);
            Console.WriteLine("Plain 2: " + cipher2);
            Console.WriteLine("Plain 3: " + cipher3);

            //Counted Text and print
            Dictionary<int, int> countRepeated1 = countRepeatedKeys(cipher1);
            Dictionary<int, int> countRepeated2 = countRepeatedKeys(cipher2);
            Dictionary<int, int> countRepeated3 = countRepeatedKeys(cipher3);
            Console.WriteLine("-------Counted Repeating Key-----------\n");
            Console.WriteLine("Normal English repeated key");
            Console.WriteLine("A B C D E  F G H I G K L M N O P Q R S T U V W X Y Z");
            Console.WriteLine("8 2 3 4 13 2 2 6 7 0 1 4 2 7 8 2 0 6 6 9 3 1 2 0 2 0");
            for (int i = 0; i < 26; i++)
            {
                Console.Write(Enum.GetName(typeof(pos), i) + " ");
            }
            Console.WriteLine("\ncipher1");
            for (int i = 0; i < 26; i++)
            {
                Console.Write(countRepeated1[i] + " ");
            }
            Console.WriteLine("\ncipher2");
            for (int i = 0; i < 26; i++)
            {
                Console.Write(countRepeated2[i] + " ");
            }
            Console.WriteLine("\ncipher3");
            for (int i = 0; i < 26; i++)
            {
                Console.Write(countRepeated3[i] + " ");
            }

            //Loop through all possible decrypted texts
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    for (int k = 0; k < 25; k++)
                    {
                        string plainText1 = CaesarCipher.decrypt(cipher1, i); //P is the highest probability in text1, it should be E in normal English, shift back 11/2
                        string plainText2 = CaesarCipher.decrypt(cipher2, j); //P is the highest probability in text1, it should be E in normal English, shift back 22
                        string plainText3 = CaesarCipher.decrypt(cipher3, k); //P is the highest probability in text1, it should be E in normal English, shift back 7 / 15
                        plainText = string.Empty;
                        for (int l = 0; l < plainText1.Length; l++)
                        {
                            plainText += plainText1[l];
                            plainText += plainText2[l];
                            if (l < plainText3.Length) //Clumpsy code 
                                plainText += plainText3[l];
                        }
                        //Console.WriteLine("----" + i + "," + j + "," + k + ":" + plainText);
                        if (plainText.Contains("THE") || plainText.Contains("AND"))
                        {
                            Console.WriteLine("KEY is : " + Enum.GetName(typeof(pos), i) + Enum.GetName(typeof(pos), j) + Enum.GetName(typeof(pos), k));
                            Console.WriteLine("----" + Enum.GetName(typeof(pos), i) + Enum.GetName(typeof(pos), j) + Enum.GetName(typeof(pos), k) + " : " + i + "," + j + "," + k + ":" + plainText);
                            Console.ReadKey();
                        }
                        /*if (i == 2 && j == 0 && k == 19)
                        {
                            Console.WriteLine("KEY is : " + Enum.GetName(typeof(pos), i) + Enum.GetName(typeof(pos), j) + Enum.GetName(typeof(pos), k));
                            string shortPlainText = string.Empty;
                            for (int m = 0; m < 40; m++)
                            {
                                shortPlainText += plainText[m];
                            }
                            Console.WriteLine("First 40 words of plainText: " + shortPlainText);
                            return plainText;
                        }*/
                    }
                }
            }
            return plainText;
        }

        public static Dictionary<int, int> countRepeatedKeys(string cipher)
        {
            int[] countPos = new int[26];
            Dictionary<int, int> countingCipher = new Dictionary<int, int>();

            foreach (char c in cipher)
            {
                switch (c)
                {
                    case 'A': ++countPos[(int)pos.A]; break;
                    case 'B': ++countPos[(int)pos.B]; break;
                    case 'C': ++countPos[(int)pos.C]; break;
                    case 'D': ++countPos[(int)pos.D]; break;
                    case 'E': ++countPos[(int)pos.E]; break;
                    case 'F': ++countPos[(int)pos.F]; break;
                    case 'G': ++countPos[(int)pos.G]; break;
                    case 'H': ++countPos[(int)pos.H]; break;
                    case 'I': ++countPos[(int)pos.I]; break;
                    case 'J': ++countPos[(int)pos.J]; break;
                    case 'K': ++countPos[(int)pos.K]; break;
                    case 'L': ++countPos[(int)pos.L]; break;
                    case 'M': ++countPos[(int)pos.M]; break;
                    case 'N': ++countPos[(int)pos.N]; break;
                    case 'O': ++countPos[(int)pos.O]; break;
                    case 'P': ++countPos[(int)pos.P]; break;
                    case 'Q': ++countPos[(int)pos.Q]; break;
                    case 'R': ++countPos[(int)pos.R]; break;
                    case 'S': ++countPos[(int)pos.S]; break;
                    case 'T': ++countPos[(int)pos.T]; break;
                    case 'U': ++countPos[(int)pos.U]; break;
                    case 'V': ++countPos[(int)pos.V]; break;
                    case 'W': ++countPos[(int)pos.W]; break;
                    case 'Y': ++countPos[(int)pos.Y]; break;
                    case 'Z': ++countPos[(int)pos.Z]; break;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                countingCipher.Add(i, countPos[i]);
            }
            return countingCipher;
        }
    }
}
