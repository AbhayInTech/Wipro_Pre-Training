using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SOLID_C_
{
    // this is Single Responsibility Principle (SRP) example
    public class EmailSender
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Sending Email : {message}");
        }
    }

    public class SmsSender
    {
        public void SendSms(string message)
        {
            Console.WriteLine($"Sending SMS : {message}");
        }
    }

    // for implementing OCP(Open/Closed Principle), we can use an interface to entend notification types without cahnging existing code
    
    public interface INotifier
    {
        void Send(string message);
    }
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("Email sent : "+message);
        }
    }
    public class SmsNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS sent : " + message);
        }
    }
    // LSP(Liskov Substitution Principle) is already implemented by using interface INotifier

    public class NotificationProcessor
    {
        private readonly INotifier _notifier;// Reference of Interface
        public NotificationProcessor(INotifier notifier)
        {
            _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
        }
        public void Process(string message)
        {
            _notifier.Send(message);// LSP works: can use EmailNotifier or SmsNotifier interchangeably
        } 
    }
    // ISP(Interface Segregation Principle) : keeping all teh interface small and focused
    public interface IEmailSender
    {
        void SendEmail(string message);
    }
    public interface ISmsSender
    {
        void SendSms(string message);
    }
    public class EmailSenders : IEmailSender
    {// Here we are not forcing 
        public void SendEmail(string message)
        {
            Console.WriteLine("Email : "+message);
        }
    }
}
// C-Sharp - Reference Book
//  - complete reference
//  - black book
//  - head first c-sharp
//  - C# 8.0 and .NET Core 3.0 - Modern Cross-Platform Development
