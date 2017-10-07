using System;
using BitefightBot.Model;
using GalaSoft.MvvmLight.Messaging;

namespace BitefightBot.Service
{
    /// <summary>
    /// Logger
    /// </summary>
    public static class Loggr
    {
        public static void Log(string text)
        {
            Messenger.Default.Send(new LoggerMessage()
            {
                Message = DateTime.Now.ToString("t") + " - " + text
            });
        }
    }
}