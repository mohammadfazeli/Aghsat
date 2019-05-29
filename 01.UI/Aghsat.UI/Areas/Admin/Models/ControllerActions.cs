using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aghsat.UI.Areas.Admin.Models
{
    public class ControllerActions
    {
        public string Controller { get; set; }
        public string ControllerName { get; set; }
        public string ControllerIcon { get; set; }
        public string Action { get; set; }
        public string ActionName { get; set; }
        public string ActionIcon { get; set; }
        public string Attributes { get; set; }
        public string ReturnType { get; set; }
        public IEnumerable<ListControllers> ListControllers { get; set; }
    }

    public class ListControllers
    {
        public string Controller { get; set; }
        public string ControllerName { get; set; }
        public string ControllerIcon { get; set; }
        public IEnumerable<ListActions> ListActions { get; set; }

    }

    public class ListActions
    {
        public string Action { get; set; }
        public string ActionName { get; set; }
        public string ActionIcon { get; set; }
        public string Attributes { get; set; }
        public string ReturnType { get; set; }
    }


}