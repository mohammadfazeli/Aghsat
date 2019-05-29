using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aghsat.UI.Classes.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TitleAttribute : Attribute
    {
        public TitleAttribute(string title)
        {
            this.Title = title;
        }
        public string Title { get; set; }

    }
}