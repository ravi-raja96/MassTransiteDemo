using System;
using AutoMapper;
using InventoryService.Entity;
using Model;

namespace InventoryService
{
    public class AutoMapperClass : Profile
    {
        public AutoMapperClass()
        {
            CreateMap<AddOrder,Order>();
            CreateMap<UpdateOrder,Order>();
        }
    }
}
