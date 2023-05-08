using ShopPanel.Entity.DTOs.Stores;

namespace ShopPanel.Business.Services.Abstract
{
	public interface IStoreService
	{
		Task<List<StoreDto>> GetAllStoresWithNonDeleted();
	}
}
