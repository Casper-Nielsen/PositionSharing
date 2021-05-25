using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PositionSharing.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateGroupView : ContentView
    {
        private Action.ActionHandler handler;
        public CreateGroupView(ref Action.ActionHandler handler)
        {
            this.handler = handler;
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string groupName = GroupName.Text;
            string username = Username.Text;
            handler.Username = username;
            _ = handler.CreateGroupAsync(groupName);
        }
    }
}