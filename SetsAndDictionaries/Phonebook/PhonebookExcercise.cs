using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class PhonebookExcercise
    {
        public static void Main()
        {
            var phoneBook = new Dictionary<string, string>();

            PopulatePhoneBook(phoneBook);
            ProcessPhonebook(phoneBook);
        }

        private static void ProcessPhonebook(Dictionary<string, string> phoneBook)
        {
            var contactName = Console.ReadLine();

            while (contactName != "stop")
            {
                
                if (phoneBook.ContainsKey(contactName))
                {
                    var contactNumber = phoneBook[contactName];
                    Console.WriteLine($"{contactName} -> {contactNumber}");
                }
                else
                {
                    Console.WriteLine($"Contact {contactName} does not exist.");
                }

                contactName = Console.ReadLine();
            }
        }

        private static void PopulatePhoneBook(Dictionary<string, string> phoneBook)
        {
            var input = Console.ReadLine();
            while (input != "search")
            {
                var inputParts = input.Split('-');
                var contactName = inputParts[0];
                var contactPhoneNumber = inputParts[1];
                if (phoneBook.ContainsKey(contactName))
                {
                    
                    phoneBook[inputParts[0]] = contactPhoneNumber;
                }
                else
                {
                    phoneBook.Add(inputParts[0], contactPhoneNumber);
                }
                

                input = Console.ReadLine();
            }
        }
    }
}
