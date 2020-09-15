using System;
using Xamarin.Forms;

namespace RSXamarinFormsControls.Effects
{
    public class RSTouchEffect : RoutingEffect
    {
        public delegate void TouchActionEventHandler();
        public event TouchActionEventHandler TouchAction;
        public event TouchActionEventHandler LongTouchAction;
        public event TouchActionEventHandler ReleasedTouchAction;

        public RSTouchEffect() : base("Vapolia.TouchEffect")
        {

        }

        public void OnTouchAction()
        {
            TouchAction?.Invoke();
        }

        public void OnLongTouchAction()
        {
            LongTouchAction?.Invoke();
        }

        public void OnReleasedTouchAction()
        {
            ReleasedTouchAction?.Invoke();
        }
    }

    public enum TouchActionType
    {
        Entered,
        Pressed,
        Moved,
        Released,
        Exited,
        Cancelled
    }

    public class TouchActionEventArgs : EventArgs
    {
        public TouchActionEventArgs(long id, TouchActionType type, Point location, bool isInContact)
        {
            Id = id;
            Type = type;
            Location = location;
            IsInContact = isInContact;
        }

        public long Id { private set; get; }

        public TouchActionType Type { private set; get; }

        public Point Location { private set; get; }

        public bool IsInContact { private set; get; }
    }
}
