using System;
using Xamarin.Forms;

namespace RSXamarinFormsControls.Controls
{
    public class RSCounter : RSLabelPicker
    {
        private int currentValue = 0;
        private int waitingValue = 0;
        private bool startedLongTapTimer = false;
        public RSCounter()
        {
            SetValueText("0");
            EntryComponent.Keyboard = Keyboard.Numeric;
        }

        public override void TouchEffect_Plus_LongTouchAction()
        {
            base.TouchEffect_Plus_LongTouchAction();
            startedLongTapTimer = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(200), LongTappedPlusTask);
        }

        public override void TouchEffect_Minus_LongTouchAction()
        {
            base.TouchEffect_Minus_LongTouchAction();
            startedLongTapTimer = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(200), LongTappedMinusTask);
        }

        public override void TouchEffect_Plus_TouchAction()
        {
            base.TouchEffect_Plus_TouchAction();
            currentValue++;
            SetValueText($"{currentValue}");
        }

        public override void TouchEffect_Minus_TouchAction()
        {
            base.TouchEffect_Minus_TouchAction();
            if (currentValue >= 1)
            {
                currentValue--;
            }
            else
            {
                currentValue = 0;
            }
            SetValueText($"{currentValue}");
        }

        public override void TouchEffect_Minus_ReleasedTouchAction()
        {
            base.TouchEffect_Minus_TouchAction();
            startedLongTapTimer = false;
        }

        public override void TouchEffect_Plus_ReleasedTouchAction()
        {
            base.TouchEffect_Minus_TouchAction();
            startedLongTapTimer = false;
            waitingValue = 0;
        }

        public bool LongTappedPlusTask()
        {
            waitingValue++;
            if (waitingValue == 5)
            {
                Device.StartTimer(TimeSpan.FromMilliseconds(100), LongTappedPlusTask);
                return false;
            }
            else if (waitingValue == 10)
            {
                Device.StartTimer(TimeSpan.FromMilliseconds(70), LongTappedPlusTask);
                return false;
            }
            currentValue += 10;
            SetValueText($"{currentValue}");
            return startedLongTapTimer;
        }

        public bool LongTappedMinusTask()
        {
            waitingValue++;
            if (waitingValue == 5)
            {
                Device.StartTimer(TimeSpan.FromMilliseconds(100), LongTappedMinusTask);
                return false;
            }
            else if (waitingValue == 10)
            {
                Device.StartTimer(TimeSpan.FromMilliseconds(70), LongTappedMinusTask);
                return false;
            }

            if (currentValue - 10 >= 1)
            {
                currentValue -= 10;
            }
            else
            {
                currentValue = 0;
            }
            SetValueText($"{currentValue}");
            return startedLongTapTimer;
        }
    }
}
