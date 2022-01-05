using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorHomePage : ContentPage
    {
        public CalculatorHomePage()
        {
            InitializeComponent();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OnButton7Clicked(object sender, EventArgs args)
        {
            textEntry.Text += "7";
        } 
        
        private void OnButton8Clicked(object sender, EventArgs args)
        {
            textEntry.Text += "8";
        }

        private void OnBackspaceClicked(object sender, EventArgs args)
        {
            if (textEntry.Text.Length != 0)
            {
                textEntry.Text = textEntry.Text.Remove(textEntry.Text.Length - 1, 1);
            }
            else { return; }
        }

    }
}