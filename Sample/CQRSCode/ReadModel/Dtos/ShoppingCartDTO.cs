using System.Collections.Generic;

namespace CQRSCode.ReadModel.Dtos
{
    public class ShoppingCartDTO
    {
        public int ItemCount;
        public List<ShoppingCartItemDTO> Items = new List<ShoppingCartItemDTO>();
    }

    public class ShoppingCartItemDTO
    {
        public string Name;
        
    }
}