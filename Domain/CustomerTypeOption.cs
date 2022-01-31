using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public enum CustomerTypeOption
    {
        [Display(Name = "Corporate")]
        Corporate = 0,
        [Display(Name = "Home/Office")]
        HomeOffice = 1,
        [Display(Name = "Student")]
        Student = 2
    }
}
