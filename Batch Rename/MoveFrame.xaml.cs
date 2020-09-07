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
    /// Interaction logic for MoveFrame.xaml
    /// </summary>
    public partial class MoveFrame : Page
    {
        public delegate void MoveDelegate(string from, string count, string to);
        public MoveDelegate DataChanged;
        public MoveFrame()
        {
            InitializeComponent();
        }

        private void TextBoxMoveFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxChanged();
        }

        private void TextBoxCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxChanged();
        }

        private void TextBoxMoveTo_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxChanged();
        }

        private void TextBoxChanged()
        {
            DataChanged?.Invoke(TextBoxMoveFrom.Text, TextBoxCount.Text, TextBoxMoveTo.Text);
        }
    }
}
