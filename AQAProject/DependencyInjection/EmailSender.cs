using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DependencyInjection
{
    public class EmailSender
    {
        public void Send(string to, string text)
        {
            // Логика отправки письма
            Console.WriteLine($"Sending mail to {to}: {text}");
        }
    }
}
