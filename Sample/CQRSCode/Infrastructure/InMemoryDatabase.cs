using System;
using System.Collections.Generic;
using CQRSCode.ReadModel;
using CQRSCode.ReadModel.Dtos;

namespace CQRSCode.Infrastructure
{
    public static class InMemoryDatabase 
    {
        public static Dictionary<Guid, InventoryItemDetailsDto> Details = new Dictionary<Guid,InventoryItemDetailsDto>();
        public static List<InventoryItemListDto> List = new List<InventoryItemListDto>();

        public static Dictionary<Guid, ShoppingCartDTO> ShoppingCart = new Dictionary<Guid, ShoppingCartDTO>();
    }
}