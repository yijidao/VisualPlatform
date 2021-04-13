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
    /// SourceView1.xaml 的交互逻辑
    /// </summary>
    public partial class SourceView1 
    {
        public SourceView1()
        {
            InitializeComponent();

            ViewModel = new SourceViewModel1();
            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.Sources, v => v.source.ItemsSource).DisposeWith(d);
                this.Bind(ViewModel, vm => vm.SelectedSource, v => v.source.SelectedValue).DisposeWith(d);
            });

        }
    }
}
