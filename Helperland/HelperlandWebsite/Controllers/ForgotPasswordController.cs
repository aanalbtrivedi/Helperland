using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace HelperlandWebsite.Controllers
{
    public class ForgotPasswordController : Controller
    {
        public IActionResult Check()
        {
            return View();
        }
        public IActionResult Index()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test", "aanalbtrivedi@gmail.com"));
            message.To.Add(new MailboxAddress("180540107173", "180540107173@darshan.ac.in"));
            message.Subject = "How you doin?";

            var builder = new BodyBuilder();
            builder.TextBody = @"Hey Alice,What are you up to this weekend? Monica is throwing one of her parties on Saturday and I was hoping you could make it.Will you be my +1?-- Joey";
            var image = builder.LinkedResources.Add(@"C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\wwwroot\img\become-a-pro-banner.png");
            image.ContentId = MimeUtils.GenerateMessageId();
            //Set the html version of the message text
            builder.HtmlBody = string.Format(@"<p>Hey Alice,
            <a href=""http://localhost:20179/ForgotPassword/Check"">
            Click</a><br><p>What are you up to this weekend? Monica is throwing one of her parties onSaturday and I was hoping you could make it.<br><p>Will you be my +1?<br><p>-- Joey<br><center><img src=""C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\wwwroot\img\become-a-pro-banner.png""></center>", image.ContentId);
            message.Body = builder.ToMessageBody();
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("aanalbtrivedi@gmail.com", "JAYMATAJI");
                client.Send(message);
                client.Disconnect(true);
                client.Dispose();
            }
            return View();
}
    }
}
