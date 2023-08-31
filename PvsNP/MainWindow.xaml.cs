using System;
using System.Collections.Generic;
using System.Data.Odbc;
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

namespace PvsNP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // #FF3BA8AB not focused
        // #FFD4EFEF focused
        private SolidColorBrush brushGotFocus = new SolidColorBrush(Color.FromRgb(212, 239, 239));
        private SolidColorBrush brushLostFocus = new SolidColorBrush(Color.FromRgb(59, 168, 171));
        private TextBox newVariable;
        ListBoxItem listBoxItem;
        private ListBox editContent;
        private List changeList;
        private int[] randomInt;
        private Random random;

        public MainWindow()
        {
            newVariable = new TextBox();
            random = new Random();
            randomInt = new int[3];
            InitializeComponent();
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                if (textBoxVariableInput.Focus() && !newVariable.Focus())
                {
                    NewListboxItem();   
                }

                if (newVariable.Focus())
                {
                    newVariable.Focusable = false;
                }

            }

        }

        private void NewListboxItem()
        {
            randomInt[0] = random.Next(20, 255);
            randomInt[1] = random.Next(20, 255);
            randomInt[2] = random.Next(20, 255);

            listBoxItem = new ListBoxItem();
            newVariable = new TextBox();
            newVariable.Background = Brushes.Transparent;
            newVariable.BorderBrush = Brushes.Transparent;
            newVariable.Text = textBoxVariableInput.Text;
            newVariable.Focusable = false;

            listBoxItem.Content = newVariable;

            listBoxItem.Background = new SolidColorBrush(Color.FromRgb(Convert.ToByte(randomInt[0]), Convert.ToByte(randomInt[1]), Convert.ToByte(randomInt[2])));

            if ((randomInt[0] + randomInt[1] + randomInt[2]) / 3 < 128)
            {
                newVariable.Foreground = Brushes.White;
            }
            else
            {
                newVariable.Foreground = Brushes.Black;
            }

            listBoxVariableList.Items.Add(listBoxItem);

            textBoxVariableInput.Clear();
        }

        private void LostFocus(object sender, RoutedEventArgs e)
        {
            
            if (sender is TextBox)
            {
                TextBox textBox = sender as TextBox;

                if (textBox.Text == "" && textBox.Name == "textBoxVariableInput")
                {
                    textBox.Text = "Set Variable";
                }

                if (textBox.Text == "" && textBox.Name == "textBoxBoolianEquation")
                {
                    textBox.Text = "Boolische Formel";
                }

                textBox.Background = brushLostFocus;
            }
        
        }

        private void GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox textBox = sender as TextBox;

                if (textBox.Text == "Set Variable" || textBox.Text == "Boolische Formel")
                {
                    textBox.Clear();
                }

                textBox.Background = brushGotFocus;
            }
        }

        private void ChangeName(object sender, MouseButtonEventArgs e)
        {
            
            //MessageBox.Show(sender.GetType().Name);
            editContent = new ListBox();
            editContent = sender as ListBox;
            
            newVariable = new TextBox();
            System.Collections.IList i;
            i = editContent.SelectedItems;
            //MessageBox.Show(i.Count.ToString() + "\n" + i[0].GetType());
            listBoxItem = new ListBoxItem();
            listBoxItem = i[0] as ListBoxItem;
            newVariable = listBoxItem.Content as TextBox;
            newVariable.Focusable = true;
            newVariable.Focus();
            newVariable.SelectAll();

        }

    }

}
