﻿using System;
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
        public BaseViewModel()
        {
            CreateDate = Convert.ToDateTime(PersianCalender.PersianCalender.GetDate());
            IsDeleted = false;
            IsActive = true;
        }
        public int Id { get; set; }
        [Display(Name = nameof(Resources.Resource.CreateDate), ResourceType = typeof(Resources.Resource))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime? CreateDate { get; set; }
        [Display(Name = nameof(Resources.Resource.ModifeDate), ResourceType = typeof(Resources.Resource))]
        public DateTime? ModifeDate { get; set; }
        [Display(Name = nameof(Resources.Resource.IsDeleted), ResourceType = typeof(Resources.Resource))]
        public bool IsDeleted { get; set; }

        [Display(Name = nameof(Resources.Resource.IsActive), ResourceType = typeof(Resources.Resource))]
        public bool IsActive { get; set; }
    }
}
