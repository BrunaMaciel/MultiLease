﻿#pragma checksum "..\..\ViewLease.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1E6F823BA9580D0E1E8BB4AC3B0FCCAF16EDD495"
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
    /// ViewLease
    /// </summary>
    public partial class ViewLease : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 54 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker contractDate;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox leaseID_textbox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button terminate_btn;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox status_textBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox customersList;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox termsList;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox vehicles;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amount_textBox;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker firstPaymentDate;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel numOfPayments;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton months12;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton months24;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton months36;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton months48;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save_btn;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel_btn;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button edit_btn;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView paymentList;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newPayment_btn;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem newLease;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem editLease;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem searchLease;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem newPayment;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem searchPayment;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem newCustomer;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem editCustomer;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem searchCustomer;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem newVehicle;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem editVehicle;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\ViewLease.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem searchVehicle;
        
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
            System.Uri resourceLocater = new System.Uri("/MultiLease;component/viewlease.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ViewLease.xaml"
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
            
            #line 9 "..\..\ViewLease.xaml"
            ((MultiLease.ViewLease)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.contractDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.leaseID_textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.terminate_btn = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\ViewLease.xaml"
            this.terminate_btn.Click += new System.Windows.RoutedEventHandler(this.Terminate_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.status_textBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.customersList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.termsList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.vehicles = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.amount_textBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 75 "..\..\ViewLease.xaml"
            this.amount_textBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Amount_textBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.firstPaymentDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 11:
            this.numOfPayments = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 12:
            this.months12 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 13:
            this.months24 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 14:
            this.months36 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 15:
            this.months48 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 16:
            this.save_btn = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\ViewLease.xaml"
            this.save_btn.Click += new System.Windows.RoutedEventHandler(this.Save_btn_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.cancel_btn = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\ViewLease.xaml"
            this.cancel_btn.Click += new System.Windows.RoutedEventHandler(this.Cancel_btn_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.edit_btn = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\ViewLease.xaml"
            this.edit_btn.Click += new System.Windows.RoutedEventHandler(this.Edit_btn_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.paymentList = ((System.Windows.Controls.ListView)(target));
            return;
            case 21:
            this.newPayment_btn = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\ViewLease.xaml"
            this.newPayment_btn.Click += new System.Windows.RoutedEventHandler(this.NewPayment_btn_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.newLease = ((System.Windows.Controls.MenuItem)(target));
            
            #line 114 "..\..\ViewLease.xaml"
            this.newLease.Click += new System.Windows.RoutedEventHandler(this.MenuNewLease_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            this.editLease = ((System.Windows.Controls.MenuItem)(target));
            
            #line 115 "..\..\ViewLease.xaml"
            this.editLease.Click += new System.Windows.RoutedEventHandler(this.MenuEditLease_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            this.searchLease = ((System.Windows.Controls.MenuItem)(target));
            
            #line 116 "..\..\ViewLease.xaml"
            this.searchLease.Click += new System.Windows.RoutedEventHandler(this.MenuSearchLease_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            this.newPayment = ((System.Windows.Controls.MenuItem)(target));
            
            #line 119 "..\..\ViewLease.xaml"
            this.newPayment.Click += new System.Windows.RoutedEventHandler(this.MenuNewPayment_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            this.searchPayment = ((System.Windows.Controls.MenuItem)(target));
            
            #line 120 "..\..\ViewLease.xaml"
            this.searchPayment.Click += new System.Windows.RoutedEventHandler(this.MenuSearchPayment_Click);
            
            #line default
            #line hidden
            return;
            case 27:
            this.newCustomer = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 28:
            this.editCustomer = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 29:
            this.searchCustomer = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 30:
            this.newVehicle = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 31:
            this.editVehicle = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 32:
            this.searchVehicle = ((System.Windows.Controls.MenuItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 20:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 103 "..\..\ViewLease.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.PaymentItem_MouseDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}
