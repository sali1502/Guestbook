/* DT201G Programmering med C#.NET, moment 3. Åsa Lindskog sali1502@student.miun.se. */
/* En applikation som fungerar som en gästbok där användare kan posta och radera inlägg. */

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