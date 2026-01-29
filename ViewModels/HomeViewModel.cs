using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Svg;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;

namespace CM_Simulator.ViewModels;

public partial class HomeViewModel : ViewModelBase
{

    private readonly MainViewModel _mainViewModel;
    public MainViewModel MainViewModel => _mainViewModel;

    // Forwarding properties to enable proper change notification for nested bindings
    public bool IsHomePageActive => _mainViewModel.HomePageIsActive;
    public ViewModelBase CurrentIccPage => _mainViewModel.CurrentPage;

    [ObservableProperty]
    private bool _alsfMode = true;

    // Navigation properties for LVICC carousel
    [ObservableProperty]
    private int _currentStartIndex = 1; // 1-based index of the first visible LVICC

    // Computed properties for navigation visibility
    public bool CanNavigateLeft => CurrentStartIndex > 1;
    public bool CanNavigateRight => CurrentStartIndex + 2 < 4;

    // Computed properties for visible LVICC numbers (1-based)
    public int VisibleLvicc1Number => CurrentStartIndex;
    public int VisibleLvicc2Number => CurrentStartIndex + 1;
    public int VisibleLvicc3Number => CurrentStartIndex + 2;

    // Computed properties for visible LVICC headers
    public string VisibleLvicc1Header => $"LVICC {VisibleLvicc1Number}";
    public string VisibleLvicc2Header => $"LVICC {VisibleLvicc2Number}";
    public string VisibleLvicc3Header => $"LVICC {VisibleLvicc3Number}";

    // Computed properties for visible LVICC backgrounds
    public IBrush VisibleLvicc1Background => GetLviccBackground(VisibleLvicc1Number);
    public IBrush VisibleLvicc2Background => GetLviccBackground(VisibleLvicc2Number);
    public IBrush VisibleLvicc3Background => GetLviccBackground(VisibleLvicc3Number);

    // Computed properties for visible LVICC side menus
    public string VisibleLvicc1SideMenu => GetLviccSideMenu(VisibleLvicc1Number);
    public string VisibleLvicc2SideMenu => GetLviccSideMenu(VisibleLvicc2Number);
    public string VisibleLvicc3SideMenu => GetLviccSideMenu(VisibleLvicc3Number);

    // Computed properties for visible LVICC REM buttons
    public IBrush VisibleLvicc1RemButton => GetLviccRemButton(VisibleLvicc1Number);
    public IBrush VisibleLvicc2RemButton => GetLviccRemButton(VisibleLvicc2Number);
    public IBrush VisibleLvicc3RemButton => GetLviccRemButton(VisibleLvicc3Number);

    // Computed properties for visible LVICC command error visibility
    public bool VisibleLvicc1CommandErrorVisible => GetLviccCommandErrorVisible(VisibleLvicc1Number);
    public bool VisibleLvicc2CommandErrorVisible => GetLviccCommandErrorVisible(VisibleLvicc2Number);
    public bool VisibleLvicc3CommandErrorVisible => GetLviccCommandErrorVisible(VisibleLvicc3Number);

    // Computed properties for visible LVICC misfire error visibility
    public bool VisibleLvicc1MisfireErrorVisible => GetLviccMisfireErrorVisible(VisibleLvicc1Number);
    public bool VisibleLvicc2MisfireErrorVisible => GetLviccMisfireErrorVisible(VisibleLvicc2Number);
    public bool VisibleLvicc3MisfireErrorVisible => GetLviccMisfireErrorVisible(VisibleLvicc3Number);

    // Computed properties for visible LVICC comm error visibility
    public bool VisibleLvicc1CommErrorVisible => GetLviccCommErrorVisible(VisibleLvicc1Number);
    public bool VisibleLvicc2CommErrorVisible => GetLviccCommErrorVisible(VisibleLvicc2Number);
    public bool VisibleLvicc3CommErrorVisible => GetLviccCommErrorVisible(VisibleLvicc3Number);

    // Computed properties for visible LVICC mode error visibility
    public bool VisibleLvicc1ModeErrorVisible => GetLviccModeErrorVisible(VisibleLvicc1Number);
    public bool VisibleLvicc2ModeErrorVisible => GetLviccModeErrorVisible(VisibleLvicc2Number);
    public bool VisibleLvicc3ModeErrorVisible => GetLviccModeErrorVisible(VisibleLvicc3Number);

    // Computed properties for visible LVICC button enabled states
    // In SSALR mode (AlsfMode = false), only odd-numbered LVICCs are enabled
    public bool VisibleLvicc1ButtonEnabled => AlsfMode || (VisibleLvicc1Number % 2 == 1);
    public bool VisibleLvicc2ButtonEnabled => AlsfMode || (VisibleLvicc2Number % 2 == 1);
    public bool VisibleLvicc3ButtonEnabled => AlsfMode || (VisibleLvicc3Number % 2 == 1);

