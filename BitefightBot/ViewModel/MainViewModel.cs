using System;
using DotNetBrowser;
using DotNetBrowser.Events;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using BitefightBot.Enumerations;
using BitefightBot.Model;
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

        private void LogMessage(LoggerMessage obj)
        {
            LoggerText += obj.Message + Environment.NewLine;
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password) && !IsLoggedIn;
        }

        private void Login()
        {
            Loggr.Log($"Logging in user {Username} to {SelectedServer}");
            Javascripter.Login(Browser, SelectedServer, Username, Password);
            IsLoggedIn = true;
        }

        // TODO
        private bool CanStartPvp()
        {
            return true;
        }

        private void StartPvp()
        {
            throw new NotImplementedException();
        }

        // TODO
        private bool CanStartManHunt()
        {
            return true;
        }

        private void StartManHunt()
        {
            throw new NotImplementedException();
        }

        // TODO
        private bool CanStartGrotto()
        {
            return true;
        }

        private void StartGrotto()
        {
            throw new NotImplementedException();
        }

        // TODO
        private bool CanStartStory()
        {
            return true;
        }

        private void StartStory()
        {
        }

        #endregion METHODS

        #region CTOR

        public MainViewModel()
        {
            Messenger.Default.Register<FinishLoadingEventArgs>(this, PageLoaded);
            Messenger.Default.Register<LoggerMessage>(this, LogMessage);

            LoginCommand = new RelayCommand(Login, CanLogin);
            StartStoryCommand = new RelayCommand(StartStory, CanStartStory);
            StartGrottoCommand = new RelayCommand(StartGrotto, CanStartGrotto);
            StartManHuntCommand = new RelayCommand(StartManHunt, CanStartManHunt);
            StartPvpCommand = new RelayCommand(StartPvp, CanStartPvp);
        }

        #endregion CTOR

        #region COMMANDS

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand StartStoryCommand { get; set; }
        public RelayCommand StartGrottoCommand { get; set; }
        public RelayCommand StartManHuntCommand { get; set; }
        public RelayCommand StartPvpCommand { get; set; }

        #endregion COMMANDS

        #region PROPERTIES

        private string _url;
        private Browser _browser;
        private EServer _selectedServer;
        private bool _isLoggedIn;
        private string _loggerText;

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

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set => Set(() => IsLoggedIn, ref _isLoggedIn, value);
        }

        public string LoggerText
        {
            get => _loggerText;
            set => Set(() => LoggerText, ref _loggerText, value);
        }

        #endregion GETTERS/SETTERS
    }
}