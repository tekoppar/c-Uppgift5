using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5.Classes
{
    public enum OrderType : int
    {
        Null = -1,
        RepairOrder,
        UpgradeOrder,
        WaresOrder
    }

    public class OrderSystem
    {
        static public OrderSystem GOS = new OrderSystem();
        private Dictionary<int, Order> Orders = new Dictionary<int, Order>();
        public OrderSystem()
        {

        }

        public int GenerateOrderNumber()
        {
            int newOrderNumber = new Random().Next(int.MaxValue - 1);

            if (this.DoesOrderExist(newOrderNumber) == true)
                return this.GenerateOrderNumber();
            else
                return newOrderNumber;
        }

        private bool DoesOrderExist(int orderNumber)
        {
            return this.Orders.ContainsKey(orderNumber);
        }

        private bool RemoveOrder(Order order)
        {
            if (this.Orders.ContainsKey(order.OrderNumber) == true)
            {
                this.Orders.Remove(order.OrderNumber);
                return true;
            }

            return false;
        }

        public bool RemoveOrderByNumber(int orderNumber)
        {
            if (this.Orders.ContainsKey(orderNumber) == true)
            {
                return this.RemoveOrder(this.Orders[orderNumber]);
            }

            return false;
        }

        public int RemoveOrdersByCustomer(int customerNumber)
        {
            int ordersRemoved = 0;

            foreach (KeyValuePair<int, Order> order in this.Orders)
            {
                if (order.Value.CustomerNumber == customerNumber)
                {
                    if (this.RemoveOrder(order.Value) == true)
                        ordersRemoved++;

                }
            }

            return ordersRemoved;
        }

        public void UpdateOrder(Order order)
        {
            if (this.Orders.ContainsKey(order.OrderNumber) == true)
            {
                this.Orders[order.OrderNumber] = order;
            }
        }

        public bool AddOrder(Order order)
        {
            if (this.Orders.ContainsKey(order.OrderNumber) == false)
            {
                this.Orders.Add(order.OrderNumber, order);
                return true;
            }

            return false;
        }

        public Order GetOrder(int orderNumber)
        {
            if (this.Orders.ContainsKey(orderNumber) == true)
            {
                return this.Orders[orderNumber];
            }

            return null;
        }

        public List<Order> GetOrders()
        {
            return this.Orders.Values.ToList();
        }

        public List<Order> GetOrdersByCustomer(int customerNumber)
        {
            List<Order> customerOrderList = new List<Order>();

            foreach (KeyValuePair<int, Order> order in this.Orders)
            {
                if (order.Value.CustomerNumber == customerNumber)
                {
                    customerOrderList.Add(order.Value);
                }
            }

            return customerOrderList;
        }

        public List<Order> GetOrdersByType(OrderType type = OrderType.RepairOrder)
        {
            List<Order> customerOrderList = new List<Order>();

            foreach (KeyValuePair<int, Order> order in this.Orders)
            {
                if (order.Value.Type == type)
                {
                    customerOrderList.Add(order.Value);
                }
            }

            return customerOrderList;
        }
    }

    public class Order
    {
        public int OrderNumber { get; private set; } = -1;
        public OrderType Type { get; private set; } = OrderType.Null;
        public int CustomerNumber { get; private set; } = -1;

        public Order(int orderNumber, OrderType type, int customerNumber)
        {
            this.OrderNumber = orderNumber;
            this.Type = type;
            this.CustomerNumber = customerNumber;
        }
    }
}
