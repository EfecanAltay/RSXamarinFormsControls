using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSLabelPicker : ContentView
    {
        public EventHandler<EventArgs> negativeButtonActionEvent { get; set; }
        public EventHandler<EventArgs> possitiveButtonActionEvent { get; set; }
        public EventHandler<EventArgs> negativeButtonLongActionEvent { get; set; }
        public EventHandler<EventArgs> possitiveButtonLongActionEvent { get; set; }
        public EventHandler<EventArgs> negativeButtonReleaseActionEvent { get; set; }
        public EventHandler<EventArgs> possitiveButtonReleaseActionEvent { get; set; }

        protected Entry EntryComponent => entry;

        public RSLabelPicker()
        {
            InitializeComponent();
        }

        public virtual void TouchEffect_Plus_LongTouchAction()
        {
            possitiveButtonLongActionEvent?.Invoke(this, new EventArgs());
        }

        public virtual void TouchEffect_Minus_LongTouchAction()
        {
            negativeButtonLongActionEvent?.Invoke(this, new EventArgs());
        }

        public virtual void TouchEffect_Plus_TouchAction()
        {
            possitiveButtonActionEvent?.Invoke(this, new EventArgs());
        }

        public virtual void TouchEffect_Minus_TouchAction()
        {
            negativeButtonActionEvent?.Invoke(this, new EventArgs());
        }

        public virtual void TouchEffect_Minus_ReleasedTouchAction()
        {
            negativeButtonReleaseActionEvent?.Invoke(this, new EventArgs());
        }

        public virtual void TouchEffect_Plus_ReleasedTouchAction()
        {
            possitiveButtonReleaseActionEvent?.Invoke(this, new EventArgs());
        }

        public void SetValueText(string valueText)
        {
            entry.Text = valueText;
        }

        private void TouchEffect_ReleasedTouchAction()
        {

        }
    }
}
