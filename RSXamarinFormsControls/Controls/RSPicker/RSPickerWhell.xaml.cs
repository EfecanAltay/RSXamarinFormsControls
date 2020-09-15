using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private double scrollIndexOffset = 20;
        private int maxNumber = 9;

        public int SelectedNumber => selectedIndex;

        public RSPickerWhell()
        {
            InitializeComponent();
            CreateItemView("");
            CreateItemView("");
            for (int i = 0; i < 100; i++)
            {
                CreateItemView(i.ToString());
            }
            lastSelected = Content.Children[0];
        }

        public void AddItem(View view)
        {
            ItemList.AddLast(view);
            Content.Children.Add(view);
            SelectedNode = ItemList.First;
        }

        double lastY = -99;
        Task addingTask = null;
        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            var currentY = e.ScrollY;
            bool isScrollDown = currentY > lastY;
            if (currentY != lastY)
            {

                selectedIndex = (int)(currentY / scrollIndexOffset);
                selected = Content.Children[selectedIndex + 2];
                selected.Scale = 2;
                if (lastSelected != selected)
                {
                    lastSelected.Scale = 1;
                    lastSelected = selected;
                }
                if (isScrollDown)
                {
                    if (selectedIndex > Content.Children.Count - 10)
                    {
                        if (addingTask == null || (addingTask != null && addingTask.IsCompleted))
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                for (int i = 0; i < 20; i++)
                                {
                                    CreateItemView(Content.Children.Count.ToString());
                                }
                            });
                        }
                    }
                }
                else
                {
                    //if (currentY < (scrollIndexOffset * selectedIndex) - 5)
                    //{
                    //    lastSelected = Content.Children[selectedIndex + 2];
                    //    selectedIndex = (int)(currentY / scrollIndexOffset);
                    //    selected = Content.Children[selectedIndex + 2];
                    //    selected.Scale = 2;
                    //    lastSelected.Scale = 1;
                    //}
                }

                /*
                if (isScrollDown)
                {
                    if (currentY > (scrollIndexOffset * selectedIndex) + 5)
                    {
                        lastSelected = Content.Children[selectedIndex + 2];
                        selectedIndex++;
                        selected = Content.Children[selectedIndex + 2];
                        selected.Scale = 2;
                        lastSelected.Scale = 1;
                        if (selectedIndex > Content.Children.Count - 8)
                        {
                            for (int i = 0; i < 50; i++)
                            {
                                CreateItemView(Content.Children.Count.ToString());
                            }
                        }
                    }
                    else
                    {

                    }
                }
                else if (selectedIndex != 0)
                {
                    if (currentY < (scrollIndexOffset * selectedIndex) - 5)
                    {
                        lastSelected = Content.Children[selectedIndex + 2];
                        selectedIndex--;
                        selected = Content.Children[selectedIndex + 2];
                        selected.Scale = 2;
                        lastSelected.Scale = 1;
                    }
                }
                */
                lastY = currentY;
            }
            else
            {
                await sView.ScrollToAsync(0, currentY, false);
            }
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
                TextColor = (Color)Application.Current.Resources["RSTextColor"],
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