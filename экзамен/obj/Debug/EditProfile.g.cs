﻿#pragma checksum "..\..\EditProfile.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8B0206EC28659629E2FE65DBCD2F6EEB04B8CE569FDC8076A4CCE2FA11664991"
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
    /// EditProfile
    /// </summary>
    public partial class EditProfile : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 105 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scroller;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock username;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border photo_holder;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush photo;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button browser;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox login;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox newpassword;
        
        #line default
        #line hidden
        
        
        #line 248 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander extras;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button user_edit;
        
        #line default
        #line hidden
        
        
        #line 265 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel;
        
        #line default
        #line hidden
        
        
        #line 273 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirm;
        
        #line default
        #line hidden
        
        
        #line 287 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup not_match;
        
        #line default
        #line hidden
        
        
        #line 315 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup newpass;
        
        #line default
        #line hidden
        
        
        #line 344 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup login_check;
        
        #line default
        #line hidden
        
        
        #line 354 "..\..\EditProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock login_popup_text;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/editprofile.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditProfile.xaml"
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
            
            #line 9 "..\..\EditProfile.xaml"
            ((WpfApp2.EditProfile)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.scroller = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 3:
            this.username = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.photo_holder = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.photo = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 6:
            this.browser = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\EditProfile.xaml"
            this.browser.Click += new System.Windows.RoutedEventHandler(this.browser_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.delete = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\EditProfile.xaml"
            this.delete.Click += new System.Windows.RoutedEventHandler(this.delete_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.login = ((System.Windows.Controls.TextBox)(target));
            
            #line 184 "..\..\EditProfile.xaml"
            this.login.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.login_TextChanged);
            
            #line default
            #line hidden
            
            #line 185 "..\..\EditProfile.xaml"
            this.login.LostFocus += new System.Windows.RoutedEventHandler(this.login_LostFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.password = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 218 "..\..\EditProfile.xaml"
            this.password.PasswordChanged += new System.Windows.RoutedEventHandler(this.password_PasswordChanged);
            
            #line default
            #line hidden
            
            #line 219 "..\..\EditProfile.xaml"
            this.password.LostFocus += new System.Windows.RoutedEventHandler(this.password_LostFocus);
            
            #line default
            #line hidden
            return;
            case 10:
            this.newpassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 235 "..\..\EditProfile.xaml"
            this.newpassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.newpassword_PasswordChanged);
            
            #line default
            #line hidden
            
            #line 236 "..\..\EditProfile.xaml"
            this.newpassword.LostFocus += new System.Windows.RoutedEventHandler(this.newpassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 11:
            this.extras = ((System.Windows.Controls.Expander)(target));
            return;
            case 12:
            this.user_edit = ((System.Windows.Controls.Button)(target));
            
            #line 256 "..\..\EditProfile.xaml"
            this.user_edit.Click += new System.Windows.RoutedEventHandler(this.user_edit_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.cancel = ((System.Windows.Controls.Button)(target));
            
            #line 271 "..\..\EditProfile.xaml"
            this.cancel.Click += new System.Windows.RoutedEventHandler(this.cancel_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.confirm = ((System.Windows.Controls.Button)(target));
            
            #line 279 "..\..\EditProfile.xaml"
            this.confirm.Click += new System.Windows.RoutedEventHandler(this.confirm_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.not_match = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 16:
            this.newpass = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 17:
            this.login_check = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 18:
            this.login_popup_text = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

