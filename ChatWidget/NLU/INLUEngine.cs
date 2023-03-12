using ChatWidget.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.NLU
{
    public interface INLUEngine
    {
        void Train(List<Utterance> utterances, int botId);
        void OnMessage(MessageContext context);
    }
}
