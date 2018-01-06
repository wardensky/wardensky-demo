using ChinaTtlWifi.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ChinaTtlWifi.Bll
{
    /// <summary>
    /// 这个类写的不太好，文件多的时候可能效率比较低。
    /// </summary>
    public class XmlLoader
    {
        private string paramXml = "FlowConfig/params.xml";
        private string actionXml = "FlowConfig/actions.xml";
        private string channelXml = "FlowConfig/channels.xml";
        private string scriptXml = "FlowConfig/cases";
        private XmlLoader() { }
        private static XmlLoader inst;
        public static XmlLoader GetInst()
        {
            if (null == inst)
                inst = new XmlLoader();
            return inst;
        }
        public List<Case> ScriptList { get; set; }
        public List<Params> ParamsList { get; set; }
        public List<Channel> ChannelList { get; set; }

        public List<AAction> ActionList { get; set; }
        public List<Case> Load()
        {

            this.LoadChannels();
            this.LoadActions();
            this.LoadParams();
            this.LoadCases();

            return this.ScriptList;
        }

        public void SaveChannels()
        {
            var xDoc = new XDocument(new XElement("channels"));
            foreach (var inst in this.ChannelList)
            {
                XElement ele = new XElement("channel", new XAttribute("id", inst.Id)
                    , new XAttribute("agentName", inst.AgentName)
                    , new XAttribute("description", inst.Description));
                xDoc.Root.Add(ele);
            }

            xDoc.Save(this.channelXml);
        }
        public void SaveActions()
        {
            var xDoc = new XDocument(new XElement("actions"));
            foreach (var inst in this.ActionList)
            {
                XElement ele1 = new XElement("action", new XAttribute("id", inst.Id)
                    , new XAttribute("name", inst.Name)
                    , new XAttribute("waitresponse", inst.WaitResponse)
                     , new XAttribute("breakOnFail", inst.BreakOnFail));
                XElement ele2 = new XElement("predelay", inst.Predelay);
                XElement ele3 = new XElement("command", inst.Command);
                XElement ele4 = new XElement("postdelay", inst.Postdelay);
                ele1.Add(ele2);
                ele1.Add(ele3);
                ele1.Add(ele4);
                xDoc.Root.Add(ele1);
            }

            xDoc.Save(this.actionXml);
        }
        public void SaveParams()
        {
            var xDoc = new XDocument(new XElement("ArrayOfParams"));
            foreach (var inst in this.ParamsList)
            {
                XElement ele1 = new XElement("params", new XAttribute("id", inst.Id), new XAttribute("name", inst.Name), new XAttribute("desc", inst.Desc));
                foreach (var inst1 in inst.ParamList)
                {
                    XElement ele2 = new XElement("param", new XAttribute("id", inst1.Id), new XAttribute("key", inst1.Key), new XAttribute("value", inst1.Value));
                    ele1.Add(ele2);
                }
                xDoc.Root.Add(ele1);
            }

            xDoc.Save(this.paramXml);
        }
        public void AddScript(Case entity)
        {

        }

        public void DeleteScript(Case entity)
        {

        }
        private void LoadParams()
        {
            this.ParamsList = new List<Params>();
            XElement xe = XElement.Load(paramXml);
            foreach (var item in xe.Elements("params"))
            {
                Params Params = new Params();
                Params.Id = item.Attribute("id").Value;
                Params.Name = item.Attribute("name").Value;
                Params.Desc = item.Attribute("desc").Value;
                Params.ParamList = new List<Param>();
                foreach (var param in item.Descendants("param"))
                {
                    Param p = new Param();
                    p.Id = param.Attribute("id").Value;
                    p.Key = param.Attribute("key").Value;
                    p.Value = param.Attribute("value").Value;
                    Params.ParamList.Add(p);
                }
                ParamsList.Add(Params);
            }
        }

        private void LoadChannels()
        {
            ChannelList = new List<Channel>();
            XElement xe = XElement.Load(channelXml);
            foreach (var item in xe.Elements("channel"))
            {
                Channel channel = new Channel();
                channel.Id = item.Attribute("id").Value;
                channel.AgentName = item.Attribute("agentName").Value;
                channel.Description = item.Attribute("description").Value;
                ChannelList.Add(channel);
            }
        }

        private void LoadActions()
        {
            this.ActionList = new List<AAction>();


            ActionList = new List<AAction>();
            XElement xe = XElement.Load(actionXml);
            foreach (var inst in xe.Descendants("action"))
            {
                AAction Action = new AAction();
                Action.Id = inst.Attribute("id").Value;
                Action.Name = GetAttributeValue(inst.Attribute("name"));
                string waitResponseString = GetAttributeValue(inst.Attribute("waitresponse"));
                if (!string.IsNullOrEmpty(waitResponseString))
                {
                    Action.WaitResponse = bool.Parse(waitResponseString);
                }
                string breakOnFailString = GetAttributeValue(inst.Attribute("breakOnFail"));
                if (!string.IsNullOrEmpty(breakOnFailString))
                {
                    Action.BreakOnFail = bool.Parse(breakOnFailString);
                }
                string predelayString = GetElementValue(inst.Element("predelay"));
                if (!string.IsNullOrEmpty(predelayString))
                {
                    Action.Predelay = int.Parse(predelayString);
                }


                string postdelayString = GetElementValue(inst.Element("postdelay"));
                if (!string.IsNullOrEmpty(postdelayString))
                {
                    Action.Postdelay = int.Parse(postdelayString);
                }

                Action.Command = GetElementValue(inst.Element("command"));
                ActionList.Add(Action);
            }
        }

        private void LoadCases()
        {
            this.ScriptList = new List<Case>();

            DirectoryInfo di = new DirectoryInfo(scriptXml);
            if (di.Exists)
            {
                foreach (DirectoryInfo inst in di.GetDirectories())
                {
                    string xmlPath = inst.FullName + @"\case.xml";
                    if (File.Exists(xmlPath))
                    {
                        Case TestCase = LoadScript(xmlPath);
                        this.ScriptList.Add(TestCase);
                    }
                }
            }
        }

        private Case LoadScript(string XmlPath)
        {
            XElement xe = XElement.Load(XmlPath);
            Case TestCase = new Case();
            TestCase.StepList = new List<Step>();
            TestCase.Id = xe.Attribute("id").Value;
            TestCase.Name = GetAttributeValue(xe.Attribute("name"));
            TestCase.Desc = GetAttributeValue(xe.Attribute("desc"));
            TestCase.Limit = GetAttributeValue(xe.Attribute("limit"));
            foreach (var inst in xe.Elements("step"))
            {
                Step step = new Step();
                step.Id = Convert.ToInt32(GetAttributeValue(inst.Attribute("id")));
                step.Name = GetAttributeValue(inst.Attribute("name"));
                string actionId = GetAttributeValue(inst.Attribute("action"));
                step.StepAction = this.ActionList.Where(s => s != null && s.Id == actionId).FirstOrDefault();
                string paramsId = GetAttributeValue(inst.Attribute("paramsId"));
                step.StepParams = this.ParamsList.Where(s => paramsId != null && s.Id == paramsId).FirstOrDefault();
                step.Conditon = GetAttributeValue(inst.Attribute("condition"));
                step.NextStepId = Convert.ToInt32(GetAttributeValue(inst.Attribute("nextStep")));
                if (step.Id != 99)
                {
                    var channel = this.ChannelList.Where(a => a.Id == GetAttributeValue(inst.Attribute("channel"))).First();
                    if (channel != null)
                    {
                        step.AgentName = channel.AgentName;
                    }
                    else
                    {
                        Console.WriteLine("case 找不到 channel");
                    }
                }
                TestCase.StepList.Add(step);
            }
            return TestCase;
        }
        private string GetAttributeValue(XAttribute attribute)
        {
            if (attribute != null)
            {
                return attribute.Value;
            }
            return null;
        }

        private string GetElementValue(XElement element)
        {
            if (element != null)
            {
                return element.Value;
            }
            return null;
        }
    }
}
