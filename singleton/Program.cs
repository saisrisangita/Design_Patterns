public class Email
{
    private static volatile Email instance = null;
    public string Sender { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public string name { get; private set; }

    private static readonly object lockObject = new object();

    private Email() { } // Private constructor

    public static Email Instance(string s)
    {
        
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Email();
                        instance.name = s;
                    }
                }
            }
            return instance;
        
    }

    public void Send()
    {
        // Implementation for sending the email
        Console.WriteLine("Sending email...");
        Console.WriteLine($"Sender: {Sender}");
        Console.WriteLine($"Subject: {Subject}");
        Console.WriteLine($"Body: {Body}");
        Console.WriteLine("Email sent successfully.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Email email = Email.Instance("first");
        email.Sender = "sai@example.com";
        email.Subject = "Greetings";
        email.Body = "Hello, world!";
        email.Send();

        // Attempt to create another instance
        Email anotherEmail = Email.Instance("second");
        anotherEmail.Sender = "durga";
        anotherEmail.Subject = "hi";
        anotherEmail.Body = "Hello, durga!";
        anotherEmail.Send();
    }
}
