using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Avalonia.VisualTree;
using CM_Simulator.ViewModels;
using System;
using System.ComponentModel;
using System.Reflection;

namespace CM_Simulator.Views;

public partial class HomeView : Window
{
    private ScrollViewer? _scrollViewer;
    private MainViewModel? _mainViewModel;
    private bool _autoScroll = true;

    public HomeView()
    {
        InitializeComponent();

        // Create MainViewModel and use its HomePage instance
        _mainViewModel = new MainViewModel();
        DataContext = _mainViewModel.HomePage;

        this.AttachedToVisualTree += (_, _) =>
        {
            // Find ScrollViewer inside the TextBox template
            _scrollViewer = LogTextBox.FindDescendantOfType<ScrollViewer>();
        };

        LogTextBox.PointerPressed += LogTextBox_PointerPressed;

        this.DataContextChanged += OnDataContextChanged;
        this.Opened += HomeView_Opened;
    }

    private async void HomeView_Opened(object? sender, EventArgs e)
    {
        var popup = new ConnectPopupView
        {
            DataContext = _mainViewModel
        };
        await popup.ShowDialog(this);
    }

    private void OnDataContextChanged(object? sender, EventArgs e)
    {
        if (DataContext is HomeViewModel vm)
        {
            vm.PropertyChanged += OnViewModelPropertyChanged;
        }
    }

    private void LogTextBox_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (_autoScroll)
        {
            // User clicked while auto-scroll is active — pause it so they can read
            _autoScroll = false;
        }
        else
        {
            // User clicked again — scroll to bottom and re-enable auto-scroll
            _autoScroll = true;
            ScrollToBottom();
        }
    }

    private void ScrollToBottom()
    {
        LogTextBox.CaretIndex = LogTextBox.Text?.Length ?? 0;

        if (_scrollViewer != null)
        {
            _scrollViewer.Offset = new Avalonia.Vector(
                _scrollViewer.Offset.X,
                _scrollViewer.Extent.Height);
        }
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(HomeViewModel.LogText))
        {
            // Use Background priority so the scroll runs after the layout pass
            // has updated the TextBox extent with the new content
            Dispatcher.UIThread.Post(() =>
            {
                if (_autoScroll)
                {
                    ScrollToBottom();
                }
            }, DispatcherPriority.Background);
        }
    }

    private void Scan_Click(object? sender, RoutedEventArgs e)
    {
        var window = this.VisualRoot as Window;
        if (DataContext is null) return;

        var vm = DataContext;
        // 1) Try ICommand properties first
        if (TryExecuteICommand(vm, "ScanIccCommand", window) ||
            TryExecuteICommand(vm, "ScanIcc", window))
        {
            return;
        }

        // 2) Try method with Window parameter
        if (TryInvokeMethod(vm, "ScanIcc", window))
            return;

        // 3) Try parameterless method
        if (TryInvokeMethod(vm, "ScanIcc", null))
            return;

        // fallback
        var dlg = new Window
        {
            Title = "Scan ICCs",
            Width = 360,
            Height = 180,
            Content = new TextBlock { Text = "Scan ICC action not found on ViewModel." },
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        dlg.ShowDialog(window);
    }

    private void ChangePort_Click(object? sender, RoutedEventArgs e)
    {
        var window = this.VisualRoot as Window;
        if (DataContext is null) return;

        var vm = DataContext;
        // 1) Try ICommand properties first
        if (TryExecuteICommand(vm, "OpenConnectPopupCommand", window) ||
            TryExecuteICommand(vm, "OpenConnectPopup", window))
        {
            return;
        }

        // 2) Try method with Window parameter
        if (TryInvokeMethod(vm, "OpenConnectPopup", window))
            return;

        // 3) Try parameterless method
        if (TryInvokeMethod(vm, "OpenConnectPopup", null))
            return;

        // fallback
        // (replace with whatever fallback UI you want)
        var dlg = new Window
        {
            Title = "Change Port",
            Width = 360,
            Height = 180,
            Content = new TextBlock { Text = "Change port action not found on ViewModel." },
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        dlg.ShowDialog(window);
    }

    private void ExportLog_Click(object? sender, RoutedEventArgs e)
    {
        var window = this.VisualRoot as Window;
        if (DataContext is null) return;

        var vm = DataContext;
        // 1) Try ICommand properties first
        if (TryExecuteICommand(vm, "ExportToTxtCommand", window) ||
            TryExecuteICommand(vm, "ExportToTxt", window))
        {
            return;
        }

        // 2) Try method with Window parameter
        if (TryInvokeMethod(vm, "ExportToTxt", window))
            return;

        // 3) Try parameterless method
        if (TryInvokeMethod(vm, "ExportToTxt", null))
            return;

        // fallback
        var dlg = new Window
        {
            Title = "Export Log",
            Width = 360,
            Height = 180,
            Content = new TextBlock { Text = "Export log action not found on ViewModel." },
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        dlg.ShowDialog(window);
    }

    // Helper: try to find and execute an ICommand property on the VM
    private bool TryExecuteICommand(object vm, string propName, Window? parameter)
    {
        try
        {
            var t = vm.GetType();
            var prop = t.GetProperty(propName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (prop == null) return false;
            var value = prop.GetValue(vm);
            if (value is System.Windows.Input.ICommand cmd)
            {
                var param = (object?)parameter;
                if (cmd.CanExecute(param))
                {
                    cmd.Execute(param);
                    return true;
                }
                // try without parameter
                if (cmd.CanExecute(null))
                {
                    cmd.Execute(null);
                    return true;
                }
            }
        }
        catch
        {
            // ignore and fallback
        }
        return false;
    }

    // Helper: try to find and invoke a method on the VM (with optional argument)
    private bool TryInvokeMethod(object vm, string methodName, object? argument)
    {
        try
        {
            var t = vm.GetType();
            MethodInfo? mi = null;

            if (argument != null)
            {
                mi = t.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase,
                               null, new Type[] { argument.GetType() }, null);
            }

            if (mi == null)
            {
                // try Window parameter type specifically (in case of base type)
                mi = t.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase,
                               null, new Type[] { typeof(Window) }, null);
            }

            if (mi == null && argument == null)
            {
                // parameterless
                mi = t.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase,
                               null, Type.EmptyTypes, null);
            }

            if (mi == null) return false;

            if (mi.GetParameters().Length == 0)
            {
                mi.Invoke(vm, null);
                return true;
            }
            else
            {
                mi.Invoke(vm, new object?[] { argument });
                return true;
            }
        }
        catch (TargetInvocationException ex)
        {
            // method threw an exception; rethrow or handle/log as you prefer
            Console.WriteLine($"VM method threw: {ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invoke error: {ex.Message}");
        }
        return false;
    }

}