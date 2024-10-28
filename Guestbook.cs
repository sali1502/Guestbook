/* DT201G Programmering med C#.NET, moment 3. Åsa Lindskog sali1502@student.miun.se. */
/* En applikation som fungerar som en gästbok där användare kan posta och radera inlägg. */

using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace messages
{
    public class Guestbook
    {
        private string filename = @"guestbook.json";
        private List<Message> messages = new List<Message>();

        public Guestbook()
        {
            // Om det finns lagrade meddelanden läs ut dessa
            if (File.Exists(filename) == true)
            {
                string jsonString = File.ReadAllText(filename);
                messages = JsonSerializer.Deserialize<List<Message>>(jsonString)!;
            }
        }

        public Message addMessage(string text)
        {
            Message obj = new Message();
            obj.TextMessage = text;
            messages.Add(obj);
            marshal();
            return obj;
        }

        public int delMessage(int index)
        {
            messages.RemoveAt(index);
            marshal();
            return index;
        }
        public List<Message> getMessages()
        {
            return messages;
        }

        private void marshal()
        {
            // Serialisering av alla objekt och spara till fil
            var jsonString = JsonSerializer.Serialize(messages);
            File.WriteAllText(filename, jsonString);

        }
    }
}
