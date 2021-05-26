using PositionSharing.Model;
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
    public partial class GroupSettingsView : ContentView
    {
        Action.ActionHandler handler;
        GroupView groupView;
        Group group;
        
        public GroupSettingsView(ref Action.ActionHandler handler, ref GroupView groupView, Group group)
        {
            this.handler = handler;
            this.groupView = groupView;
            this.group = group;
            InitializeComponent();
        }

        private void Backbtn_Clicked(object sender, EventArgs e)
        {
            groupView.ClosePopup();
        }

        private void LeaveGroupbtn_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}