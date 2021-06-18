using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Uppgift5.Classes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Uppgift5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;

        public MainPage()
        {
            MainPage.Current = this;
            this.InitializeComponent();
            this.FillCustomers();
        }

        private void FillCustomers()
        {
            this.listCustomers.ItemsSource = CustomerRegister.GetCustomers();
            this.listCustomers.DisplayMemberPath = nameof(Customer.Name);
        }

        private void FillOrders()
        {
            if (this.listCustomers.SelectedIndex != -1)
            {
                Customer customer = (Customer)this.listCustomers.SelectedItem;
                this.listOrders.ItemsSource = OrderSystem.GOS.GetOrdersByCustomer(customer.CustomerNumber);
                this.listOrders.DisplayMemberPath = nameof(Order.OrderNumber);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Control baseElement = (Control)sender;

            switch (baseElement.Name)
            {
                case "buttonNewCustomer":
                    Frame.Navigate(typeof(NewCustomer));
                    break;

                case "buttonNewOrder":
                    Frame.Navigate(typeof(CustomerOrder));
                    break;

                case "buttonEditCustomer":
                    if (this.listCustomers.SelectedItem != null) 
                    {
                        Customer customer = (Customer)this.listCustomers.SelectedItem;
                        Frame.Navigate(typeof(NewCustomer), customer);
                    }
                    break;

                case "buttonEditOrder":
                    if (this.listOrders.SelectedItem != null)
                    {
                        Order order = (Order)this.listOrders.SelectedItem;
                        Frame.Navigate(typeof(CustomerOrder), order);
                    }
                    break;
            }
        }

        private void listCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.FillOrders();
        }
    }
}
