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

namespace Batch_Rename
{
    /// <summary>
    /// Interaction logic for TrimFrame.xaml
    /// </summary>
    public partial class TrimFrame : Page
    {
        public delegate void TrimDelegate(string data);
        public event TrimDelegate TrimStringChanged;
        public TrimFrame()
        {
            InitializeComponent();
        }

        private void TrimCharacter_TextChanged(object sender, TextChangedEventArgs e)
        {
            TrimStringChanged?.Invoke(TrimCharacter.Text);
        }
    }
}
