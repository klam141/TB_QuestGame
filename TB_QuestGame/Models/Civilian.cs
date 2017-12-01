using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Civilian : Npc, ISpeak
    {
        public override int Id { get; set; }

        public override string Description { get; set; }

        public List<string> Messages { get; set; }

        public int CurrentMessageNum { get; set; }

        public string Speak()
        {
            if(Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return base.Greeting();
            }
        }

        private string GetMessage()
        {
            string message = Messages[CurrentMessageNum];

            //goes through the messages until you reach the last message
            //repeats the last message after that
            if(CurrentMessageNum < (Messages.Count() - 1)) CurrentMessageNum++;

            return message;
        }
    }
}
