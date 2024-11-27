﻿using Microsoft.Maui.Controls;

namespace Contabilidad
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            await Database.Initialize();
        }
    }
}
