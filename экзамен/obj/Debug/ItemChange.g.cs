﻿#pragma checksum "..\..\ItemChange.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "707CC8FC96D493390063B288E9AE6B04E994C7A05241628BD63A965EC3A0A1BC"
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
using WpfApp2;


namespace WpfApp2 {
    
    
    /// <summary>
    /// ItemChange
    /// </summary>
    public partial class ItemChange : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 123 "..\..\ItemChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox surname;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\ItemChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\ItemChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patronymic;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\ItemChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox twind;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\ItemChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\ItemChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirm;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/itemchange.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ItemChange.xaml"
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
            
            #line 9 "..\..\ItemChange.xaml"
            ((WpfApp2.ItemChange)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.surname = ((System.Windows.Controls.TextBox)(target));
            
            #line 127 "..\..\ItemChange.xaml"
            this.surname.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.surname_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 128 "..\..\ItemChange.xaml"
            this.surname.LostKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.surname_LostKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 129 "..\..\ItemChange.xaml"
            this.surname.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.surname_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.name = ((System.Windows.Controls.TextBox)(target));
            
            #line 146 "..\..\ItemChange.xaml"
            this.name.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.name_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 147 "..\..\ItemChange.xaml"
            this.name.LostKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.name_LostKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 148 "..\..\ItemChange.xaml"
            this.name.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.name_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.patronymic = ((System.Windows.Controls.TextBox)(target));
            
            #line 164 "..\..\ItemChange.xaml"
            this.patronymic.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.patronymic_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 165 "..\..\ItemChange.xaml"
            this.patronymic.LostKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.patronymic_LostKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 166 "..\..\ItemChange.xaml"
            this.patronymic.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.patronymic_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.twind = ((System.Windows.Controls.TextBox)(target));
            
            #line 182 "..\..\ItemChange.xaml"
            this.twind.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.twind_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 183 "..\..\ItemChange.xaml"
            this.twind.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.twind_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cancel = ((System.Windows.Controls.Button)(target));
            
            #line 196 "..\..\ItemChange.xaml"
            this.cancel.Click += new System.Windows.RoutedEventHandler(this.cancel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.confirm = ((System.Windows.Controls.Button)(target));
            
            #line 204 "..\..\ItemChange.xaml"
            this.confirm.Click += new System.Windows.RoutedEventHandler(this.confirm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

