﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "394E443DC4FFD97AD092A41FB20053A7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18444
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using System.Windows.Forms.Integration;
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
using WpfApplication4.ViewModels;


namespace WpfApplication4 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 7 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MediaGrid;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid libgrid;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement MediaEl;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider SeekBar;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MediaButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RepeatButton;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider volume;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox playlist;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Plname;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication4;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.MediaGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.libgrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.listView = ((System.Windows.Controls.ListView)(target));
            
            #line 23 "..\..\MainWindow.xaml"
            this.listView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.listView1_DoubleClick);
            
            #line default
            #line hidden
            
            #line 23 "..\..\MainWindow.xaml"
            this.listView.KeyDown += new System.Windows.Input.KeyEventHandler(this.listView_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 35 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.UpdateBinding);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 38 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.UpdateBinding);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 40 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.UpdateBinding);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 42 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.UpdateBinding);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 44 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.UpdateBinding);
            
            #line default
            #line hidden
            return;
            case 10:
            this.MediaEl = ((System.Windows.Controls.MediaElement)(target));
            
            #line 47 "..\..\MainWindow.xaml"
            this.MediaEl.MediaOpened += new System.Windows.RoutedEventHandler(this.MediaElement_MediaOpened);
            
            #line default
            #line hidden
            
            #line 47 "..\..\MainWindow.xaml"
            this.MediaEl.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.MediaElement_LeftClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.SeekBar = ((System.Windows.Controls.Slider)(target));
            
            #line 55 "..\..\MainWindow.xaml"
            this.SeekBar.AddHandler(System.Windows.Controls.Primitives.Thumb.DragStartedEvent, new System.Windows.Controls.Primitives.DragStartedEventHandler(this.seekBar_DragStarted));
            
            #line default
            #line hidden
            
            #line 55 "..\..\MainWindow.xaml"
            this.SeekBar.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.seekBar_DragCompleted));
            
            #line default
            #line hidden
            return;
            case 12:
            this.MediaButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\MainWindow.xaml"
            this.MediaButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 58 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 63 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 15:
            this.RepeatButton = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\MainWindow.xaml"
            this.RepeatButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 16:
            this.volume = ((System.Windows.Controls.Slider)(target));
            
            #line 65 "..\..\MainWindow.xaml"
            this.volume.AddHandler(System.Windows.Controls.Primitives.Thumb.DragStartedEvent, new System.Windows.Controls.Primitives.DragStartedEventHandler(this.volume_DragStarted));
            
            #line default
            #line hidden
            
            #line 65 "..\..\MainWindow.xaml"
            this.volume.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.volume_DragCompleted));
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 66 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_7);
            
            #line default
            #line hidden
            return;
            case 18:
            this.playlist = ((System.Windows.Controls.ListBox)(target));
            
            #line 74 "..\..\MainWindow.xaml"
            this.playlist.DragEnter += new System.Windows.DragEventHandler(this.playlist_DragEnter);
            
            #line default
            #line hidden
            
            #line 74 "..\..\MainWindow.xaml"
            this.playlist.Drop += new System.Windows.DragEventHandler(this.playlist_Drop);
            
            #line default
            #line hidden
            
            #line 74 "..\..\MainWindow.xaml"
            this.playlist.KeyDown += new System.Windows.Input.KeyEventHandler(this.playlist_KeyDown);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 77 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            this.Plname = ((System.Windows.Controls.TextBox)(target));
            
            #line 86 "..\..\MainWindow.xaml"
            this.Plname.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Textbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 87 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_5);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 88 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_6);
            
            #line default
            #line hidden
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
            
            #line 82 "..\..\MainWindow.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ListBoxItem_MouseDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}
