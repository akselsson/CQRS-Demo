using System;
using System.Collections.Generic;
using CQRSCode.ReadModel.Dtos;

namespace CQRSCode.ReadModel
{
    public interface IReadModelFacade
    {
        IEnumerable<InventoryItemListDto> GetInventoryItems();
        InventoryItemDetailsDto GetInventoryItemDetails(Guid id);
        ShoppingCartDTO GetShoppingCart(Guid id);
    }

    public class ShoppingCartDTO
    {
        public int Items;
        public bool FreeShipping;
    }
}