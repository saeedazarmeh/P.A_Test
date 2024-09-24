using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmsIrRestfulNetCore;

namespace P.A_Service.SMS
{
    public class SMSService
    {
        public static void SendVerfiedcode(string phoneNumber, string code)
        {
            Token smsToken = new Token();
            var token = smsToken.GetToken("5dffc9923e9763f461c6df18", "@Fartakecu09129176076");


            var ultraFastSend = new UltraFastSend()
            {
                Mobile = Convert.ToInt64(phoneNumber),
                TemplateId = 76051,
                ParameterArray = new List<UltraFastParameters>()
                {
                    new UltraFastParameters()
                    {
                        Parameter = "VerificationCode" , ParameterValue = code,
                    },
                }.ToArray()

            };

            UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(token, ultraFastSend);

            if (ultraFastSendRespone.IsSuccessful)
            {

            }
            else
            {

            }
        }
        public static void Sendsuccessfullymessage(string phoneNumber, string firstName, string lasttName)
        {
            Token smsToken = new Token();
            var token = smsToken.GetToken("5dffc9923e9763f461c6df18", "@Fartakecu09129176076");


            var ultraFastSend = new UltraFastSend()
            {
                Mobile = Convert.ToInt64(phoneNumber),
                TemplateId = 76053,
                ParameterArray = new List<UltraFastParameters>()
                {
                    new UltraFastParameters()
                    {
                        Parameter = "fullName" , ParameterValue =firstName +" " +lasttName
                    },
                }.ToArray()

            };

            UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(token, ultraFastSend);

            if (ultraFastSendRespone.IsSuccessful)
            {

            }
            else
            {

            }
        }
    }
}
