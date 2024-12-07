using System;
using System.Linq;

namespace PrimitivaApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnGenerateNumbersClicked(object sender, EventArgs e)
    {
        
        var random = new Random();
        var numbers = Enumerable.Range(1, 49)
                                .OrderBy(_ => random.Next())
                                .Take(6)
                                .OrderBy(n => n)
                                .ToList();

       
        ResultLabel.Text = $"Números: {string.Join(", ", numbers)}";
    }
}