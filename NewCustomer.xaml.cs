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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Uppgift5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewCustomer : Page
    {
        private bool EditingExistingCustomer { get; set; } = false;

        public NewCustomer()
        {
            this.InitializeComponent();
            textBoxCustomerNumber.Text = GenerateCustomerNumber().ToString();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                Customer customer = (Customer)e.Parameter;
                this.EditingExistingCustomer = true;

                this.textBoxName.Text = customer.Name;
                this.textBoxLastName.Text = customer.LastName;
                this.textBoxAdress.Text = customer.Adress;
                this.textBoxCustomerNumber.Text = customer.CustomerNumber.ToString();
                this.btnNewCustomer.Content = "Update Customer";
            }
        }

        private void ResetInputValues()
        {
            IEnumerable<TextBox> inputs = this.gridView.Children.OfType<TextBox>();

            foreach (TextBox textBox in inputs)
            {
                textBox.Text = "";
            }
        }

        public int GenerateCustomerNumber()
        {
            int newCustomerNumber = new Random().Next(int.MaxValue - 1);

            if (CustomerRegister.DoesCustomerExist(newCustomerNumber) == true)
                return this.GenerateCustomerNumber();
            else
                return newCustomerNumber;
        }

        private async void AddErrorMessage(string errorMessage = "No error message was found, please try again.")
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(errorMessage);

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand(
                "Try again",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand(
                "Close",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }

        private void AddNewCustomer()
        {
            if (this.textBoxName.Text.Length <= 0 || this.textBoxLastName.Text.Length <= 0 || this.textBoxAdress.Text.Length <= 0)
            {
                this.AddErrorMessage("One or more of the fields are empty, please fill them in.");
                return;
            }

            bool wasSuccess = false;
            if (this.EditingExistingCustomer == false)
            {
                wasSuccess = CustomerRegister.AddCustomer(new Customer(this.textBoxName.Text, this.textBoxLastName.Text, this.textBoxAdress.Text, int.Parse(this.textBoxCustomerNumber.Text)));
            }
            else
            {
                CustomerRegister.UpdateCustomer(new Customer(this.textBoxName.Text, this.textBoxLastName.Text, this.textBoxAdress.Text, int.Parse(this.textBoxCustomerNumber.Text)));
                wasSuccess = true;
            }

            if (wasSuccess == true)
            {
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                this.AddErrorMessage("The customer already exists.");
            }
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            // Display message showing the label of the command that was invoked
            //MainPage.Current.NotifyUser("The '" + command.Label + "' command has been selected.", MainPage.Current.NotifyType.StatusMessage);
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

                case "btnNewCustomer":
                    this.AddNewCustomer();
                    break;
            }
        }
    }
}
