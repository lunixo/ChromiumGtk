using System;
using Lunixo.ChromiumGtk.Handlers;
using Xilium.CefGlue;

namespace Lunixo.ChromiumGtk.Core
{
    public class WebClient : CefClient
    {
        public static bool DumpProcessMessages { get; set; }
        private readonly LifeSpanHandler _lifeSpanHandler;
        private readonly DisplayHandler _displayHandler;
        private readonly LoadHandler _loadHandler;

        public WebClient(WebBrowser core)
        {
            _lifeSpanHandler = new LifeSpanHandler(core);
            _displayHandler = new DisplayHandler(core);
            _loadHandler = new LoadHandler(core);
        }

        protected override CefLifeSpanHandler GetLifeSpanHandler()
        {
            return _lifeSpanHandler;
        }

        protected override CefDisplayHandler GetDisplayHandler()
        {
            return _displayHandler;
        }

        protected override CefLoadHandler GetLoadHandler()
        {
            return _loadHandler;
        }

        protected override bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
        {
            if (DumpProcessMessages)
            {
                Console.WriteLine("Client::OnProcessMessageReceived: SourceProcess={0}", sourceProcess);
                Console.WriteLine("Message Name={0} IsValid={1} IsReadOnly={2}", message.Name, message.IsValid, message.IsReadOnly);
                var arguments = message.Arguments;
                for (var i = 0; i < arguments.Count; i++)
                {
                    var type = arguments.GetValueType(i);
                    object value;
                    switch (type)
                    {
                        case CefValueType.Null: value = null; break;
                        case CefValueType.String: value = arguments.GetString(i); break;
                        case CefValueType.Int: value = arguments.GetInt(i); break;
                        case CefValueType.Double: value = arguments.GetDouble(i); break;
                        case CefValueType.Bool: value = arguments.GetBool(i); break;
                        default: value = null; break;
                    }

                    Console.WriteLine("  [{0}] ({1}) = {2}", i, type, value);
                }
            }
            
            return false;
        }
    }
}
