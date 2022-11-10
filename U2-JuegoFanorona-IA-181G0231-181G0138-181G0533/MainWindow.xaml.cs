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
using U2_JuegoFanorona_IA_181G0231_181G0138_181G0533.Models;

namespace U2_JuegoFanorona_IA_181G0231_181G0138_181G0533
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Nodo nodo = new Nodo();
            nodo.ChildrenGenerate(1, 200);
            InitializeComponent();
        }
    }
}
