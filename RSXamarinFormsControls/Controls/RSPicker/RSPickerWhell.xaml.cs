using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSPickerWhell : ContentView
    {
        LinkedList<View> ItemList = new LinkedList<View>();
        public LinkedListNode<View> SelectedNode;

        public Action TappedAction = null;

        View lastSelected = null;
        View selected = null;

        private int selectedIndex = 0;
        private int scrollIndexOffset = 20;
        private int maxNumber = 9;

        public int SelectedNumber => selectedIndex;

        public RSPickerWhell()
        {
            InitializeComponent();
            CreateItemView("");
            CreateItemView("");
            CreateItemView("0");
            CreateItemView("1");
            CreateItemView("2");
            CreateItemView("3");
            CreateItemView("4");
            CreateItemView("5");
            CreateItemView("6");
            CreateItemView("7");
            CreateItemView("8");
            CreateItemView("9");
            lastSelected = Content.Children[0];
        }

        public void AddItem(View view)
        {
            ItemList.AddLast(view);
            Content.Children.Add(view);
            SelectedNode = ItemList.First;
        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            var y = e.ScrollY;
            if ((int)y > (scrollIndexOffset * selectedIndex) + 5)
            {
                lastSelected = Content.Children[selectedIndex + 2];
                selectedIndex++;
                selected = Content.Children[selectedIndex + 2];
                selected.Scale = 2;
                lastSelected.Scale = 1;
                if (selectedIndex > Content.Children.Count - 8)
                {
                    CreateItemView((selectedIndex + 5).ToString());
                }
                scrollView.ScrollToAsync(0, scrollIndexOffset * selectedIndex, false);
            }
            else if (selectedIndex != 0)
            {
                if ((int)y < (scrollIndexOffset * (selectedIndex)) - 5)
                {
                    lastSelected = Content.Children[selectedIndex + 2];
                    selectedIndex--;
                    selected = Content.Children[selectedIndex + 2];
                    selected.Scale = 2;
                    lastSelected.Scale = 1;
                    scrollView.ScrollToAsync(0, scrollIndexOffset * (selectedIndex), false);
                }
            }
            Debug.WriteLine($"{selectedIndex}");
        }

        private void CreateItemView(string text)
        {
            StackLayout stackLayout = new StackLayout()
            {
                HeightRequest = 20
            };
            stackLayout.Children.Add(new Label()
            {
                Text = text,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = (Color)Application.Current.Resources["TextColor"],
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                VerticalTextAlignment = TextAlignment.Center
            });
            Content.Children.Add(stackLayout);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            TappedAction?.Invoke();
        }
    }
}