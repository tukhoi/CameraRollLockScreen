using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Davang.Utilities.Extensions;
using CameraRollLockscreen.WP.ViewModels;
using System.IO;
using System.Windows.Media.Imaging;

namespace CameraRollLockscreen.WP.Code
{
    public class AlbumService
    {
        public IList<MyAlbum> GetAllAlbums() 
        {
            var albums = GetPictureAlbums();
            if (albums == null || albums.Count == 0) return null;

            var myAlbums = new List<MyAlbum>();
            albums.ForEach(a =>
                {
                    var myAlbum = new MyAlbum(a);
                    myAlbum.PhotoCount = a.Pictures.Count;
                    if (a.Pictures.Count > 0)
                    {
                        var fileStream = a.Pictures[0].GetThumbnail();
                        var bitmapImage = new BitmapImage();
                        bitmapImage.SetSource(a.Pictures[0].GetThumbnail());
                        myAlbum.ThumbnailPhoto = bitmapImage;
                    }

                    

                    myAlbums.Add(myAlbum);
                });

            return myAlbums;
        }

        private IList<PictureAlbum> GetPictureAlbums()
        {
            var library = new MediaLibrary();
            return library.RootPictureAlbum.Albums.ToList();
        }
    }
}
