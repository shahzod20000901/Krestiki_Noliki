using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Krestiki_Noliki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //check();
        }

        // public void check()
        // {
        //     if
        //     (
        //         
        //         Button_0_0.Content == Button_1_1.Content && Button_0_0.Content == Button_2_2.Content ||
        //         Button_0_0.Content == Button_0_1.Content && Button_0_0.Content == Button_0_2.Content ||
        //         Button_0_0.Content == Button_1_0.Content && Button_0_0.Content == Button_2_0
        //     )
        //         MessageBox.Show($"Пользователь с использованием {Button_0_0.Content} победил!!!");
        // }

        public string move = "X";

        private bool Equals(Button buttonA, Button buttonB, Button buttonC)
        {
            if (buttonA.Content == null || buttonB.Content == null || buttonC.Content == null) return false;
            return buttonA.Content.ToString() == buttonB.Content.ToString() &&
                   buttonA.Content.ToString() == buttonC.Content.ToString();
        }

        private bool ThreeinRow()
        {
            bool threeinrow = false;

            // вертикальное
            threeinrow = Equals(Button_0_0, Button_1_0, Button_2_0);
            if (threeinrow) return true;
            threeinrow = Equals(Button_0_1, Button_1_1, Button_2_1);
            if (threeinrow) return true;
            threeinrow = Equals(Button_0_2, Button_1_2, Button_2_2);
            if (threeinrow) return true;

            // горизонтальное
            threeinrow = Equals(Button_0_0, Button_0_1, Button_0_2);
            if (threeinrow) return true;
            threeinrow = Equals(Button_1_0, Button_1_1, Button_1_2);
            if (threeinrow) return true;
            threeinrow = Equals(Button_2_0, Button_2_1, Button_2_2);
            if (threeinrow) return true;

            //диагональное
            threeinrow = Equals(Button_0_0, Button_1_1, Button_2_2);
            if (threeinrow) return true;
            threeinrow = Equals(Button_0_2, Button_1_1, Button_2_0);
            if (threeinrow) return true;

            return threeinrow;
        }

        private void ButtonBase_OnClick_X(object sender, RoutedEventArgs e)
        {
            //  local =Convert.ToString( Button_X.Content);
            move = "X";
            Label_fisrt.Background = Label_colour.Background;
            Label_second.Background = Label_white.Background;
        }

        private void ButtonBase_OnClick_O(object sender, RoutedEventArgs e)
        {
            // local = Convert.ToString(Button_O.Content);
            move = "O";
            
            Label_second.Background = Label_red.Background;
            Label_fisrt.Background = Label_white.Background;
        }

        private void ButtonBase_OnClick_0_0(object sender, RoutedEventArgs e)
        {
            Button dynamicButton = sender as Button;
            if (dynamicButton.Content != null) return;
            dynamicButton.Content = move;
            if (ThreeinRow())
            {
                MessageBox.Show("Выйграл " + move);
            }
        }


        public void Clear()
        {
            Button_0_0.Content = null;
            Button_0_1.Content = null;
            Button_0_2.Content = null;
            Button_1_0.Content = null;
            Button_1_1.Content = null;
            Button_1_2.Content = null;
            Button_2_0.Content = null;
            Button_2_1.Content = null;
            Button_2_2.Content = null;
        }

        private void Button_New_OnClick(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Button_Exit_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}