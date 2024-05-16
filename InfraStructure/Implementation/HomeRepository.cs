using Domain_Models;
using InfraStructure.Interfaces;
using InfraStructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Implementation
{
    public class HomeRepository: IHomeRepository
    {
        public readonly IGenericRepository genericRepository;
        public readonly RealEstateContext db;
        public HomeRepository(IGenericRepository genericRepository,RealEstateContext realEstateContext) 
        {
             this.genericRepository = genericRepository;
            this.db = realEstateContext;
        }

        public async Task<List<PropertyVm>> PropertyList()
        {
           
            var results = await db.Properties
    .Select(p => new PropertyVm
    {
        Id = p.Id,
        Title = p.Title,
        Price = p.Price,
        Address = p.Address,
        Baths = p.Baths,
        Rooms = p.Rooms,
        Size = p.Size,
        Image = p.Image,
        choise = p.Choise != null ? p.Choise.Choise1 : "N/A",
        type = p.Type != null ? p.Type.Type1 : "N/A",
        owner = p.Owner != null ? p.Owner.FirstName : "N/A"
    })
    .ToListAsync();

            return results;
        }
    }
}
