using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitefightBot.Service
{
    public static class Logger
    {
        public static string Text { get; private set; }

        public static void Log(string text)
        {
            Text += text;
        }
    }
}