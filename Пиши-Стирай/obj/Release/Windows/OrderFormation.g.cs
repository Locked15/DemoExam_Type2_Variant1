﻿#pragma checksum "..\..\..\Windows\OrderFormation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "79592BFB9420B521E839F9BD4ADD41650F9C857BFF1D21E55FB7BA05ADBEA6B0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Пиши_Стирай.Windows;


namespace Пиши_Стирай.Windows {
    
    
    /// <summary>
    /// OrderFormation
    /// </summary>
    public partial class OrderFormation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\Windows\OrderFormation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserRoleInfo;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Windows\OrderFormation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserNameInfo;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Windows\OrderFormation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FinalCost_TextBlock;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Windows\OrderFormation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FinalDiscount_TextBlock;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Windows\OrderFormation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView AllProductsInOrder;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Windows\OrderFormation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CurrentProductCount_TextBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Windows\OrderFormation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PickupPointSelector;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Windows\OrderFormation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveOrder;
        
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
            System.Uri resourceLocater = new System.Uri("/Пиши-Стирай;component/windows/orderformation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\OrderFormation.xaml"
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
            
            #line 11 "..\..\..\Windows\OrderFormation.xaml"
            ((Пиши_Стирай.Windows.OrderFormation)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\Windows\OrderFormation.xaml"
            ((Пиши_Стирай.Windows.OrderFormation)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UserRoleInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.UserNameInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.FinalCost_TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.FinalDiscount_TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.AllProductsInOrder = ((System.Windows.Controls.ListView)(target));
            
            #line 57 "..\..\..\Windows\OrderFormation.xaml"
            this.AllProductsInOrder.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AllProductsInOrder_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CurrentProductCount_TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 62 "..\..\..\Windows\OrderFormation.xaml"
            this.CurrentProductCount_TextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CurrentProductCount_TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PickupPointSelector = ((System.Windows.Controls.ComboBox)(target));
            
            #line 65 "..\..\..\Windows\OrderFormation.xaml"
            this.PickupPointSelector.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PickupPointSelector_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SaveOrder = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Windows\OrderFormation.xaml"
            this.SaveOrder.Click += new System.Windows.RoutedEventHandler(this.SaveOrder_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

