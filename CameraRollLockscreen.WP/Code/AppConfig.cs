using Davang.Utilities.Config;
using Davang.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraRollLockscreen.WP.Code
{
    public class AppConfig : BaseAppConfig<ConfigKey>
    {
        public static string SelectedAlbum
        {
            get
            {
                return GetConfig<string>(ConfigKey.SelectedAlbum, string.Empty);
            }
            set
            {
                SetConfig<string>(ConfigKey.SelectedAlbum, value);
            }
        }
    }

    public enum ConfigKey
    {
        ClientId,
        SelectedAlbum
    }
}
