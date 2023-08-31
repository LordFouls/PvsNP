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

namespace PvsNP
{
    /// <summary>
    /// Interaction logic for GridScale3x3.xaml
    /// </summary>
    public partial class GridScale3x3 : UserControl
    {
        public GridScale3x3()
        {
            InitializeComponent();
        }

        // Event
        private void NewObjectAdded(object sender, MouseButtonEventArgs e)
        {

            if (sender is Label)
            {

                Label lableClicked = sender as Label;
                //MessageBox.Show(lableClicked.Name);


                Random random = new Random();

                SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(
                    Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255))));

                lableClicked.Background = brush;
                lableClicked.Content = new DaDscaleControls();
                lableClicked.MouseDown -= NewObjectAdded;



            }

        }
    
    }

}
