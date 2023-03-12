using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.NLU.NodeNLU
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Classification
    {
        public string intent { get; set; }
        public int score { get; set; }
    }

    public class Entity
    {
        public int start { get; set; }
        public int end { get; set; }
        public int len { get; set; }
        public int levenshtein { get; set; }
        public double accuracy { get; set; }
        public string entity { get; set; }
        public string type { get; set; }
        public string option { get; set; }
        public string sourceText { get; set; }
        public string utteranceText { get; set; }
        public Resolution resolution { get; set; }
    }

    public class NluAnswer
    {
        public List<Classification> classifications { get; set; }
    }

    public class Resolution
    {
        public List<Value> values { get; set; }
        public string type { get; set; }
        public string timex { get; set; }
        public string strValue { get; set; }
        public DateTime date { get; set; }
    }

    public class ResponseModel
    {
        public string locale { get; set; }
        public string utterance { get; set; }
        public bool languageGuessed { get; set; }
        public string localeIso2 { get; set; }
        public string language { get; set; }
        public NluAnswer nluAnswer { get; set; }
        public List<Classification> classifications { get; set; }
        public string intent { get; set; }
        public int score { get; set; }
        public string domain { get; set; }
        public List<SourceEntity> sourceEntities { get; set; }
        public List<Entity> entities { get; set; }
        public List<object> answers { get; set; }
        public List<object> actions { get; set; }
        public Sentiment sentiment { get; set; }
    }

    public class Sentiment
    {
        public double score { get; set; }
        public int numWords { get; set; }
        public int numHits { get; set; }
        public double average { get; set; }
        public string type { get; set; }
        public string locale { get; set; }
        public string vote { get; set; }
    }

    public class SourceEntity
    {
        public int start { get; set; }
        public int end { get; set; }
        public Resolution resolution { get; set; }
        public string text { get; set; }
        public string typeName { get; set; }
    }

    public class Value
    {
        public string timex { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }
}
