using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSSelection : ContentView
    {
        private Dictionary<string, RSToggle> list;
        public List<string> selectedTagList;
        public EventHandler<EventArgs> selectedTagListChanged;

        public RSSelection()
        {
            InitializeComponent();
            list = new Dictionary<string, RSToggle>();
            selectedTagList = new List<string>();
            tglAllTag.toggledCallback += TglAllTag_toggledCallback;
        }

        private void TglAllTag_toggledCallback(object sender, RSToggleButtonEventArgs e)
        {
            selectedTagList.Clear();
            if (e.IsActive)
            {
                foreach (var item in list)
                {
                    item.Value.SetActive(true);
                    selectedTagList.Add(item.Key);
                }
            }
            else
            {
                foreach (var item in list)
                {
                    item.Value.SetActive(false);
                }
            }
            selectedTagListChanged?.Invoke(sender, e);
        }

        public void AddItem(string text)
        {
            var tglButton = new RSToggle() { Text = text };
            tglButton.toggledCallback += TglButton_toggledCallback;
            if (list.ContainsKey(text) == false)
            {
                list.Add(text, tglButton);
            }
            stkContent.Children.Add(tglButton);
        }

        public void ClearTags()
        {
            selectedTagList.Clear();
            foreach (var item in list)
            {
                item.Value.SetActive(false);
            }
            tglAllTag.SetActive(false);
            selectedTagListChanged?.Invoke(null, null);
        }

        private void TglButton_toggledCallback(object sender, RSToggleButtonEventArgs e)
        {
            if (e.IsActive)
            {
                selectedTagList.Add(e.Text);
            }
            else
            {
                selectedTagList.Remove(e.Text);
            }
            selectedTagListChanged?.Invoke(sender, e);
        }
    }
}
