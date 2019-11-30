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
using Swin_Adventure.Core;

namespace Swin_Adventure.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProgramInstance _program;

        public MainWindow()
        {
            InitializeComponent();
            _program = new ProgramInstance();
            GameConsole.Text = _program.Output;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameConsole.Text += "\r\n" + _program.InputCommand(CommandBox.Text);
            CommandBox.Clear();
        }
    }
}
