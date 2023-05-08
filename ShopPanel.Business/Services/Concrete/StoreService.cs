using AutoMapper;
using ShopPanel.Business.Services.Abstract;
using ShopPanel.DataAccess.UnitOfWorks;
using ShopPanel.Entity.DTOs.Stores;
using ShopPanel.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.Business.Services.Concrete
{
	public class StoreService : IStoreService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}
		public async Task<List<StoreDto>> GetAllStoresWithNonDeleted()
		{
			var stores = await unitOfWork.GetRepository<Store>().GetAllAsync(x => !x.IsDeleted);
			var map = mapper.Map<List<StoreDto>>(stores);

			return map;
		}
	}
}