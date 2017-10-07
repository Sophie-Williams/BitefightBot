using GalaSoft.MvvmLight;

namespace BitefightBot.Model
{
    public class ValueDescription : ObservableObject
    {
        private object _value;
        private object _description;

        public object Value
        {
            get => _value;
            set => Set(() => Value, ref _value, value);
        }

        public object Description
        {
            get => _description;
            set => Set(() => Description, ref _description, value);
        }
    }
}