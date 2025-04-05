using Independiente.ViewModel;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Lógica de interacción para FinancialData.xaml
    /// </summary>
    public partial class FinancialData : Page
    {
        FinancialDataViewModel _financialDataViewModel;
        public FinancialData(PageMode mode)
        {
            InitializeComponent();


            _financialDataViewModel = new FinancialDataViewModel();
            _financialDataViewModel.SwitchMode(mode);
            this.DataContext = _financialDataViewModel;
            _financialDataViewModel.RequestClose += ViewModel_RequestClose;
        }

        private void ViewModel_RequestClose(object sender, EventArgs e)
        {
            if (_financialDataViewModel.IsNextSuccessful)
            {
                this.NavigationService.Navigate(new References(PageMode.View));
            }
        }

    }
}
