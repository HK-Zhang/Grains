using log4net.Layout.Pattern;
using System;
using System.IO;
using log4net.Core;
using log4net.Layout;

namespace CSDemo
{
    public class LogHelper
    {
        //log4net日志专用
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
        /// <summary>
        /// 普通的文件记录日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                //loginfo.Info(info);
                loginfo.Info(new Message {SuportCode = "abc", MessageBody = "body"});
            }
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        public static void WriteLog(string info, Exception se)
        {
            if (logerror.IsErrorEnabled)
            {
                //logerror.Error(info, se);
                logerror.Error(new Message{SuportCode="abc", MessageBody="body"}, se);


            }
        }
    }

    public class Message
    {
        public string SuportCode { get; set; }

        public string MessageBody { get; set; }

        public LoggingEvent LogEvent { get; set; }

    }

    public class SuportCodePatternConvert : PatternLayoutConverter
    {

        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            var LogMessage = loggingEvent.MessageObject as Message;
            if (LogMessage != null)
                writer.Write(LogMessage.SuportCode);
        }
    }

    public class CsPocLayout : PatternLayout
    {
        public CsPocLayout()
        {
            this.AddConverter("SuportCode", typeof(SuportCodePatternConvert));
        }
    }

    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
            IgnoresException = false;
        }

        public JsonLayout()
        {
            //this.AddConverter("SuportCode", typeof(SuportCodePatternConvert));
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {

            //loggingEvent.Properties["SuportCode"] = (loggingEvent.MessageObject as Message).SuportCode;
            //loggingEvent.Properties["MessageBody"] = (loggingEvent.MessageObject as Message).MessageBody;
            var obj = loggingEvent.MessageObject as Message;
            obj.LogEvent = loggingEvent;

            writer.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }
    }
}
