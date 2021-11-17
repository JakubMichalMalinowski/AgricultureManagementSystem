using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public enum HeaderType
    {
        [Display(Name = "Przystawka zbożowa")]
        GrainHeader,

        [Display(Name = "Przystawka do kukurydzy")]
        CornHeader,

        [Display(Name = "Przystawka do słonecznika")]
        SunflowerHeader
    }
}
