
using System.Net;
using System.Net.Mail;
using MailKit.Net.Imap;
using MailKit;
using System;

namespace LWASpecflow.Utilities;

public class EmailService
{
    
    
    public static void SendEmail(string emailTo)
    {
        { 
        // Define the email message
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("abhishekcpj@yahoo.com"); // Sender's email address
        mail.To.Add(emailTo); // Recipient's email address
        mail.Subject = "Subject of the Email";
        mail.Body = "Body of the email";

        // Add an attachment
        // Attachment attachment = new Attachment("path-to-your-file.txt");
        // mail.Attachments.Add(attachment);


        // Configure SMTP client
        SmtpClient smtpClient = new SmtpClient("smtp.mail.yahoo.com"); // SMTP server address
        smtpClient.Port = 587; // SMTP port number   (it can be 25, 465, )
        smtpClient.Credentials = new NetworkCredential("abhishekcpj@yahoo.com", "ymohxrvhjmdlkwgf"); // SMTP credentials
        smtpClient.EnableSsl = true; // Enable SSL for secure connection

        try
        {
            // Send the email
            smtpClient.Send(mail);
          
            Console.WriteLine("Email sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending email: " + ex.Message);
        }
    }

   

    }

    
    public static void reaadEmail()
    {
         using (var client = new ImapClient())
        {
            try
            {
                // Connect to the IMAP server
                client.Connect("imap.example.com", 993, MailKit.Security.SecureSocketOptions.SslOnConnect); // Use SSL/TLS

                // Authenticate
                client.Authenticate("your-email@example.com", "your-email-password");

                // Select the inbox folder
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                // Fetch all messages
                var messages = inbox.Fetch(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId);

                foreach (var summary in messages)
                {
                    // Fetch the full message using UniqueId
                    var message = inbox.GetMessage(summary.UniqueId);

                    // Print email details
                    Console.WriteLine($"Subject: {message.Subject}");
                    Console.WriteLine($"From: {message.From}");
                    Console.WriteLine($"Date: {message.Date}");
                    Console.WriteLine($"Body: {message.TextBody}");
                    Console.WriteLine(new string('-', 40));
                }

                // Disconnect from the server
                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }

}