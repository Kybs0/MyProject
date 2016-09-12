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
using MyProject.DAL;
using MyProject.DAL.IService;
using MyProject.DAL.Service;
using MyProject.Entity.Entity;

namespace MyProject.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            IExampleService aa = new ExampleService();
            aa.Create(new Example(){Id = 1,Name="aa"});
            //EFDataContext.GetCurrentDbContext();
        }
    }
}
