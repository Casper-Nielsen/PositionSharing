using PositionSharing.Action;
using PositionSharing.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PositionSharing.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupView : ContentView
    {
        private ObservableCollection<Group> groups = new ObservableCollection<Group>();
        private ActionHandler handler;
        private GroupView context;
        public GroupView(ref ActionHandler handler)
        {
            this.handler = handler;
            InitializeComponent();
            GroupsView.ItemsSource = groups;
            this.context = this;

            // Gets all the groups
            Task.Run(() =>
            {
                List<Group> group = this.handler.GetLocalGroups();
                foreach (Group item in group)
                {
                    groups.Add(item);
                }
            });
        }

        /// <summary>
        /// opens settings for that group
        /// </summary>
        private void GroupsView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Group group = (Group)e.SelectedItem;
            ChangePopup(true, new GroupSettingsView(ref handler, ref this.context, group));
        }

        /// <summary>
        /// sets the popup to the join view
        /// </summary>
        private void Joinbtn_Clicked(object sender, EventArgs e)
        {
            ChangePopup(false, null);
        }

        /// <summary>
        /// sets the popup to the create view
        /// </summary>
        private void Createbtn_Clicked(object sender, EventArgs e)
        {
            ChangePopup(true, new CreateGroupView(ref handler, ref this.context));
        }

        /// <summary>
        /// removes the popup
        /// </summary>
        private void openArea_Clicked(object sender, EventArgs e)
        {
            ChangePopup(false, null);
        }

        /// <summary>
        /// changes the popup visibility
        /// </summary>
        /// <param name="isVisible">the visibility</param>
        public void ChangeVisiblePopup(bool isVisible)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (isVisible)
                {
                    Popup.Opacity = 0;
                    Popup.FadeTo(1);
                }
                else
                {
                    Task fade = Popup.FadeTo(0);
                }
                OpenAreaBottombtn.IsVisible = isVisible;
                OpenAreaTopbtn.IsVisible = isVisible;
                Popup.IsVisible = isVisible;
            });
        }

        /// <summary>
        /// changes the popup state
        /// </summary>
        /// <param name="isVisible">the visibility</param>
        /// <param name="view">the view that will be loaded into the popup</param>
        private void ChangePopup(bool isVisible, View view)
        {
            ChangeVisiblePopup(isVisible);
            Device.BeginInvokeOnMainThread(() =>
            {
                if (IsVisible)
                {
                    Popup.Content = view;
                }
                else
                {
                    Popup.Content = null;
                }
            });
        }

        /// <summary>
        /// addes a group to the list
        /// </summary>
        /// <param name="group">the group to be added</param>
        public void Add(Group group)
        {
            if (group != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    groups.Add(group);
                });
            }
            ChangePopup(false, null);
        }

        /// <summary>
        /// Closes the popup
        /// </summary>
        public void ClosePopup()
        {
            ChangePopup(false, null);
        }
    }
}