    [ObservableProperty]
    private IBrush _lvicc1PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc2PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc3PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc4PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc5PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc6PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc7PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc8PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc9PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc10PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc11PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc12PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc13PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc14PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc15PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc16PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc17PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc18PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc19PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc20PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    private IBrush _lvicc21PgBackground = new SolidColorBrush(Colors.LightGray);
    [ObservableProperty]
    public bool _lvicc1PgStatus = false;
    [ObservableProperty]
    public bool _lvicc2PgStatus = false;
    [ObservableProperty]
    public bool _lvicc3PgStatus = false;
    [ObservableProperty]
    public bool _lvicc4PgStatus = false;
    [ObservableProperty]
    public bool _lvicc5PgStatus = false;
    [ObservableProperty]
    public bool _lvicc6PgStatus = false;
    [ObservableProperty]
    public bool _lvicc7PgStatus = false;
    [ObservableProperty]
    public bool _lvicc8PgStatus = false;
    [ObservableProperty]
    public bool _lvicc9PgStatus = false;
    [ObservableProperty]
    public bool _lvicc10PgStatus = false;
    [ObservableProperty]
    public bool _lvicc11PgStatus = false;
    [ObservableProperty]
    public bool _lvicc12PgStatus = false;
    [ObservableProperty]
    public bool _lvicc13PgStatus = false;
    [ObservableProperty]
    public bool _lvicc14PgStatus = false;
    [ObservableProperty]
    public bool _lvicc15PgStatus = false;
    [ObservableProperty]
    public bool _lvicc16PgStatus = false;
    [ObservableProperty]
    public bool _lvicc17PgStatus = false;
    [ObservableProperty]
    public bool _lvicc18PgStatus = false;
    [ObservableProperty]
    public bool _lvicc19PgStatus = false;
    [ObservableProperty]
    public bool _lvicc20PgStatus = false;
    [ObservableProperty]
    public bool _lvicc21PgStatus = false;

    [ObservableProperty]
    private bool _cmOffEnabled = false;
    [ObservableProperty]
    private bool _cmOnEnabled = false;
    [ObservableProperty]
    private bool _cmLowEnabled = false;
    [ObservableProperty]
    private bool _cmMedEnabled = false;
    [ObservableProperty]
    private bool _cmHighEnabled = false;
    [ObservableProperty]
    private bool _cmAlsfEnabled = false;
    [ObservableProperty]
    private bool _cmSsalrEnabled = false;
    [ObservableProperty]
    private bool _resetEnabled = false;
    [ObservableProperty]
    private bool _shortEnabled = false;
    [ObservableProperty]
    private bool _configEnabled = false;

    [ObservableProperty]
    private IBrush _offButton = new SolidColorBrush(Colors.DarkGray);

    [ObservableProperty]
    private IBrush _offForeground = new SolidColorBrush(Colors.White);

    [ObservableProperty]
    private IBrush _onButton = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _onForeground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _lowButton = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _lowForeground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _medButton = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _medForeground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _highButton = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _highForeground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _alsfButton = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _ssalrButton = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _shortButton = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _configButton = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _caution = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _cautionForeground = new SolidColorBrush(Colors.Black);

    /*
    [ObservableProperty]
    private IBrush _commFault = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _commFaultForeground = new SolidColorBrush(Colors.Black);
    */

    [ObservableProperty]
    private IBrush _failure = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _failureForeground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _txStatus = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _rxStatus = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _twoHzSyncStatus = new SolidColorBrush(Colors.LightGray);

    // 2Hz Flash overlay properties for visible LVICCs
    [ObservableProperty]
    private bool _visibleLvicc1FlashActive = false;

    [ObservableProperty]
    private bool _visibleLvicc2FlashActive = false;

    [ObservableProperty]
    private bool _visibleLvicc3FlashActive = false;

    [ObservableProperty]
    private string _logText = "";

    private const int MaxLogLines = 1000;
    private readonly List<string> _logLines = new List<string>();

    public void AppendLog(string message)
    {
        _logLines.Add(message);
        if (_logLines.Count > MaxLogLines)
        {
            _logLines.RemoveRange(0, _logLines.Count - MaxLogLines);
        }
        LogText = string.Join(Environment.NewLine, _logLines);
    }

    public bool stopCautionBeep = false;
    public bool failureBtnPressed = false;

    public HomeViewModel()
    {
        // Only used for design-time, so initialize minimally or leave empty
        if (Design.IsDesignMode)
        {
            _mainViewModel = null; // Or provide a mock MainViewModel if needed
        }
        else
        {
            throw new InvalidOperationException("This constructor is for design-time only.");
        }
    }

    public HomeViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;

