using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstRabbitMQ
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Task<int> input1 = new Task<int>(() => 45);
            Task<int> input2 = new Task<int>(() => 34);

           // var result = DoAllMathematicOperation(45, 34);

            //int result1 = await Addition(34, 45);
            //int result2 = await Subraction(45, 34);

            Task<int> result3 = Addition(34, 45);
            Task<int> result4 = Subraction(45, 34);

           // int resultFinal = await Multiply(result1, result2);

           int resultFinal = await Multiply(result3.Result, result4.Result);
        }


        private async Task<string> DoAllMathematicOperation(int input1, int input2)
        {
            string combinedResult = "";
            int task1 = await Addition(input1, input2);
            int task2 = await Subraction(input1, input2);
           // int task3 = await Multiply(task1, task2);

            //int result1 = await task1;
            //int result2 = await task2;
            //int result3 = await task3;

            //var allresult = await Task.WhenAll(result1, result2, result3);
            //string combinedResult = result1.Result.ToString() + ", " + result1.Result.ToString() + ", " + result1.Result.ToString();
            //combinedResult = result1.ToString() + ", " + result1.ToString() + ", " + result1.ToString();
           // combinedResult = task3.ToString();
            return combinedResult;
        }


        private async Task<int> Addition(int value1, int value2)
        {
            var result = await Task.Run(() => (value1 + value2));
            Thread.Sleep(10000);
            return result;
        }

        private async Task<int> Subraction(int value1, int value2)
        {
            var result = await Task.Run(() => (value1 - value2));
            return result;
        }

        private async Task<int> Multiply(int value1, int value2)
        {
            //Thread.Sleep(20000);
            var result = await Task.Run(() => (value1 * value2));
            return result;
        }

    }
}
