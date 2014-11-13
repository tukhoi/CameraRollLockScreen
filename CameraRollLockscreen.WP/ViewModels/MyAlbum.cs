using CameraRollLockscreen.WP.Code;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CameraRollLockscreen.WP.ViewModels
{
    public class MyAlbum
    {
        public PictureAlbum PictureAlbum { get; set; }

        public int PhotoCount { get; set; }
        public BitmapImage ThumbnailPhoto { get; set; }
        public string Name { get; set; }
        public Uri BackgroundImageUri 
        { 
            get 
            {
                if (!string.IsNullOrEmpty(AppConfig.SelectedAlbum) && Name.Equals(AppConfig.SelectedAlbum))
                    return new Uri("/Resources/background2.png");
                return null;
            }
        }
        //public bool Selected { get; set; }

        public MyAlbum(PictureAlbum pictureAlbum)
        {
            PictureAlbum = pictureAlbum;
            Name = pictureAlbum.Name;
        }
    }
}
