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

namespace 感知机网络
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //感知机网络
            //如果输入为正或0.则该函数返回1，否则返回0，具有这种激活函数的神经元称为感知器。他是我们可以开发的最简单的神经网络形式。
            //感知器遵循前馈模型，意味着输入被传送到神经元，并被处理，然后产生输出。输入进来，输入结束。
            //假设有一个具有两个输入的感知器，，输入1为x1,输入2为x2
            //输入1 x1=12 输入2 x2=4
            //每个输入必须加权，即乘以某个值，该值通常介于-1到1之间，为他们随机分配权重， x1我们标记权重为w1 ,x2权重w2。
            //处理过程如下
            //       x1----------加权w1----->|----------| 
            //                               |加权后求和|----输出
            //       x2---------加权w2------>|----------|
            //对于每个输入，将该输入乘以其权重；
            //对于所有加权的输入求和。
            //根据通过激活函数的总和，来计算感知器的输出。
            //原因：将输入向量视为点的坐标，对于有N个元素的向量，改点将在N维空间中，拿一张纸，在这张纸上绘制一组点，然后用一条直线将这些点分成两组，
            //分为2组后，线的两边各一组，如果能用单条直线清楚的分离所有点，那么这两组点就是线性可分。 
            Perceptron p = new Perceptron(3);
            //输入是3个值，x、y偏差
            float[] point = { 5, -2, 19 };
            int result = p.feedforward(point);
            //通过创建train函数训练，来控制学习率
            float c = 0.01f;

            //根据提供的输入进行有根据的猜测
            //int guess = p.feedforward(inputs);



        }
    }
    public class Perceptron
    {
        float[] weights;
        public Perceptron(int n)
        {
            weights = new float[n];

            for (int i = 0; i < weights.Length; i++)
            {
                //随机选择权重
                weights[i] = random(-1, 1);
            }
        }
        Random _random = new Random();
        /// <summary>
        /// 生成最小值和最大值之间的一个随机数。保留1位小数
        /// </summary>
        /// <param name="minNum"></param>
        /// <param name="maxNum"></param>
        /// <returns></returns>
        private float random(int minNum, int maxNum)
        {
            float result = 0;
            //生成负数
            float negativeNum = _random.Next(1, Math.Abs(minNum) * 10) * (-0.1f);
            //生成正数
            float justNum = _random.Next(1, Math.Abs(maxNum) * 10) * 0.1f;

            int b = _random.Next(0, 100);
            if (b < 40)
            {
                result = negativeNum;
            }
            else
            {
                result = justNum;
            }
            return result;
        }
        /// <summary>
        /// 依据输入的值乘以权重。。x1*w1,x2*w2。每个数。乘以自己的权重。
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public int feedforward(float[] inputs)
        {
            float sum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                sum += inputs[i] * weights[i];
            }
            return activate(sum);
        }
        private int activate(float sum)
        {
            return (int)sum;
        }
    }
}
