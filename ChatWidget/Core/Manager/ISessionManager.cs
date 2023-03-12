using System;
using System.Collections.Generic;
using System.Text;

namespace ChatWidget.Core.Manager
{
    public interface ISessionManager
    {
        string ActiveFlowId { get; set; }
        string ActiveNodeId { get; set; }
        string Intent { get; set; }
        Dictionary<string, string> Slots { get; set; }
        void Set<T>(string key, T value);
        T Get<T>(string key);
        object Get(string key);
        bool Remove(string key);
        void Clear();
    }
}
