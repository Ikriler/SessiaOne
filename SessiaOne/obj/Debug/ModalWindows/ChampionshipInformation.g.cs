﻿#pragma checksum "..\..\..\ModalWindows\ChampionshipInformation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "712CD1938DDC236A538373FE987AEB8BFC93CE262B7437600593C76747104DD1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SessiaOne.ModalWindows;
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


namespace SessiaOne.ModalWindows {
    
    
    /// <summary>
    /// ChampionshipInformation
    /// </summary>
    public partial class ChampionshipInformation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\ModalWindows\ChampionshipInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonClose;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\ModalWindows\ChampionshipInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock championshipName;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\ModalWindows\ChampionshipInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label championshipDates;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\ModalWindows\ChampionshipInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label championshipCity;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\ModalWindows\ChampionshipInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock championshipDesctiption;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\ModalWindows\ChampionshipInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label championshipMembersCount;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\ModalWindows\ChampionshipInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label championshipExpertsCount;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\ModalWindows\ChampionshipInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label championshipCompetentionsCount;
        
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
            System.Uri resourceLocater = new System.Uri("/SessiaOne;component/modalwindows/championshipinformation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ModalWindows\ChampionshipInformation.xaml"
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
            
            #line 8 "..\..\..\ModalWindows\ChampionshipInformation.xaml"
            ((SessiaOne.ModalWindows.ChampionshipInformation)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MoveWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonClose = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\ModalWindows\ChampionshipInformation.xaml"
            this.buttonClose.Click += new System.Windows.RoutedEventHandler(this.buttonClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.championshipName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.championshipDates = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.championshipCity = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.championshipDesctiption = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.championshipMembersCount = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.championshipExpertsCount = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.championshipCompetentionsCount = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

