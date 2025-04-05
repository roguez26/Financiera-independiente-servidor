using Independiente.Commands;
using Independiente.Model;
using Independiente.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Independiente.ViewModel
{
    public class FinancialDataViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Bank> BanksList { get; set; }
        private Bank _selectedBankCharge;

        private Bank _selectedBankDeposit;

        public FinancialData FinancialData { get; set; }

        private bool _isReadOnlyMode { get; set; }

        public bool _isViewMode { get; set; }

        public bool _isUpdateMode { set; get; }

        public PageMode Mode { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler RequestClose;
        public bool IsNextSuccessful;

        


        public ICommand NextCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public FinancialDataViewModel()
        {
            BanksList = new ObservableCollection<Bank>
                {
                    new Bank { BankId = 1, Name = "Banco A" },
                    new Bank { BankId = 2, Name = "Banco B" },
                    new Bank { BankId = 3, Name = "Banco C" },
                };
            NextCommand = new RelayCommand(Next, CanNext);
            EditCommand = new RelayCommand(Edit, CanNext);
            CancelCommand = new RelayCommand(Cancel, CanNext);
            SaveCommand = new RelayCommand(Save, CanNext);
            FinancialData = new FinancialData();

        }




        public void SwitchMode(PageMode mode)
        {
            switch (mode)
            {
                case PageMode.Registration:
                    IsReadOnlyMode = true;
                    IsUpdateMode = false;
                    IsViewMode = false;
                    break;
                case PageMode.Update:
                    IsReadOnlyMode = true;
                    IsUpdateMode = true;
                    IsViewMode = false;
                    break;
                case PageMode.View:
                    IsReadOnlyMode = true;
                    IsUpdateMode = false;
                    IsViewMode = true;
                    break;
            }
        }
        private void Next(object obj)
        {
            if (FinancialData != null)
            {
                IsNextSuccessful = true;
                RequestClose?.Invoke(this, EventArgs.Empty);
            }
            else
            {

                IDialogService dialogService = new DialogService();
                dialogService.Dismiss("gg");
                IsNextSuccessful = false;
            }

        }

        private void Cancel(object obj)
        {
            Console.WriteLine("cancelaste");
            SwitchMode(PageMode.View);
        }

        private void Save(object obj)
        {
            Console.WriteLine("guardaste");
            SwitchMode(PageMode.View);
        }

        private void Edit(object obj)
        {
            Console.WriteLine("vas a editar");

            SwitchMode(PageMode.Update);
        }

        private bool CanNext(object obj)
        {
            return true;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsReadOnlyMode
        {
            get => _isReadOnlyMode;
            set
            {
                _isReadOnlyMode = value;
                OnPropertyChanged(nameof(IsReadOnlyMode));
            }
        }

        public bool IsViewMode
        {
            get => _isViewMode;
            set
            {
                _isViewMode = value;
                OnPropertyChanged(nameof(IsViewMode));
            }
        }

        public bool IsUpdateMode
        {
            get => _isUpdateMode;
            set
            {
                _isUpdateMode = value;
                OnPropertyChanged(nameof(IsUpdateMode));
            }
        }


        public Bank SelectedBankCharge
        {
            get => _selectedBankCharge;
            set
            {
                _selectedBankCharge = value;
                OnPropertyChanged(nameof(SelectedBankCharge));
            }
        }

        public Bank SelectedBankDeposit
        {
            get => _selectedBankDeposit;
            set
            {
                _selectedBankDeposit = value;
                OnPropertyChanged(nameof(SelectedBankDeposit));
            }
        }
    }
}
