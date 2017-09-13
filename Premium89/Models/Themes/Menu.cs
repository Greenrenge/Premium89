using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Premium89.Models.Themes
{
    public class Menu
    {
        public Menu()
        {
            ChildMenus = new List<Menu>();
        }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public string DisplayText { get; set; }
        public string Link { get; set; }
        public short Order { get; set; }
        public bool HasChild { get { return ChildMenus.Count > 0; } }
        public List<Menu> ChildMenus { get; set; }
    }
}