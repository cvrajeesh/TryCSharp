using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using Roslyn.Scripting.CSharp;

namespace TryCSharp
{
    public class ScriptExecutionService
    {
        private static ScriptEngine _scriptEngineInstance = null;
        private static readonly object syncRoot = new object();

        public string Execute(string sessionId, string statement)
        {
            var engine = this.GetInstance();
            var session = SessionStore.GetSession(sessionId);
            var oldOut = Console.Out;
            var sw = new StringWriter();
            Console.SetOut(sw);
            try
            {
                engine.Execute(statement, session);
            }
            catch (Exception exception)
            {
                sw.WriteLine(exception.Message);
            }
            return sw.ToString();
        }

        private ScriptEngine GetInstance()
        {

            if (_scriptEngineInstance == null)
            {
                lock (syncRoot)
                {
                    if (_scriptEngineInstance == null)
                    {
                        _scriptEngineInstance = new ScriptEngine();
                    }
                }
            }

            return _scriptEngineInstance;
        }
    }
}