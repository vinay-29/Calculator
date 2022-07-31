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
        private string operatorSelected = string.Empty;
        private string operType = string.Empty;
        private double totalValue = 0;
        private double previousValue = 0;
        private bool isOperSelected = false;
        private int colorCount = 2;
        public CalculatorHomePage()
        {
            InitializeComponent();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //Future Implementation
            //Master Code Update
        }


        private void OnNumberClicked(object sender, EventArgs args)
        {
            string num = (sender as Button).Text;
            //if (isOperSelected)
            //{
            //    if (texteditor.Text.Contains("."))
            //    {
            //        texteditor.Text = string.Empty;
            //    }
            //    else
            //    {
            //        texteditor.Text = string.Empty;
            //    }
            //    isOperSelected = false;
            //}

            if (isOperSelected)
            {
                texteditor.Text = string.Empty;
                isOperSelected = false;
            }
            texteditor.Text += num;

            textViewEditor.Text += num;
        }

        private void OnBackspaceClicked(object sender, EventArgs args)
        {
            if (texteditor.Text.Length != 0)
            {
                texteditor.Text = texteditor.Text.Remove(texteditor.Text.Length - 1, 1);
            }
            else { return; }
        }


        private void OnClearTextClicked(object sender, EventArgs args)
        {
            //if (texteditor.Text.Length != 0)
            //{
            //    texteditor.Text = string.Empty;
            //    textViewEditor.Text = string.Empty;
            //    restoreColor("C");
            //}
            //else { return; }
            texteditor.Text = string.Empty;
            textViewEditor.Text = string.Empty;
            enrtyRecordLbl.Text = string.Empty;
            totalValue = 0;
            previousValue = 0;
            restoreColor("C");
        }

        private void OperatorKeyClicked(object sender, EventArgs args)
        {
            try
            {
                string operat = (sender as Button).Text;
                double preVal = 0;
                isOperSelected = true;
                if (!string.IsNullOrEmpty(texteditor.Text) && totalValue == 0)
                {
                    if (IsTextNumeric(texteditor.Text))
                    {
                        totalValue = Convert.ToDouble(texteditor.Text);
                        previousValue = Convert.ToDouble(texteditor.Text);
                    }
                    else
                    {
                        DisplayAlert("Invalid Entry", "Please enter only numbers", "Ok");
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(texteditor.Text))
                    {
                        operatorSelected = operat;
                        preVal = Convert.ToDouble(texteditor.Text);
                        var outputVal = CalculateValue(operatorSelected, preVal);
                        //enrtyRecordLbl.Text = outputVal.ToString("N4");
                        enrtyRecordLbl.Text = outputVal.ToString();
                        texteditor.Text = string.Empty;
                    }
                }

                // assign the operator
                operatorSelected = operat;
                if (!string.IsNullOrEmpty(operat))
                {
                    restoreColor(operat);
                }


                //if ()
                //{

                //}
                //2nd feilds
                textViewEditor.Text += operat;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                DisplayAlert("Error", "Clear Text 'C' ", "Ok");
            }
        }

        private void restoreColor(string oper)
        {
            switch (oper)
            {
                case "+":
                    plusBtn.BackgroundColor = Color.FromHex("#33ADEE");
                    minusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    multiplyBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    percentageBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    divisionBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    break;
                case "-":
                    minusBtn.BackgroundColor = Color.FromHex("#33ADEE");
                    plusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    multiplyBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    percentageBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    divisionBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    break;
                case "x":
                    multiplyBtn.BackgroundColor = Color.FromHex("#33ADEE");
                    plusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    minusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    percentageBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    divisionBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    break;
                case "%":
                    percentageBtn.BackgroundColor = Color.FromHex("#33ADEE");
                    plusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    minusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    multiplyBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    divisionBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    break;
                case "÷":
                    divisionBtn.BackgroundColor = Color.FromHex("#33ADEE");
                    plusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    minusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    multiplyBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    percentageBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    break;
                case "C":
                    divisionBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    plusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    minusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    multiplyBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    percentageBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    isOperSelected = false;
                    break;
                default:
                    divisionBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    plusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    minusBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    multiplyBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    percentageBtn.BackgroundColor = Color.FromHex("#Ec4d03");
                    isOperSelected = false;
                    break;
            }
        }

        //private bool isOperatorSelected()
        //{
        //    bool isSeleted = false;

        //    if (plusBtn.IsPressed || minusBtn.IsPressed || divisionBtn.IsPressed || multiplyBtn.IsPressed || percentageBtn.IsPressed)
        //    {
        //        isSeleted = true;
        //    }

        //    return isSeleted;

        //}

        private void OnEqualsClicked(object sender, EventArgs args)
        {
            try
            {
                double secondVal = 0;
                string inputText = texteditor.Text;

                if (!string.IsNullOrEmpty(inputText))
                {
                    if (IsTextNumeric(texteditor.Text))
                    {
                        secondVal = Convert.ToDouble(inputText);
                        previousValue = secondVal;
                        var outputVal = CalculateValue(operatorSelected, previousValue);
                        //enrtyRecordLbl.Text = outputVal.ToString("N4");
                        enrtyRecordLbl.Text = outputVal.ToString();

                        if (!string.IsNullOrEmpty(operatorSelected))
                        {
                            texteditor.Text = string.Empty;
                        }
                    }
                    else
                    {
                        DisplayAlert("Invalid Entry", "Please enter only numbers", "Ok");
                    }

                }
                else
                {
                    if (previousValue != 0)
                    {
                        var outputVal = CalculateValue(operatorSelected, previousValue);
                        enrtyRecordLbl.Text = outputVal.ToString();
                        texteditor.Text = string.Empty;
                    }
                    else
                    {
                        DisplayAlert("No entry", "Enter number", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                DisplayAlert("Error", "Clear Text 'C' ", "Ok");
            }

        }

        private double CalculateValue(string operatorType, double enteredValue)
        {
            double returnValue = 0;
            switch (operatorType)
            {
                case "+":
                    returnValue = totalValue + enteredValue;
                    break;
                case "-":
                    returnValue = totalValue - enteredValue;
                    break;
                case "x":
                    returnValue = totalValue * enteredValue;
                    break;
                case "%":
                    returnValue = ReturnPercentage(enteredValue);
                    break;
                case "÷":
                    returnValue = totalValue / enteredValue;
                    break;
                case "C":
                    returnValue = totalValue + enteredValue;
                    break;
                default:
                    returnValue = 0;
                    return returnValue;
            }
            //All values stored to total values
            totalValue = returnValue;
            return returnValue;
        }

        private double ReturnPercentage(double secondVal)
        {
            var returnVal = secondVal;
            returnVal = (totalValue / 100) * secondVal;
            return returnVal;
        }

        //OnDecimalKeyClicked
        private void OnDecimalKeyClicked(object sender, EventArgs args)
        {
            string enteredText = texteditor.Text;
            if (!string.IsNullOrEmpty(texteditor.Text))
            {
                if (texteditor.Text.Contains("."))
                {
                    if (isOperSelected)
                    {
                        texteditor.Text = " ";
                        texteditor.Text += ".";
                        textViewEditor.Text += ".";
                    }
                }
                else
                {
                    if (isOperSelected)
                    {
                        texteditor.Text = " ";
                        texteditor.Text += ".";
                        textViewEditor.Text += ".";
                    }
                    else
                    {
                        texteditor.Text += ".";
                        textViewEditor.Text += ".";
                    }
                }
            }
            else
            {
                texteditor.Text += ".";
                textViewEditor.Text += ".";
            }
        }

        private bool IsTextNumeric(string enteredText)
        {

            double n;
            bool isNumeric = double.TryParse(enteredText, out n);

            return isNumeric;
        }

        private void OnPlusMinusClicked(object sender, EventArgs args)
        {
            if (texteditor.Text.Contains("-"))
            {
                texteditor.Text = texteditor.Text.Trim('-');
            }
            else
            {
                texteditor.Text = string.Format("-{0:F}", texteditor.Text);
            }
        }

        private void OnMagicKeyClicked(object sender, EventArgs args)
        {
            if (colorCount % 2 == 0)
            {
                gridView.BackgroundColor = Color.FromHex("#350c0d"); //future ref 9A2F31
                colorCount++;
            }
            else
            {
                gridView.BackgroundColor = Color.FromHex("#F1b292");
                colorCount++;
            }
        }

    }
}