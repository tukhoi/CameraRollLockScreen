using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CameraRollLockscreen.WP.Resources;
using Windows.Storage;
using System.Threading.Tasks;
using Davang.Utilities.Extensions;
using Microsoft.Xna.Framework.Media;
using CameraRollLockscreen.WP.Code;
using CameraRollLockscreen.WP.ViewModels;

namespace CameraRollLockscreen.WP
{
    public partial class MainPage : MyPage
    {
        AlbumService albumService = new AlbumService();

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await Binding();
        }

        private async Task Binding()
        {
            var hubTiles = albumService.GetAllAlbums();
            this.lstAlbums.ItemsSource = hubTiles;
        }

        private async void HubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var tileItem = sender as HubTile;
            if (tileItem == null) return;

            AppConfig.SelectedAlbum = tileItem.Title;
            await Binding();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}