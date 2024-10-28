/* DT201G Programmering med C#.NET, moment 3. Åsa Lindskog sali1502@student.miun.se. */
/* En konsollapplikation som fungerar som en gästbok där användare kan posta och radera inlägg. */

// Klass för inlägg - representerar ett enskilt inlägg i gästboken
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