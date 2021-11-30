using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class DeliveryOrderDetails
    {
        public DeliveryOrderDetails(int id, IReadOnlyCollection<OrderItem> items, Address address)
        {
            Id = id;
            Items = items;
            Address = address;
            Price = CalculateFinalPrice();
        }
        public int Id { get; set; }

        public IReadOnlyCollection<OrderItem> Items { get; set; }

        public Address Address { get; set; }

        public decimal Price { get; set; }

        public decimal CalculateFinalPrice()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Units), 2);
        }
    }
}
