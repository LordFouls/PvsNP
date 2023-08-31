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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PvsNP
{
    /// <summary>
    /// Interaction logic for DaDscaleControls.xaml
    /// </summary>
    public partial class DaDscaleControls : UserControl
    {
        //varible
        private Label variable;
        private Viewbox scaleVariable;
        private Grid origin;
        private Random random;
        private SolidColorBrush brushRandom;
        private DaDscaleControls division;
        private ColumnDefinition columnDefinition;
        int columnCount;

        //Class
        public DaDscaleControls()
        {
            random = new Random();
            InitializeComponent();
        }


        // Event
        private void NewObjectAdded(object sender, MouseButtonEventArgs e)
        {

            if(sender is Label)
            {
                variable = sender as Label;
                // Print(variable.Name);
                    brushRandom = new SolidColorBrush(RandomColor());
                    division = new DaDscaleControls();
                        variable.Background = brushRandom;
                        variable.Content = division;
                        variable.MouseDown -= NewObjectAdded;
            
                scaleVariable = variable.Parent as Viewbox;
                // Print(scaleVariable.Name);
                    columnCount = Grid.GetColumn(scaleVariable);
                    // Print(columnCount.ToString());

                origin = scaleVariable.Parent as Grid;
                // Print(origin.Name);
                    columnDefinition = new ColumnDefinition();
                    columnDefinition.Width = new GridLength(1);
                origin.ColumnDefinitions.Add(columnDefinition);
                    columnDefinition = new ColumnDefinition();
                    columnDefinition.Width = new GridLength(0, GridUnitType.Star);
                origin.ColumnDefinitions.Add(columnDefinition);

                scaleVariable = new Viewbox();
                    Grid.SetColumn(scaleVariable, columnCount + 2);
                variable = new Label();
                    variable.MouseDown += NewObjectAdded;
                    variable.Background = Brushes.White;

                scaleVariable.Child = variable;
                origin.Children.Add(scaleVariable);

            }

        }


        //Funktion
        private Color RandomColor()
        {
            return Color.FromRgb(Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255)));
        }

        private void Print(string txt)
        {
            MessageBox.Show(txt);
        }

    }

}