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
using System.Text;
using System.Threading.Tasks;

namespace CM_Simulator.ViewModels;

public partial class HomeViewModel : ViewModelBase
{

    private readonly MainViewModel _mainViewModel;

    [ObservableProperty]
    private bool _alsfMode = true;

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

    [ObservableProperty]
    private IBrush _commFault = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _commFaultForeground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _failure = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _failureForeground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _txStatus = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _rxStatus = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private bool _ft2400Enabled = false;

    [ObservableProperty]
    private bool _ft3000Enabled = false;

    [ObservableProperty]
    private bool _ft2400Visible = true;

    [ObservableProperty]
    private bool _ft3000Visible = true;

    [ObservableProperty]
    private IBrush _ft2400Background = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _ft3000Background = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    public string _logText = "";

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
    private void AlsfModeChange()
    {
        if (!_mainViewModel.AlsfMode)
        {
            AlsfMode = true;
            AlsfButton = new SolidColorBrush(Colors.LightGreen);
            SsalrButton = new SolidColorBrush(Colors.LightGray);
            _mainViewModel.AlsfMode = true;
            _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.alsfModeByte);
            _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.ssalrModeByte);
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
            _mainViewModel.AlsfMode = false;
            _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.alsfModeByte);
            _mainViewModel.cmMessageData = (byte)(_mainViewModel.cmMessageData ^ _mainViewModel.ssalrModeByte);
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
                LogText += $"Log exported to {result}\n";
            }
            else
            {
                LogText += "Export canceled by user\n";
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show($"Error exporting log: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogText += $"Error exporting log: {ex.Message}\n";
        }
    }


    [RelayCommand]
    public void MainOffControlClicked()
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

            _mainViewModel.SendCmCommand();
        }
    }

    [RelayCommand]
    public void MainOnControlClicked()
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

            _mainViewModel.SendCmCommand();
        }
    }

    [RelayCommand]
    public void MainLowControlClicked()
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

                _mainViewModel.SendCmCommand();
            }
        }
    }

    [RelayCommand]
    public void MainMedControlClicked()
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

                _mainViewModel.SendCmCommand();
            }
            
        }
    }

    [RelayCommand]
    public void MainHighControlClicked()
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

                _mainViewModel.SendCmCommand();
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

        for(int i = 0; i < 21; i++)
        {
            _mainViewModel.SendShortDataRequest(_mainViewModel.addresses[i]);
            await Task.Delay(1500);

        }

        _mainViewModel.enableButtons();
    }

    [RelayCommand]
    public async Task ConfigDataRequested()
    {
        _mainViewModel.disableButtons();

        for(int i = 0; i < 21; i++)
        {
            _mainViewModel.SendConfigDataRequest(_mainViewModel.addresses[i]);
            await Task.Delay(1500);
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
        if (!_mainViewModel.commFault)
        {
            _mainViewModel.StopContinuousBeep();
        }
        
    }

    [RelayCommand]
    public void Ft2400Clicked()
    {

    }

    [RelayCommand]
    public void Ft3000Clicked()
    {

    }
}


