using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class EventDemo
    {
        public static void RunDemo()
        {
            SMS sms = new SMS();
            SmsReceiver r = new SmsReceiver(sms);
            sms.SendSms("188288388","Hello world");
        }
    }

    public class SMS
    {
        public EventHandler<SmsEventArgs> SmsEvent = (o, e) => { };
        //public event EventHandler SmsEvent2;
        public EventHandler SmsEvent2;

        protected virtual void OnSmsEvent(SmsEventArgs e)
        {
            //EventHandler<SmsEventArgs> handler = this.SmsEvent;
            //if (handler != null)
            //{
            //    handler(this, e);
            //}

            this.SmsEvent(this, e);

        }

        protected virtual void OnSmsEvent2()
        {
            EventHandler handler = this.SmsEvent2;

            if (handler != null)
            {
                handler(this,null);
            }
        }


        public void SendSms(string phone, string message)
        {
            SmsEventArgs e = new SmsEventArgs();
            e.Message = message;
            e.ToPhone = phone;
            OnSmsEvent(e);
        }
    }

    public class SmsEventArgs:EventArgs
    {
        public string ToPhone { get; set; }
        public string Message { get; set; }
    }

    public class SmsReceiver
    {
        public SmsReceiver(SMS sms)
        {
            sms.SmsEvent += new EventHandler<SmsEventArgs>(sms_SmsEvent);
        }

        void sms_SmsEvent(object sender, SmsEventArgs e)
        {
            Console.WriteLine(e.ToPhone + ":" + e.Message);
        }
 
    }
}
