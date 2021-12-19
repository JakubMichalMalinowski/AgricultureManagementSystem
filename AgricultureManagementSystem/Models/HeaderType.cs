using System.ComponentModel.DataAnnotations;

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
