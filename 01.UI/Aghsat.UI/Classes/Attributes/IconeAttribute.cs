using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aghsat.UI.Classes.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IconeAttribute : Attribute
    {
        public IconeAttribute(string Icon)
        {
            this.Icon = Icon;
        }
        public string Icon { get; set; }
    }
}