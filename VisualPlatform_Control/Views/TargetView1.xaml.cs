using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveUI;
using VisualPlatform_Control.ViewModels;

namespace VisualPlatform_Control.Views
{
    /// <summary>
    /// TargetView1.xaml 的交互逻辑
    /// </summary>
    public partial class TargetView1 
    {
        public TargetView1()
        {
            InitializeComponent();
            ViewModel = new TargetViewModel1();

            this.WhenActivated(d =>
            {
                this.Bind(ViewModel, vm => vm.Value, v => v.textBlock1.Text).DisposeWith(d);
            });

        }
    }
}
