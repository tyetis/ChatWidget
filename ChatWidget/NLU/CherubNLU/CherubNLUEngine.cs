using ChatWidget.Core;
using ChatWidget.Core.Message;
using CherubNLP;
using CherubNLP.Classify;
using CherubNLP.Tokenize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.NLU.CherubNLU
{
    public class CherubNLUEngine : INLUEngine
    {
        public Config Config { get; set; }

        public CherubNLUEngine(Config config)
        {
            Config = config;
        }

        public void OnMessage(MessageContext context)
        {
            if (context.UserMessage is UserTextMessage msg)
            {
                var result = Predict(msg.Text, context.Bot.Id);
                context.Session.Intent = result.Item1;
            }
        }

        public void Train(List<Utterance> utterances, int botId)
        {
            var classifier = GetClassifier($"{Config.DataPath}/Bot_{botId}");
            var tokenizer = GetTokenizer();
            var sentences = utterances.Select(n => new Sentence
            {
                Label = n.Intent,
                Words = tokenizer.Tokenize(n.Text)
            }).ToList();
            classifier.Train(sentences);
        }

        private Tuple<string, double> Predict(string utterance, int botId)
        {
            if (!Directory.Exists(Config.DataPath)) return null;
            var classifier = GetClassifier($"{Config.DataPath}/Bot_{botId}");
            var tokenizer = GetTokenizer();
            var result = classifier.Classify(new Sentence
            {
                Words = tokenizer.Tokenize(utterance)
            });
            var maxMatch = result.OrderByDescending(n => n.Item2).FirstOrDefault();
            if (maxMatch.Item2 < 0.20) return null;
            else return maxMatch;
        }

        private ClassifierFactory<SentenceFeatureExtractor> GetClassifier(string modelDir)
        {
            string metaModel = "intent.model";
            var options = new ClassifyOptions
            {
                ModelFilePath = Path.Combine(modelDir, metaModel),
                ModelDir = modelDir,
                ModelName = metaModel,
                Word2VecFilePath = null
            };
            var _classifier = new ClassifierFactory<SentenceFeatureExtractor>(options, SupportedLanguage.English);
            _classifier.GetClassifer("NaiveBayesClassifier");
            return _classifier;
        }
  
        private TokenizerFactory GetTokenizer()
        {
            var tokenizer = new TokenizerFactory(new TokenizationOptions
            {
                Pattern = RegexTokenizer.WHITE_SPACE
            }, SupportedLanguage.English);
            tokenizer.GetTokenizer<TreebankTokenizer>();
            return tokenizer;
        }
    }
}
