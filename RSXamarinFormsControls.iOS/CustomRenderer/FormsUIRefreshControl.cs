using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Foundation;
using UIKit;

namespace RSXamarinFormsControls.iOS.CustomRenderer
{
    public class FormsUIRefreshControl : UIRefreshControl
    {
        public FormsUIRefreshControl()
        {
            ValueChanged += (sender, e) =>
            {
                var command = RefreshCommand;
                if (command == null)
                    return;

                command.Execute(null);
            };
        }

        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                if (string.IsNullOrWhiteSpace(message))
                    return;

                this.AttributedTitle = new NSAttributedString(message);
            }
        }

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                if (_isRefreshing)
                    BeginRefreshing();
                else
                    EndRefreshing();
            }
        }

        public ICommand RefreshCommand { get; set; }
    }
}