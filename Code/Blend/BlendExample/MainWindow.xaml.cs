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

namespace BlendExample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //教程地址
            //https://www.cnblogs.com/hielvis/archive/2010/10/09/1846046.html
            //在Blend下提供一个VisualStateManger(VSM)来管理当前控件的状态，一个状态到另外一个状态的切换有很多属性值需要发生改变，这样就需要启动一个StoryBoard过渡不同的状态，而VSM则管理不同的状态。
            //包含关系
            //VSM-States-StoryBorad-Duration
        }
    }
}
