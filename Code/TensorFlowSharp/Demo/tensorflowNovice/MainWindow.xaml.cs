using System;
using System.Text;
using System.Windows;
using TensorFlow;

namespace tensorflowNovice
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //使用NuGet安装，在工具--NuGet包管理器--程序包管理器控制台
            //Install-Package TensorFlowSharp
            //http://wiki.jikexueyuan.com/project/tensorflow-zh/ 教程
        }
        public void AddTwoNumbers()
        {
            using (var session = new TFSession())
            {
                var graph = session.Graph;
                int one = Convert.ToInt32(tb_one.Text.Trim().ToString());
                int two = Convert.ToInt32(tb_two.Text.Trim().ToString());
                var numberOne = graph.Const(one);
                var numberTwo = graph.Const(two);


                // 两常量加
                var addingResults = session.GetRunner().Run(graph.Add(numberOne,numberTwo));
                var addingResultValue = addingResults.GetValue();
                tb_content.Text = addingResultValue.ToString();

            }
        }

        private void Btn_calculator_Click(object sender, RoutedEventArgs e)
        {
            AddTwoNumbers();
        }

        private void Btn_MoverImageRecognition_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
