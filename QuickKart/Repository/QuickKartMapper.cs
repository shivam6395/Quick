using AutoMapper;
using QuickKartDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickKart.Repository
{
   public class QuickKartMapper:Profile
    {
        public QuickKartMapper()
        {
            CreateMap<Products, Models.Products>();
            CreateMap<Models.Products, Products>();
            CreateMap<Categories, Models.Categories>();
            CreateMap<Models.Categories, Categories>();
            CreateMap<PurchaseDetails, Models.PurchaseDetails>();
            CreateMap<Models.PurchaseDetails, PurchaseDetails>();


        }
    }
}
