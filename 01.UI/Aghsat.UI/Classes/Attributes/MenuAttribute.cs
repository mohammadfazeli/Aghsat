using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aghsat.UI.Classes.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MenuAttribute : Attribute
    {
        public MenuAttribute(bool ForMenu = true)
        {
            this.ForMenu = ForMenu;
        }
        public bool ForMenu { get; set; }
    }
}