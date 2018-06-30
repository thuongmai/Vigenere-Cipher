using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class CaesarCipher
    {
        //Shift to the left to decrypt. Positive keyLength is left
        public static string decrypt(string cipherText, int keyLength)
        {
            string plainText = string.Empty;
            foreach (char c in cipherText)
            {
                if ((char)c >= 65 && (char)c <= 90)
                {
                    /* cipherText: Text that needs to encrypt
                     * cipherCode: a position of each alphabet e.g A=0, B=1, ...
                     * keyLength: the length that need to be shifted
                     * plainCode: the ASCII position of the alphabet after shifted.
                     * plainChar: converted alphabet after shifted
                     * plainText: Completed text after decrypt
                     */
                    int cipherCode = (char)c - 65;
                    int shifted = cipherCode - keyLength;

                    int plainCode = 0;
                    if (shifted >= 0)  // Modulo is stupid in C#. -4 % 26 return -4 instead of 22
                        plainCode = (shifted % 26) + 65; //decrypt
                    else
                        plainCode = (shifted % 26) + 65 + 26; //decrypt

                    char plainChar = (char)plainCode;
                    plainText += plainChar;
                }
                else
                {
                    plainText += c;
                }
            }

            return plainText;
        }

        public static string encrypt (string plainText, int keyLength)
        {
            string cipherText = string.Empty;
            foreach (char c in plainText)
            {
                if ((char)c >= 65 && (char)c <= 90)
                {
                    int plainCode = (char)c - 65;
                    int shifted = plainCode + keyLength;
                    int cipherCode = ((shifted) % 26) + 65;
                    char cipherChar = (char)cipherCode;
                    cipherText += cipherChar;
                }
                else
                {
                    cipherText += c;
                }
            }
            return cipherText;
        }
    }
}
