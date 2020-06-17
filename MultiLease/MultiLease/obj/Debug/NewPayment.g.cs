﻿#pragma checksum "..\..\NewPayment.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "596B70F69596F1C416489E9EFAB090D130751986"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MultiLease;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MultiLease {
    
    
    /// <summary>
    /// NewPayment
    /// </summary>
    public partial class NewPayment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\NewPayment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker paymentDate;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\NewPayment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amount_textBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\NewPayment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirm_btn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\NewPayment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel_btn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\NewPayment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lease_lb;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NewPayment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox leaseID_textBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\NewPayment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker contractDate;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MultiLease;component/newpayment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewPayment.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.paymentDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 12 "..\..\NewPayment.xaml"
            this.paymentDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.PaymentDate_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.amount_textBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\NewPayment.xaml"
            this.amount_textBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Amount_textBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.confirm_btn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\NewPayment.xaml"
            this.confirm_btn.Click += new System.Windows.RoutedEventHandler(this.Confirm_btn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cancel_btn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\NewPayment.xaml"
            this.cancel_btn.Click += new System.Windows.RoutedEventHandler(this.Cancel_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lease_lb = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.leaseID_textBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\NewPayment.xaml"
            this.leaseID_textBox.LostFocus += new System.Windows.RoutedEventHandler(this.LeaseID_textBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.contractDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 19 "..\..\NewPayment.xaml"
            this.contractDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.PaymentDate_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

