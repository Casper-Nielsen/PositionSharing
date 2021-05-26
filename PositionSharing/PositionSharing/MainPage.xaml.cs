using PositionSharing.Communication;
using PositionSharing.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PositionSharing.Action;
using Xamarin.Forms;

namespace PositionSharing
{
    public partial class MainPage : ContentPage
    {
        private ActionHandler handler;
        public MainPage()
        {
            InitializeComponent();
            handler = new ActionHandler(new SocketCommunicationManager(), new LocalDBManager());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            View.Content = null;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            View.Content = new view.GroupView(ref handler);
        }
    }
}
