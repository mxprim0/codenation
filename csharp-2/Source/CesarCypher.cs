using System;
using System.Linq;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public const int cypher = 3;
        public const string letters = "abcdefghijklmnopqrstuvwxyz";
        public const string numbers = "0123456789";

        public string Crypt(string message)
        {
            string cryptedMessage = null;

            if (message != null)
            {
                message = message.ToLower();
            }
            else throw new ArgumentNullException();

            foreach(char c in message)
            {
                if (letters.Contains(c))
                {
                    int lettersIndex = letters.IndexOf(c);
                    if (lettersIndex + cypher >= letters.Length)
                        lettersIndex = (lettersIndex + cypher) - letters.Length;
                    else lettersIndex += cypher;

                    cryptedMessage += letters.Substring(lettersIndex, 1);
                }
                else if (numbers.Contains(c))
                {
                    cryptedMessage += c;
                }
                else if (Char.IsWhiteSpace(c))
                {
                    cryptedMessage += c;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            return cryptedMessage;
        }

        public string Decrypt(string cryptedMessage)
        {
            string descryptedMessage = null;

            if (cryptedMessage != null)
            {
                cryptedMessage = cryptedMessage.ToLower();
            }
            else throw new ArgumentNullException();

            foreach (char c in cryptedMessage)
            {
                if (letters.Contains(c))
                {
                    int lettersIndex = letters.IndexOf(c);
                    if (lettersIndex - cypher < 0)
                        lettersIndex = (lettersIndex - cypher) + 26;
                    else lettersIndex -= cypher;

                    descryptedMessage += letters.Substring(lettersIndex, 1);
                }
                else if (numbers.Contains(c))
                {
                    descryptedMessage += c;
                }
                else if (Char.IsWhiteSpace(c))
                {
                    descryptedMessage += c;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            return descryptedMessage;
        }

    }
}
