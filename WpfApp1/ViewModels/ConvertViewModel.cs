using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            if (!decimal.TryParse(AmountToConvert, out decimal amount))
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            if (SelectedFromCurrency == null || SelectedToCurrency == null)
            {
                MessageBox.Show("Please select currencies.");
                return;
            }

            decimal convertedAmount = (amount / SelectedFromCurrency.Price) * SelectedToCurrency.Price;
            MessageBox.Show($"{AmountToConvert} {SelectedFromCurrency.Symbol} = {convertedAmount} {SelectedToCurrency.Symbol}");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
