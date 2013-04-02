using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace AppGest.Util
{
    /// <summary>
    /// Clase Wrapper de ILog para centralizar el logs de errores en unico punto
    /// </summary>
    public sealed class Logger : ILogger
    {
        private static ILog _log;
        private static readonly Logger _instancia = new Logger();
        private static object syncRoot = new Object();

        private Logger()
        {
        
        }

        public static Logger Inst
        {
            get
            {
                return _instancia;
            }
        }

        public ILog Log
        {
            private get
            {
                //Carga por demanda del log
                if(_log == null)
                {
                    //ThradSafe
                    lock (syncRoot)
                    {
                        _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    }
                }

                return _log;
            }
            set
            {
                //Set para unit test's
                _log = value;
            }
        }

        #region ILog

        public void Debug(object message, Exception exception)
        {
            this.Log.Debug(message, exception);
        }

        public void Debug(object message)
        {
            this.Log.Debug(message);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.Log.DebugFormat(provider, format, args);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            this.Log.DebugFormat(format, arg0, arg1, arg2);
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            this.Log.DebugFormat(format, arg0, arg1);
        }

        public void DebugFormat(string format, object arg0)
        {
            this.Log.DebugFormat(format, arg0);
        }

        public void DebugFormat(string format, params object[] args)
        {
            this.Log.DebugFormat(format, args);
        }

        public void Error(object message, Exception exception)
        {
            this.Log.Error(message, exception);
        }

        public void Error(object message)
        {
            this.Log.Error(message);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.Log.ErrorFormat(provider, format, args);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            this.Log.ErrorFormat(format, arg0, arg1, arg2);
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            this.Log.ErrorFormat(format, arg0, arg1);
        }

        public void ErrorFormat(string format, object arg0)
        {
            this.Log.ErrorFormat(format, arg0);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            this.Log.ErrorFormat(format, args);
        }

        public void Fatal(object message, Exception exception)
        {
            this.Log.Fatal(message, exception);
        }

        public void Fatal(object message)
        {
            this.Log.Fatal(message);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.Log.FatalFormat(provider, format, args);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            this.Log.FatalFormat(format, arg0, arg1, arg2);
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            this.Log.FatalFormat(format, arg0, arg1);
        }

        public void FatalFormat(string format, object arg0)
        {
            this.Log.FatalFormat(format, arg0);
        }

        public void FatalFormat(string format, params object[] args)
        {
            this.Log.FatalFormat(format, args);
        }

        public void Info(object message, Exception exception)
        {
            this.Log.Info(message, exception);
        }

        public void Info(object message)
        {
            this.Log.Info(message);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.Log.InfoFormat(provider, format, args);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            this.Log.InfoFormat(format, arg0, arg1, arg2);
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            this.Log.InfoFormat(format, arg0, arg1);
        }

        public void InfoFormat(string format, object arg0)
        {
            this.Log.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, params object[] args)
        {
            this.Log.InfoFormat(format, args);
        }

        public bool IsDebugEnabled
        {
            get { return this.Log.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return this.Log.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return this.Log.IsFatalEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return this.Log.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return this.Log.IsWarnEnabled; }
        }

        public void Warn(object message, Exception exception)
        {
            this.Log.Warn(message, exception);
        }

        public void Warn(object message)
        {
            this.Log.Warn(message);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.Log.WarnFormat(provider, format, args);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            this.Log.WarnFormat(format, arg0, arg1, arg2);
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            this.Log.WarnFormat(format, arg0, arg1);
        }

        public void WarnFormat(string format, object arg0)
        {
            this.Log.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, params object[] args)
        {
            this.Log.WarnFormat(format, args);
        }

        #endregion
    }

}
