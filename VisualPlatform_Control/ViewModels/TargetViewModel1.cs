using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using VisualPlatform_Common.ViewModels;

namespace VisualPlatform_Control.ViewModels
{
    public class TargetViewModel1 : BaseRuiViewModel
    {
        private string _value;
        public string Value
        {
            get => _value;
            set => this.RaiseAndSetIfChanged(ref _value, value);
        }

    }
}
