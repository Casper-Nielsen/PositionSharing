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

            // Fills the view with the information from the group
            TitleLabel.Text = this.group.Title;
            KeyLabel.Text = this.group.GroupKey;
            UserKeyLabel.Text = this.group.UserGroupKey;
        }

        /// <summary>
        /// returns to listview
        /// </summary>
        private void Backbtn_Clicked(object sender, EventArgs e)
        {
            groupView.ClosePopup();
        }

        /// <summary>
        /// leaves the group
        /// </summary>
        private void LeaveGroupbtn_Clicked(object sender, EventArgs e)
        {
            Task.Run(LeaveGroupbtn_ClickedAsync);
        }

        /// <summary>
        /// async method for leave group botton
        /// </summary>
        private async Task LeaveGroupbtn_ClickedAsync()
        {
            await handler.LeaveGroup(group);
            groupView.RemoveGroup(group);
        }
    }
}