﻿#pragma checksum "..\..\..\..\Components\MeetingCreator.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36FA01DCB155BD038AA23145E8F0C60F07CFB101"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using MeetingScheduler.Components;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace MeetingScheduler.Components {
    
    
    /// <summary>
    /// MeetingCreator
    /// </summary>
    public partial class MeetingCreator : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Components\MeetingCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Components\MeetingCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox subjectTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Components\MeetingCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox descriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Components\MeetingCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox priorityListBox;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Components\MeetingCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button locationButton;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Components\MeetingCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button usersButton;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Components\MeetingCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dateTimeButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MeetingScheduler;component/components/meetingcreator.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Components\MeetingCreator.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.subjectTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.descriptionTextBox = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 4:
            this.priorityListBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.locationButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.usersButton = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\Components\MeetingCreator.xaml"
            this.usersButton.Click += new System.Windows.RoutedEventHandler(this.OnUsersButtonClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dateTimeButton = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\..\Components\MeetingCreator.xaml"
            this.dateTimeButton.Click += new System.Windows.RoutedEventHandler(this.OnDateTimeButtonClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 91 "..\..\..\..\Components\MeetingCreator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnCreateButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

