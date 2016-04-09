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
using System.Windows.Threading;

namespace RPG
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

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (DirectionControl.MovementKeys.Contains(e.Key))
            {
                Character.Move(e.Key);
            }
        }

        private void KeyUpEvent(object sender, KeyEventArgs e)
        {
            if (DirectionControl.MovementKeys.Contains(e.Key))
            {
                Character.Stop(e.Key);
            }
        }

    }
}
