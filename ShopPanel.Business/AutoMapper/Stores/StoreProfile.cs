using AutoMapper;
using ShopPanel.Entity.DTOs.Stores;
using ShopPanel.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.Business.AutoMapper.Stores
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<StoreDto, Store>().ReverseMap();
        }
    }
}
