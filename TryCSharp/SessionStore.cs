using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Roslyn.Scripting;

namespace TryCSharp
{
    /// <summary>
    /// Static class which is reponsible for storing and retrieving one Roslyn session.
    /// </summary>
    public static class SessionStore
    {
        private static ConcurrentDictionary<string, Session> SessionHolder = new ConcurrentDictionary<string, Session>();


        public static Session GetSession(string key)
        {
            return SessionHolder.GetOrAdd(key, Session.Create());
        }
    }
}