using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace RSXamarinFormsControls.Controls
{
    public class RSPullToRefreshScrollView : ScrollView
    {
        public static readonly BindableProperty IsRefreshingProperty =
          BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(RSPullToRefreshScrollView), false);

        public static readonly BindableProperty RefreshCommandProperty =
            BindableProperty.Create(nameof(RefreshCommand), typeof(ICommand), typeof(RSPullToRefreshScrollView), null);

        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create(nameof(Message), typeof(string), typeof(RSPullToRefreshScrollView), String.Empty);

        public bool IsRefreshing
        {
            get { return (bool)GetValue(IsRefreshingProperty); }
            set { SetValue(IsRefreshingProperty, value); }
        }

        public ICommand RefreshCommand
        {
            get { return (ICommand)GetValue(RefreshCommandProperty); }
            set { SetValue(RefreshCommandProperty, value); }
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
    }
}
