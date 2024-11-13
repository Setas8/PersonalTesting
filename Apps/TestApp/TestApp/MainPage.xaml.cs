
using Microsoft.Maui.Controls;
using System;

namespace TestApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            CounterLbl.Text = $"You clicked {count} times";
        }
    }
}
