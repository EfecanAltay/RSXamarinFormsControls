using System;
using System.Collections.Generic;
using System.Text;

namespace RSXamarinFormsControls.CustomControls.CustomMapViews
{
    public class PinData
    {
        public BindingPinType BindingPinType { get; set; }
        public BindingPinCardType BindingPinCardType { get; set; }
        public string Title { get; set; }
        public string Adress { get; set; }
        public bool IsActive { get; set; }
        public double Cost { get; set; }
    }
}
