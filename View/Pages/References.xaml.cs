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
    /// Lógica de interacción para References.xaml
    /// </summary>
    public partial class References : Page
    {
        private ReferencesViewModel _referencesViewModel;
        public References(PageMode mode)
        {
            InitializeComponent();


            _referencesViewModel = new ReferencesViewModel();
            _referencesViewModel.SwitchMode(mode);

            _referencesViewModel.RequestClose += ViewModel_RequestClose;
            this.DataContext = _referencesViewModel;
        }

        private void ViewModel_RequestClose(object sender, EventArgs e)
        {
            if (_referencesViewModel.IsNextSuccessful)
            {
               
                this.NavigationService.Navigate(new FinancialData(PageMode.View));
                
            }
        }
    }
}
