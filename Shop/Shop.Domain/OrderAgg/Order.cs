using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public class Order:AggregateRoot
    {
        private Order()
        {

        }
        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pennding;
            Items = new List<OrderItem>();
        }

        public long  UserId { get; private set; }

        public OrderStatus Status { get; private set; }

        public OrderDiscount? Discount { get; private set; }
        public OrderAddress? Address { get; private set; }
        public ShippingMethod? ShippingMethod { get; private set; }

        public List<OrderItem> Items { get; private set; }

        public DateTime? LastUpdate { get; private set; }
        public int TotalPrice { get { 
            
                var totalPrice = Items.Sum(x => x.Price);
                if(ShippingMethod !=null)
                {
                    totalPrice += ShippingMethod.ShippingCost;
                }
                if(Discount != null)
                {
                    totalPrice -= Discount.DiscountAmount;
                }
                return totalPrice;
            } 
        }

        public int ItemCount => Items.Count;



        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }


        public void RemoveItem(long itemId)
        {
            var curentItem = Items.FirstOrDefault(p => p.Id == itemId);
            if (curentItem != null)
            {
                Items.Remove(curentItem);
            }

        }

        public void ChangeCountItem(long itemId, int newCount)
        {
            var curentItem = Items.FirstOrDefault(p => p.Id == itemId);
                if(curentItem == null)
                    throw new NullOrEmptyDomainDataException();
                curentItem.ChangeCount(newCount);
        }


        public void  ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.UtcNow;
        }


        public void Checkout(OrderAddress orderAddress)
        {
            Address = orderAddress;
        }

    }
}
