using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Utilities;

namespace WpfApp1.ViewModels
{
    public class ConvertViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Currency> Currencies { get; set; }

        private string _amountToConvert;
        public string AmountToConvert
        {
            get { return _amountToConvert; }
            set
            {
                _amountToConvert = value;
                OnPropertyChanged(nameof(AmountToConvert));
            }
        }

        private Currency _selectedFromCurrency;
        public Currency SelectedFromCurrency
        {
            get { return _selectedFromCurrency; }
            set
            {
                _selectedFromCurrency = value;
                OnPropertyChanged(nameof(SelectedFromCurrency));
            }
        }

        private Currency _selectedToCurrency;
        public Currency SelectedToCurrency
        {
            get { return _selectedToCurrency; }
            set
            {
                _selectedToCurrency = value;
                OnPropertyChanged(nameof(SelectedToCurrency));
            }
        }

        public ICommand ConvertCommand { get; set; }

        public ConvertViewModel(ObservableCollection<Currency> currencies)
        {
            Currencies = currencies;

            ConvertCommand = new RelayCommand(Convert);
        }

        private void Convert(object parameter)
        {
            // Perform conversion logic here
            double amount;
            if (!double.TryParse(AmountToConvert, out amount))
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            // Assume a simple conversion rate of 1:1 for demonstration
            double convertedAmount = amount;
            MessageBox.Show($"{AmountToConvert} {SelectedFromCurrency.Symbol} = {convertedAmount} {SelectedToCurrency.Symbol}");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
