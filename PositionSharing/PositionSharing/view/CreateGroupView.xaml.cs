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
    public partial class CreateGroupView : ContentView
    {
        private Action.ActionHandler handler;
        private GroupView groupAdding;
        public CreateGroupView(ref Action.ActionHandler handler, ref GroupView groupAdding)
        {
            this.handler = handler;
            this.groupAdding = groupAdding;
            InitializeComponent();
        }

        /// <summary>
        /// create button clicks method
        /// </summary>
        private void Button_Clicked(object sender, EventArgs e)
        {
            Task.Run(Button_ClickedAsync);
        }

        /// <summary>
        /// async task for creating a group
        /// </summary>
        /// <returns></returns>
        private async Task Button_ClickedAsync()
        {
            string groupName = GroupName.Text;
            string username = Username.Text;
            handler.Username = username;
            groupAdding.ChangeVisiblePopup(false);
            groupAdding.Add(await handler.CreateGroupAsync(groupName));
        }
    }
}