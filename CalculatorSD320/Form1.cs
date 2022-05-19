using System;
using System.Windows.Forms;

namespace CalculatorSD320
{
    public partial class MyCalculator : Form
    {
        public MyCalculator()
        {
            InitializeComponent();
            //it's for controlling by keyboard function from KepUp and KeyDown methods type boolean has true value
            KeyPreview = true;
        }
        // firstInput data is stored before op, after inputing op, the second input is stored, then result means it can be calculated after hit equal button.
        decimal firstInput, secondInput, result;
        //declare operaton type is int with :1 is + , 2 is -, 3 is x ,4 is /
        int op; 

        private void ZeroEliminate(string number)
        {
            //if the number displayed on textBox is 0, it's been replacd by the new number that click
            if (textBox.Text == "0")
                textBox.Text = number;
            else
                textBox.Text += number; //adding next number on textBox
        }
        //if click btn1, call the function "ZeroEliminate" in the body part,
        //0 can be replaced to new number then add new value
        private void btn1_Click(object sender, EventArgs e)
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
        //After click plusBtn, first input is stored from screen to textBox.Text,
        //this string data convert to decimal
        //convert is needed because type of textBox.Text is string, string and decimal are not equal
        private void plusBtn_Click(object sender, EventArgs e)
        {
            //firstly, check if there's number in box, then if there is, first input data will be made to textBox
            //There's no data in box-string.Empty,then go into body, body shows error message
            if (textBox.Text == string.Empty)
                //if click plus btn, system checks text is empty or 0,if the first input is 0,cannot calculate 
                MessageBox.Show("please enter valid value");
           
            firstInput = Convert.ToDecimal(textBox.Text);//set first input using the nubmer in box
            op = 1;//set the operation, this will be used when click equal
            textBox.Text = "";// this reset the box to ""
            _operator.Text = "+";//this shows plus operator in another label
        }
        //
        private void equalBtn_Click(object sender, EventArgs e)
        {
            if (textBox.Text == string.Empty)//No data in box-string.Empty,then go into body, body shows error message
                MessageBox.Show("please enter valid value");
            //if click equal btn, we should check text is empty or 0,if the first input is 0, calculate will not achieve
            //if operation is divide(op=4), and number converted by decimal from textBob is 0, go into body-message box
            if (op == 4 && Convert.ToDecimal(textBox.Text) == 0)
                //declare 2 conditions, one is operation is divided, and the number in the box is 0
                MessageBox.Show("any number cannot be divided by 0");
            //set the secondIput in textBox and to convert it's format from string to decimal.
            secondInput = Convert.ToDecimal(textBox.Text);

            CalculateResult();//call result
            

        }
        private void CalculateResult()//when the result is called, the system will check op(operation)
        {
            switch (op) //checking what operation is
            {
                case 1://if op is one, run plus firstinput and secondinput
                    result = firstInput + secondInput;
                    //show the result in textBox,result shoud be converted to string from decimal
                    textBox.Text = result.ToString();
                    //when the op is one just run case 1 first two lines code, then stop this switch then go out side of swtich(op)
                    break;

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

        //check if there's number in box, then if there is, first input data will be made to textBox
        private void minusBtn_Click(object sender, EventArgs e)
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
            //To avoid another "dot. when the string doesn't contain dot in textBox    
            if (!textBox.Text.Contains("."))
                    textBox.Text += ".";//add dot after number
        }

        private void BINBtn_Click(object sender, EventArgs e)
        {
            //converting string type textBox.Text to double using Parse method
            //convert is anoter method can replace with parse
            double dec = double.Parse(textBox.Text);
            //call convertBIN using dec argument (is double),result will be displayed in textBox
            textBox.Text = CovertToBinary(dec);
        }

        public string CovertToBinary(double Dec)
        {
            int maxPow = 0;//declare maxPower will be set in while iterate
            string binary = "";//declare the type of binary will be result"".
            //(if base input is 8, power is 2, result will be 64(8*8))
            //first argument base is 2,second argument is maximum power, find maxpower under decimal(<DEL),
            while (Math.Pow(2, maxPow) < Dec) 
            {//while math.pow over to dec, this will finish, this should be under Dec
                maxPow++;// maxpow plus one when while iterate runs 
            }
            //when output go out from while statement, maxpower is over than dec,
            //so output should minis one when it's finished becasue the output is one more step from the correct answer
            maxPow--;
            for (int i = maxPow; i >= 0; i--)// start with maxpow until i=0, each step change output then i minus one 
            {
                if (Math.Pow(2, i) <= Dec)//if math.pow(2,i ) is under Dec is ture, go to body
                {
                    binary += "1";//add one in binary string
                    //mathpower(2, i) is converted to binary, then remove the number from original dec
                    Dec = Dec - Math.Pow(2, i);
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

        //this method is to covert a binary number to decimal number,
        //this action invokes DEC button event listener,get string argument Bin to make result as double
        private double ConvertToDec(string Bin)
        {
            double Dec = 0;//declare DEC set default value is 0
            var length = Bin.Length;//Count the number of length of binary string
            //start with length minus 1, end with i is 0(loop stops), i will decrease 1 in each step
            for (int i = length - 1; i >= 0; i--)
            {
                //binary string begins with 0,binary 1101 length(4) minus 1 is 3, i starts with 3, make 3 minus 3, 0 will be get
                if (Bin[length - 1 - i] == '1')
                {
                    //if Bin is equal 1, go into body part Dec 
                    //i is used in maxPower so the length of counting will minus 1 at beginning of i
                    //example:1101 count legth is 4, decimal is started with 2power3
                    Dec += Math.Pow(2, i);
                    //make double Dec start and plus from Math.Pow(2,i) binary,
                    //1101 i starts with 3, Dec output will be 2 power 3 is 8, then next step 3 minus 1 will be 2
                    //if binary output is not equal '1', then skip this step
               
                }


            }
            return Dec;//output the result from Dec type is same with doulbe dec declaration
        }

        // call keyup function, before that set event of Form1 keyup to Calculator_Keyup
        private void Calculator_KeyUp(object sender, KeyEventArgs e)
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