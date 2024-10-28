/* DT201G Programmering med C#. Moment 3. Åsa Lindskog sali1502@student.miun.se. */
/* En applikation som fungerar som en gästbok där användare kan posta medddelanden och radera meddelanden.
Meddelanden lagras i en JSON-fil */

// Klass för meddelanden
namespace messages
{
    public class Message
    {
        public string? TextMessage
        {
            get; set;
        }
    }
}