using AutoMapper;
using ShopPanel.Entity.DTOs.Products;
using ShopPanel.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.Business.AutoMapper.Productd
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductDto, Product>().ReverseMap();
			CreateMap<ProductUpdateDto, Product>().ReverseMap();
			CreateMap<ProductUpdateDto, ProductDto>().ReverseMap();
		}
	}
}
