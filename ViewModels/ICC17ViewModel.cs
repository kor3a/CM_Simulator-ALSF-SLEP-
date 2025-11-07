using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_Simulator.ViewModels;

public partial class ICC17ViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;
    private readonly HomeViewModel _homeViewModel;

    [ObservableProperty]
    public string _vac240V;
    [ObservableProperty]
    public string _vac240A;
    [ObservableProperty]
    public string _flashTriggerV;
    [ObservableProperty]
    public string _flashBiasV;
    [ObservableProperty]
    public string _vdc33V;
    [ObservableProperty]
    public string _vdc5V;
    [ObservableProperty]
    public string _vdc8V;
    [ObservableProperty]
    public string _vdc8A;
    [ObservableProperty]
    public string _vdc18V;
    [ObservableProperty]
    public string _vdc24V;
    [ObservableProperty]
    public string _vdc24A;
    [ObservableProperty]
    public string _cpuTemp;
    [ObservableProperty]
    public string _triggerPulseWidth;
    [ObservableProperty]
    public string _triggerPulseDelay;
    [ObservableProperty]
    public string _triggerPeriod;
    [ObservableProperty]
    public string _triggerCurrent;
    [ObservableProperty]
    public string _anodePulseWidth;
    [ObservableProperty]
    public string _anodePulseDelay;
    [ObservableProperty]
    public string _bleederV;
    [ObservableProperty]
    public string _flasherMisfires;

    [ObservableProperty]
    public IBrush _flasherMisfireBackground;

    [ObservableProperty]
    private IBrush _offButton = new SolidColorBrush(Colors.DarkGray);

    [ObservableProperty]
    private IBrush _offForeground = new SolidColorBrush(Colors.White);

    [ObservableProperty]
    private IBrush _remButton = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _remForeground = new SolidColorBrush(Colors.Black);

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
    private IBrush _flashHeadBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _mtBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _modeBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _controlBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _elevatedBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _inPavementBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _compatBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _enhancedBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private string _modeStatus = "ALSF";

    [ObservableProperty]
    private string _controlType = "Serial";

    [ObservableProperty]
    private string _startByte = "";

    [ObservableProperty]
    private IBrush _startByteBackground = new SolidColorBrush(Colors.White);

    [ObservableProperty]
    private string _destinationByte = "";

    [ObservableProperty]
    private IBrush _destinationByteBackground = new SolidColorBrush(Colors.White);

    [ObservableProperty]
    private string _sourceByte = "";

    [ObservableProperty]
    private IBrush _sourceByteBackground = new SolidColorBrush(Colors.White);

    [ObservableProperty]
    private string _endByte = "";

    [ObservableProperty]
    private IBrush _endByteBackground = new SolidColorBrush(Colors.White);

    [ObservableProperty]
    public bool _isCommandErrorVisible;

    [ObservableProperty]
    public bool _isMisfireErrorVisible;

    [ObservableProperty]
    public bool _isStartByteErrorVisible;

    [ObservableProperty]
    public bool _isDestinationByteErrorVisible;

    [ObservableProperty]
    public bool _isSourceByteErrorVisible;

    [ObservableProperty]
    public bool _isEndByteErrorVisible;

    public ICC17ViewModel()
    {
        // Only used for design-time, so initialize minimally or leave empty
        if (Design.IsDesignMode)
        {
            _mainViewModel = null; // Or provide a mock MainViewModel if needed
            _homeViewModel = null;
        }
        else
        {
            throw new InvalidOperationException("This constructor is for design-time only.");
        }
    }
    public ICC17ViewModel(MainViewModel mainViewModel, HomeViewModel homeViewModel)
    {
        _mainViewModel = mainViewModel;
        _homeViewModel = homeViewModel;
        IsCommandErrorVisible = false;
        IsMisfireErrorVisible = false;
        IsStartByteErrorVisible = false;
        IsDestinationByteErrorVisible = false;
        IsSourceByteErrorVisible = false;
        IsEndByteErrorVisible = false;
        FlasherMisfireBackground = new SolidColorBrush(Colors.White);
        FlasherMisfires = "0";
    }

    [RelayCommand]
    public void SubmitFlasherMisfires(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            _homeViewModel.LogText += "Error ICC17: FlasherMisfires input is empty.\n";
            return;
        }

        if (int.TryParse(text, out int misfires))
        {
            if (misfires >= 0) // Adjust validation as needed
            {
                FlasherMisfires = misfires.ToString(); // Update property
                FlasherMisfireBackground = new SolidColorBrush(Colors.White); // Reset background
                _homeViewModel.LogText += $"ICC17 FlasherMisfires updated to {misfires}.\n";

                // Update cmMessageData or other logic if needed

                _mainViewModel.SendCmCommand(); // Send updated cmMessageData

                if (misfires > 7)
                {
                    FlasherMisfireBackground = new SolidColorBrush(Colors.Red);
                    IsMisfireErrorVisible = true;
                }
                else
                {
                    IsMisfireErrorVisible = false;
                }
            }
            else
            {
                _homeViewModel.LogText += "Error ICC17: FlasherMisfires must be non-negative.\n";
                FlasherMisfireBackground = new SolidColorBrush(Colors.Yellow);
            }
        }
        else
        {
            _homeViewModel.LogText += "Error ICC17: Invalid FlasherMisfires input. Please enter a number.\n";
            FlasherMisfireBackground = new SolidColorBrush(Colors.Yellow);
        }
    }

    [RelayCommand]
    public void SubmitStartByte(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            _homeViewModel.LogText += "Error ICC17: Start Byte input is empty.\n";
            return;
        }

        string cleanedText = text.Trim().ToLower().StartsWith("0x") ? text.Substring(2) : text;

        byte startByte;
        bool isValidInput;

        // Try parsing as hexadecimal first
        try
        {
            startByte = Convert.ToByte(cleanedText, 16);
            isValidInput = true;
        }
        catch
        {
            // Fallback to decimal parsing
            isValidInput = byte.TryParse(cleanedText, out startByte);
        }

        if (isValidInput)
        {
            StartByte = "0x" + startByte.ToString("X2"); // Update property in hex format
            StartByteBackground = new SolidColorBrush(Colors.White); // Reset background
            _homeViewModel.LogText += $"ICC17 Start Byte updated to 0x{startByte.ToString("X2")}.\n";

            // Update cmMessageData or other logic if needed
            _mainViewModel.SendCmCommand(); // Send updated cmMessageData

            if (startByte != _mainViewModel.start)
            {
                StartByteBackground = new SolidColorBrush(Colors.Red);
                IsStartByteErrorVisible = true;
            }
            else
            {
                IsStartByteErrorVisible = false;
            }
        }
        else
        {
            _homeViewModel.LogText += "Error ICC17: Invalid Start Byte input. Please enter a byte number without '0x'.\n";
            StartByteBackground = new SolidColorBrush(Colors.Yellow);
        }
    }

    [RelayCommand]
    public void SubmitDestinationByte(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            _homeViewModel.LogText += "Error ICC17: Destination Byte input is empty.\n";
            return;
        }

        string cleanedText = text.Trim().ToLower().StartsWith("0x") ? text.Substring(2) : text;

        byte destinationByte;
        bool isValidInput;

        // Try parsing as hexadecimal first
        try
        {
            destinationByte = Convert.ToByte(cleanedText, 16);
            isValidInput = true;
        }
        catch
        {
            // Fallback to decimal parsing
            isValidInput = byte.TryParse(cleanedText, out destinationByte);
        }

        if (isValidInput)
        {
            DestinationByte = "0x" + destinationByte.ToString("X2"); // Update property in hex format
            DestinationByteBackground = new SolidColorBrush(Colors.White); // Reset background
            _homeViewModel.LogText += $"ICC17 Destination Byte updated to 0x{destinationByte.ToString("X2")}.\n";

            // Update cmMessageData or other logic if needed
            _mainViewModel.SendCmCommand(); // Send updated cmMessageData

            if (destinationByte != _mainViewModel.cm)
            {
                DestinationByteBackground = new SolidColorBrush(Colors.Red);
                IsDestinationByteErrorVisible = true;
            }
            else
            {
                IsDestinationByteErrorVisible = false;
            }
        }
        else
        {
            _homeViewModel.LogText += "Error ICC17: Invalid Destination Byte input. Please enter a byte number without '0x'.\n";
            DestinationByteBackground = new SolidColorBrush(Colors.Yellow);
        }
    }

    [RelayCommand]
    public void SubmitSourceByte(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            _homeViewModel.LogText += "Error ICC17: Source Byte input is empty.\n";
            return;
        }

        string cleanedText = text.Trim().ToLower().StartsWith("0x") ? text.Substring(2) : text;

        byte sourceByte;
        bool isValidInput;

        // Try parsing as hexadecimal first
        try
        {
            sourceByte = Convert.ToByte(cleanedText, 16);
            isValidInput = true;
        }
        catch
        {
            // Fallback to decimal parsing
            isValidInput = byte.TryParse(cleanedText, out sourceByte);
        }

        if (isValidInput)
        {
            SourceByte = "0x" + sourceByte.ToString("X2"); // Update property in hex format
            SourceByteBackground = new SolidColorBrush(Colors.White); // Reset background
            _homeViewModel.LogText += $"ICC17 Source Byte updated to 0x{sourceByte.ToString("X2")}.\n";

            // Update cmMessageData or other logic if needed
            _mainViewModel.SendCmCommand(); // Send updated cmMessageData

            if (sourceByte != _mainViewModel.icc17)
            {
                SourceByteBackground = new SolidColorBrush(Colors.Red);
                IsSourceByteErrorVisible = true;
            }
            else
            {
                IsSourceByteErrorVisible = false;
            }
        }
        else
        {
            _homeViewModel.LogText += "Error ICC17: Invalid Source Byte input. Please enter a byte number without '0x'.\n";
            SourceByteBackground = new SolidColorBrush(Colors.Yellow);
        }
    }

    [RelayCommand]
    public void SubmitEndByte(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            _homeViewModel.LogText += "Error ICC17: End Byte input is empty.\n";
            return;
        }

        string cleanedText = text.Trim().ToLower().StartsWith("0x") ? text.Substring(2) : text;

        byte endByte;
        bool isValidInput;

        // Try parsing as hexadecimal first
        try
        {
            endByte = Convert.ToByte(cleanedText, 16);
            isValidInput = true;
        }
        catch
        {
            // Fallback to decimal parsing
            isValidInput = byte.TryParse(cleanedText, out endByte);
        }

        if (isValidInput)
        {
            EndByte = "0x" + endByte.ToString("X2"); // Update property in hex format
            EndByteBackground = new SolidColorBrush(Colors.White); // Reset background
            _homeViewModel.LogText += $"ICC17 End Byte updated to 0x{endByte.ToString("X2")}.\n";

            // Update cmMessageData or other logic if needed
            _mainViewModel.SendCmCommand(); // Send updated cmMessageData

            if (endByte != _mainViewModel.end)
            {
                EndByteBackground = new SolidColorBrush(Colors.Red);
                IsEndByteErrorVisible = true;
            }
            else
            {
                IsEndByteErrorVisible = false;
            }
        }
        else
        {
            _homeViewModel.LogText += "Error ICC17: Invalid End Byte input. Please enter a byte number without '0x'.\n";
            EndByteBackground = new SolidColorBrush(Colors.Yellow);
        }
    }

    /*
    [RelayCommand]
    public void OffButtonClicked()
    {
        if (_mainViewModel.icc17On && !_mainViewModel.cmAuto)
        {
            _mainViewModel.icc17On = false;
            _mainViewModel.Icc17SideMenu = "OFF";
            _mainViewModel.Icc17BorderBrush = new SolidColorBrush(Colors.Black);
            _mainViewModel.Icc17BorderBackground = new SolidColorBrush(Colors.Black);
            _homeViewModel.Lvicc17PgBackground = new SolidColorBrush(Colors.LightGray);

            OffButton = new SolidColorBrush(Colors.DarkGray);
            OffForeground = new SolidColorBrush(Colors.White);
            OnButton = new SolidColorBrush(Colors.LightGray);
            OnForeground = new SolidColorBrush(Colors.Black);
            RemButton = new SolidColorBrush(Colors.LightGray);
            RemForeground = new SolidColorBrush(Colors.Black);
            LowButton = new SolidColorBrush(Colors.LightGray);
            LowForeground = new SolidColorBrush(Colors.Black);
            MedButton = new SolidColorBrush(Colors.LightGray);
            MedForeground = new SolidColorBrush(Colors.Black);
            HighButton = new SolidColorBrush(Colors.LightGray);
            HighForeground = new SolidColorBrush(Colors.Black);

            _mainViewModel.icc17Rem = false;

            _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fOffByte);
            _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fOnByte);

            if (_mainViewModel.icc17Low)
            {
                _mainViewModel.icc17Low = false;
                _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fLowByte);
            }
            if (_mainViewModel.icc17Med)
            {
                _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fMedByte);
                _mainViewModel.icc17Med = false;
            }
            if (_mainViewModel.icc17High)
            {
                _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fHighByte);
                _mainViewModel.icc17High = false;
            }

            _mainViewModel.SendCmCommand();
        }

    }

    [RelayCommand]
    public void OnButtonClicked()
    {
        if (!_mainViewModel.icc17On && !_mainViewModel.cmAuto)
        {
            _mainViewModel.icc17On = true;
            _mainViewModel.Icc17SideMenu = "";
            _mainViewModel.Icc17BorderBrush = new SolidColorBrush(Colors.Green);
            _mainViewModel.Icc17BorderBackground = new SolidColorBrush(Colors.Green);
            _homeViewModel.Lvicc17PgBackground = new SolidColorBrush(Colors.Green);

            OnButton = new SolidColorBrush(Colors.Green);
            OnForeground = new SolidColorBrush(Colors.White);
            OffButton = new SolidColorBrush(Colors.LightGray);
            OffForeground = new SolidColorBrush(Colors.Black);

            _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fOffByte);
            _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fOnByte);

            _mainViewModel.SendCmCommand();
        }
    }

    [RelayCommand]
    public void RemButtonClicked()
    {
        if (_mainViewModel.icc17On && !_mainViewModel.cmAuto)
        {
            if (!_mainViewModel.icc17Rem)
            {
                _mainViewModel.icc17Rem = true;
                RemButton = new SolidColorBrush(Colors.Green);
                RemForeground = new SolidColorBrush(Colors.White);
            }
            else
            {
                _mainViewModel.icc17Rem = false;
                RemButton = new SolidColorBrush(Colors.LightGray);
                RemForeground = new SolidColorBrush(Colors.Black);
            }

        }
    }

    [RelayCommand]
    public void LowButtonClicked()
    {
        if (_mainViewModel.icc17On && !_mainViewModel.icc17Low && !_mainViewModel.cmAuto)
        {
            if (_mainViewModel.icc17Med)
            {
                _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fMedByte);
                _mainViewModel.icc17Med = false;
            }
            if (_mainViewModel.icc17High)
            {
                _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fHighByte);
                _mainViewModel.icc17High = false;
            }
            _mainViewModel.icc17Low = true;
            _mainViewModel.Icc17SideMenu = "LOW";
            _mainViewModel.Icc17BorderBrush = new SolidColorBrush(Colors.Green);
            _mainViewModel.Icc17BorderBackground = new SolidColorBrush(Colors.Green);
            _homeViewModel.Lvicc17PgBackground = new SolidColorBrush(Colors.Green);

            LowButton = new SolidColorBrush(Colors.Green);
            LowForeground = new SolidColorBrush(Colors.White);
            MedButton = new SolidColorBrush(Colors.LightGray);
            MedForeground = new SolidColorBrush(Colors.Black);
            HighButton = new SolidColorBrush(Colors.LightGray);
            HighForeground = new SolidColorBrush(Colors.Black);

            _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fLowByte);

            _mainViewModel.SendCmCommand();
        }

    }

    [RelayCommand]
    public void MedButtonClicked()
    {
        if (_mainViewModel.icc17On && !_mainViewModel.icc17Med && !_mainViewModel.cmAuto)
        {
            if (_mainViewModel.icc17Low)
            {
                _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fLowByte);
                _mainViewModel.icc17Low = false;
            }
            if (_mainViewModel.icc17High)
            {
                _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fHighByte);
                _mainViewModel.icc17High = false;
            }
            _mainViewModel.icc17Med = true;
            _mainViewModel.Icc17SideMenu = "MED";
            _mainViewModel.Icc17BorderBrush = new SolidColorBrush(Colors.Orange);
            _mainViewModel.Icc17BorderBackground = new SolidColorBrush(Colors.Orange);
            _homeViewModel.Lvicc17PgBackground = new SolidColorBrush(Colors.Orange);

            MedButton = new SolidColorBrush(Colors.Orange);
            MedForeground = new SolidColorBrush(Colors.White);
            LowButton = new SolidColorBrush(Colors.LightGray);
            LowForeground = new SolidColorBrush(Colors.Black);
            HighButton = new SolidColorBrush(Colors.LightGray);
            HighForeground = new SolidColorBrush(Colors.Black);

            _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fMedByte);

            _mainViewModel.SendCmCommand();

        }

    }

    [RelayCommand]
    public void HighButtonClicked()
    {
        if (_mainViewModel.icc17On && !_mainViewModel.icc17High && !_mainViewModel.cmAuto)
        {
            if (_mainViewModel.icc17Low)
            {
                _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fLowByte);
                _mainViewModel.icc17Low = false;
            }
            if (_mainViewModel.icc17Med)
            {
                _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fMedByte);
                _mainViewModel.icc17Med = false;
            }
            _mainViewModel.icc17High = true;
            _mainViewModel.Icc17SideMenu = "HIGH";
            _mainViewModel.Icc17BorderBrush = new SolidColorBrush(Colors.OrangeRed);
            _mainViewModel.Icc17BorderBackground = new SolidColorBrush(Colors.OrangeRed);
            _homeViewModel.Lvicc17PgBackground = new SolidColorBrush(Colors.OrangeRed);

            HighButton = new SolidColorBrush(Colors.OrangeRed);
            HighForeground = new SolidColorBrush(Colors.White);
            LowButton = new SolidColorBrush(Colors.LightGray);
            LowForeground = new SolidColorBrush(Colors.Black);
            MedButton = new SolidColorBrush(Colors.LightGray);
            MedForeground = new SolidColorBrush(Colors.Black);

            _mainViewModel.icc17MessageData = (byte)(_mainViewModel.icc17MessageData ^ _mainViewModel.fHighByte);

            _mainViewModel.SendCmCommand();
        }
    }
    */
}


