using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.ViewModel
{
    public class BaseViewModel
    {

        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime? CreateDate { get; set; } = Convert.ToDateTime(PersianCalender.PersianCalender.GetDate());
        public DateTime? ModifeDate { get; set; }

        [Display(Name = "IsDeleted", ResourceType = typeof(Resources.Resource))]
        public bool IsDeleted { get; set; } = false;

        [Display(Name = "IsActive", ResourceType = typeof(Resources.Resource))]
        public bool IsActive { get; set; } = true;
    }
}
