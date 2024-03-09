using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Wpf_ComputerStore.Services
{
    public class SMTPService
    {
        public SMTPService()
        { 
        }
        public void Send(string receiver, string body, string subject, string password, string sender)
        {         
                try
                {               
                            //MailMessage - представляет сообщение электронной почты, которое может быть отправлено с помощью класса SmtpClient.
                            MailMessage message = new MailMessage();
                            message.To.Add(new MailAddress(receiver)); // электронный адрес получателя (login@itstep.academy) polyanskiy@itstep.academy  
                            message.From = new MailAddress(sender); // электронный адрес отправителя (login@gmail.com)        nastasia.schull@gmail.com
                            
                            message.Subject = subject; // тема письма
                            message.Body = body; // содержимое письма                 
                            message.SubjectEncoding = Encoding.UTF8;                           
                            message.BodyEncoding = Encoding.UTF8;   // кодировка, используемая для кодирования текста письма
                           // SmtpClient позволяет приложениям отправлять электронную почту с помощью протокола SMTP (Simple Mail Transfer Protocol)

                            int port = 587;
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com" /* сервер SMTP */, port /* порт */); // например, smtp.gmail.com   порт 587

                            // Credentials - учетные данные, используемые для проверки подлинности отправителя
                           
                            smtp.Credentials = new NetworkCredential(sender /* логин */, password /* пароль */);
                            smtp.EnableSsl = true;                                                   // Указывает, использует ли SmtpClient протокол SSL для шифрования подключения.
                                                                                                     // Send отправляет указанное сообщение на сервер SMTP для доставки
                            smtp.Send(message);
                            MessageBox.Show("Квитанцiю вiдправлено!");
                       
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }
    }
}
                                                                                                                                                                                                                                                                                                                                       