using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSTabMenu : ContentView
    {
        public event EventHandler<RSTabButtonEventArgs> tabButtonCallback;

        private ICollection<RSTabButton> _menuItemList = null;
        private RSTabButton _selectedButton = null;
        public string SelectedTag => _selectedButton?.Tag;

        public RSTabMenu()
        {
            InitializeComponent();
            _menuItemList = new ObservableCollection<RSTabButton>();
        }

        public bool AddMenuItem(RSTabItemData menuItem)
        {
            if (_menuItemList.Where(x => x.Tag == menuItem.Tag).Any() == false)
            {
                var element = new RSTabButton();
                element.tabButtonCallback += Element_tabButtonCallback; ;
                element.HorizontalOptions = LayoutOptions.FillAndExpand;
                element.VerticalOptions = LayoutOptions.FillAndExpand;
                element.SetMenuItemData(menuItem);
                _menuItemList.Add(element);
                int c = rootContent.Children.Count;
                Grid.SetColumn(element, c);
                rootContent.Children.Add(element);
                RefleshUI();
                return true;
            }
            return false;
        }

        public bool SelectItemWithTag(string tag)
        {
            var selectedItem = _menuItemList.Where(x => x.Tag == tag)?.First();
            if (selectedItem == null)
                return false;
            return SelectItem(selectedItem);
        }

        public bool SelectItem(RSTabButton selectButton)
        {
            if (_selectedButton == selectButton)
                return false;
            if (_selectedButton != null)
            {
                _selectedButton.IsActive = false;
            }
            _selectedButton = selectButton;
            _selectedButton.IsActive = true;
            return true;
        }

        private void Element_tabButtonCallback(object sender, RSTabButtonEventArgs e)
        {
            var customTabButton = (RSTabButton)sender;
            if (SelectItem(customTabButton))
                tabButtonCallback?.Invoke(this, e);
        }

        private void RefleshUI()
        {
            foreach (var Column in rootContent.ColumnDefinitions)
            {
                Column.Width = rootContent.Width / rootContent.Children.Count;
            }
        }
    }
}
