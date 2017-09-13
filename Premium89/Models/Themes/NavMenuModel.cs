using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Premium89.Models.Themes
{
    public class NavMenuModel
    {
        private List<Menu> _rootMenu;
        public NavMenuModel()
        {
            _rootMenu = new List<Menu>();
        }
        public List<Menu> RootMenu
        {
            get { return _rootMenu; }
            set { _rootMenu = value; }
        }
        public void AddRoot(Menu menu)
        {
            _rootMenu.Add(menu);
        }
        public string Render(string activeMenuName = null)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var menu in _rootMenu.OrderBy(x=>x.Order))
            {
                bool IsActive = activeMenuName == menu.MenuName;
                if (menu.HasChild)
                {
                    sb.AppendFormat(@"
                                    <li class='dropdown xt-drop-nav'>
                                    <a href='' class='dropdown-toggle' data-toggle='dropdown' data-hover='dropdown'>
                                       {0} <span class='caret'></span>
                                    </a>
                                        <ul class='dropdown-menu'>
                                        ", menu.DisplayText);
                    foreach (var firstLevelChild in menu.ChildMenus.OrderBy(x => x.Order))
                    {
                        if (firstLevelChild.HasChild)
                        {
                            sb.AppendLine(RenderChild(firstLevelChild));
                        }
                        else
                        {
                            sb.AppendFormat(@"<li><a href='{0}'>{1}</a></li>", menu.Link, menu.DisplayText);
                        }
                    }

                    sb.Append(@"
                                        </ul>
                                    </li>");
                }
                else
                {
                    sb.AppendFormat(@"<li{0}><a href='{1}'>{2}</a></li>", IsActive ? " class'active'" : string.Empty, menu.Link, menu.DisplayText);
                }


            }
            return sb.ToString();
        }
        public string RenderChild(Menu menu)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
                                            <li class='dropdown'>
                                            <a href='#'>{0}</a>
                                                <ul class='dropdown-menu'>
                                                ", menu.DisplayText);

            foreach (var child in menu.ChildMenus.OrderBy(x => x.Order))
            {
                if (child.HasChild)
                {
                    sb.Append(RenderChild(child));
                }
                else
                {
                    sb.AppendFormat(@"<li><a href='{0}'>{1}</a></li>", child.Link, child.DisplayText);
                }
            }

            sb.Append(@"
                                                </ul>
                                            </li>");
            return sb.ToString();
        }
    }

    public class Menu
    {
        public Menu()
        {
            ChildMenus = new List<Menu>();
        }
        public string MenuName { get; set; }
        public string DisplayText { get; set; }
        public string Link { get; set; }
        public short Order { get; set; }
        public bool HasChild { get { return ChildMenus.Count > 0; } }
        public List<Menu> ChildMenus { get; set; }
    }
}