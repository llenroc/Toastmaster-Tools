﻿using Template10.Services.NavigationService;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ToastmastersTimer.UWP.Views
{
    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-SplitView
    public sealed partial class Shell : Page
    {
        private static Shell Instance { get; set; }
        private static Template10.Common.WindowWrapper Window { get; set; }

        public Shell(NavigationService navigationService)
        {
            Instance = this;
            InitializeComponent();
            Window = Template10.Common.WindowWrapper.Current();
        }
    }
}
