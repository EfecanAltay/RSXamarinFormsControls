using System;
using System.Collections.Generic;
using System.Text;
using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.iOS.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPullToRefreshScrollView), typeof(CustomPullToRefreshScrollViewRenderer))]
namespace RSXamarinFormsControls.iOS.CustomRenderer
{
    public class CustomPullToRefreshScrollViewRenderer : ScrollViewRenderer
    {
        private FormsUIRefreshControl refreshControl;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (refreshControl != null)
                return;

            var pullToRefreshScrollView = (CustomPullToRefreshScrollView)Element;
            pullToRefreshScrollView.PropertyChanged += OnElementPropertyChanged;

            refreshControl = new FormsUIRefreshControl
            {
                RefreshCommand = pullToRefreshScrollView.RefreshCommand,
                Message = pullToRefreshScrollView.Message
            };

            AlwaysBounceVertical = true;

            AddSubview(refreshControl);
        }

        private void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var pullToRefreshScrollView = Element as CustomPullToRefreshScrollView;
            if (pullToRefreshScrollView == null)
                return;

            if (e.PropertyName == CustomPullToRefreshScrollView.IsRefreshingProperty.PropertyName)
                refreshControl.IsRefreshing = pullToRefreshScrollView.IsRefreshing;
            else if (e.PropertyName == CustomPullToRefreshScrollView.MessageProperty.PropertyName)
                refreshControl.Message = pullToRefreshScrollView.Message;
            else if (e.PropertyName == CustomPullToRefreshScrollView.RefreshCommandProperty.PropertyName)
                refreshControl.RefreshCommand = pullToRefreshScrollView.RefreshCommand;
        }
    }
}