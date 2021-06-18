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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Uppgift5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerOrder : Page
    {
        private bool EditingExistingOrder { get; set; } = false;
        public CustomerOrder()
        {
            this.InitializeComponent();
            this.FillCustomerList();

            if (this.EditingExistingOrder == false)
            {
                this.textBoxOrderNumber.Text = OrderSystem.GOS.GenerateOrderNumber().ToString();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                this.EditingExistingOrder = true;
                Order order = (Order)e.Parameter;
                Customer customer = CustomerRegister.GetCustomer(order.CustomerNumber);
                this.FillInCustomerInfo(customer);
                this.textBoxOrderNumber.Text = order.OrderNumber.ToString();
                this.CustomerList.SelectedItem = customer;
                this.orderTypeComboBox.SelectedItem = Enum.GetName(typeof(OrderType), order.Type);
                this.btnNewOrder.Content = "Update Order";
                this.customerNameText.Visibility = CustomerList.Visibility = Visibility.Collapsed;
            }
        }

        private void FillCustomerList()
        {
            List<Customer> customers = CustomerRegister.GetCustomers();

            if (customers != null)
            {
                this.CustomerList.ItemsSource = customers;
                this.CustomerList.DisplayMemberPath = nameof(Customer.Name);
            }

            List<string> orderTypes = new List<string>(Enum.GetNames(typeof(OrderType)).ToList());
            orderTypes.Remove("Null");
            orderTypeComboBox.ItemsSource = orderTypes;
        }

        private void AddNewOrder()
        {
            Customer customer = CustomerRegister.GetCustomer(int.Parse(this.textBoxCustomerNumber.Text));

            if (customer == null)
                return;

            if (this.EditingExistingOrder == false)
            {
                OrderSystem.GOS.AddOrder(new Order(int.Parse(this.textBoxOrderNumber.Text), (OrderType)this.orderTypeComboBox.SelectedIndex, int.Parse(this.textBoxCustomerNumber.Text)));
            }
            else
            {
                OrderSystem.GOS.UpdateOrder(new Order(int.Parse(this.textBoxOrderNumber.Text), (OrderType)this.orderTypeComboBox.SelectedIndex, int.Parse(this.textBoxCustomerNumber.Text)));
            }

            Frame.Navigate(typeof(MainPage));
        }

        private void ResetInputValues()
        {
            IEnumerable<TextBox> inputs = this.gridView.Children.OfType<TextBox>();

            foreach (TextBox textBox in inputs)
            {
                textBox.Text = "";
            }

            this.textBoxOrderNumber.Text = OrderSystem.GOS.GenerateOrderNumber().ToString();
        }

        private void CustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer selectedCustomer = (Customer)e.AddedItems[0];

            if (selectedCustomer != null)
            {
                this.FillInCustomerInfo(selectedCustomer);
            }
        }

        private void FillInCustomerInfo(Customer customer)
        {
            this.textBoxName.Text = customer.Name;
            this.textBoxLastName.Text = customer.LastName;
            this.textBoxAdress.Text = customer.Adress;
            this.textBoxCustomerNumber.Text = customer.CustomerNumber.ToString();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Control baseElement = (Control)sender;

            switch (baseElement.Name)
            {
                case "btnReset":
                    this.ResetInputValues();
                    break;

                case "btnCancel":
                    Frame.Navigate(typeof(MainPage));
                    break;

                case "btnNewOrder":
                    this.AddNewOrder();
                    break;
            }
        }
    }
}
