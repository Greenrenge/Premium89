﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Premium89.Models.Themes
{
    public static class MasterMenu
    {
        public static NavMenuModel NavMenu { get; set; }

        internal static void Initialize(string prefixUrl)
        {
            NavMenuModel nav = new NavMenuModel();
            Menu Home = new Menu
            {
                DisplayText = "HOME",
                MenuName="Home",
                Link = prefixUrl + "/Home/Index",
                Order = 0
            };

            Menu Shop = new Menu
            {
                DisplayText = "SHOP",
                MenuName = "Shop",
                Link = prefixUrl + "/Shop/Items",
                Order = 1
            };

            Menu Gallery = new Menu
            {
                DisplayText = "GALLERY",
                MenuName = "Gallery",
                Order = 2,
            };
            Menu Mobile = new Menu
            {
                DisplayText = "MOBILE",
                MenuName = "Mobile",
                Order = 1,
            };
            Menu Nokia = new Menu
            {
                DisplayText = "NOKIA",
                MenuName = "Nokia",
                Order = 1,
            };
            Menu _3310 = new Menu
            {
                DisplayText = "NOKIA 3310",
                MenuName = "Nokia3310",
                Order = 1,
            };
            Nokia.ChildMenus.Add(_3310);
            Mobile.ChildMenus.Add(Nokia);

            Menu TV = new Menu
            {
                DisplayText = "TV",
                MenuName = "TV",
                Link = prefixUrl + "/Shop/Items",
                Order = 2,
            };
            Gallery.ChildMenus.Add(Mobile);
            Gallery.ChildMenus.Add(TV);




            Menu About = new Menu
            {
                DisplayText = "ABOUT",
                MenuName = "About",
                Link = prefixUrl + "/Shop/Items",
                Order = 3
            };
            Menu Contact = new Menu
            {
                DisplayText = "CONTACT",
                MenuName = "Contact",
                Link = prefixUrl + "/Shop/Items",
                Order = 4
            };
            nav.AddRoot(Home);
            nav.AddRoot(Shop);
            nav.AddRoot(Gallery);
            nav.AddRoot(About);
            nav.AddRoot(Contact);
            NavMenu = nav;
        }
    }
}