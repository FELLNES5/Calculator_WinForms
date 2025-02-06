namespace Calculator
{
    public partial class Form1 : Form
    {
        private string input = string.Empty;
        private string number1 = string.Empty;
        private string number2 = string.Empty;
        private char operation;
        private double result;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            if (buttonText == "C")
            {
                textBox_Result.Text = "";
                input = string.Empty;
                number1 = string.Empty;
                number2 = string.Empty;
                operation = '\0';
            }
            else if (buttonText == "=")
            {
                if (!string.IsNullOrEmpty(number1) && !string.IsNullOrEmpty(input))
                {
                    number2 = input;
                    double num1, num2;
                    double.TryParse(number1, out num1);
                    double.TryParse(number2, out num2);

                    switch (operation)
                    {
                        case '+':
                            result = num1 + num2;
                            break;
                        case '-':
                            result = num1 - num2;
                            break;
                        case '*':
                            result = num1 * num2;
                            break;
                        case '/':
                            if (num2 != 0)
                            {
                                result = num1 / num2;
                            }
                            else
                            {
                                textBox_Result.Text = "Деление на ноль";
                                return;
                            }
                            break;
                        case '^':
                            result = Math.Pow(num1, num2);
                            break;
                    }
                    textBox_Result.Text = result.ToString();
                    input = result.ToString();
                    number1 = string.Empty;
                    number2 = string.Empty;
                    operation = '\0';
                }
            }
            else if (buttonText == "+" || buttonText == "-" || buttonText == "*" || buttonText == "/" || buttonText == "^")
            {
                if (string.IsNullOrEmpty(number1))
                {
                    number1 = input;
                    operation = char.Parse(buttonText);
                    input = string.Empty;
                    textBox_Result.Text += " " + buttonText + " ";
                }
            }
            else if (buttonText == "√")
            {
                if (!string.IsNullOrEmpty(input))
                {
                    double num;
                    double.TryParse(input, out num);
                    result = Math.Sqrt(num);
                    textBox_Result.Text = result.ToString();
                    input = result.ToString();
                    number1 = string.Empty;
                    number2 = string.Empty;
                    operation = '\0';
                }
            }
            else
            {
                if (string.IsNullOrEmpty(number2))
                {
                    input += buttonText;
                    textBox_Result.Text += buttonText;
                }
            }
        }
    }
}


