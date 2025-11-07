using Avalonia.Controls;
using Avalonia.Media;
using CM_Simulator.ViewModels;
using System.IO.Ports;
using System;
using Avalonia.Threading;
using HarfBuzzSharp;
using System.Reflection.Metadata;

namespace CM_Simulator
{
    public partial class MainView : Window
    {

        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); // Ensure this is present
            Opened += MainView_Opened;
        }

        private async void MainView_Opened(object? sender, EventArgs e)
        {
            var popup = new ConnectPopupView
            {
                DataContext = this.DataContext
            };
            await popup.ShowDialog(this);
        }

        private void Image_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (e.ClickCount != 1)
            {
                return;
            }

            (DataContext as MainViewModel)?.SideMenuResizeCommand?.Execute(null);
        }

     
    }
}