        // Subscribe to MainViewModel property changes to forward notifications
        _mainViewModel.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == nameof(MainViewModel.HomePageIsActive))
            {
                OnPropertyChanged(nameof(IsHomePageActive));
            }
            else if (e.PropertyName == nameof(MainViewModel.CurrentPage))
            {
                OnPropertyChanged(nameof(CurrentIccPage));
            }
            // Forward property changes for all ICC pages to update visible LVICC bindings
            else if (e.PropertyName?.StartsWith("Icc") == true)
            {
                NotifyVisibleLviccPropertiesChanged();
            }
        };
    }

    // Called when CurrentStartIndex changes - notify all computed properties
    partial void OnCurrentStartIndexChanged(int value)
    {
        NotifyVisibleLviccPropertiesChanged();
        OnPropertyChanged(nameof(CanNavigateLeft));
        OnPropertyChanged(nameof(CanNavigateRight));

        // Update the addresses array in MainViewModel to match the visible LVICCs
        _mainViewModel?.UpdateVisibleAddresses(value);
    }

    // Called when AlsfMode changes - notify button enabled properties
    partial void OnAlsfModeChanged(bool value)
    {
        OnPropertyChanged(nameof(VisibleLvicc1ButtonEnabled));
        OnPropertyChanged(nameof(VisibleLvicc2ButtonEnabled));
        OnPropertyChanged(nameof(VisibleLvicc3ButtonEnabled));
    }

    private void NotifyVisibleLviccPropertiesChanged()
    {
        OnPropertyChanged(nameof(VisibleLvicc1Number));
        OnPropertyChanged(nameof(VisibleLvicc2Number));
        OnPropertyChanged(nameof(VisibleLvicc3Number));
        OnPropertyChanged(nameof(VisibleLvicc1Header));
        OnPropertyChanged(nameof(VisibleLvicc2Header));
        OnPropertyChanged(nameof(VisibleLvicc3Header));
        OnPropertyChanged(nameof(VisibleLvicc1Background));
        OnPropertyChanged(nameof(VisibleLvicc2Background));
        OnPropertyChanged(nameof(VisibleLvicc3Background));
        OnPropertyChanged(nameof(VisibleLvicc1SideMenu));
        OnPropertyChanged(nameof(VisibleLvicc2SideMenu));
        OnPropertyChanged(nameof(VisibleLvicc3SideMenu));
        OnPropertyChanged(nameof(VisibleLvicc1RemButton));
        OnPropertyChanged(nameof(VisibleLvicc2RemButton));
        OnPropertyChanged(nameof(VisibleLvicc3RemButton));
        OnPropertyChanged(nameof(VisibleLvicc1CommandErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc2CommandErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc3CommandErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc1MisfireErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc2MisfireErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc3MisfireErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc1CommErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc2CommErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc3CommErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc1ModeErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc2ModeErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc3ModeErrorVisible));
        OnPropertyChanged(nameof(VisibleLvicc1ButtonEnabled));
        OnPropertyChanged(nameof(VisibleLvicc2ButtonEnabled));
        OnPropertyChanged(nameof(VisibleLvicc3ButtonEnabled));
    }

    // Helper methods to get data for any LVICC number
    private IBrush GetLviccBackground(int lviccNumber)
    {
        return lviccNumber switch
        {
            1 => Lvicc1PgBackground,
            2 => Lvicc2PgBackground,
            3 => Lvicc3PgBackground,
            4 => Lvicc4PgBackground,
            5 => Lvicc5PgBackground,
            6 => Lvicc6PgBackground,
            7 => Lvicc7PgBackground,
            8 => Lvicc8PgBackground,
            9 => Lvicc9PgBackground,
            10 => Lvicc10PgBackground,
            11 => Lvicc11PgBackground,
            12 => Lvicc12PgBackground,
            13 => Lvicc13PgBackground,
            14 => Lvicc14PgBackground,
            15 => Lvicc15PgBackground,
            16 => Lvicc16PgBackground,
            17 => Lvicc17PgBackground,
            18 => Lvicc18PgBackground,
            19 => Lvicc19PgBackground,
            20 => Lvicc20PgBackground,
            21 => Lvicc21PgBackground,
            _ => new SolidColorBrush(Colors.LightGray)
        };
    }

    private string GetLviccSideMenu(int lviccNumber)
    {
        return lviccNumber switch
        {
            1 => _mainViewModel?.Icc1SideMenu ?? "OFF",
            2 => _mainViewModel?.Icc2SideMenu ?? "OFF",
            3 => _mainViewModel?.Icc3SideMenu ?? "OFF",
            4 => _mainViewModel?.Icc4SideMenu ?? "OFF",
            5 => _mainViewModel?.Icc5SideMenu ?? "OFF",
            6 => _mainViewModel?.Icc6SideMenu ?? "OFF",
            7 => _mainViewModel?.Icc7SideMenu ?? "OFF",
            8 => _mainViewModel?.Icc8SideMenu ?? "OFF",
            9 => _mainViewModel?.Icc9SideMenu ?? "OFF",
            10 => _mainViewModel?.Icc10SideMenu ?? "OFF",
            11 => _mainViewModel?.Icc11SideMenu ?? "OFF",
            12 => _mainViewModel?.Icc12SideMenu ?? "OFF",
            13 => _mainViewModel?.Icc13SideMenu ?? "OFF",
            14 => _mainViewModel?.Icc14SideMenu ?? "OFF",
            15 => _mainViewModel?.Icc15SideMenu ?? "OFF",
            16 => _mainViewModel?.Icc16SideMenu ?? "OFF",
            17 => _mainViewModel?.Icc17SideMenu ?? "OFF",
            18 => _mainViewModel?.Icc18SideMenu ?? "OFF",
            19 => _mainViewModel?.Icc19SideMenu ?? "OFF",
            20 => _mainViewModel?.Icc20SideMenu ?? "OFF",
            21 => _mainViewModel?.Icc21SideMenu ?? "OFF",
            _ => "OFF"
        };
    }

    private IBrush GetLviccRemButton(int lviccNumber)
    {
        var defaultBrush = new SolidColorBrush(Colors.LightGray);
        return lviccNumber switch
        {
            1 => _mainViewModel?.Icc1Page?.RemButton ?? defaultBrush,
            2 => _mainViewModel?.Icc2Page?.RemButton ?? defaultBrush,
            3 => _mainViewModel?.Icc3Page?.RemButton ?? defaultBrush,
            4 => _mainViewModel?.Icc4Page?.RemButton ?? defaultBrush,
            5 => _mainViewModel?.Icc5Page?.RemButton ?? defaultBrush,
            6 => _mainViewModel?.Icc6Page?.RemButton ?? defaultBrush,
            7 => _mainViewModel?.Icc7Page?.RemButton ?? defaultBrush,
            8 => _mainViewModel?.Icc8Page?.RemButton ?? defaultBrush,
            9 => _mainViewModel?.Icc9Page?.RemButton ?? defaultBrush,
            10 => _mainViewModel?.Icc10Page?.RemButton ?? defaultBrush,
            11 => _mainViewModel?.Icc11Page?.RemButton ?? defaultBrush,
            12 => _mainViewModel?.Icc12Page?.RemButton ?? defaultBrush,
            13 => _mainViewModel?.Icc13Page?.RemButton ?? defaultBrush,
            14 => _mainViewModel?.Icc14Page?.RemButton ?? defaultBrush,
            15 => _mainViewModel?.Icc15Page?.RemButton ?? defaultBrush,
            16 => _mainViewModel?.Icc16Page?.RemButton ?? defaultBrush,
            17 => _mainViewModel?.Icc17Page?.RemButton ?? defaultBrush,
            18 => _mainViewModel?.Icc18Page?.RemButton ?? defaultBrush,
            19 => _mainViewModel?.Icc19Page?.RemButton ?? defaultBrush,
            20 => _mainViewModel?.Icc20Page?.RemButton ?? defaultBrush,
            21 => _mainViewModel?.Icc21Page?.RemButton ?? defaultBrush,
            _ => defaultBrush
        };
    }

    private bool GetLviccCommandErrorVisible(int lviccNumber)
    {
        return lviccNumber switch
        {
            1 => _mainViewModel?.Icc1Page?.IsCommandErrorVisible ?? false,
            2 => _mainViewModel?.Icc2Page?.IsCommandErrorVisible ?? false,
            3 => _mainViewModel?.Icc3Page?.IsCommandErrorVisible ?? false,
            4 => _mainViewModel?.Icc4Page?.IsCommandErrorVisible ?? false,
            5 => _mainViewModel?.Icc5Page?.IsCommandErrorVisible ?? false,
            6 => _mainViewModel?.Icc6Page?.IsCommandErrorVisible ?? false,
            7 => _mainViewModel?.Icc7Page?.IsCommandErrorVisible ?? false,
            8 => _mainViewModel?.Icc8Page?.IsCommandErrorVisible ?? false,
            9 => _mainViewModel?.Icc9Page?.IsCommandErrorVisible ?? false,
            10 => _mainViewModel?.Icc10Page?.IsCommandErrorVisible ?? false,
            11 => _mainViewModel?.Icc11Page?.IsCommandErrorVisible ?? false,
            12 => _mainViewModel?.Icc12Page?.IsCommandErrorVisible ?? false,
            13 => _mainViewModel?.Icc13Page?.IsCommandErrorVisible ?? false,
            14 => _mainViewModel?.Icc14Page?.IsCommandErrorVisible ?? false,
            15 => _mainViewModel?.Icc15Page?.IsCommandErrorVisible ?? false,
            16 => _mainViewModel?.Icc16Page?.IsCommandErrorVisible ?? false,
            17 => _mainViewModel?.Icc17Page?.IsCommandErrorVisible ?? false,
            18 => _mainViewModel?.Icc18Page?.IsCommandErrorVisible ?? false,
            19 => _mainViewModel?.Icc19Page?.IsCommandErrorVisible ?? false,
            20 => _mainViewModel?.Icc20Page?.IsCommandErrorVisible ?? false,
            21 => _mainViewModel?.Icc21Page?.IsCommandErrorVisible ?? false,
            _ => false
        };
    }

    private bool GetLviccMisfireErrorVisible(int lviccNumber)
    {
        return lviccNumber switch
        {
            1 => _mainViewModel?.Icc1Page?.IsMisfireErrorVisible ?? false,
            2 => _mainViewModel?.Icc2Page?.IsMisfireErrorVisible ?? false,
            3 => _mainViewModel?.Icc3Page?.IsMisfireErrorVisible ?? false,
            4 => _mainViewModel?.Icc4Page?.IsMisfireErrorVisible ?? false,
            5 => _mainViewModel?.Icc5Page?.IsMisfireErrorVisible ?? false,
            6 => _mainViewModel?.Icc6Page?.IsMisfireErrorVisible ?? false,
            7 => _mainViewModel?.Icc7Page?.IsMisfireErrorVisible ?? false,
            8 => _mainViewModel?.Icc8Page?.IsMisfireErrorVisible ?? false,
            9 => _mainViewModel?.Icc9Page?.IsMisfireErrorVisible ?? false,
            10 => _mainViewModel?.Icc10Page?.IsMisfireErrorVisible ?? false,
            11 => _mainViewModel?.Icc11Page?.IsMisfireErrorVisible ?? false,
            12 => _mainViewModel?.Icc12Page?.IsMisfireErrorVisible ?? false,
            13 => _mainViewModel?.Icc13Page?.IsMisfireErrorVisible ?? false,
            14 => _mainViewModel?.Icc14Page?.IsMisfireErrorVisible ?? false,
            15 => _mainViewModel?.Icc15Page?.IsMisfireErrorVisible ?? false,
            16 => _mainViewModel?.Icc16Page?.IsMisfireErrorVisible ?? false,
            17 => _mainViewModel?.Icc17Page?.IsMisfireErrorVisible ?? false,
            18 => _mainViewModel?.Icc18Page?.IsMisfireErrorVisible ?? false,
            19 => _mainViewModel?.Icc19Page?.IsMisfireErrorVisible ?? false,
            20 => _mainViewModel?.Icc20Page?.IsMisfireErrorVisible ?? false,
            21 => _mainViewModel?.Icc21Page?.IsMisfireErrorVisible ?? false,
            _ => false
        };
    }

    private bool GetLviccCommErrorVisible(int lviccNumber)
    {
        return lviccNumber switch
        {
            1 => _mainViewModel?.Icc1Page?.IsCommErrorVisible ?? false,
            2 => _mainViewModel?.Icc2Page?.IsCommErrorVisible ?? false,
            3 => _mainViewModel?.Icc3Page?.IsCommErrorVisible ?? false,
            4 => _mainViewModel?.Icc4Page?.IsCommErrorVisible ?? false,
            5 => _mainViewModel?.Icc5Page?.IsCommErrorVisible ?? false,
            6 => _mainViewModel?.Icc6Page?.IsCommErrorVisible ?? false,
            7 => _mainViewModel?.Icc7Page?.IsCommErrorVisible ?? false,
            8 => _mainViewModel?.Icc8Page?.IsCommErrorVisible ?? false,
            9 => _mainViewModel?.Icc9Page?.IsCommErrorVisible ?? false,
            10 => _mainViewModel?.Icc10Page?.IsCommErrorVisible ?? false,
            11 => _mainViewModel?.Icc11Page?.IsCommErrorVisible ?? false,
            12 => _mainViewModel?.Icc12Page?.IsCommErrorVisible ?? false,
            13 => _mainViewModel?.Icc13Page?.IsCommErrorVisible ?? false,
            14 => _mainViewModel?.Icc14Page?.IsCommErrorVisible ?? false,
            15 => _mainViewModel?.Icc15Page?.IsCommErrorVisible ?? false,
            16 => _mainViewModel?.Icc16Page?.IsCommErrorVisible ?? false,
            17 => _mainViewModel?.Icc17Page?.IsCommErrorVisible ?? false,
            18 => _mainViewModel?.Icc18Page?.IsCommErrorVisible ?? false,
            19 => _mainViewModel?.Icc19Page?.IsCommErrorVisible ?? false,
            20 => _mainViewModel?.Icc20Page?.IsCommErrorVisible ?? false,
            21 => _mainViewModel?.Icc21Page?.IsCommErrorVisible ?? false,
            _ => false
        };
    }

    private bool GetLviccModeErrorVisible(int lviccNumber)
    {
        return lviccNumber switch
        {
            1 => _mainViewModel?.Icc1Page?.IsModeErrorVisible ?? false,
            2 => _mainViewModel?.Icc2Page?.IsModeErrorVisible ?? false,
            3 => _mainViewModel?.Icc3Page?.IsModeErrorVisible ?? false,
            4 => _mainViewModel?.Icc4Page?.IsModeErrorVisible ?? false,
            5 => _mainViewModel?.Icc5Page?.IsModeErrorVisible ?? false,
            6 => _mainViewModel?.Icc6Page?.IsModeErrorVisible ?? false,
            7 => _mainViewModel?.Icc7Page?.IsModeErrorVisible ?? false,
            8 => _mainViewModel?.Icc8Page?.IsModeErrorVisible ?? false,
            9 => _mainViewModel?.Icc9Page?.IsModeErrorVisible ?? false,
            10 => _mainViewModel?.Icc10Page?.IsModeErrorVisible ?? false,
            11 => _mainViewModel?.Icc11Page?.IsModeErrorVisible ?? false,
            12 => _mainViewModel?.Icc12Page?.IsModeErrorVisible ?? false,
            13 => _mainViewModel?.Icc13Page?.IsModeErrorVisible ?? false,
            14 => _mainViewModel?.Icc14Page?.IsModeErrorVisible ?? false,
            15 => _mainViewModel?.Icc15Page?.IsModeErrorVisible ?? false,
            16 => _mainViewModel?.Icc16Page?.IsModeErrorVisible ?? false,
            17 => _mainViewModel?.Icc17Page?.IsModeErrorVisible ?? false,
            18 => _mainViewModel?.Icc18Page?.IsModeErrorVisible ?? false,
            19 => _mainViewModel?.Icc19Page?.IsModeErrorVisible ?? false,
            20 => _mainViewModel?.Icc20Page?.IsModeErrorVisible ?? false,
            21 => _mainViewModel?.Icc21Page?.IsModeErrorVisible ?? false,
            _ => false
        };
    }

    // Navigation commands
    [RelayCommand]
    private void NavigateLeft()
    {
        if (CanNavigateLeft)
        {
            CurrentStartIndex--;
        }
    }

    [RelayCommand]
    private void NavigateRight()
    {
        if (CanNavigateRight)
        {
            CurrentStartIndex++;
        }
    }

    // Commands to navigate to visible LVICC pages
    [RelayCommand]
    private void GoToVisibleIcc1()
    {
        GoToIccByNumber(VisibleLvicc1Number);
    }

    [RelayCommand]
    private void GoToVisibleIcc2()
    {
        GoToIccByNumber(VisibleLvicc2Number);
    }

    [RelayCommand]
    private void GoToVisibleIcc3()
    {
        GoToIccByNumber(VisibleLvicc3Number);
    }

    private void GoToIccByNumber(int iccNumber)
    {
        switch (iccNumber)
        {
            case 1: _mainViewModel.GoToICC1(); break;
            case 2: _mainViewModel.GoToICC2(); break;
            case 3: _mainViewModel.GoToICC3(); break;
            case 4: _mainViewModel.GoToICC4(); break;
            case 5: _mainViewModel.GoToICC5(); break;
            case 6: _mainViewModel.GoToICC6(); break;
            case 7: _mainViewModel.GoToICC7(); break;
            case 8: _mainViewModel.GoToICC8(); break;
            case 9: _mainViewModel.GoToICC9(); break;
            case 10: _mainViewModel.GoToICC10(); break;
            case 11: _mainViewModel.GoToICC11(); break;
            case 12: _mainViewModel.GoToICC12(); break;
            case 13: _mainViewModel.GoToICC13(); break;
            case 14: _mainViewModel.GoToICC14(); break;
            case 15: _mainViewModel.GoToICC15(); break;
            case 16: _mainViewModel.GoToICC16(); break;
            case 17: _mainViewModel.GoToICC17(); break;
            case 18: _mainViewModel.GoToICC18(); break;
            case 19: _mainViewModel.GoToICC19(); break;
            case 20: _mainViewModel.GoToICC20(); break;
            case 21: _mainViewModel.GoToICC21(); break;
        }
    }

    // Public method to refresh visible LVICC properties (can be called from MainViewModel)
    public void RefreshVisibleLviccs()
    {
        NotifyVisibleLviccPropertiesChanged();
    }

    [RelayCommand]
    private void GoToICC1() 
    {
        _mainViewModel.GoToICC1();
    }

    [RelayCommand]
    private void GoToICC2()
    {
        _mainViewModel.GoToICC2();
    }

    [RelayCommand]
    private void GoToICC3()
    {
        _mainViewModel.GoToICC3();
    }

    [RelayCommand]
    private void GoToICC4()
    {
        _mainViewModel.GoToICC4();
    }

    [RelayCommand]
    private void GoToICC5()
    {
        _mainViewModel.GoToICC5();
    }

    [RelayCommand]
    private void GoToICC6()
    {
        _mainViewModel.GoToICC6();
    }

    [RelayCommand]
    private void GoToICC7()
    {
        _mainViewModel.GoToICC7();
    }

    [RelayCommand]
    private void GoToICC8()
    {
        _mainViewModel.GoToICC8();
    }

    [RelayCommand]
    private void GoToICC9()
    {
        _mainViewModel.GoToICC9();
    }

    [RelayCommand]
    private void GoToICC10()
    {
        _mainViewModel.GoToICC10();
    }

    [RelayCommand]
    private void GoToICC11()
    {
        _mainViewModel.GoToICC11();
    }

    [RelayCommand]
    private void GoToICC12()
    {
        _mainViewModel.GoToICC12();
    }

    [RelayCommand]
    private void GoToICC13()
    {
        _mainViewModel.GoToICC13();
    }

    [RelayCommand]
    private void GoToICC14()
    {
        _mainViewModel.GoToICC14();
    }

    [RelayCommand]
    private void GoToICC15()
    {
        _mainViewModel.GoToICC15();
    }

    [RelayCommand]
    private void GoToICC16()
    {
        _mainViewModel.GoToICC16();
    }

    [RelayCommand]
    private void GoToICC17()
    {
        _mainViewModel.GoToICC17();
    }

    [RelayCommand]
    private void GoToICC18()
    {
        _mainViewModel.GoToICC18();
    }

    [RelayCommand]
    private void GoToICC19()
    {
        _mainViewModel.GoToICC19();
    }

    [RelayCommand]
    private void GoToICC20()
    {
        _mainViewModel.GoToICC20();
    }

    [RelayCommand]
    private void GoToICC21()
    {
        _mainViewModel.GoToICC21();
    }

    [RelayCommand]
    private void GoToHome()
    {
        _mainViewModel.GoToHome();
    }

    [RelayCommand]
    private void AlsfModeChange()
    {
        if (!_mainViewModel.AlsfMode)
        {
            AlsfMode = true;
            AlsfButton = new SolidColorBrush(Colors.LightGreen);
            SsalrButton = new SolidColorBrush(Colors.LightGray);
            // Update cmMessageData mode bits BEFORE setting AlsfMode
            // so that OnAlsfModeChanged has the correct mode bits when it syncs ICC 2/4
            _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.alsfModeByte);
            _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.ssalrModeByte);
            _mainViewModel.AlsfMode = true;
        }

    }

    [RelayCommand]
    private void SsalrModeChange()
    {
        if (_mainViewModel.AlsfMode)
        {
            AlsfMode = false;
            SsalrButton = new SolidColorBrush(Colors.LightGreen);
            AlsfButton = new SolidColorBrush(Colors.LightGray);
            // Update cmMessageData mode bits BEFORE setting AlsfMode
            // so that OnAlsfModeChanged has the correct mode bits when it syncs ICC 2/4
            _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.alsfModeByte);
            _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.ssalrModeByte);
            _mainViewModel.AlsfMode = false;
        }

    }

    [RelayCommand]
    public async Task OpenConnectPopup(Window popupWindow)
    {
        await _mainViewModel.OpenConnectPopup(popupWindow);
    }

    [RelayCommand]
    public async Task ScanIcc()
    {
        await _mainViewModel.ScanIcc();
        _mainViewModel.alsfFailure = false;
    }

    [RelayCommand]
    public async Task ExportToTxt(Window ownerWindow)
    {
        try
        {
            // Create a SaveFileDialog
            var dialog = new SaveFileDialog
            {
                Title = "Save Log File",
                Filters = new System.Collections.Generic.List<FileDialogFilter>
                {
                    new FileDialogFilter { Name = "Text Files", Extensions = { "txt" } },
                    new FileDialogFilter { Name = "All Files", Extensions = { "*" } }
                },
                DefaultExtension = "txt",
                InitialFileName = $"Log_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
            };

            // Show the dialog and get the selected file path
            var result = await dialog.ShowAsync(ownerWindow);
            if (!string.IsNullOrEmpty(result))
            {
                // Write LogText to the selected file
                await File.WriteAllTextAsync(result, LogText);
                AppendLog($"Log exported to {result}");
            }
            else
            {
                AppendLog("Export canceled by user");
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show($"Error exporting log: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            AppendLog($"Error exporting log: {ex.Message}");
        }
    }


    [RelayCommand]
    public async Task MainOffControlClicked()
    {
        if (_mainViewModel.cmOn)
        {
            _mainViewModel.cmOn = false;
            OffButton = new SolidColorBrush(Colors.DarkGray);
            OffForeground = new SolidColorBrush(Colors.White);
            OnButton = new SolidColorBrush(Colors.LightGray);
            OnForeground = new SolidColorBrush(Colors.Black);
            LowButton = new SolidColorBrush(Colors.LightGray);
            LowForeground = new SolidColorBrush(Colors.Black);
            MedButton = new SolidColorBrush(Colors.LightGray);
            MedForeground = new SolidColorBrush(Colors.Black);
            HighButton = new SolidColorBrush(Colors.LightGray);
            HighForeground = new SolidColorBrush(Colors.Black);
            AlsfButton = new SolidColorBrush(Colors.LightGray);
            SsalrButton = new SolidColorBrush(Colors.LightGray);

            _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fOffByte ^ _mainViewModel.fOnByte);

            if (_mainViewModel.cmLow)
            {
                _mainViewModel.cmLow = false;
                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fLowByte);
            }
            if (_mainViewModel.cmMed)
            {
                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fMedByte);
                _mainViewModel.cmMed = false;
            }
            if (_mainViewModel.cmHigh)
            {
                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fHighByte);
                _mainViewModel.cmHigh = false;
            }

            await _mainViewModel.SendCmCommandAsync();
        }
    }

    [RelayCommand]
    public async Task MainOnControlClicked()
    {
        if (!_mainViewModel.cmOn)
        {
            _mainViewModel.cmOn = true;
            _mainViewModel.cmLow = true;

            OnButton = new SolidColorBrush(Colors.LightGreen);
            OnForeground = new SolidColorBrush(Colors.Black);
            LowButton = new SolidColorBrush(Colors.LightGreen);
            LowForeground = new SolidColorBrush(Colors.Black);
            OffButton = new SolidColorBrush(Colors.LightGray);
            OffForeground = new SolidColorBrush(Colors.Black);

            if (_mainViewModel.AlsfMode)
            {
                _mainViewModel.AlsfMode = true;
                AlsfButton = new SolidColorBrush(Colors.LightGreen);
            }else
            {
                _mainViewModel.AlsfMode = false;
                SsalrButton = new SolidColorBrush(Colors.LightGreen);
            }


            _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fOffByte ^ _mainViewModel.fOnByte ^ _mainViewModel.fLowByte);

            await _mainViewModel.SendCmCommandAsync();
        }
    }

    [RelayCommand]
    public async Task MainLowControlClicked()
    {
        if (_mainViewModel.cmOn)
        {
            if (_mainViewModel.cmMed)
            {
                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fMedByte);
                _mainViewModel.cmMed = false;
            }
            if (_mainViewModel.cmHigh)
            {
                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fHighByte);
                _mainViewModel.cmHigh = false;
            }
            if (!_mainViewModel.cmLow)
            {
                _mainViewModel.cmLow = true;


                LowButton = new SolidColorBrush(Colors.LightGreen);
                LowForeground = new SolidColorBrush(Colors.Black);
                MedButton = new SolidColorBrush(Colors.LightGray);
                MedForeground = new SolidColorBrush(Colors.Black);
                HighButton = new SolidColorBrush(Colors.LightGray);
                HighForeground = new SolidColorBrush(Colors.Black);


                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fLowByte);

                await _mainViewModel.SendCmCommandAsync();
            }
        }
    }

    [RelayCommand]
    public async Task MainMedControlClicked()
    {
        if (_mainViewModel.cmOn)
        {
            if (_mainViewModel.cmLow)
            {
                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fLowByte);
                _mainViewModel.cmLow = false;
            }
            if (_mainViewModel.cmHigh)
            {
                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fHighByte);
                _mainViewModel.cmHigh = false;
            }
            if (!_mainViewModel.cmMed)
            {
                _mainViewModel.cmMed = true;

                MedButton = new SolidColorBrush(Colors.LightGreen);
                MedForeground = new SolidColorBrush(Colors.Black);
                LowButton = new SolidColorBrush(Colors.LightGray);
                LowForeground = new SolidColorBrush(Colors.Black);
                HighButton = new SolidColorBrush(Colors.LightGray);
                HighForeground = new SolidColorBrush(Colors.Black);


                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fMedByte);

                await _mainViewModel.SendCmCommandAsync();
            }

        }
    }

    [RelayCommand]
    public async Task MainHighControlClicked()
    {
        if (_mainViewModel.cmOn)
        {
            if (_mainViewModel.cmLow)
            {
                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fLowByte);
                _mainViewModel.cmLow = false;
            }
            if (_mainViewModel.cmMed)
            {
                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fMedByte);
                _mainViewModel.cmMed = false;
            }
            if (!_mainViewModel.cmHigh)
            {
                _mainViewModel.cmHigh = true;

                HighButton = new SolidColorBrush(Colors.LightGreen);
                HighForeground = new SolidColorBrush(Colors.Black);
                LowButton = new SolidColorBrush(Colors.LightGray);
                LowForeground = new SolidColorBrush(Colors.Black);
                MedButton = new SolidColorBrush(Colors.LightGray);
                MedForeground = new SolidColorBrush(Colors.Black);

                _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.fHighByte);

                await _mainViewModel.SendCmCommandAsync();
            }

        }
    }

    [RelayCommand]
    public void ResetResultRequested()
    {
        _mainViewModel.SendResetResultRequest();
    }

    [RelayCommand]
    public async Task ShortDataRequested()
    {
        _mainViewModel.disableButtons();

        List<byte> addressesToPoll = _mainViewModel.GetAddressesToPoll();
        foreach (byte address in addressesToPoll)
        {
            await _mainViewModel.SendShortDataRequestAsync(address);
            // Wait for response
            await _mainViewModel.WaitForResponseAsync(address, 500);
            await Task.Delay(100);
        }

        _mainViewModel.enableButtons();
    }

    [RelayCommand]
    public async Task ConfigDataRequested()
    {
        _mainViewModel.disableButtons();

        List<byte> addressesToPoll = _mainViewModel.GetAddressesToPoll();
        foreach (byte address in addressesToPoll)
        {
            await _mainViewModel.SendConfigDataRequestAsync(address);
            // Wait for response
            await _mainViewModel.WaitForResponseAsync(address, 500);
            await Task.Delay(100);
        }

        _mainViewModel.enableButtons();
    }

    [RelayCommand]
    public void CommFaultClicked()
    {
        stopCautionBeep = true;
        _mainViewModel.cautionToneCts?.Cancel();
        if (failureBtnPressed)
        {
            _mainViewModel.StopContinuousBeep();
        }
        failureBtnPressed = false;
    }

    [RelayCommand]
    public void FailureClicked()
    {
        failureBtnPressed = true;
        _mainViewModel.StopContinuousBeep();
        if (!_mainViewModel.commFault)
        {
            _mainViewModel.StopContinuousBeep();
        }

    }
}


