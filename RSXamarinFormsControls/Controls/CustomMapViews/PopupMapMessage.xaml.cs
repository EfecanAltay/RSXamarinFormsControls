using System;
using InfiniMobile.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;

namespace InfiniMobile.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupMapMessage
    {
        public event EventHandler InnerButton_Clicked;

        public bool DialogResult = false;
        public object Data = null;
        public ActionType actionType;

        public enum ActionType
        {
            Plan, GoLocation, Others
        }

        public PopupMapMessage(MessageData messageData)
        {
            InitializeComponent();
            BindingContext = messageData;
        }

        protected override bool OnBackgroundClicked()
        {
            IsVisible = false;
            return base.OnBackgroundClicked();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (sender == btnPlan)
                actionType = ActionType.Plan;
            else if (sender == btnGoLocation)
                actionType = ActionType.GoLocation;
            else if (sender == btnOthers)
                actionType = ActionType.Others;
            
            IsVisible = false;

            if(InnerButton_Clicked != null)
            {
                InnerButton_Clicked(this, e);
            }
            await PopupNavigation.Instance.PopAsync();
        }

            

    }
}
