using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GTrustDashBoard.Repository;
using GTrustDashBoard.Util;

namespace GTrustDashBoard
{
    /// <summary>
    /// Interaction logic for StartUpWindow.xaml
    /// </summary>
    public partial class StartUpWindow : Window
    {
        public StartUpWindow()
        {
            InitializeComponent();
            System.Threading.Thread.Sleep(5000);
            CheckAuthorizedSystem();
        }


        void CheckAuthorizedSystem()
        {
            if(SystemFunctions.IsRegisteredSystem()==true)
            {
                MainWindow Main = new MainWindow();
                Main.ShowDialog();
            }
            else
            {
               MessageBoxResult result= MessageBox.Show("UnAuthorized System!...", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);

                if(MessageBoxResult.OK==result)
                {
                    this.Close();
                }

            }
        }
    }
}
