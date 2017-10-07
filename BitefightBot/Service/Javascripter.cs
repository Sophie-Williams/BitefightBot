using System;
using System.Text.RegularExpressions;
using BitefightBot.Enumerations;
using BitefightBot.Util;
using DotNetBrowser;

namespace BitefightBot.Service
{
    /// <summary>
    /// Used to inject/execute javascript into the web page.
    /// </summary>
    public static class Javascripter
    {
        /// <summary>
        /// Login to the game.
        /// </summary>
        /// <param name="browser">Browser instance</param>
        /// <param name="server">Selected server</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        public static void Login(Browser browser, EServer server, string username, string password)
        {
            string serverUrl;
            string formServerActionUrl;

            switch (server)
            {
                case EServer.County3:
                    serverUrl = Properties.Resources.UrlCounty3;
                    formServerActionUrl = Properties.Resources.UrlFormCounty3;
                    break;
                case EServer.County9:
                    serverUrl = Properties.Resources.UrlCounty9;
                    formServerActionUrl = Properties.Resources.UrlFormCounty9;
                    break;
                case EServer.County19:
                    serverUrl = Properties.Resources.UrlCounty19;
                    formServerActionUrl = Properties.Resources.UrlFormCounty19;
                    break;
                case EServer.County20:
                    serverUrl = Properties.Resources.UrlCounty20;
                    formServerActionUrl = Properties.Resources.UrlFormCounty20;
                    break;
                case EServer.County21:
                    serverUrl = Properties.Resources.UrlCounty21;
                    formServerActionUrl = Properties.Resources.UrlFormCounty21;
                    break;
                case EServer.County22:
                    serverUrl = Properties.Resources.UrlCounty22;
                    formServerActionUrl = Properties.Resources.UrlFormCounty22;
                    break;
                case EServer.County202:
                    serverUrl = Properties.Resources.UrlCounty202;
                    formServerActionUrl = Properties.Resources.UrlFormCounty202;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(server), server, null);
            }

            var loginScript = FileUtil.ReadFileContent(DirectoryService.BaseDir() + "/Javascript/Homepage/Login.js");

            loginScript = Regex.Replace(loginScript, Properties.Resources.HashSelectedCounty, serverUrl);
            loginScript = Regex.Replace(loginScript, Properties.Resources.HashFormServerActionUrl, formServerActionUrl);
            loginScript = Regex.Replace(loginScript, Properties.Resources.HashUsername, username);
            loginScript = Regex.Replace(loginScript, Properties.Resources.HashPassword, password);

            Execute(browser, loginScript);
        }

        public static void Execute(Browser browser, string javascript)
        {
            browser.ExecuteJavaScript(javascript);
        }
    }
}