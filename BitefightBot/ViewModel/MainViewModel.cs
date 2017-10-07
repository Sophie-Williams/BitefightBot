using System.Collections.ObjectModel;
using DotNetBrowser;
using DotNetBrowser.Events;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using BitefightBot.Enumerations;
using BitefightBot.Service;

namespace BitefightBot.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region METHODS

        private void PageLoaded(FinishLoadingEventArgs args)
        {
            if (Browser == null)
            {
                Browser = args.Browser;
            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private void Login()
        {
            Javascripter.Login(Browser, Username, Password);
        }

        private void Test2()
        {
        }

        private void Test3()
        {
        }

        private void Test4()
        {
        }

        #endregion METHODS

        #region CTOR

        public MainViewModel()
        {
            Messenger.Default.Register<FinishLoadingEventArgs>(this, PageLoaded);

            LoginCommand = new RelayCommand(Login, CanLogin);
            Test2Command = new RelayCommand(Test2);
            Test3Command = new RelayCommand(Test3);
            Test4Command = new RelayCommand(Test4);
        }

        #endregion CTOR

        #region COMMANDS

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand Test2Command { get; set; }
        public RelayCommand Test3Command { get; set; }
        public RelayCommand Test4Command { get; set; }

        #endregion COMMANDS

        #region PROPERTIES

        private string _url;
        private Browser _browser;
        private EServer _selectedServer;

        private string _username;
        private string _password;

        #endregion PROPERTIES

        #region GETTERS/SETTERS

        public string Url
        {
            get => _url ?? (_url = "https://en.bitefight.gameforge.com/game");
            set => Set(() => Url, ref _url, value);
        }

        public Browser Browser
        {
            get => _browser;
            set => Set(() => Browser, ref _browser, value);
        }

        public EServer SelectedServer
        {
            get => _selectedServer;
            set
            {
                if (_selectedServer != value)
                {
                    Set(() => SelectedServer, ref _selectedServer, value);
                }
            }
        }

        public string Username
        {
            get => _username;
            set => Set(() => Username, ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => Set(() => Password, ref _password, value);
        }

        #endregion GETTERS/SETTERS
    }
}