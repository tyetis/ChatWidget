using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.NLU.RasaNLU
{
    class RasaResponseModel
    {
        public string text { get; set; }
        public Intent intent { get; set; }
        public Entity[] entities { get; set; }
        public int[][] text_tokens { get; set; }
        public Intent_Ranking[] intent_ranking { get; set; }
    }

    public class Rootobject
    {
    }

    public class Intent
    {
        public string name { get; set; }
        public float confidence { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public float confidence_entity { get; set; }
        public string role { get; set; }
        public float confidence_role { get; set; }
        public string value { get; set; }
        public string extractor { get; set; }
    }

    public class Intent_Ranking
    {
        public string name { get; set; }
        public float confidence { get; set; }
    }
}
