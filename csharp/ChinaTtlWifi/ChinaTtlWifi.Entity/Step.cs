
namespace ChinaTtlWifi.Entity
{
    public class Step
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AAction StepAction { get; set; }

        public Params StepParams { get; set; }

        public string AgentName { get; set; }

        public string Conditon { get; set; }
        public int NextStepId { get; set; }
        public string StepStatus { get; set; }

        public static Step GenEndStep()
        {
            Step ret = new Step();
            ret.Id = 99;
            ret.Name = "End";
            return ret;

        }
    }
}
