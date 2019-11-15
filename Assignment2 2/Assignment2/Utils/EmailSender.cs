using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Assignment2.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String toAddRecipients, String subject, String contents, HttpPostedFileBase postedFile)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var msg = new SendGridMessage();
            var htmlContent = "<p>" + contents + "</p>";
            msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            if (postedFile != null)
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(postedFile.InputStream))
                {
                    fileData = binaryReader.ReadBytes(postedFile.ContentLength);
                }
                var fileString = Convert.ToBase64String(fileData);
                msg.AddAttachment(postedFile.FileName, fileString);
            }
            var response = client.SendEmailAsync(msg);

            if (toAddRecipients != null)
            {
                String[] recipientsInfo = toAddRecipients.Split(',');
                List<String> recipientsList = recipientsInfo.ToList();

                var tos = recipientsList.Select(x => MailHelper.StringToEmailAddress(x)).ToList();
                
                msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, plainTextContent, htmlContent);
                if (postedFile != null)
                {
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(postedFile.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(postedFile.ContentLength);
                    }
                    var fileString = Convert.ToBase64String(fileData);
                    msg.AddAttachment(postedFile.FileName, fileString);
                }
                response = client.SendEmailAsync(msg);
            }
        }

    }
}