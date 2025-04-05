using Independiente.Services;
using Independiente.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Independiente.View.Pages
{
    public partial class PersonalData : Page
    {
        PersonalDataViewModel _personalDataViewModel;
        public PersonalData(RegistrationType type, PageMode mode)
        {
            InitializeComponent();


            _personalDataViewModel = new PersonalDataViewModel();
            _personalDataViewModel.Type = type;
            _personalDataViewModel.SwitchMode(mode);
           
            _personalDataViewModel.RequestClose += ViewModel_RequestClose;
            this.DataContext = _personalDataViewModel;
        }
      

        private void ViewModel_RequestClose(object sender, EventArgs e)
        {
            if (_personalDataViewModel.IsNextSuccessful)
            {
                if (_personalDataViewModel.Type == RegistrationType.Client)
                {
                    this.NavigationService.Navigate(new FinancialData(PageMode.View));
                }
            }
        }



    }
}
