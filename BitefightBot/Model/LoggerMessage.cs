using GalaSoft.MvvmLight;

namespace BitefightBot.Model
{
    public class LoggerMessage : ObservableObject
    {
        private string _message;

        public string Message
        {
            get => _message;
            set => Set(() => Message, ref _message, value);
        }
    }
}