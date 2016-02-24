using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MEPLibrary {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MEP : IMEP {
        public void sendEmail(string toAddress) {
            try {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("yklouk@gmail.com");
                mail.To.Add(toAddress);
                mail.Subject = "Welcome to Course";
                mail.Body = "Hi, we heartly welcome you to new learnings.";

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("yklouk@gmail.com", "05797263681");

                client.Send(mail);

                //once email has been successful sent out.
                IMEPCallBack cb = OperationContext.Current.GetCallbackChannel<IMEPCallBack>();
                cb.SendEmailCallBack(toAddress);
            } catch (Exception Ex) {
                throw new FaultException(Ex.Message);
            }
        }
    }


}
