using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public enum ShippingOption
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Courier")]
        Courier = 1,
        [Display(Name = "Postal Service")]
        PostalService = 2,

    }
}
