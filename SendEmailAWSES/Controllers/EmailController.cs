using Amazon;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmailAWSES.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(string name, string subject, string message, string email )
        {
            string receiver = "pruebaawsses001@gmail.com";
            Amazon.SimpleEmail.AmazonSimpleEmailServiceClient sesClient =
                new Amazon.SimpleEmail.AmazonSimpleEmailServiceClient(RegionEndpoint.USEast1);
            Amazon.SimpleEmail.Model.SendEmailRequest sendEmailRequest =
                new Amazon.SimpleEmail.Model.SendEmailRequest()
                {
                    Destination = new Amazon.SimpleEmail.Model.Destination()
                    {
                        ToAddresses = new List<string>() { receiver }
                    },
                    Message = new Amazon.SimpleEmail.Model.Message
                    {
                        Body = new Amazon.SimpleEmail.Model.Body
                        {
                            Html = new Amazon.SimpleEmail.Model.Content
                            {
                                Charset ="UTF-8",
                                Data= "El contacto: " + name + ". Ha dejado el siguiente mensaje: " + message
                            },
                            Text = new Amazon.SimpleEmail.Model.Content
                            {
                                Charset = "UTF-8",
                                Data = "Contacto de: " + name + "\n" + message
                            },
                        },
                        Subject = new Amazon.SimpleEmail.Model.Content
                        {
                            Charset = "UTF-8",
                            Data ="Email de contacto: " + subject

                        }
                    },
                    Source= "pruebaawsses001@gmail.com"
                };
            var res = sesClient.SendEmailAsync(sendEmailRequest);
            Task.WaitAll(res);
            string messageI = res.Result.MessageId;
            return RedirectToAction("Confirmation");
        }
        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
