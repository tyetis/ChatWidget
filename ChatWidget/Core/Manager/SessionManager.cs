using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ChatWidget.Core.Manager
{
    public static class Global
    {
        public static IMemoryCache Cache = new MemoryCache(new MemoryCacheOptions());
    }

    public class SessionManager: ISessionManager
    {
        ConcurrentDictionary<string, object> SessionDictionary { get; set; }

        public SessionManager(Guid UserId)
        {
            SessionDictionary = Global.Cache.GetOrCreate(UserId, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20);
                entry.AddExpirationToken(new CancellationChangeToken(new CancellationTokenSource(TimeSpan.FromMinutes(20)).Token));
                entry.RegisterPostEvictionCallback(ExpiredCallBack);
                return new ConcurrentDictionary<string, object>();
            });
        }
        public string ActiveFlowId
        {
            get => SessionDictionary.GetOrAdd("ActiveFlowId", "MainFlow").ToString();
            set => SessionDictionary.AddOrUpdate("ActiveFlowId", value, (key, old) => value);
        }
        public string ActiveNodeId
        {
            get => SessionDictionary.GetOrAdd("ActiveNodeId", string.Empty).ToString();
            set => SessionDictionary.AddOrUpdate("ActiveNodeId", value, (key, old) => value);
        }
        public string Intent
        {
            get => SessionDictionary.GetOrAdd("Intent", string.Empty)?.ToString();
            set => SessionDictionary.AddOrUpdate("Intent", value, (key, old) => value);
        }
        public Dictionary<string, string> Slots
        {
            get => (Dictionary<string, string>)SessionDictionary.GetOrAdd("Slots", new Dictionary<string, string>());
            set => SessionDictionary.AddOrUpdate("Slots", value, (key, old) => value);
        }
        public void Set<T>(string key, T value) => SessionDictionary[key] = value;
        public T Get<T>(string key) => (T)SessionDictionary.GetValueOrDefault(key);
        public object Get(string key) => SessionDictionary.GetValueOrDefault(key);
        public bool Remove(string key) => SessionDictionary.Remove(key, out object value);
        public void Clear()
        {
            SessionDictionary.Clear();
        }
        public void ExpiredCallBack(object key, object value, EvictionReason reason, object substate)
        {

        }
    }
}