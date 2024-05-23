using Domain_Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Domain_Models.Type;

namespace InfraStructure.ViewModels
{

    //View model used for property list on home page
    public class PropertyVm
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public string Image { get; set; } = null!;
        //public IFormFile ImageFile { get; set; }

        public int Size { get; set; }

        public int Baths { get; set; }

        public int Rooms { get; set; }
        public string Address { get; set; } = null!;
        public string choise { get; set; }
        public string type { get; set; }
        public string owner { get; set; }


    }


    //View model used for add new property by owner
    public class PropertyCreatVm
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = null!;


        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1 lac and 10000 lacs.")]
        public decimal Price { get; set; }


        public string Image { get; set; } = null!;


        [Display(Name = "Upload Image")]
        [Required(ErrorMessage = "Image is required.")]

        public IFormFile ImageFile { get; set; }


        [Display(Name = "Size")]
        [Required(ErrorMessage = "Size is required.")]
        [Range(1, 1000, ErrorMessage = "Size must be between 1 and 1000 marla")]
        public int Size { get; set; }


        [Display(Name = "Baths")]
        [Required(ErrorMessage = "Baths is required.")]
        [Range(1, 1000, ErrorMessage = "No. of baths must be between 0 and 1000")]
        public int Baths { get; set; }


        [Display(Name = "Rooms")]
        [Required(ErrorMessage = "Rooms is required.")]
        [Range(1, 1000, ErrorMessage = "No. of rooms must be between 0 and 1000")]
        public int Rooms { get; set; }


        [Display(Name = "Choise")]
        [Required(ErrorMessage = "Choise is required.")]
        public int? ChoiseId { get; set; }


        [Display(Name = "Type")]
        [Required(ErrorMessage = "Type is required.")]
        public int? TypeId { get; set; }


        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required.")]

        public string Address { get; set; } = null!;


        [Display(Name = "Owner")]
        [Required(ErrorMessage = "Owner is required.")]
        public int OwnerId { get; set; }

        public List<TypeVm> types { get; set;}
        public List<ChoiseVm> choises { get; set; }

    }


    //View model used for property list on home page
    public class PropertyTypesCountVm
    {
        public int ApartmentCount { get; set; }
        public int HomeCount { get; set; }
        public int OfficeCount { get; set; }
        public int BuildingCount { get; set; }
        public int TownHouseCount { get; set; }
        public int VillCount { get; set; }

    }

    //View model include search dropdowns , property list and Property Count for home page
    public class PropertyListPlusTypeVm
    {
        public List<TypeVm> types { get; set; }
        public List<ChoiseVm> choises { get; set; }
        public List<PropertyVm> propertyList { get; set; }
        public PropertyTypesCountVm propertyTypesCountVm { get; set; }

    }

    //View model to show all details of specific property
    public class PropertyDetailsVm
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public string Image { get; set; } = null!;

        public int Size { get; set; }

        public int Baths { get; set; }

        public int Rooms { get; set; }
        public string Address { get; set; } = null!;
        public string Choise { get; set; }
        public string Type { get; set; }

        [Display(Name = "Owner Name")]
        public string ownerName { get; set; }

        [Display(Name = "Owner Contact")]
        public string ownerContact { get; set; }

        [Display(Name = "Owner Email")]
        public string ownerEmail { get; set; }
    }

}
