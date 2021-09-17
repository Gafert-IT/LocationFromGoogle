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
using LocationFromGoogle.Classes;
using LocationFromGoogle.MVVM.ViewModel;
using LocationFromGoogle.MVVM.View;
using LocationFromGoogle.Core;

/***************************************************************************************
*    Title: Google Maps Location Tool
*    Author: Mike Gafert
*    Contributors:
*    Date: 17.09.2021
*    Time: 11:00
*    Code version: 0.1.1.27
*    Availability: https://github.com/Gafert-IT/LocationFromGoogle
*    License: GNU General Public License v3.0
*
***************************************************************************************/

namespace LocationFromGoogle
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
    }
}
