using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DynamicData;
using ReactiveUI;
using  VisualPlatform_Common.ViewModels;

namespace VisualPlatform_Control.ViewModels
{
    public class SourceViewModel1 : BaseRuiViewModel
    {

        private ObservableCollection<string> _sources = new ObservableCollection<string>();
        public ObservableCollection<string> Sources
        {
            get => _sources;
            set => this.RaiseAndSetIfChanged(ref _sources, value);
        }

        private string _selectedSource;
        public string SelectedSource
        {
            get => _selectedSource;
            set => this.RaiseAndSetIfChanged(ref _selectedSource, value);
        }

        public SourceViewModel1()
        {
            Sources.Add("源1");
            Sources.Add("源2");
            Sources.Add("源3");
            Sources.Add("源4");
        }

    }
}
