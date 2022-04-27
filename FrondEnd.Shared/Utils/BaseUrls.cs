using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrondEnd.Shared.Utils
{
    /// <summary>
    /// Configure here the base api urls according to your env configs
    /// </summary>
    public static class BaseUrls
    {
#if DEBUG
        public const string BASE_URL = "https://localhost:7247";//dev api url for the project change it if your env gives you different url in the launch settings file
#elif RELEASE
        public const string BASE_URL =""; // prod api url if your backend is hosted somewhere on the internet put that base url here.
#endif
    }
}
