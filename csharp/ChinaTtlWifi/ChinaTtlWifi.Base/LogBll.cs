using CommonConfig;
using System;
using System.Collections.Generic;
using Wims.Common.MongoDBUtil;

namespace ChinaTtlWifi.Base
{
    public class LogBll : MongoUtil<Log>
    {
        private MongoUtil<LogHeartBeat> heartBeatBll = new MongoUtil<LogHeartBeat>();
        private MongoUtil<LogError> errorBll = new MongoUtil<LogError>();


        public static LogBll GenLogBll(string type)
        {
            return new LogBll(type);
        }

        private string type = "";
        private LogBll(string type)
        {
            this.type = type;
        }


        public void HeartBeat(string content)
        {
            LogHeartBeat log = new LogHeartBeat();
            log.Content = content;
            log.Author = this.type;
            log.CreateTime = DateTime.Now;
            log.Level = "heartbeat";
            Console.WriteLine("heartbeat \t" + content);
            this.heartBeatBll.Insert(log);
        }

        public void Info(string content)
        {
            this.WriteLog(content, "info");
        }
        public void Info(string content, string taskId)
        {
            this.WriteLog(content, "info", taskId);
        }

        public void Error(string content)
        {
            LogError log = new LogError();
            log.Content = content;
            log.Author = this.type;
            log.CreateTime = DateTime.Now;
            log.Level = "error";
            Console.WriteLine("error \t" + content);
            this.errorBll.Insert(log);

        }



        private void WriteLog(string content, string level)
        {
            Log log = new Log();
            log.Content = content;
            log.Author = this.type;
            log.CreateTime = DateTime.Now;
            log.Level = level;
            Console.WriteLine(level + "\t" + content);
            this.Insert(log);
        }
        private void WriteLog(string content, string level, string taskId)
        {
            Log log = new Log();
            log.TaskId = taskId;
            log.Content = content;
            log.Author = this.type;
            log.CreateTime = DateTime.Now;
            log.Level = level;
            Console.WriteLine(level + "\t" + content);
            this.Insert(log);
        }

        public List<Log> findLog(string taskId)
        {
            return GenLogBll(this.type).SelectBy("TaskId", taskId);
        }
    }
}
