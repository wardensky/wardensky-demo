using Apache.NMS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Wims.Common.ActiveMQUtil
{
    public class MqConsumerBase : MqBase
    {

        protected MqConsumerBase()
            : base()
        {
        }

        protected string name = "";
        protected string filter = "";
        protected Action<IMessage> listener = null;
        public static Dictionary<string, object> ReadMapFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }
        public static T ReadFromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }


    }
}
