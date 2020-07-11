using System;
using System.Text.RegularExpressions;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public static char codecipher(char ch, int key) {  
            if (!char.IsLetter(ch)) {  
  
                return ch;  
            }  
  
            char d = char.IsUpper(ch) ? 'A' : 'a';  
            return (char)((((ch + key) - d) % 26) + d);}

        private bool confirmMessage(string message)
        {
            var regex = new Regex("^[a-zA-Z0-9 ]*$");
            if (!regex.IsMatch(message))
                throw new ArgumentOutOfRangeException();

            else if (message == null)
                throw new ArgumentNullException();

            else if (message == string.Empty)
                return false;

            else
                return true;
        }

        public string Crypt(string message)
        {
            string cryptedMessage = string.Empty;
            
            if (confirmMessage(message))
            {
                message = message.ToLower();
                foreach (char ch in message)
                    cryptedMessage += codecipher(ch, 3);

                return cryptedMessage;
            }
            else  
                return message; 
        }

        public string Decrypt(string cryptedMessage)
        {
            string decryptedMessage = string.Empty;
            
            if (confirmMessage(cryptedMessage))
            {
                cryptedMessage = cryptedMessage.ToLower();
                foreach (char ch in cryptedMessage)
                    decryptedMessage += codecipher(ch, 23);

                return decryptedMessage;
            }
            else 
                return cryptedMessage;
        }
    }
}
