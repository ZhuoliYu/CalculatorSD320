using System;
using System.Windows.Forms;

namespace CalculatorSD320
{
    public partial class MyCalculator : Form
    {
        public MyCalculator()
        {
            InitializeComponent();
            KeyPreview = true;//it's for controlling by keyboard function from KepUp and KeyDown methods type boolean has true value
        }

        decimal firstInput, secondInput, result;// firstInput data is stored before op, after inputing op, the second input is stored, then result means it can be calculated after hit equal button.
        int op; //declare operaton type is int with :1 is + , 2 is -, 3 is x ,4 is /

        private void ZeroEliminate(string number)
        {
            if (textBox.Text == "0")//if the number on screen is 0, it's been replacd by the new number we click
                textBox.Text = number;
            else
                textBox.Text += number; //adding next number on screen
        }
        private void btn1_Click(object sender, EventArgs e)//if click btn1, call the function "ZeroEliminate" in the body part, 0 can be replaced to new number then add new value
        {
            ZeroEliminate("1");//set the argument to "1" from ZeroEliminate
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ZeroEliminate("2");
        }

        

        private void btn3_Click(object sender, EventArgs e)
        {
            ZeroEliminate("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            ZeroEliminate("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            ZeroEliminate("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            ZeroEliminate("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            ZeroEliminate("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            ZeroEliminate("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            ZeroEliminate("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            ZeroEliminate("0");
        }
        //After click plus, first input is stored from screen to textBox.Text,this string data convert to decimal,convert is needed because textBox.Text is string, string and decimal are not equal
        private void plusBtn_Click(object sender, EventArgs e)//firstly, check if there's number in box, then if there is, first input data will be made to textBox
        {
            if (textBox.Text == string.Empty)//There's no data in box-string.Empty,then go into body, body shows error message
                MessageBox.Show("please enter valid value");//if click plus btn, we should check text is empty or 0,if the first input is 0, we cannot calculate this
           
            firstInput = Convert.ToDecimal(textBox.Text);//set first input using the nubmer in box
            op = 1;//set the operation, this will be used when click equal
            textBox.Text = "";// this reset the box to ""
            _operator.Text = "+";//this shows plus operator in another label
        }
        //
        private void equalBtn_Click(object sender, EventArgs e)
        {
            if (textBox.Text == string.Empty)//There's no data in box-string.Empty,then go into body, body shows error message
                MessageBox.Show("please enter valid value");//if click equal btn, we should check text is empty or 0,if the first input is 0, we cannot calculate this
            if (op == 4 && Convert.ToDecimal(textBox.Text) == 0) //if operation is divide(op=4), and number converted by decimal from textBob is 0, go into body-message box
                MessageBox.Show("any number cannot be divided by 0");//there are 2 conditions, one is operation is divided, and the number in the box is 0

            secondInput = Convert.ToDecimal(textBox.Text);//set the secondIput in textBox and to convert it's format from string to decimal.

            CalculateResult();//call result
            

        }
        private void CalculateResult()//when the result is called, the system will check op(operation)
        {
            switch (op) //checking what operation is
            {
                case 1://if op is one, run plus firstinput and secondinput
                    result = firstInput + secondInput;
                    textBox.Text = result.ToString();//show the result in textBox,result shoud be converted to string from decimal
                    break;//when the op is one just run case 1 two lines code, then stop this switch then go out side of swtich(op)

                case 2:
                    result = firstInput - secondInput;//if op is 2, run minus firstinput and secondinput
                    textBox.Text = result.ToString();//show the result in textBox,result shoud be converted to string from decimal
                    break;//when the op is two just run case 2, then stop this switch then go out side of swtich(op) again

                case 3:
                    result = firstInput * secondInput;//case 3 is for multipy
                    textBox.Text = result.ToString();
                    break;
                case 4:
                    result = firstInput / secondInput;//case 4 is for divide
                    textBox.Text = result.ToString();
                    break;
            }
        }

        private void minusBtn_Click(object sender, EventArgs e)//firstly, check if there's number in box, then if there is, first input data will be made to textBox
        {
            if (textBox.Text == string.Empty)//There's no data in box-string.Empty,then go into body, body shows error message
                MessageBox.Show("please enter valid value");

            firstInput = Convert.ToDecimal(textBox.Text);//same with plusbutton function
            op = 2;
            textBox.Text = "";
            _operator.Text = "-";
        }

        private void multipyBtn_Click(object sender, EventArgs e)//same with plusbutton function
        {
            if (textBox.Text == string.Empty )
                MessageBox.Show("please enter valid value");

            firstInput = Convert.ToDecimal(textBox.Text);
            op = 3;
            textBox.Text = "";
            _operator.Text = "*";
        }

        private void divideBtn_Click(object sender, EventArgs e)//same with plusbutton function
        {
            if (textBox.Text == string.Empty )
                MessageBox.Show("please enter valid value");

            firstInput = Convert.ToDecimal(textBox.Text);
            op = 4;
            textBox.Text = "";
            _operator.Text = "/";
        }

        private void dotBtn_Click(object sender, EventArgs e)
        {
                if(!textBox.Text.Contains("."))//To avoid another "dot. when the string doesn't contain dot in textBox
                    textBox.Text += ".";//add dot after number
        }

        private void BINBtn_Click(object sender, EventArgs e)
        {
            double dec = double.Parse(textBox.Text);//converting string type textBox.Text to double using Parse method, convert is anoter method can replace with parse
            textBox.Text = CovertToBinary(dec);//call convertBIN using dec argument (is double),result will be displayed in textBox
        }

        public string CovertToBinary(double Dec)
        {
            int maxPow = 0;//declare maxPower will be set in while iterate
            string binary = "";//declare the type of binary will be result"".
            while (Math.Pow(2, maxPow) < Dec) //if base input is 8, power is 2, result will be 64(8*8), first argument base is 2, second argument is maximum power, find maxpower under decial(<DEL),
            {//while math.pow over to dec, this will finish, this should be under Dec
                maxPow++;// maxpow plus one when while iterate runs 
            }
            maxPow--;//when it go out from while statement, maxpower is over than dec, so output should minis one when it;s finished becasue the output is one more step from the correct answer
            for (int i = maxPow; i >= 0; i--)// start with maxpow until i=0, each step change output then i minus one 
            {
                if (Math.Pow(2, i) <= Dec)//if math.pow(2,i ) is under Dec is ture, go to body
                {
                    binary += "1";//add one in binary string
                    Dec = Dec - Math.Pow(2, i);//mathpower(2, i) is converted to binary, then remove the number from original dec
                }
                else//otherwise go to the body below
                {
                    binary += "0";//add "0" to binary string
                }
            }
            return binary;//binary type is exactly same with string binary line173 class system string
        }

        private void DECBtn_Click(object sender, EventArgs e)
        {
            string dec = textBox.Text;//string type dec will be output to textBox
            textBox.Text = ConvertToDec(dec).ToString();//textBox output converts from double to string 
        }

        private double ConvertToDec(string Bin)//this method is to covert a binary number to decimal number,this action invokes DEC button event listener,get string argument Bin to make result as double
        {
            double Dec = 0;//declare DEC set default value is 0
            var length = Bin.Length;//Count the number of length of binary string
            for (int i = length - 1; i >= 0; i--)//start with length minus 1, end with i is 0(will stop), each step,i will decrease 1
            {
                if (Bin[length - 1 - i] == '1')//binary string begins with 0,binary 1101 length(4) minus 1 is 3, i starts with 3, make 3 minus 3, 0 will be get
                {
                    //if Bin is equal 1, go into body part Dec 
                    Dec += Math.Pow(2, i);//i is used in maxPower so the length of counting will minus 1 at beginning of i example:1101 count legth is 4, decimal is started with 2power3
                    //make double Dec start and plus from Math.Pow(2,i) binary, 1101 i starts with 3, Dec output will be 2 power 3 is 8, then next step 3 minus 1 will be 2
                    //if binary output is not equal '1', then skip this step
               
                }


            }
            return Dec;//output the result from Dec type is same with doulbe dec declaration
        }

        private void Calculator_KeyUp(object sender, KeyEventArgs e)// call keyup function, before that set event of Form1 keyup to Calculator_Keyup
        {
            switch (e.KeyCode)//check Key code from KeyEventArg
            {
                case Keys.Enter://set function of enter button case to equalBtn
                    equalBtn.PerformClick(); //click trigger equalBtn event
                    break;

            }
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)//switch keyEventArgument to keyborad input style to KeyCode
            {
                case Keys.NumPad0:// set keyboard number pad number0 
                    btn0.PerformClick();//using click event trigger input button 0
                    break;
                case Keys.D0://set D0 as the 0 key on the main keys
                    btn0.PerformClick();//output result 0 on textBox through press 0
                    break;
                case Keys.NumPad1:
                    btn1.PerformClick();
                    break;
                case Keys.D1:
                    btn1.PerformClick();
                    break;
                case Keys.NumPad2:
                    btn2.PerformClick();
                    break;
                case Keys.D2:
                    btn2.PerformClick();
                    break;
                case Keys.NumPad3:
                    btn3.PerformClick();
                    break;
                case Keys.D3:
                    btn3.PerformClick();
                    break;
                case Keys.NumPad4:
                    btn4.PerformClick();
                    break;
                case Keys.D4:
                    btn4.PerformClick();
                    break;
                case Keys.NumPad5:
                    btn5.PerformClick();
                    break;
                case Keys.D5:
                    btn5.PerformClick();
                    break;
                case Keys.NumPad6:
                    btn6.PerformClick();
                    break;
                case Keys.D6:
                    btn6.PerformClick();
                    break;
                case Keys.NumPad7:
                    btn7.PerformClick();
                    break;
                case Keys.D7:
                    btn7.PerformClick();
                    break;
                case Keys.NumPad8:
                    btn8.PerformClick();
                    break;
                case Keys.D8:
                    btn8.PerformClick();
                    break;
                case Keys.NumPad9:
                    btn9.PerformClick();
                    break;
                case Keys.D9:
                    btn9.PerformClick();
                    break;
                case Keys.Add:
                    plusBtn.PerformClick();
                    break;
                case Keys.Subtract:
                    minusBtn.PerformClick();
                    break;
                case Keys.Multiply:
                    multipyBtn.PerformClick();
                    break;
                case Keys.Divide:
                    divideBtn.PerformClick();
                    break;

            }
        }

        
    }
}