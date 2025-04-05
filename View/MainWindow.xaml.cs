using Independiente.Services;
using Independiente.View.Pages;
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

namespace Independiente
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            var pagina = new PersonalData(RegistrationType.Client, PageMode.Update);
            IDialogService dialogService = new Services.DialogService();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(dialogService);
            this.DataContext = mainWindowViewModel;  
            PageFrame.Navigate(pagina);
            mainWindowViewModel.RequestClose += (s, e) => this.Close();
        }



       

    }
}
