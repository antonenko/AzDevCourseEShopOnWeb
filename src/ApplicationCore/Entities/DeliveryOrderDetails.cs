using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class DeliveryOrderDetails
    {
        public DeliveryOrderDetails(int basketId, IReadOnlyCollection<OrderItem> items, Address address)
        {
            Id = Guid.NewGuid();
            BasketId = basketId;
            Items = items;
            Address = address;
            Price = CalculateFinalPrice();
        }
        public Guid Id { get; set; }
        
        public int BasketId { get; set; }

        public IReadOnlyCollection<OrderItem> Items { get; set; }

        public Address Address { get; set; }

        public decimal Price { get; set; }

        public decimal CalculateFinalPrice()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Units), 2);
        }
    }
}
