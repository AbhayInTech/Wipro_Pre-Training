using Demo_SOLID_C_;
using System;
using static Demo_SOLID_C_.EmailNotifier;
{
    
}
class Program : NotificationProcessor
{
    static void Main()
    {
        //NotificationService service = new NotificationService();
        //service.Send("email", "Hello, this is a test email!");

        Console.WriteLine("After Implementing SOLID principles, here we are... !!!");
        INotifier emailNotifier = new EmailNotifier();
        NotificationProcessor emailProcessor = new NotificationProcessor(emailNotifier);
        emailProcessor.Process("Hello, this is a test email!");


    }
}
public class NotificationService()
{
    public void Send(string type, string message)
    {
        if (type == "email")
        {
            Console.WriteLine($"Sending email: {message}");
        }
        else if (type == "sms")
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
        else
        {
            Console.WriteLine($"Unknown notification type: {type}");
        }
    }
}


// here SRP is voilated : Sending Mail and SMS in same class
// OCP voilated : New Logic bREAKS THE EXISTING CODE
// No Abstraction : No Interface or Abstract class used