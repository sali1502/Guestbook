/* DT201G Programmering med C#.NET, moment 3. Åsa Lindskog sali1502@student.miun.se. */
/* En konsollapplikation som fungerar som en gästbok där användare kan posta och radera inlägg. */

using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace messages
{
    public class Guestbook
    {
        // Filnamn för lagring av gästboksinlägg i JSON-format
        private string filename = @"guestbook.json";

        // Lista för att lagra inlägg (objekt)
        private List<Message> messages = new List<Message>();

        public Guestbook()
        {
            // Kontrollera om JSON-filen med de lagrade inläggen finns
            // Om den gör det, läs ut innehållet "avserialiserat" till listan messages
            if (File.Exists(filename) == true)
            {
                string jsonString = File.ReadAllText(filename);
                messages = JsonSerializer.Deserialize<List<Message>>(jsonString)!;
            }
        }

        // Metod för att lägga till ett nytt inlägg
        public Message addMessage(string text)
        {
            // Skapa ett mytt Message-objekt
            Message obj = new Message();
            obj.TextMessage = text;
            // Lägg till inlägg i listan och spara uppdateringen
            messages.Add(obj);
            // Spara hela listan med det nya inlägget
            marshal();
            return obj;
        }

        // Metod för att ta bort ett inlägg baserat på index
        public int delMessage(int index)
        {
            // Ta bort ett inlägg från listan och uppdatera listan 
            messages.RemoveAt(index);
            // Uppdatera filen efter borttagingen
            marshal();
            return index;
        }

        // Hämta alla inlägg i gästboken som en lista
        public List<Message> getMessages()
        {
            return messages;
        }
        // Metod för att spara (serialisera) listan med inlägg tlll JSON-fil
        private void marshal()
        {
            // Serialisera listan messages till JSON-format och skriv till filen
            var jsonString = JsonSerializer.Serialize(messages);
            File.WriteAllText(filename, jsonString);

        }
    }
}
