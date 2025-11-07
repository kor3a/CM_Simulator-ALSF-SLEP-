using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CM_Simulator.ViewModels;
using System;
using System.IO.Ports;

namespace CM_Simulator;

public partial class ConnectPopupView : Window
{

    public ConnectPopupView()
    {
        InitializeComponent();
    }
}