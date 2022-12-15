using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DynamicDropdown.ViewModels
{
    public class IndexViewModel
    {
        [Required(ErrorMessage = "Province is required.")]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "District is required.")]
        public int DistrictId { get; set; }

        [Required(ErrorMessage = "Municipality is required.")]
        public int MunicipalityId { get; set; }

        public SelectList? ProvinceDrop { get; set; }
        public SelectList? DistrictDrop { get; set; }
        public SelectList? MunicipalityDrop { get; set; }
    }
}
