﻿#pragma checksum "..\..\ClientMenuPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "29E2BA636B52473542A77C026B62548752F18AB2E7F4EF3FEB4E0F00A793AB48"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using book_store;


namespace book_store {
    
    
    /// <summary>
    /// ClientMenuPage
    /// </summary>
    public partial class ClientMenuPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\ClientMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem SearchMenuItem;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ClientMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ShelfMenuItem;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ClientMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem PurchasesMenuItem;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ClientMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem CartMenuSubItem;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ClientMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ActiveMenuSubItem;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ClientMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem FinishedMenuSubItem;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ClientMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem LogOut;
        
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
            System.Uri resourceLocater = new System.Uri("/book_store;component/clientmenupage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ClientMenuPage.xaml"
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
            this.SearchMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 12 "..\..\ClientMenuPage.xaml"
            this.SearchMenuItem.Click += new System.Windows.RoutedEventHandler(this.SearchMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ShelfMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\ClientMenuPage.xaml"
            this.ShelfMenuItem.Click += new System.Windows.RoutedEventHandler(this.ShelfMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PurchasesMenuItem = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 4:
            this.CartMenuSubItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\ClientMenuPage.xaml"
            this.CartMenuSubItem.Click += new System.Windows.RoutedEventHandler(this.CartMenuSubItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ActiveMenuSubItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 21 "..\..\ClientMenuPage.xaml"
            this.ActiveMenuSubItem.Click += new System.Windows.RoutedEventHandler(this.ActiveMenuSubItem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.FinishedMenuSubItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 22 "..\..\ClientMenuPage.xaml"
            this.FinishedMenuSubItem.Click += new System.Windows.RoutedEventHandler(this.FinishedMenuSubItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LogOut = ((System.Windows.Controls.MenuItem)(target));
            
            #line 27 "..\..\ClientMenuPage.xaml"
            this.LogOut.Click += new System.Windows.RoutedEventHandler(this.LogOut_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

