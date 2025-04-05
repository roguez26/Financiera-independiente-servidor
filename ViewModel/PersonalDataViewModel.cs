using Independiente.Commands;
using Independiente.Model;
using Independiente.Services;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Independiente.ViewModel
{
    public enum RegistrationType
    {
        Client,
        Employee
    }

    public enum PageMode
    {
        Registration,
        View,
        Update
    }

    public class PersonalDataViewModel : INotifyPropertyChanged
    {
        public PersonalData PersonalData { get; set; }
        public RegistrationType Type { get; set; }

        private List<string> _statesList;
        private string _selectedState;

        private bool _isReadOnlyMode {  get; set; }

        private bool _isViewMode { get; set; }

        private bool _isUpdateMode { set; get; }

        public PageMode Mode { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler RequestClose;

        public ICommand NextCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public bool IsNextSuccessful;

        public PersonalDataViewModel() {
            NextCommand = new RelayCommand(Next, CanNext);
            EditCommand = new RelayCommand(Edit, CanNext);
            CancelCommand = new RelayCommand(Cancel, CanNext);
            SaveCommand = new RelayCommand(Save, CanNext);
            PersonalData = new PersonalData();
            LoadStates();
            IsNextSuccessful = false;

        }

        private void LoadStates()
        {
            var resourceManager = new ResourceManager("Independiente.Properties.States", typeof(PersonalDataViewModel).Assembly);

            var resourceSet = resourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true);

            var states = resourceSet.Cast<DictionaryEntry>()
                                    .Where(entry => entry.Value is string)
                                    .Select(entry => entry.Value.ToString()) 
                                    .ToList();

            StatesList = states;
        }


        public void SwitchMode(PageMode mode)
        {
            switch(mode)
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
            Console.WriteLine(PersonalData.Name);
            switch (Type)
            {
                case RegistrationType.Client:
                    break;
                case RegistrationType.Employee:
                    break;
            }
          
            if (PersonalData.Name != null && PersonalData.Name.Length > 0)
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
            
            SwitchMode(PageMode.View);
        }

        private void Edit(object obj)
        {

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

        public List<string> StatesList
        {
            get => _statesList;
            set
            {
                _statesList = value;
                OnPropertyChanged(nameof(StatesList));
            }
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
        public string SelectedState
        {
            get => _selectedState;
            set
            {
                if (_selectedState != value)
                {
                    _selectedState = value;
                    OnPropertyChanged(nameof(SelectedState));
                }
            }
        }
    }
}
