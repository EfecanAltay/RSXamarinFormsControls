using RSXamarinFormsControls.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace RSXamarinFormsControls.ViewModels
{
    public class TestPageViewModel : BaseViewModel
    {
        private ObservableCollection<MyData> mylist = new ObservableCollection<MyData>();

        public ObservableCollection<MyData> MyList
        {
            get { return mylist; }
            set
            {
                mylist = value;
                OnPropertyChanged("MyList");
            }
        }

        public List<string> myChatData = new List<string>();
        public int currentChatRow = 0;
        public bool chatStarted = false;

        public TestPageViewModel()
        {
            myChatData.Add("Hello");
            myChatData.Add("My name is Efecan");
            myChatData.Add("Thank You Your Interest");
            myChatData.Add("Xamarin Development");
            myChatData.Add("and My Codes");
            myChatData.Add("and New Ideas");
            myChatData.Add(":P :D");
            myChatData.Add("anyway");
            myChatData.Add("see Soon");
            myChatData.Add("and be carefull");
            myChatData.Add("in your Life");
            myChatData.Add("be best in your job");
            myChatData.Add("ok, its just BYE!");
        }

        public void StartChat(Action finisedAction = null)
        {
            mylist.Clear();
            currentChatRow = 0;
            chatStarted = true;
            Device.StartTimer(System.TimeSpan.FromSeconds(1), () =>
            {
                if (chatStarted == false)
                    return false;
                mylist.Add(new MyData() { data1 = myChatData[currentChatRow], data2 = currentChatRow + 1 });
                if (myChatData.Count > currentChatRow + 1)
                {
                    currentChatRow++;
                    return true;
                }
                finisedAction?.Invoke();
                return false;
            });
        }

        public void StopChat()
        {
            currentChatRow = 0;
            chatStarted = false;
        }
    }
}
