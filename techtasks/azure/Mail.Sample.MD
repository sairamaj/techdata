### Azure Using SendGrid for email
```csharp
     public async Task SendEmailAsync(string email, string subject, string htmlContent)
        {
            var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("test@testdomain.com", "This is sample"),
                Subject = subject,
                HtmlContent = htmlContent
            };

            msg.AddTo(new EmailAddress(email));
            msg.AddCc(new EmailAddress("testuser@hotmail.com"));      
            var response = await client.SendEmailAsync(msg);
        }

```

[source](https://sendgrid.com/docs/for-developers/partners/microsoft-azure/)