﻿#pragma checksum "C:\Users\Tekoppar\source\repos\Uppgift5\CustomerOrder.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "65C629D0A97AE1DF9CFBA415C581FA80C97CCC1D71DF5AA8DF6D86DD08CCB318"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uppgift5
{
    partial class CustomerOrder : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // CustomerOrder.xaml line 16
                {
                    this.gridView = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // CustomerOrder.xaml line 50
                {
                    this.btnReset = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnReset).Click += this.btn_Click;
                }
                break;
            case 4: // CustomerOrder.xaml line 53
                {
                    this.btnNewOrder = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnNewOrder).Click += this.btn_Click;
                }
                break;
            case 5: // CustomerOrder.xaml line 54
                {
                    this.btnCancel = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCancel).Click += this.btn_Click;
                }
                break;
            case 6: // CustomerOrder.xaml line 32
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // CustomerOrder.xaml line 33
                {
                    this.textBoxName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // CustomerOrder.xaml line 35
                {
                    this.textBoxLastName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // CustomerOrder.xaml line 37
                {
                    this.textBoxAdress = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10: // CustomerOrder.xaml line 39
                {
                    this.textBoxCustomerNumber = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11: // CustomerOrder.xaml line 41
                {
                    this.textBoxOrderNumber = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12: // CustomerOrder.xaml line 43
                {
                    this.orderTypeComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 13: // CustomerOrder.xaml line 13
                {
                    this.customerNameText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // CustomerOrder.xaml line 14
                {
                    this.CustomerList = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.CustomerList).SelectionChanged += this.CustomerList_SelectionChanged;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
