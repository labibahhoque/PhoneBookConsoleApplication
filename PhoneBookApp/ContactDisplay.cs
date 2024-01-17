using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class ContactDisplay : IContactDisplayer
    {
        private List<Contact> contacts { get; set; } = new List<Contact>();

        private Contact contact { get; set; }

        string filePath = @"C:\\Users\\User\\source\\repos\\PhoneBookApp\\PhoneBookApp\\Contacts.txt";
     
        public void DisplayAllContacts()
        {

            try
            {
                var lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    Console.WriteLine("No contacts found in the file.");
                    return;
                }
                Console.WriteLine(lines.Length);
                Console.WriteLine("Contacts from File:");
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
             
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


    }
}
