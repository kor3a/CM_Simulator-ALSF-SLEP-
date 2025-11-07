using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Tmds.DBus.Protocol;

namespace CM_Simulator.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    private WaveOutEvent waveOut;
    private SignalGenerator signalGen;

    [ObservableProperty]
    private bool _sideMenuExpanded = true;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc1PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc2PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc3PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc4PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc5PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc6PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc7PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc8PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc9PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc10PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc11PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc12PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc13PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc14PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc15PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc16PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc17PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc18PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc19PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc20PageIsActive))]
    [NotifyPropertyChangedFor(nameof(Icc21PageIsActive))]
    private ViewModelBase _currentPage;

    public bool HomePageIsActive => CurrentPage == _homePage;
    public bool Icc1PageIsActive => CurrentPage == _icc1Page;
    public bool Icc2PageIsActive => CurrentPage == _icc2Page;
    public bool Icc3PageIsActive => CurrentPage == _icc3Page;
    public bool Icc4PageIsActive => CurrentPage == _icc4Page;
    public bool Icc5PageIsActive => CurrentPage == _icc5Page;
    public bool Icc6PageIsActive => CurrentPage == _icc6Page;
    public bool Icc7PageIsActive => CurrentPage == _icc7Page;
    public bool Icc8PageIsActive => CurrentPage == _icc8Page;
    public bool Icc9PageIsActive => CurrentPage == _icc9Page;
    public bool Icc10PageIsActive => CurrentPage == _icc10Page;
    public bool Icc11PageIsActive => CurrentPage == _icc11Page;
    public bool Icc12PageIsActive => CurrentPage == _icc12Page;
    public bool Icc13PageIsActive => CurrentPage == _icc13Page;
    public bool Icc14PageIsActive => CurrentPage == _icc14Page;
    public bool Icc15PageIsActive => CurrentPage == _icc15Page;
    public bool Icc16PageIsActive => CurrentPage == _icc16Page;
    public bool Icc17PageIsActive => CurrentPage == _icc17Page;
    public bool Icc18PageIsActive => CurrentPage == _icc18Page;
    public bool Icc19PageIsActive => CurrentPage == _icc19Page;
    public bool Icc20PageIsActive => CurrentPage == _icc20Page;
    public bool Icc21PageIsActive => CurrentPage == _icc21Page;

    private readonly HomeViewModel _homePage;
    private readonly ICC1ViewModel _icc1Page;
    private readonly ICC2ViewModel _icc2Page;
    private readonly ICC3ViewModel _icc3Page;
    private readonly ICC4ViewModel _icc4Page;
    private readonly ICC5ViewModel _icc5Page;
    private readonly ICC6ViewModel _icc6Page;
    private readonly ICC7ViewModel _icc7Page;
    private readonly ICC8ViewModel _icc8Page;
    private readonly ICC9ViewModel _icc9Page;
    private readonly ICC10ViewModel _icc10Page;
    private readonly ICC11ViewModel _icc11Page;
    private readonly ICC12ViewModel _icc12Page;
    private readonly ICC13ViewModel _icc13Page;
    private readonly ICC14ViewModel _icc14Page;
    private readonly ICC15ViewModel _icc15Page;
    private readonly ICC16ViewModel _icc16Page;
    private readonly ICC17ViewModel _icc17Page;
    private readonly ICC18ViewModel _icc18Page;
    private readonly ICC19ViewModel _icc19Page;
    private readonly ICC20ViewModel _icc20Page;
    private readonly ICC21ViewModel _icc21Page;

    public bool cmOn = false;
    public bool cmLow = false;
    public bool cmMed = false;
    public bool cmHigh = false;

    public bool icc1On = false;
    public bool icc1Rem = false;
    public bool icc1Low = false;
    public bool icc1Med = false;
    public bool icc1High = false;

    public bool icc2On = false;
    public bool icc2Rem = false;
    public bool icc2Low = false;
    public bool icc2Med = false;
    public bool icc2High = false;

    public bool icc3On = false;
    public bool icc3Rem = false;
    public bool icc3Low = false;
    public bool icc3Med = false;
    public bool icc3High = false;

    public bool icc4On = false;
    public bool icc4Rem = false;
    public bool icc4Low = false;
    public bool icc4Med = false;
    public bool icc4High = false;

    public bool icc5On = false;
    public bool icc5Rem = false;
    public bool icc5Low = false;
    public bool icc5Med = false;
    public bool icc5High = false;

    public bool icc6On = false;
    public bool icc6Rem = false;
    public bool icc6Low = false;
    public bool icc6Med = false;
    public bool icc6High = false;

    public bool icc7On = false;
    public bool icc7Rem = false;
    public bool icc7Low = false;
    public bool icc7Med = false;
    public bool icc7High = false;

    public bool icc8On = false;
    public bool icc8Rem = false;
    public bool icc8Low = false;
    public bool icc8Med = false;
    public bool icc8High = false;

    public bool icc9On = false;
    public bool icc9Rem = false;
    public bool icc9Low = false;
    public bool icc9Med = false;
    public bool icc9High = false;

    public bool icc10On = false;
    public bool icc10Rem = false;
    public bool icc10Low = false;
    public bool icc10Med = false;
    public bool icc10High = false;

    public bool icc11On = false;
    public bool icc11Rem = false;
    public bool icc11Low = false;
    public bool icc11Med = false;
    public bool icc11High = false;

    public bool icc12On = false;
    public bool icc12Rem = false;
    public bool icc12Low = false;
    public bool icc12Med = false;
    public bool icc12High = false;

    public bool icc13On = false;
    public bool icc13Rem = false;
    public bool icc13Low = false;
    public bool icc13Med = false;
    public bool icc13High = false;

    public bool icc14On = false;
    public bool icc14Rem = false;
    public bool icc14Low = false;
    public bool icc14Med = false;
    public bool icc14High = false;

    public bool icc15On = false;
    public bool icc15Rem = false;
    public bool icc15Low = false;
    public bool icc15Med = false;
    public bool icc15High = false;

    public bool icc16On = false;
    public bool icc16Rem = false;
    public bool icc16Low = false;
    public bool icc16Med = false;
    public bool icc16High = false;

    public bool icc17On = false;
    public bool icc17Rem = false;
    public bool icc17Low = false;
    public bool icc17Med = false;
    public bool icc17High = false;

    public bool icc18On = false;
    public bool icc18Rem = false;
    public bool icc18Low = false;
    public bool icc18Med = false;
    public bool icc18High = false;

    public bool icc19On = false;
    public bool icc19Rem = false;
    public bool icc19Low = false;
    public bool icc19Med = false;
    public bool icc19High = false;

    public bool icc20On = false;
    public bool icc20Rem = false;
    public bool icc20Low = false;
    public bool icc20Med = false;
    public bool icc20High = false;

    public bool icc21On = false;
    public bool icc21Rem = false;
    public bool icc21Low = false;
    public bool icc21Med = false;
    public bool icc21High = false;

    [ObservableProperty]
    private GridLength _borderWidth = new GridLength(200.0); // Default expanded width

    [ObservableProperty]
    private double _sideMenuItemWidth = 180;

    [ObservableProperty]
    private ObservableCollection<string> _availablePorts;

    [ObservableProperty]
    private string _selectedPort;

    [ObservableProperty]
    private SerialPort _sp;

    [ObservableProperty]
    private bool _alsfMode = true;

    [ObservableProperty]
    private string _icc1SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc1SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc1BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc1BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc2SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc2SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc2BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc2BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc3SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc3SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc3BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc3BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc4SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc4SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc4BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc4BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc5SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc5SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc5BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc5BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc6SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc6SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc6BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc6BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc7SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc7SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc7BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc7BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc8SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc8SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc8BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc8BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc9SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc9SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc9BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc9BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc10SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc10SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc10BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc10BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc11SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc11SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc11BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc11BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc12SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc12SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc12BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc12BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc13SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc13SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc13BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc13BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc14SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc14SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc14BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc14BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc15SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc15SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc15BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc15BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc16SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc16SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc16BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc16BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc17SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc17SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc17BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc17BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc18SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc18SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc18BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc18BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc19SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc19SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc19BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc19BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc20SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc20SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc20BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc20BorderBackground = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private string _icc21SideMenu = "OFF";

    [ObservableProperty]
    private IBrush _icc21SideBackground = new SolidColorBrush(Colors.LightGray);

    [ObservableProperty]
    private IBrush _icc21BorderBrush = new SolidColorBrush(Colors.Black);

    [ObservableProperty]
    private IBrush _icc21BorderBackground = new SolidColorBrush(Colors.Black);

    // addresses
    private byte global = 0x20;
    public byte cm = 0x21;
    public byte icc1 = 0x26;
    public byte icc2 = 0x27;
    public byte icc3 = 0x28;
    public byte icc4 = 0x29;
    public byte icc5 = 0x2A;
    public byte icc6 = 0x2B;
    public byte icc7 = 0x2C;
    public byte icc8 = 0x2D;
    public byte icc9 = 0x2E;
    public byte icc10 = 0x2F;
    public byte icc11 = 0x30;
    public byte icc12 = 0x31;
    public byte icc13 = 0x32;
    public byte icc14 = 0x33;
    public byte icc15 = 0x34;
    public byte icc16 = 0x35;
    public byte icc17 = 0x36;
    public byte icc18 = 0x37;
    public byte icc19 = 0x38;
    public byte icc20 = 0x39;
    public byte icc21 = 0x3A;
    public byte[] addresses = {};

    // icc connected?
    public bool icc1Connected = false;
    public bool icc2Connected = false;
    public bool icc3Connected = false;
    public bool icc4Connected = false;
    public bool icc5Connected = false;
    public bool icc6Connected = false;
    public bool icc7Connected = false;
    public bool icc8Connected = false;
    public bool icc9Connected = false;
    public bool icc10Connected = false;
    public bool icc11Connected = false;
    public bool icc12Connected = false;
    public bool icc13Connected = false;
    public bool icc14Connected = false;
    public bool icc15Connected = false;
    public bool icc16Connected = false;
    public bool icc17Connected = false;
    public bool icc18Connected = false;
    public bool icc19Connected = false;
    public bool icc20Connected = false;
    public bool icc21Connected = false;

    // protocol
    public byte start = 0x01;
    public byte end = 0x03;
    
    public byte cmMessageData = 0xA2;
    public byte icc1MessageData = 0xA2;
    public byte icc2MessageData = 0xA2;
    public byte icc3MessageData = 0xA2;
    public byte icc4MessageData = 0xA2;
    public byte icc5MessageData = 0xA2;
    public byte icc6MessageData = 0xA2;
    public byte icc7MessageData = 0xA2;
    public byte icc8MessageData = 0xA2;
    public byte icc9MessageData = 0xA2;
    public byte icc10MessageData = 0xA2;
    public byte icc11MessageData = 0xA2;
    public byte icc12MessageData = 0xA2;
    public byte icc13MessageData = 0xA2;
    public byte icc14MessageData = 0xA2;
    public byte icc15MessageData = 0xA2;
    public byte icc16MessageData = 0xA2;
    public byte icc17MessageData = 0xA2;
    public byte icc18MessageData = 0xA2;
    public byte icc19MessageData = 0xA2;
    public byte icc20MessageData = 0xA2;
    public byte icc21MessageData = 0xA2;

    // Reset
    public byte RESET_COMMAND = 0x41;
    public byte RESET_RESULTS = 0xC0;
    public byte cpuTest = 0x01;
    public byte epromTest = 0x02;
    public byte sramTest = 0x04;
    public byte digitalTest = 0x08;
    public byte adConverterTest = 0x10;
    public byte watchdogTest = 0x20;
    public byte idleTest = 0x40;
    public byte rs485_1Test = 0x80;
    public byte rs485_2Test = 0x01;
    public byte rs232Test = 0x02;
    public byte ledDisplayTest = 0x04;

    // Commands Response Message
    public byte COMMANDS_RESPONSE = 0x42;
    public byte fOnByte = 0x01;
    public byte fOffByte = 0x02;
    public byte fLowByte = 0x04;
    public byte fMedByte = 0x08;
    public byte fHighByte = 0x10;
    public byte alsfModeByte = 0x20;
    public byte ssalrModeByte = 0x40;
    public byte gen2HzByte = 0x80;
    public byte commandRejected = 0x80;

    // Short Data Response Message
    public byte SHORT_DATA_RESPONSE = 0x43;

    // Enquire and Acknowledge
    public byte ENQ = 0xB7;
    public byte ACK = 0x78;

    // Configuration Response Message
    public byte CONFIG_RESPONSE = 0x47;
    public byte remoteConfig = 0x01;
    public byte offConfig = 0x02;
    public byte lowConfig = 0x04;
    public byte medConfig = 0x08;
    public byte highConfig = 0x10;
    public byte flashOpen = 0x20;
    public byte mtConnected = 0x40;
    public byte alsfConfig = 0x00;
    public byte malsrConfig = 0x01;
    public byte ldinConfig = 0x02;
    public byte reilConfig = 0x03;
    public byte controlConfig = 0x04;
    public byte flasherType = 0x08;
    public byte compatMode = 0x80;

    public bool icc1Compat = true;
    public bool icc2Compat = true;
    public bool icc3Compat = true;
    public bool icc4Compat = true;
    public bool icc5Compat = true;
    public bool icc6Compat = true;
    public bool icc7Compat = true;
    public bool icc8Compat = true;
    public bool icc9Compat = true;
    public bool icc10Compat = true;
    public bool icc11Compat = true;
    public bool icc12Compat = true;
    public bool icc13Compat = true;
    public bool icc14Compat = true;
    public bool icc15Compat = true;
    public bool icc16Compat = true;
    public bool icc17Compat = true;
    public bool icc18Compat = true;
    public bool icc19Compat = true;
    public bool icc20Compat = true;
    public bool icc21Compat = true;

    public bool alsfCaution = false;
    public bool ssalrCaution = false;
    public bool alsfFailure = false;
    public bool ssalrFailure = false;
    public int flashersConnected = 0;
    public bool[] iccs = new bool[21];

    public bool portHealthy = true;
    public bool commFault = false;
    private bool _initialScanComplete = false;
    private int _expectedConfigResponses = 0;
    private int _processedConfigResponses = 0;

    Dictionary<byte, int> dict = new Dictionary<byte, int>()
    {
        { 0x26, 1 },
        { 0x27, 2 },
        { 0x28, 3 },
        { 0x29, 4 },
        { 0x2A, 5 },
        { 0x2B, 6 },
        { 0x2C, 7 },
        { 0x2D, 8 },
        { 0x2E, 9 },
        { 0x2F, 10 },
        { 0x30, 11 },
        { 0x31, 12 },
        { 0x32, 13 },
        { 0x33, 14 },
        { 0x34, 15 },
        { 0x35, 16 },
        { 0x36, 17 },
        { 0x37, 18 },
        { 0x38, 19 },
        { 0x39, 20 },
        { 0x3A, 21 },
    };

    public CancellationTokenSource? cautionToneCts = null;
    public CancellationTokenSource? sequentialFlashCts = null;

    private readonly Dictionary<byte, TaskCompletionSource<byte[]>> _pendingResponses = new();
    private readonly object _lock = new();

    // State Machines
    private enum ParseState
    {
        WaitingForStart,
        WaitingForDestination,
        WaitingForSource,
        WaitingForMessageID,
        WaitingForLength,
        WaitingForParameter,
        WaitingForStop
    }

    private ParseState _currentState = ParseState.WaitingForStart;
    private byte _currentSource;
    private int _expectedLength;
    private List<byte> _currentMessage = new List<byte>();

    // CRC
    private static readonly int[] crc16 = {
        0x0000, 0xC0C1, 0xC181, 0x0140, 0xC301, 0x03C0, 0x0280, 0xC241,
        0xC601, 0x06C0, 0x0780, 0xC741, 0x0500, 0xC5C1, 0xC481, 0x0440,
        0xCC01, 0x0CC0, 0x0D80, 0xCD41, 0x0F00, 0xCFC1, 0xCE81, 0x0E40,
        0x0A00, 0xCAC1, 0xCB81, 0x0B40, 0xC901, 0x09C0, 0x0880, 0xC841,
        0xD801, 0x18C0, 0x1980, 0xD941, 0x1B00, 0xDBC1, 0xDA81, 0x1A40,
        0x1E00, 0xDEC1, 0xDF81, 0x1F40, 0xDD01, 0x1DC0, 0x1C80, 0xDC41,
        0x1400, 0xD4C1, 0xD581, 0x1540, 0xD701, 0x17C0, 0x1680, 0xD641,
        0xD201, 0x12C0, 0x1380, 0xD341, 0x1100, 0xD1C1, 0xD081, 0x1040,
        0xF001, 0x30C0, 0x3180, 0xF141, 0x3300, 0xF3C1, 0xF281, 0x3240,
        0x3600, 0xF6C1, 0xF781, 0x3740, 0xF501, 0x35C0, 0x3480, 0xF441,
        0x3C00, 0xFCC1, 0xFD81, 0x3D40, 0xFF01, 0x3FC0, 0x3E80, 0xFE41,
        0xFA01, 0x3AC0, 0x3B80, 0xFB41, 0x3900, 0xF9C1, 0xF881, 0x3840,
        0x2800, 0xE8C1, 0xE981, 0x2940, 0xEB01, 0x2BC0, 0x2A80, 0xEA41,
        0xEE01, 0x2EC0, 0x2F80, 0xEF41, 0x2D00, 0xEDC1, 0xEC81, 0x2C40,
        0xE401, 0x24C0, 0x2580, 0xE541, 0x2700, 0xE7C1, 0xE681, 0x2640,
        0x2200, 0xE2C1, 0xE381, 0x2340, 0xE101, 0x21C0, 0x2080, 0xE041,
        0xA001, 0x60C0, 0x6180, 0xA141, 0x6300, 0xA3C1, 0xA281, 0x6240,
        0x6600, 0xA6C1, 0xA781, 0x6740, 0xA501, 0x65C0, 0x6480, 0xA441,
        0x6C00, 0xACC1, 0xAD81, 0x6D40, 0xAF01, 0x6FC0, 0x6E80, 0xAE41,
        0xAA01, 0x6AC0, 0x6B80, 0xAB41, 0x6900, 0xA9C1, 0xA881, 0x6840,
        0x7800, 0xB8C1, 0xB981, 0x7940, 0xBB01, 0x7BC0, 0x7A80, 0xBA41,
        0xBE01, 0x7EC0, 0x7F80, 0xBF41, 0x7D00, 0xBDC1, 0xBC81, 0x7C40,
        0xB401, 0x74C0, 0x7580, 0xB541, 0x7700, 0xB7C1, 0xB681, 0x7640,
        0x7200, 0xB2C1, 0xB381, 0x7340, 0xB101, 0x71C0, 0x7080, 0xB041,
        0x5000, 0x90C1, 0x9181, 0x5140, 0x9301, 0x53C0, 0x5280, 0x9241,
        0x9601, 0x56C0, 0x5780, 0x9741, 0x5500, 0x95C1, 0x9481, 0x5440,
        0x9C01, 0x5CC0, 0x5D80, 0x9D41, 0x5F00, 0x9FC1, 0x9E81, 0x5E40,
        0x5A00, 0x9AC1, 0x9B81, 0x5B40, 0x9901, 0x59C0, 0x5880, 0x9841,
        0x8801, 0x48C0, 0x4980, 0x8941, 0x4B00, 0x8BC1, 0x8A81, 0x4A40,
        0x4E00, 0x8EC1, 0x8F81, 0x4F40, 0x8D01, 0x4DC0, 0x4C80, 0x8C41,
        0x4400, 0x84C1, 0x8581, 0x4540, 0x8701, 0x47C0, 0x4680, 0x8641,
        0x8201, 0x42C0, 0x4380, 0x8341, 0x4100, 0x81C1, 0x8081, 0x4040
    };

    public static byte[] ComputeCrc16(byte[] bytes)
    {
        int crc = 0x0000;
        foreach (byte b in bytes)
        {
            crc = (crc >> 8) ^ crc16[(crc ^ b) & 0xFF];
        }
        // Convert the 16-bit CRC to two bytes (little-endian)
        return new byte[] { (byte)(crc & 0xFF), (byte)((crc >> 8) & 0xFF) };
    }

    public MainViewModel()
    {
        _homePage = new HomeViewModel(this);
        _icc1Page = new ICC1ViewModel(this, _homePage);
        _icc2Page = new ICC2ViewModel(this, _homePage);
        _icc3Page = new ICC3ViewModel(this, _homePage);
        _icc4Page = new ICC4ViewModel(this, _homePage);
        _icc5Page = new ICC5ViewModel(this, _homePage);
        _icc6Page = new ICC6ViewModel(this, _homePage);
        _icc7Page = new ICC7ViewModel(this, _homePage);
        _icc8Page = new ICC8ViewModel(this, _homePage);
        _icc9Page = new ICC9ViewModel(this, _homePage);
        _icc10Page = new ICC10ViewModel(this, _homePage);
        _icc11Page = new ICC11ViewModel(this, _homePage);
        _icc12Page = new ICC12ViewModel(this, _homePage);
        _icc13Page = new ICC13ViewModel(this, _homePage);
        _icc14Page = new ICC14ViewModel(this, _homePage);
        _icc15Page = new ICC15ViewModel(this, _homePage);
        _icc16Page = new ICC16ViewModel(this, _homePage);
        _icc17Page = new ICC17ViewModel(this, _homePage);
        _icc18Page = new ICC18ViewModel(this, _homePage);
        _icc19Page = new ICC19ViewModel(this, _homePage);
        _icc20Page = new ICC20ViewModel(this, _homePage);
        _icc21Page = new ICC21ViewModel(this, _homePage);
        CurrentPage = _homePage;
        AvailablePorts = new ObservableCollection<string>(SerialPort.GetPortNames().OrderBy(p => p));
        SelectedPort = AvailablePorts.FirstOrDefault();
        addresses = new byte[] {icc1, icc2, icc3, icc4, icc5, icc6, icc7, icc8, icc9, icc10, icc11, icc12, icc13, icc14, icc15, icc16, icc17, icc18, icc19, icc20, icc21};

        // disable all the buttons
        disableButtons();

    }

    private void resetPgStatus()
    {
        _homePage.Lvicc1PgStatus = false;
        _homePage.Lvicc2PgStatus = false;
        _homePage.Lvicc3PgStatus = false;
        _homePage.Lvicc4PgStatus = false;
        _homePage.Lvicc5PgStatus = false;
        _homePage.Lvicc6PgStatus = false;
        _homePage.Lvicc7PgStatus = false;
        _homePage.Lvicc8PgStatus = false;
        _homePage.Lvicc9PgStatus = false;
        _homePage.Lvicc10PgStatus = false;
        _homePage.Lvicc11PgStatus = false;
        _homePage.Lvicc12PgStatus = false;
        _homePage.Lvicc13PgStatus = false;
        _homePage.Lvicc14PgStatus = false;
        _homePage.Lvicc15PgStatus = false;
        _homePage.Lvicc16PgStatus = false;
        _homePage.Lvicc17PgStatus = false;
        _homePage.Lvicc18PgStatus = false;
        _homePage.Lvicc19PgStatus = false;
        _homePage.Lvicc20PgStatus = false;
        _homePage.Lvicc21PgStatus = false;
    }

    public void enableButtons()
    {
        _homePage.CmOffEnabled = true;
        _homePage.CmOnEnabled = true;
        _homePage.CmLowEnabled = true;
        _homePage.CmMedEnabled = true;
        _homePage.CmHighEnabled = true;
        _homePage.CmAlsfEnabled = true;
        _homePage.CmSsalrEnabled = true;
        _homePage.ResetEnabled = true;
        _homePage.ShortEnabled = true;
        _homePage.ConfigEnabled = true;
    }

    public void disableButtons()
    {
        _homePage.CmOffEnabled = false;
        _homePage.CmOnEnabled = false;
        _homePage.CmLowEnabled = false;
        _homePage.CmMedEnabled = false;
        _homePage.CmHighEnabled = false;
        _homePage.CmAlsfEnabled = false;
        _homePage.CmSsalrEnabled = false;
        _homePage.ResetEnabled = false;
        _homePage.ShortEnabled = false;
        _homePage.ConfigEnabled = false;
    }

    public void StartContinuousBeep()
    {
        signalGen = new SignalGenerator()
        {
            Gain = 0.2,         // volume (0.0–1.0)
            Frequency = 2000,   // Hz
            Type = SignalGeneratorType.Sin
        };

        waveOut = new WaveOutEvent();
        waveOut.Init(signalGen);
        waveOut.Play();
    }

    public void StopContinuousBeep()
    {
        waveOut?.Stop();
        waveOut?.Dispose();
        waveOut = null;
    }

    public void StartSequentialFlash()
    {
        // Cancel any existing flash task
        sequentialFlashCts?.Cancel();
        sequentialFlashCts = new CancellationTokenSource();
        var token = sequentialFlashCts.Token;

        // Start the sequential flashing task
        Task.Run(async () =>
        {
            while (!token.IsCancellationRequested)
            {
                // Array of ICC states to check
                var iccStates = new (bool connected, bool on, Action<IBrush, IBrush> setBackgrounds, Func<(IBrush border, IBrush side)> getOriginalColors)[]
                {
                    (iccs[0], icc1On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc1BorderBackground = borderBrush; Icc1SideBackground = sideBrush; }), () => (icc1Low ? new SolidColorBrush(Colors.Green) : icc1Med ? new SolidColorBrush(Colors.Orange) : icc1High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[1], icc2On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc2BorderBackground = borderBrush; Icc2SideBackground = sideBrush; }), () => (icc2Low ? new SolidColorBrush(Colors.Green) : icc2Med ? new SolidColorBrush(Colors.Orange) : icc2High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[2], icc3On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc3BorderBackground = borderBrush; Icc3SideBackground = sideBrush; }), () => (icc3Low ? new SolidColorBrush(Colors.Green) : icc3Med ? new SolidColorBrush(Colors.Orange) : icc3High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[3], icc4On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc4BorderBackground = borderBrush; Icc4SideBackground = sideBrush; }), () => (icc4Low ? new SolidColorBrush(Colors.Green) : icc4Med ? new SolidColorBrush(Colors.Orange) : icc4High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[4], icc5On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc5BorderBackground = borderBrush; Icc5SideBackground = sideBrush; }), () => (icc5Low ? new SolidColorBrush(Colors.Green) : icc5Med ? new SolidColorBrush(Colors.Orange) : icc5High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[5], icc6On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc6BorderBackground = borderBrush; Icc6SideBackground = sideBrush; }), () => (icc6Low ? new SolidColorBrush(Colors.Green) : icc6Med ? new SolidColorBrush(Colors.Orange) : icc6High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[6], icc7On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc7BorderBackground = borderBrush; Icc7SideBackground = sideBrush; }), () => (icc7Low ? new SolidColorBrush(Colors.Green) : icc7Med ? new SolidColorBrush(Colors.Orange) : icc7High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[7], icc8On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc8BorderBackground = borderBrush; Icc8SideBackground = sideBrush; }), () => (icc8Low ? new SolidColorBrush(Colors.Green) : icc8Med ? new SolidColorBrush(Colors.Orange) : icc8High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[8], icc9On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc9BorderBackground = borderBrush; Icc9SideBackground = sideBrush; }), () => (icc9Low ? new SolidColorBrush(Colors.Green) : icc9Med ? new SolidColorBrush(Colors.Orange) : icc9High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[9], icc10On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc10BorderBackground = borderBrush; Icc10SideBackground = sideBrush; }), () => (icc10Low ? new SolidColorBrush(Colors.Green) : icc10Med ? new SolidColorBrush(Colors.Orange) : icc10High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[10], icc11On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc11BorderBackground = borderBrush; Icc11SideBackground = sideBrush; }), () => (icc11Low ? new SolidColorBrush(Colors.Green) : icc11Med ? new SolidColorBrush(Colors.Orange) : icc11High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[11], icc12On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc12BorderBackground = borderBrush; Icc12SideBackground = sideBrush; }), () => (icc12Low ? new SolidColorBrush(Colors.Green) : icc12Med ? new SolidColorBrush(Colors.Orange) : icc12High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[12], icc13On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc13BorderBackground = borderBrush; Icc13SideBackground = sideBrush; }), () => (icc13Low ? new SolidColorBrush(Colors.Green) : icc13Med ? new SolidColorBrush(Colors.Orange) : icc13High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[13], icc14On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc14BorderBackground = borderBrush; Icc14SideBackground = sideBrush; }), () => (icc14Low ? new SolidColorBrush(Colors.Green) : icc14Med ? new SolidColorBrush(Colors.Orange) : icc14High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[14], icc15On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc15BorderBackground = borderBrush; Icc15SideBackground = sideBrush; }), () => (icc15Low ? new SolidColorBrush(Colors.Green) : icc15Med ? new SolidColorBrush(Colors.Orange) : icc15High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[15], icc16On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc16BorderBackground = borderBrush; Icc16SideBackground = sideBrush; }), () => (icc16Low ? new SolidColorBrush(Colors.Green) : icc16Med ? new SolidColorBrush(Colors.Orange) : icc16High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[16], icc17On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc17BorderBackground = borderBrush; Icc17SideBackground = sideBrush; }), () => (icc17Low ? new SolidColorBrush(Colors.Green) : icc17Med ? new SolidColorBrush(Colors.Orange) : icc17High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[17], icc18On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc18BorderBackground = borderBrush; Icc18SideBackground = sideBrush; }), () => (icc18Low ? new SolidColorBrush(Colors.Green) : icc18Med ? new SolidColorBrush(Colors.Orange) : icc18High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[18], icc19On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc19BorderBackground = borderBrush; Icc19SideBackground = sideBrush; }), () => (icc19Low ? new SolidColorBrush(Colors.Green) : icc19Med ? new SolidColorBrush(Colors.Orange) : icc19High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[19], icc20On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc20BorderBackground = borderBrush; Icc20SideBackground = sideBrush; }), () => (icc20Low ? new SolidColorBrush(Colors.Green) : icc20Med ? new SolidColorBrush(Colors.Orange) : icc20High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen))),
                    (iccs[20], icc21On, (borderBrush, sideBrush) => Avalonia.Threading.Dispatcher.UIThread.Post(() => { Icc21BorderBackground = borderBrush; Icc21SideBackground = sideBrush; }), () => (icc21Low ? new SolidColorBrush(Colors.Green) : icc21Med ? new SolidColorBrush(Colors.Orange) : icc21High ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.LightGreen)))
                };

                // Flash each connected and ON ICC sequentially
                int flashCount = 0;
                for (int i = 0; i < iccStates.Length; i++)
                {
                    if (token.IsCancellationRequested) break;

                    var (connected, on, setBackgrounds, getOriginalColors) = iccStates[i];

                    // Only flash if ICC is connected and ON
                    if (connected && on)
                    {
                        flashCount++;
                        // Flash to White for both backgrounds
                        setBackgrounds(new SolidColorBrush(Colors.White), new SolidColorBrush(Colors.White));

                        // Wait 250ms (2Hz rate = 500ms cycle, 250ms on)
                        await Task.Delay(250, token);

                        // Restore original colors
                        var (borderBrush, sideBrush) = getOriginalColors();
                        setBackgrounds(borderBrush, sideBrush);
                    }
                }

                // If no ICCs were flashed, add a small delay to prevent tight loop
                if (flashCount == 0)
                {
                    await Task.Delay(100, token);
                }
            }
        }, token);
    }

    public void StopSequentialFlash()
    {
        sequentialFlashCts?.Cancel();
        sequentialFlashCts = null;
    }

    private bool IsSequentialFlashRunning()
    {
        return sequentialFlashCts != null && !sequentialFlashCts.IsCancellationRequested;
    }

    private bool AnyIccOn()
    {
        return icc1On || icc2On || icc3On || icc4On || icc5On || icc6On || icc7On || icc8On || icc9On || icc10On ||
               icc11On || icc12On || icc13On || icc14On || icc15On || icc16On || icc17On || icc18On || icc19On || icc20On || icc21On;
    }

    public void CheckAndStartSequentialFlash()
    {
        // Only run after initial scan is complete
        if (!_initialScanComplete)
            return;

        // Start flash if any ICC is ON and flash is not already running
        if (AnyIccOn() && !IsSequentialFlashRunning())
        {
            StartSequentialFlash();
        }
    }

    public void CheckAndStopSequentialFlash()
    {
        // Stop flash if no ICCs are ON
        if (!AnyIccOn() && IsSequentialFlashRunning())
        {
            StopSequentialFlash();
        }
    }

    // Call from HomeViewModel
    public async Task ScanIcc()
    {
        disableButtons();

        foreach (byte address in addresses)
        {
            if (Sp == null || !Sp.IsOpen)
                break;

            try
            {
                await SendEnquireMessage(address);
                int destString = dict[address];

                bool received = await WaitForResponseAsync(address, 1000);
                if (!received)
                {
                    Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += $"Timeout waiting for response from ICC {destString}\n");
                }

                await Task.Delay(500);
            }
            catch (IOException ex)
            {
                await HandleDisconnectAsync($"I/O error: {ex.Message}");
                enableButtons();
                return;
            }
            catch (InvalidOperationException ex)
            {
                await HandleDisconnectAsync($"Disconnected: {ex.Message}");
                enableButtons();
                return;
            }
        }

        enableButtons();
    }

    [RelayCommand]
    public async Task Connect(Window popupWindow)
    {
        if (string.IsNullOrEmpty(SelectedPort))
        {
            _homePage.LogText = "No port has been selected";
            return;
        }

        try
        {
            Sp = new SerialPort(SelectedPort, 9600)
            {
                ReadBufferSize = 128,
                ReadTimeout = 200,
                WriteTimeout = 200,
            };
            Sp.DataReceived += SerialDataReceivedEventHandler; // Hook up event handler

            Sp.Open();

            _homePage.LogText = $"Connected to {SelectedPort}\n\n";
            popupWindow.Close(); // Close the pop-up

            portHealthy = true;

            // Set all the page status to false
            resetPgStatus();
            // enable all the buttons
            enableButtons();

            _ = Task.Run(async () => await CommunicationLoopAsync());
        }
        catch (Exception e)
        {
            _homePage.LogText = $"Error opening port: {e.Message}";
        }
    }

    private async Task CommunicationLoopAsync()
    {
        var lastPortCheck = DateTime.UtcNow;
        portHealthy = true;
        _initialScanComplete = false;
        _expectedConfigResponses = 0;
        _processedConfigResponses = 0;

        try
        {
            disableButtons();

            foreach (byte address in addresses)
            {
                if (Sp == null || !Sp.IsOpen)
                    break;

            try
            {
                await SendEnquireMessage(address);
                int destString = dict[address];

                bool received = await WaitForResponseAsync(address, 1000);
                if (received)
                {
                    _expectedConfigResponses++;
                }
                else
                {
                    Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += $"Timeout waiting for response from ICC {destString}\n");
                }

                    await Task.Delay(500);
                }
                catch (IOException ex)
                {
                    await HandleDisconnectAsync($"I/O error: {ex.Message}");
                    enableButtons();
                    return;
                }
                catch (InvalidOperationException ex)
                {
                    await HandleDisconnectAsync($"Disconnected: {ex.Message}");
                    enableButtons();
                    return;
                }
            }

            enableButtons();
            _initialScanComplete = true;

            // If no responses expected, call CheckAndStartSequentialFlash immediately
            if (_expectedConfigResponses == 0)
            {
                CheckAndStartSequentialFlash();
            }

            while (true)
            {
                await Task.Delay(3000);
                // COMM FAULT:  Periodic port connection check every 3 seconds
                bool portStillHealthy = true;

                try
                {
                    if (Sp == null || !Sp.IsOpen)
                        portStillHealthy = false;
                    else
                    {
                        // verify device still exists in OS
                        var currentPorts = SerialPort.GetPortNames();
                        if (!currentPorts.Contains(SelectedPort))
                            portStillHealthy = false;
                        else
                        {
                            // attempt lightweight write probe
                            Sp.Write(new byte[] { 0x00 }, 0, 1);
                        }
                    }
                }
                catch
                {
                    portStillHealthy = false;
                }

                if (portHealthy != portStillHealthy)
                {
                    portHealthy = portStillHealthy;
                    await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        if (portHealthy)
                        {
                            _homePage.CommFault = new SolidColorBrush(Colors.LightGray);
                            _homePage.CommFaultForeground = new SolidColorBrush(Colors.Black);
                            commFault = false;
                        }
                        else
                        {
                            _homePage.CommFault = new SolidColorBrush(Color.Parse("#FFBF00"));
                            _homePage.CommFaultForeground = new SolidColorBrush(Colors.White);
                            commFault = true;
                            _homePage.stopCautionBeep = false;
                            cautionToneCts?.Cancel();
                            // 0.33 second on; 0.66 second off for Comm Fault
                            cautionToneCts = new CancellationTokenSource();
                            var token = cautionToneCts.Token;
                            Task.Run(async () =>
                            {
                                while (!token.IsCancellationRequested && !_homePage.stopCautionBeep && !alsfFailure && !ssalrFailure)
                                {
                                    Console.Beep(1000, 330); // 1000 Hz tone for 0.33 s
                                    await Task.Delay(660, token); // wait 0.66 s off time
                                }
                            }, token);
                        }
                    });
                }

                if (!portStillHealthy)
                {
                    await HandleDisconnectAsync("Serial port disconnected or removed.");
                    return;
                }             

                // CAUTION & FAILURE
                await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                {
                    // CAUTION
                    if ((AlsfMode && flashersConnected == 19) || (!AlsfMode && flashersConnected == 15))
                    {
                        alsfCaution = ssalrCaution = true;
                        _homePage.Caution = new SolidColorBrush(Color.Parse("#FFBF00"));
                        _homePage.CautionForeground = new SolidColorBrush(Colors.White);
                        // single 0.2 second beep for Caution
                        Console.Beep(2000, 200);
                    }
                    else
                    {
                        alsfCaution = ssalrCaution = false;
                        _homePage.Caution = new SolidColorBrush(Colors.LightGray);
                        _homePage.CautionForeground = new SolidColorBrush(Colors.Black);
                    }

                    // FAILURE
                    if (AlsfMode)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            if ((!(iccs[i] && iccs[i + 1])) || (flashersConnected <= 18))
                            {
                                if (!alsfFailure)
                                {
                                    StartContinuousBeep();
                                }
                                alsfFailure = true;
                                _homePage.Failure = new SolidColorBrush(Colors.Red);
                                _homePage.FailureForeground = new SolidColorBrush(Colors.White);

                                cautionToneCts?.Cancel();
                                _homePage.stopCautionBeep = true;

                            }
                        }
                    }
                    else if (!AlsfMode && flashersConnected <= 14)
                    {
                        if (!ssalrFailure)
                        {
                            StartContinuousBeep();
                        }
                        ssalrFailure = true;
                        _homePage.Failure = new SolidColorBrush(Colors.Red);
                        _homePage.FailureForeground = new SolidColorBrush(Colors.White);
                        if (!portHealthy)
                        {
                            cautionToneCts?.Cancel();
                        }

                    }
                    else
                    {
                        alsfFailure = ssalrFailure = false;
                        _homePage.Failure = new SolidColorBrush(Colors.LightGray);
                        _homePage.FailureForeground = new SolidColorBrush(Colors.Black);
                    }
                });

                await Task.Delay(500);
            }
        }
        catch (Exception ex)
        {
            await HandleDisconnectAsync($"Comm loop error: {ex.Message}");
        }
    }

    private async Task<bool> WaitForResponseAsync(byte address, int timeoutMs)
    {
        TaskCompletionSource<byte[]> tcs;

        lock (_lock)
        {
            if (_pendingResponses.ContainsKey(address))
                _pendingResponses.Remove(address);

            tcs = new TaskCompletionSource<byte[]>();
            _pendingResponses[address] = tcs;
        }

        using (var cts = new CancellationTokenSource(timeoutMs))
        {
            try
            {
                using (cts.Token.Register(() => tcs.TrySetCanceled()))
                {
                    await tcs.Task;
                    return true;
                }
            }
            catch (TaskCanceledException)
            {
                return false;
            }
            finally
            {
                lock (_lock)
                {
                    _pendingResponses.Remove(address);
                }
            }
        }
    }

    private async Task HandleDisconnectAsync(string message)
    {
        await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
        {
            _homePage.LogText += $"\nConnection lost: {message}\n";
        });

        // Stop sequential flash on disconnect
        StopSequentialFlash();
        _initialScanComplete = false;
        _expectedConfigResponses = 0;
        _processedConfigResponses = 0;

        try
        {
            if (Sp != null)
            {
                Sp.DataReceived -= SerialDataReceivedEventHandler;
                if (Sp.IsOpen) Sp.Close();
                Sp.Dispose();
            }
        }
        catch { /* ignore */ }

        Sp = null;
    }

    // Mocking CM: Global Command Message (CM to ICC)
    public void SendCmCommand()
    {
        byte[] cmCommandTx = new byte[9];
        cmCommandTx[0] = start;
        // destination
        cmCommandTx[1] = global;
        // source
        cmCommandTx[2] = cm;
        // message ID = Message Type (10) 10; Message Number (0x02) 0010 = 10000010
        cmCommandTx[3] = 0x82;
        // length
        cmCommandTx[4] = 0x01;
        cmCommandTx[5] = cmMessageData;
        cmCommandTx[6] = end;

        // compute crc16 for bytes 0 to 6
        byte[] payload = new byte[7];
        Array.Copy(cmCommandTx, 0, payload, 0, 7);
        byte[] crc = ComputeCrc16(payload);

        // computed checksum
        cmCommandTx[7] = crc[1]; // low byte
        cmCommandTx[8] = crc[0]; // high byte

        // Send command if serial port is open
        if (Sp != null && Sp.IsOpen)
        {
            Sp.RtsEnable = true;
            Sp.Write(cmCommandTx, 0, cmCommandTx.Length);
            Sp.RtsEnable = false;
            _homePage.LogText += $"Sent CM to global command message: {BitConverter.ToString(cmCommandTx)}\n";

            // Set TX indicator ON
            _homePage.TxStatus = new SolidColorBrush(Colors.Green);

            // Blink for a short duration (non-blocking)
            _ = Task.Run(async () =>
            {
                await Task.Delay(300); // blink duration
                await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                {
                    _homePage.TxStatus = new SolidColorBrush(Colors.LightGray);
                });
            });
        }
        else
        {
            _homePage.LogText += "Error: Error on sending Global CM Command Message\n";
        }

        // Send Short Data Request to receive updates for GUI update
        new Thread(async () =>
        {
            for (int i = 0; i < 21; i++)
            {
                byte[] shortDataRequestTx = new byte[8];
                shortDataRequestTx[0] = start;
                shortDataRequestTx[1] = addresses[i];
                shortDataRequestTx[2] = cm;
                // message ID = Message Type 10; Message Number 0x03 = 10000011
                shortDataRequestTx[3] = 0x83;
                // length
                shortDataRequestTx[4] = 0x00;
                shortDataRequestTx[5] = end;

                byte[] payload1 = new byte[6];
                Array.Copy(shortDataRequestTx, 0, payload1, 0, 6);
                byte[] crc1 = ComputeCrc16(payload1);

                shortDataRequestTx[6] = crc1[1];
                shortDataRequestTx[7] = crc1[0];

                if (Sp != null && Sp.IsOpen)
                {
                    Sp.RtsEnable = true;
                    Sp.Write(shortDataRequestTx, 0, shortDataRequestTx.Length);
                    Sp.RtsEnable = false;
                    // Blink for a short duration (non-blocking)
                    _ = Task.Run(async () =>
                    {
                        // Set TX indicator ON
                        await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                        {
                            _homePage.TxStatus = new SolidColorBrush(Colors.Green);
                        });
                        await Task.Delay(300); // blink duration
                        await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                        {
                            _homePage.TxStatus = new SolidColorBrush(Colors.LightGray);
                        });
                    });
                }

                Thread.Sleep(1200); // safe here since it's a background thread
            }
        }).Start();
    }

    // Mocking CM: Command Message (CM to ICC)
    public void SendCmCommand(byte destination)
    {
        byte[] cmCommandTx = new byte[9];
        cmCommandTx[0] = start;
        // destination
        cmCommandTx[1] = destination;
        // source
        cmCommandTx[2] = cm;
        // message ID = Message Type (10) 10; Message Number (0x02) 0010 = 10000010
        cmCommandTx[3] = 0x82;
        // length
        cmCommandTx[4] = 0x01;
        cmCommandTx[5] = cmMessageData;
        cmCommandTx[6] = end;

        // compute crc16 for bytes 0 to 6
        byte[] payload = new byte[7];
        Array.Copy(cmCommandTx, 0, payload, 0, 7);
        byte[] crc = ComputeCrc16(payload);

        // computed checksum
        cmCommandTx[7] = crc[1]; // low byte
        cmCommandTx[8] = crc[0]; // high byte

        // convert destination byte to corresponding string of an ICC #
        int destString = dict[destination];

        if (Sp != null && Sp.IsOpen)
        {
            Sp.RtsEnable = true;
            Sp.Write(cmCommandTx, 0, cmCommandTx.Length);
            Sp.RtsEnable = false;
            _homePage.LogText += $"Sent CM Command Message to the ICC {destString}: {BitConverter.ToString(cmCommandTx)}\n";

            // Set TX indicator ON
            _homePage.TxStatus = new SolidColorBrush(Colors.Green);

            // Blink for a short duration (non-blocking)
            _ = Task.Run(async () =>
            {
                await Task.Delay(300); // blink duration
                await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                {
                    _homePage.TxStatus = new SolidColorBrush(Colors.LightGray);
                });
            });
        }
        else
        {
            _homePage.LogText += $"Error: Could not send CM command message to the ICC {destString}\n";
        }
    }

    // Reset Results Request (CM to ICC)
    public void SendResetResultRequest()
    {
        byte[] resetRequestTx = new byte[8];
        resetRequestTx[0] = start;
        resetRequestTx[1] = global;
        resetRequestTx[2] = cm;
        // message ID = Message Type 10; Message Number (0x01) 0001 = 10000001
        resetRequestTx[3] = 0x81;
        // length
        resetRequestTx[4] = 0x00;
        resetRequestTx[5] = end;

        // compute crc16 for bytes 0 to 6
        byte[] payload = new byte[6];
        Array.Copy(resetRequestTx, 0, payload, 0, 6);
        byte[] crc = ComputeCrc16(payload);

        // computed checksum
        resetRequestTx[6] = crc[1]; // low byte
        resetRequestTx[7] = crc[0]; // high byte

        // Send command if serial port is open
        if (Sp != null && Sp.IsOpen)
        {
            Sp.RtsEnable = true;
            Sp.Write(resetRequestTx, 0, resetRequestTx.Length);
            Sp.RtsEnable = false;
            _homePage.LogText += $"Sent Reset Results Request to all ICCs: {BitConverter.ToString(resetRequestTx)}\n";

            // Set TX indicator ON
            _homePage.TxStatus = new SolidColorBrush(Colors.Green);

            // Blink for a short duration (non-blocking)
            _ = Task.Run(async () =>
            {
                await Task.Delay(300); // blink duration
                await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                {
                    _homePage.TxStatus = new SolidColorBrush(Colors.LightGray);
                });
            });
        }
        else
        {
            _homePage.LogText += "Error: Error on sending reset result request to all ICCs\n";
        }
    }

    // Short Data Request (CM to ICC)
    public void SendShortDataRequest(byte destination)
    {
        byte[] shortDataRequestTx = new byte[8];
        shortDataRequestTx[0] = start;
        shortDataRequestTx[1] = destination;
        shortDataRequestTx[2] = cm;
        // message ID = Message Type 10; Message Number 0x03 = 10000011
        shortDataRequestTx[3] = 0x83;
        // length
        shortDataRequestTx[4] = 0x00;
        shortDataRequestTx[5] = end;

        // compute crc16 for bytes 0 to 6
        byte[] payload = new byte[6];
        Array.Copy(shortDataRequestTx, 0, payload, 0, 6);
        byte[] crc = ComputeCrc16(payload);

        // computed checksum
        shortDataRequestTx[6] = crc[1]; // low byte
        shortDataRequestTx[7] = crc[0]; // high byte

        // convert destination byte to corresponding string of an ICC #
        int destString = dict[destination];

        if (Sp != null && Sp.IsOpen)
        {
            Sp.RtsEnable = true;
            Sp.Write(shortDataRequestTx, 0, shortDataRequestTx.Length);
            Sp.RtsEnable = false;
            _homePage.LogText += $"Sent Short Data Request to the ICC {destString}: {BitConverter.ToString(shortDataRequestTx)}\n";

            // Set TX indicator ON
            _homePage.TxStatus = new SolidColorBrush(Colors.Green);
            _homePage.ShortButton = new SolidColorBrush(Colors.LightGreen);

            // Blink for a short duration (non-blocking)
            _ = Task.Run(async () =>
            {
                await Task.Delay(300); // blink duration
                await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                {
                    _homePage.TxStatus = new SolidColorBrush(Colors.LightGray);
                    _homePage.ShortButton = new SolidColorBrush(Colors.LightGray);
                });
            });
        }
        else
        {
            _homePage.LogText += $"Error: Could not send short data request to the ICC {destString}\n";
        }
    }

    // Config Data Request (CM to ICC)
    public void SendConfigDataRequest(byte destination)
    {
        byte[] configDataRequestTx = new byte[8];
        configDataRequestTx[0] = start;
        configDataRequestTx[1] = destination;
        configDataRequestTx[2] = cm;
        // message ID = Message Type 10; Message Number 0x07 = 10000111
        configDataRequestTx[3] = 0x87;
        // length
        configDataRequestTx[4] = 0x00;
        configDataRequestTx[5] = end;

        // compute crc16 for bytes 0 to 6
        byte[] payload = new byte[6];
        Array.Copy(configDataRequestTx, 0, payload, 0, 6);
        byte[] crc = ComputeCrc16(payload);

        // computed checksum
        configDataRequestTx[6] = crc[1]; // low byte
        configDataRequestTx[7] = crc[0]; // high byte

        // convert destination byte to corresponding string of an ICC #
        int destString = dict[destination];

        if (Sp != null && Sp.IsOpen)
        {
            Sp.RtsEnable = true;
            Sp.Write(configDataRequestTx, 0, configDataRequestTx.Length);
            Sp.RtsEnable = false;
            _homePage.LogText += $"Sent Config Request to the ICC {destString}: {BitConverter.ToString(configDataRequestTx)}\n";

            // Set TX indicator ON
            _homePage.TxStatus = new SolidColorBrush(Colors.Green);
            _homePage.ConfigButton = new SolidColorBrush(Colors.LightGreen);

            // Blink for a short duration (non-blocking)
            _ = Task.Run(async () =>
            {
                await Task.Delay(300); // blink duration
                await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                {
                    _homePage.TxStatus = new SolidColorBrush(Colors.LightGray);
                    _homePage.ConfigButton = new SolidColorBrush(Colors.LightGray);
                });
            });
        }
        else
        {
            _homePage.LogText += $"Error: Could not send config request to the ICC {destString}\n";
        }
    }

    private async Task SendEnquireMessage(byte destination)
    {
        byte[] enqTX = new byte[12];
        enqTX[0] = 0;
        enqTX[1] = 0;
        enqTX[2] = start;
        enqTX[3] = destination;
        enqTX[4] = cm;
        enqTX[5] = ENQ;
        enqTX[6] = 0;
        enqTX[7] = end;
        enqTX[10] = 0;
        enqTX[11] = 0;

        // compute crc16 for bytes 0 to 6
        byte[] payload = new byte[8];
        Array.Copy(enqTX, 0, payload, 0, 8);
        byte[] crc = ComputeCrc16(payload);

        // computed checksum5
        enqTX[8] = crc[1]; // low byte
        enqTX[9] = crc[0]; // high byte

        // convert destination byte to corresponding string of an ICC #
        int destString = dict[destination];

        if (Sp != null && Sp.IsOpen)
        {
            Sp.RtsEnable = true;
            Sp.Write(enqTX, 0, enqTX.Length);
            await Task.Delay(10);
            Sp.RtsEnable = false;
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                _homePage.LogText += $"Sent ENQ to the ICC {destString}: {BitConverter.ToString(enqTX)}\n";
                // Set TX indicator ON
                _homePage.TxStatus = new SolidColorBrush(Colors.Green);
            });

            // Blink for a short duration (non-blocking)
            _ = Task.Run(async () =>
            {
                await Task.Delay(300); // blink duration
                await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                {
                    _homePage.TxStatus = new SolidColorBrush(Colors.LightGray);
                });
            });
        }
        else
        {
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                _homePage.LogText += $"Error: Could not send ENQ message to ICC {destString}\n";
            });

        }

    }

    private string GetBitMismatchInfo(byte cmData, byte iccData, string iccName)
    {
        byte diff = (byte)(cmData ^ iccData);
        if (diff == 0)
            return ""; // No mismatch

        List<int> mismatchedBits = new List<int>();
        for (int i = 0; i < 8; i++)
        {
            if ((diff & (1 << i)) != 0)
            {
                mismatchedBits.Add(i);
            }
        }

        string bitList = string.Join(", ", mismatchedBits);
        return $"{iccName} Message Data Mismatch: CM=0x{cmData:X2} ({Convert.ToString(cmData, 2).PadLeft(8, '0')}), ICC=0x{iccData:X2} ({Convert.ToString(iccData, 2).PadLeft(8, '0')}), Mismatched bits: [{bitList}]\n";
    }

    private void SerialDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            var sp = (SerialPort)sender;
            int bytesToRead = sp.BytesToRead;
            if (bytesToRead == 0)
                return;

            byte[] buffer = new byte[bytesToRead];
            int bytesRead = sp.Read(buffer, 0, bytesToRead);

            for (int i = 0; i < bytesRead; i++)
            {
                ProcessByte(buffer[i]);
            }
        
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Serial read error: {ex.Message}");
        }
    }

    private void ProcessByte(byte b)
    {
        switch (_currentState)
        {
            case ParseState.WaitingForStart:
                if (b == 0x01) // Start byte
                {
                    _currentMessage.Clear();
                    _currentMessage.Add(b);
                    _currentState = ParseState.WaitingForDestination;
                }
                break;

            case ParseState.WaitingForDestination:
                if (b == cm) // Destination byte
                {
                    _currentMessage.Add(b);
                    _currentState = ParseState.WaitingForSource;
                }
                else
                {
                    ResetParser();
                }
                break;

            case ParseState.WaitingForSource:
                _currentSource = b;
                if (b >= 0x26 && b <= 0x3A) // Source byte
                {
                    _currentMessage.Add(b);
                    _currentState = ParseState.WaitingForMessageID;
                }
                else
                {
                    ResetParser();
                }
                break;

            case ParseState.WaitingForMessageID:
                _currentMessage.Add(b);
                _expectedLength = GetPayloadLength(b, _currentSource); // Determine payload length based on message ID
                _currentState = ParseState.WaitingForLength;
                break;

            case ParseState.WaitingForLength:
                _currentMessage.Add(b);
                _currentState = _expectedLength > 0 ? ParseState.WaitingForParameter : ParseState.WaitingForStop;
                break;

            case ParseState.WaitingForParameter:
                _currentMessage.Add(b);
                if (_currentMessage.Count > _expectedLength + 4) // Start + Dest + Source + MsgID + Payload
                {
                    _currentState = ParseState.WaitingForStop;
                }
                break;

            case ParseState.WaitingForStop:
                if (b == 0x03) // Stop byte
                {
                    _currentMessage.Add(b);
                    byte[] messageCopy = _currentMessage.ToArray();
                    Dispatcher.UIThread.InvokeAsync(() => ProcessMessage(messageCopy));
                    ResetParser();
                }else
                {
                    ResetParser();
                }
                break;

            default:
                ResetParser();
                break;
        }
    }

    private void ResetParser()
    {
        _currentState = ParseState.WaitingForStart;
        _currentMessage.Clear();
        _expectedLength = 0;
        _currentSource = 0;
    }

    private int GetPayloadLength(byte messageID, byte source)
    {
        // Define payload lengths based on message ID
        switch (messageID)
        {
            case byte n when n == RESET_COMMAND: // 0x41
                return 0;
            case byte n when n == RESET_RESULTS: // 0xC0
                return 2;
            case byte n when n == CONFIG_RESPONSE: // 0x47
                return 2; // 2-byte payload
            case byte n when n == COMMANDS_RESPONSE: // 0x42
                return 1; // 1-byte payload
            case byte n when n == SHORT_DATA_RESPONSE: // 0x43
                switch (source)
                {
                    case byte s when s == icc1: return icc1Compat ? 25 : 34;
                    case byte s when s == icc2: return icc2Compat ? 25 : 34;
                    case byte s when s == icc3: return icc3Compat ? 25 : 34;
                    case byte s when s == icc4: return icc4Compat ? 25 : 34;
                    case byte s when s == icc5: return icc5Compat ? 25 : 34;
                    case byte s when s == icc6: return icc6Compat ? 25 : 34;
                    case byte s when s == icc7: return icc7Compat ? 25 : 34;
                    case byte s when s == icc8: return icc8Compat ? 25 : 34;
                    case byte s when s == icc9: return icc9Compat ? 25 : 34;
                    case byte s when s == icc10: return icc10Compat ? 25 : 34;
                    case byte s when s == icc11: return icc11Compat ? 25 : 34;
                    case byte s when s == icc12: return icc12Compat ? 25 : 34;
                    case byte s when s == icc13: return icc13Compat ? 25 : 34;
                    case byte s when s == icc14: return icc14Compat ? 25 : 34;
                    case byte s when s == icc15: return icc15Compat ? 25 : 34;
                    case byte s when s == icc16: return icc16Compat ? 25 : 34;
                    case byte s when s == icc17: return icc17Compat ? 25 : 34;
                    case byte s when s == icc18: return icc18Compat ? 25 : 34;
                    case byte s when s == icc19: return icc19Compat ? 25 : 34;
                    case byte s when s == icc20: return icc20Compat ? 25 : 34;
                    case byte s when s == icc21: return icc21Compat ? 25 : 34;
                    default: return 25;
                }
            case byte n when n == ACK: // 0x78
                return 0;
            default:
                return 0; // Unknown message ID
        }
    }
    
    private async Task ProcessMessage(byte[] message)
    {
        try
        {
            
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                _homePage.LogText += "Received: " + BitConverter.ToString(message) + Environment.NewLine;
                _homePage.RxStatus = new SolidColorBrush(Colors.Green);
            });
            
            await Task.Delay(300);
            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                _homePage.RxStatus = new SolidColorBrush(Colors.LightGray);
            });
                
            

            // Validate message structure (start, dest, stop) - P.S: No need to check for the source (ICCs) because all individual ICCs are responding one at a time
            if (message.Length < 5 || message[0] != start || message[1] != cm || message[^1] != end)
            {
                Avalonia.Threading.Dispatcher.UIThread.Post(() =>
                {
                    _homePage.LogText += "Error: Invalid message format\n";
                });
                
                return;
            }
            
            byte messageID = message[3]; // Message ID is 4th byte            
            byte source = message[2];

            int sourceString = dict[source];

            lock (_lock)
            {
                if (_pendingResponses.TryGetValue(source, out var tcs))
                {
                    tcs.TrySetResult(message);
                    _pendingResponses.Remove(source);
                }
            }

            switch (source)
            {
                case byte s when s == icc1:
                    _icc1Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc1Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc1Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc1Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc1Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc1Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc1Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc1Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc2:
                    _icc2Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc2Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc2Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc2Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc2Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc2Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc2Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc2Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc3:
                    _icc3Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc3Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc3Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc3Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc3Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc3Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc3Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc3Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc4:
                    _icc4Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc4Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc4Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc4Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc4Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc4Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc4Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc4Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc5:
                    _icc5Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc5Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc5Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc5Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc5Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc5Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc5Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc5Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc6:
                    _icc6Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc6Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc6Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc6Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc6Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc6Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc6Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc6Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc7:
                    Avalonia.Threading.Dispatcher.UIThread.Post(() =>
                    {
                        _icc7Page.StartByteBackground = new SolidColorBrush(Colors.White);
                        _icc7Page.StartByte = "0x" + message[0].ToString("X2");
                        _icc7Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                        _icc7Page.DestinationByte = "0x" + message[1].ToString("X2");
                        _icc7Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                        _icc7Page.SourceByte = "0x" + message[2].ToString("X2");
                        _icc7Page.EndByteBackground = new SolidColorBrush(Colors.White);
                        _icc7Page.EndByte = "0x" + message[^1].ToString("X2");
                    });
                    
                    break;
                case byte s when s == icc8:
                    _icc8Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc8Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc8Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc8Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc8Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc8Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc8Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc8Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc9:
                    _icc9Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc9Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc9Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc9Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc9Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc9Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc9Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc9Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc10:
                    _icc10Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc10Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc10Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc10Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc10Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc10Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc10Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc10Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc11:
                    _icc11Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc11Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc11Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc11Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc11Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc11Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc11Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc11Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc12:
                    _icc12Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc12Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc12Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc12Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc12Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc12Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc12Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc12Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc13:
                    _icc13Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc13Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc13Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc13Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc13Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc13Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc13Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc13Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc14:
                    _icc14Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc14Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc14Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc14Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc14Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc14Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc14Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc14Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc15:
                    _icc15Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc15Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc15Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc15Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc15Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc15Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc15Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc15Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc16:
                    _icc16Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc16Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc16Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc16Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc16Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc16Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc16Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc16Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc17:
                    _icc17Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc17Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc17Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc17Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc17Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc17Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc17Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc17Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc18:
                    _icc18Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc18Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc18Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc18Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc18Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc18Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc18Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc18Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc19:
                    _icc19Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc19Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc19Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc19Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc19Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc19Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc19Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc19Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc20:
                    _icc20Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc20Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc20Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc20Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc20Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc20Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc20Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc20Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                case byte s when s == icc21:
                    _icc21Page.StartByteBackground = new SolidColorBrush(Colors.White);
                    _icc21Page.StartByte = "0x" + message[0].ToString("X2");
                    _icc21Page.DestinationByteBackground = new SolidColorBrush(Colors.White);
                    _icc21Page.DestinationByte = "0x" + message[1].ToString("X2");
                    _icc21Page.SourceByteBackground = new SolidColorBrush(Colors.White);
                    _icc21Page.SourceByte = "0x" + message[2].ToString("X2");
                    _icc21Page.EndByteBackground = new SolidColorBrush(Colors.White);
                    _icc21Page.EndByte = "0x" + message[^1].ToString("X2");
                    break;
                default:
                    break;
            }

            switch (messageID)
            {
                case byte n when n == RESET_COMMAND: // 0x41
                    _homePage.LogText += "RECEIVED RESET COMMAND (Message ID: 0x41)\n";
                    
                    break;
                case byte n when n == RESET_RESULTS: // 0xC0
                    _homePage.LogText += "POST RESULTS (Message ID: 0xC0)\n";
                    // Process payload
                    if ((message[6] & cpuTest) == 0)
                    {
                        _homePage.LogText += "CPU Test - Passed\n";
                    }
                    else if ((message[6] ^ cpuTest) == 0)
                    {
                        _homePage.LogText += "CPU Test - Failed\n";
                    }
                    if ((message[6] & epromTest) == 0)
                    {
                        _homePage.LogText += "EPROM Test - Passed\n";
                    }
                    else if ((message[6] ^ epromTest) == 0)
                    {
                        _homePage.LogText += "EPROM Test - Failed\n";
                    }
                    if ((message[6] & sramTest) == 0)
                    {
                        _homePage.LogText += "SRAM Test - Passed\n";
                    }
                    else if ((message[6] ^ sramTest) == 0)
                    {
                        _homePage.LogText += "SRAM Test - Failed\n";
                    }
                    if ((message[6] & digitalTest) == 0)
                    {
                        _homePage.LogText += "Digital I/O Test - Passed\n";
                    }
                    else if ((message[6] ^ digitalTest) == 0)
                    {
                        _homePage.LogText += "Digital I/O Test - Failed\n";
                    }
                    if ((message[6] & adConverterTest) == 0)
                    {
                        _homePage.LogText += "A/D Converter Test - Passed\n";
                    }
                    else if ((message[6] ^ adConverterTest) == 0)
                    {
                        _homePage.LogText += "A/D Converter Test - Failed\n";
                    }
                    if ((message[6] & watchdogTest) == 0)
                    {
                        _homePage.LogText += "Watchdog Timer Test - Passed\n";
                    }
                    else if ((message[6] ^ watchdogTest) == 0)
                    {
                        _homePage.LogText += "Watchdog Timer Test - Failed\n";
                    }
                    if ((message[6] & idleTest) == 0)
                    {
                        _homePage.LogText += "Idle Task Test - Passed\n";
                    }
                    else if ((message[6] ^ idleTest) == 0)
                    {
                        _homePage.LogText += "Idle Task Test - Failed\n";
                    }
                    if ((message[6] & rs485_1Test) == 0)
                    {
                        _homePage.LogText += "RS-485 Port #1 Test - Passed\n";
                    }
                    else if ((message[6] ^ rs485_1Test) == 0)
                    {
                        _homePage.LogText += "RS-485 Port #1 Test - Failed\n";
                    }
                    if ((message[5] & rs485_2Test) == 0)
                    {
                        _homePage.LogText += "RS-485 Port #2 Test - Passed\n";
                    }
                    else if ((message[5] ^ rs485_2Test) == 0)
                    {
                        _homePage.LogText += "RS-485 Port #2 Test - Failed\n";
                    }
                    if ((message[5] & rs232Test) == 0)
                    {
                        _homePage.LogText += "RS-232 Port MT Test - Passed\n";
                    }
                    else if ((message[5] ^ rs232Test) == 0)
                    {
                        _homePage.LogText += "RS-232 Port MT Test - Failed\n";
                    }
                    if ((message[5] & ledDisplayTest) == 0)
                    {
                        _homePage.LogText += "LED Display Test - Passed\n";
                    }
                    else if ((message[5] ^ ledDisplayTest) == 0)
                    {
                        _homePage.LogText += "LED Display Test - Failed\n";
                    }
                    break;
                case byte n when n == COMMANDS_RESPONSE: // 0x42
                    _homePage.LogText += "COMMANDS_RESPONSE (Message ID: 0x42)\n";
                    switch (source)
                    {
                        case byte s when s == icc1:
                            ReadIcc1Response(message[5]);
                            break;
                        case byte s when s == icc2:
                            ReadIcc2Response(message[5]);
                            break;
                        case byte s when s == icc3:
                            ReadIcc3Response(message[5]);
                            break;
                        case byte s when s == icc4:
                            ReadIcc4Response(message[5]);
                            break;
                        case byte s when s == icc5:
                            ReadIcc5Response(message[5]);
                            break;
                        case byte s when s == icc6:
                            ReadIcc6Response(message[5]);
                            break;
                        case byte s when s == icc7:
                            ReadIcc7Response(message[5]);
                            break;
                        case byte s when s == icc8:
                            ReadIcc8Response(message[5]);
                            break;
                        case byte s when s == icc9:
                            ReadIcc9Response(message[5]);
                            break;
                        case byte s when s == icc10:
                            ReadIcc10Response(message[5]);
                            break;
                        case byte s when s == icc11:
                            ReadIcc11Response(message[5]);
                            break;
                        case byte s when s == icc12:
                            ReadIcc12Response(message[5]);
                            break;
                        case byte s when s == icc13:
                            ReadIcc13Response(message[5]);
                            break;
                        case byte s when s == icc14:
                            ReadIcc14Response(message[5]);
                            break;
                        case byte s when s == icc15:
                            ReadIcc15Response(message[5]);
                            break;
                        case byte s when s == icc16:
                            ReadIcc16Response(message[5]);
                            break;
                        case byte s when s == icc17:
                            ReadIcc17Response(message[5]);
                            break;
                        case byte s when s == icc18:
                            ReadIcc18Response(message[5]);
                            break;
                        case byte s when s == icc19:
                            ReadIcc19Response(message[5]);
                            break;
                        case byte s when s == icc20:
                            ReadIcc20Response(message[5]);
                            break;
                        case byte s when s == icc21:
                            ReadIcc21Response(message[5]);
                            break;
                        default:
                            break;
                    }
                    break;
                case byte n when n == SHORT_DATA_RESPONSE: // 0x43
                    _homePage.LogText += "SHORT DATA RESPONSE (Message ID: 0x43)\n";
                    switch (source)
                    {
                        case byte s when s == icc1:
                            if (icc1Compat)
                            {
                                // compatibility mode - 25 bytes

                                // update iccMessageData from short data
                                if((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc1Low)
                                    {
                                        icc1MessageData = (byte)(icc1MessageData ^ fLowByte);
                                        icc1Low = true;
                                        Icc1SideMenu = "LOW";

                                        Icc1BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc1BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc1Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc1Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc1Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc1Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc1Med)
                                        {
                                            icc1MessageData = (byte)(icc1MessageData ^ fMedByte);
                                            icc1Med = false;
                                            _icc1Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc1Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc1High)
                                        {
                                            icc1MessageData = (byte)(icc1MessageData ^ fHighByte);
                                            icc1High = false;
                                            _icc1Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc1Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc1Med)
                                    {
                                        icc1MessageData = (byte)(icc1MessageData ^ fMedByte);
                                        icc1Med = true;
                                        Icc1SideMenu = "MED";

                                        Icc1BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc1BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc1Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc1Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc1Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc1Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc1Low)
                                        {
                                            icc1MessageData = (byte)(icc1MessageData ^ fLowByte);
                                            icc1Low = false;
                                            _icc1Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc1Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc1High)
                                        {
                                            icc1MessageData = (byte)(icc1MessageData ^ fHighByte);
                                            icc1High = false;
                                            _icc1Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc1Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc1High)
                                    {
                                        icc1MessageData = (byte)(icc1MessageData ^ fHighByte);
                                        icc1High = true;
                                        Icc1SideMenu = "HIGH";

                                        Icc1BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc1BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc1Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc1Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc1Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc1Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc1Low)
                                        {
                                            icc1MessageData = (byte)(icc1MessageData ^ fLowByte);
                                            icc1Low = false;
                                            _icc1Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc1Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc1Med)
                                        {
                                            icc1MessageData = (byte)(icc1MessageData ^ fMedByte);
                                            icc1Med = false;
                                            _icc1Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc1Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc1MessageData = (byte)(icc1MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc1MessageData = (byte)(icc1MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }

                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc1On)
                                    {
                                        icc1On = true;
                                        icc1MessageData = (byte)(icc1MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc1On)
                                    {
                                        icc1On = false;
                                        icc1MessageData = (byte)(icc1MessageData ^ fOffByte ^ fOnByte);

                                        Icc1SideMenu = "OFF";
                                        Icc1BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc1BorderBackground = new SolidColorBrush(Colors.Black);


                                        _icc1Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc1Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc1Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc1Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc1Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc1Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc1Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc1Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc1Low)
                                        {
                                            icc1Low = false;
                                            icc1MessageData = (byte)(icc1MessageData ^ fLowByte);
                                        }
                                        if (icc1Med)
                                        {
                                            icc1MessageData = (byte)(icc1MessageData ^ fMedByte);
                                            icc1Med = false;
                                        }
                                        if (icc1High)
                                        {
                                            icc1MessageData = (byte)(icc1MessageData ^ fHighByte);
                                            icc1High = false;
                                        }
                                        CheckAndStopSequentialFlash();
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();   // use this for calculating the flash rate error
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc1Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc1Page.Vac240V = vac240V;
                                _icc1Page.Vac240A = vac240A;
                                _icc1Page.FlashTriggerV = flashTriggerV;
                                _icc1Page.Vdc24V = vdc24V;
                                _icc1Page.Vdc24A = vdc24A;
                                _icc1Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc1Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc1Page.TriggerPeriod = triggerPeriod;
                                _icc1Page.TriggerCurrent = triggerCurrent;
                                _icc1Page.AnodePulseWidth = anodePulseWidth;
                                _icc1Page.AnodePulseDelay = anodePulseDelay;
                                _icc1Page.BleederV = bleederV;
                                _icc1Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes

                            }
                            // compare cmMessageData to iccMessageData
                            if(cmMessageData != icc1MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc1MessageData, "ICC1");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc1);
                            }
                            break;
                        case byte s when s == icc2:
                            if (icc2Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc2Low)
                                    {
                                        icc2MessageData = (byte)(icc2MessageData ^ fLowByte);
                                        icc2Low = true;
                                        Icc2SideMenu = "LOW";

                                        Icc2BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc2BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc2Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc2Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc2Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc2Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc2Med)
                                        {
                                            icc2MessageData = (byte)(icc2MessageData ^ fMedByte);
                                            icc2Med = false;
                                            _icc2Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc2Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc2High)
                                        {
                                            icc2MessageData = (byte)(icc2MessageData ^ fHighByte);
                                            icc2High = false;
                                            _icc2Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc2Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc2Med)
                                    {
                                        icc2MessageData = (byte)(icc2MessageData ^ fMedByte);
                                        icc2Med = true;
                                        Icc2SideMenu = "MED";

                                        Icc2BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc2BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc2Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc2Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc2Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc2Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc2Low)
                                        {
                                            icc2MessageData = (byte)(icc2MessageData ^ fLowByte);
                                            icc2Low = false;
                                            _icc2Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc2Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc2High)
                                        {
                                            icc2MessageData = (byte)(icc2MessageData ^ fHighByte);
                                            icc2High = false;
                                            _icc2Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc2Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc2High)
                                    {
                                        icc2MessageData = (byte)(icc2MessageData ^ fHighByte);
                                        icc2High = true;
                                        Icc2SideMenu = "HIGH";

                                        Icc2BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc2BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc2Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc2Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc2Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc2Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc2Low)
                                        {
                                            icc2MessageData = (byte)(icc2MessageData ^ fLowByte);
                                            icc2Low = false;
                                            _icc2Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc2Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc2Med)
                                        {
                                            icc2MessageData = (byte)(icc2MessageData ^ fMedByte);
                                            icc2Med = false;
                                            _icc2Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc2Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc2MessageData = (byte)(icc2MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc2MessageData = (byte)(icc2MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc2On)
                                    {
                                        icc2On = true;
                                        icc2MessageData = (byte)(icc2MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc2On)
                                    {
                                        icc2On = false;
                                        icc2MessageData = (byte)(icc2MessageData ^ fOffByte ^ fOnByte);

                                        Icc2SideMenu = "OFF";
                                        Icc2BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc2BorderBackground = new SolidColorBrush(Colors.Black);


                                        _icc2Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc2Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc2Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc2Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc2Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc2Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc2Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc2Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc2Low)
                                        {
                                            icc2Low = false;
                                            icc2MessageData = (byte)(icc2MessageData ^ fLowByte);
                                        }
                                        if (icc2Med)
                                        {
                                            icc2MessageData = (byte)(icc2MessageData ^ fMedByte);
                                            icc2Med = false;
                                        }
                                        if (icc2High)
                                        {
                                            icc2MessageData = (byte)(icc2MessageData ^ fHighByte);
                                            icc2High = false;
                                        }
                                        CheckAndStopSequentialFlash();
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc2Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc2Page.Vac240V = vac240V;
                                _icc2Page.Vac240A = vac240A;
                                _icc2Page.FlashTriggerV = flashTriggerV;
                                _icc2Page.Vdc24V = vdc24V;
                                _icc2Page.Vdc24A = vdc24A;
                                _icc2Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc2Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc2Page.TriggerPeriod = triggerPeriod;
                                _icc2Page.TriggerCurrent = triggerCurrent;
                                _icc2Page.AnodePulseWidth = anodePulseWidth;
                                _icc2Page.AnodePulseDelay = anodePulseDelay;
                                _icc2Page.BleederV = bleederV;
                                _icc2Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes

                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc2MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc2MessageData, "ICC2");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc2);
                            }
                            break;
                        case byte s when s == icc3:
                            if (icc3Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc3Low)
                                    {
                                        icc3MessageData = (byte)(icc3MessageData ^ fLowByte);
                                        icc3Low = true;
                                        Icc3SideMenu = "LOW";

                                        Icc3BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc3BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc3Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc3Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc3Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc3Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc3Med)
                                        {
                                            icc3MessageData = (byte)(icc3MessageData ^ fMedByte);
                                            icc3Med = false;
                                            _icc3Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc3Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc3High)
                                        {
                                            icc3MessageData = (byte)(icc3MessageData ^ fHighByte);
                                            icc3High = false;
                                            _icc3Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc3Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc3Med)
                                    {
                                        icc3MessageData = (byte)(icc3MessageData ^ fMedByte);
                                        icc3Med = true;
                                        Icc3SideMenu = "MED";

                                        Icc3BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc3BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc3Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc3Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc3Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc3Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc3Low)
                                        {
                                            icc3MessageData = (byte)(icc3MessageData ^ fLowByte);
                                            icc3Low = false;
                                            _icc3Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc3Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc3High)
                                        {
                                            icc3MessageData = (byte)(icc3MessageData ^ fHighByte);
                                            icc3High = false;
                                            _icc3Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc3Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc3High)
                                    {
                                        icc3MessageData = (byte)(icc3MessageData ^ fHighByte);
                                        icc3High = true;
                                        Icc3SideMenu = "HIGH";

                                        Icc3BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc3BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc3Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc3Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc3Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc3Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc3Low)
                                        {
                                            icc3MessageData = (byte)(icc3MessageData ^ fLowByte);
                                            icc3Low = false;
                                            _icc3Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc3Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc3Med)
                                        {
                                            icc3MessageData = (byte)(icc3MessageData ^ fMedByte);
                                            icc3Med = false;
                                            _icc3Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc3Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc3MessageData = (byte)(icc3MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc3MessageData = (byte)(icc3MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc3On)
                                    {
                                        icc3On = true;
                                        icc3MessageData = (byte)(icc3MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc3On)
                                    {
                                        icc3On = false;
                                        icc3MessageData = (byte)(icc3MessageData ^ fOffByte ^ fOnByte);

                                        Icc3SideMenu = "OFF";
                                        Icc3BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc3BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc3Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc3Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc3Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc3Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc3Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc3Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc3Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc3Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc3Low)
                                        {
                                            icc3Low = false;
                                            icc3MessageData = (byte)(icc3MessageData ^ fLowByte);
                                        }
                                        if (icc3Med)
                                        {
                                            icc3MessageData = (byte)(icc3MessageData ^ fMedByte);
                                            icc3Med = false;
                                        }
                                        if (icc3High)
                                        {
                                            icc3MessageData = (byte)(icc3MessageData ^ fHighByte);
                                            icc3High = false;
                                        }
                                        CheckAndStopSequentialFlash();
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc3Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc3Page.Vac240V = vac240V;
                                _icc3Page.Vac240A = vac240A;
                                _icc3Page.FlashTriggerV = flashTriggerV;
                                _icc3Page.Vdc24V = vdc24V;
                                _icc3Page.Vdc24A = vdc24A;
                                _icc3Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc3Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc3Page.TriggerPeriod = triggerPeriod;
                                _icc3Page.TriggerCurrent = triggerCurrent;
                                _icc3Page.AnodePulseWidth = anodePulseWidth;
                                _icc3Page.AnodePulseDelay = anodePulseDelay;
                                _icc3Page.BleederV = bleederV;
                                _icc3Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes

                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc3MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc3MessageData, "ICC3");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc3);
                            }
                            break;
                        case byte s when s == icc4:
                            if (icc4Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc4Low)
                                    {
                                        icc4MessageData = (byte)(icc4MessageData ^ fLowByte);
                                        icc4Low = true;
                                        Icc4SideMenu = "LOW";

                                        Icc4BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc4BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc4Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc4Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc4Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc4Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc4Med)
                                        {
                                            icc4MessageData = (byte)(icc4MessageData ^ fMedByte);
                                            icc4Med = false;
                                            _icc4Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc4Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc4High)
                                        {
                                            icc4MessageData = (byte)(icc4MessageData ^ fHighByte);
                                            icc4High = false;
                                            _icc4Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc4Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc4Med)
                                    {
                                        icc4MessageData = (byte)(icc4MessageData ^ fMedByte);
                                        icc4Med = true;
                                        Icc4SideMenu = "MED";

                                        Icc4BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc4BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc4Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc4Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc4Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc4Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc4Low)
                                        {
                                            icc4MessageData = (byte)(icc4MessageData ^ fLowByte);
                                            icc4Low = false;
                                            _icc4Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc4Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc4High)
                                        {
                                            icc4MessageData = (byte)(icc4MessageData ^ fHighByte);
                                            icc4High = false;
                                            _icc4Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc4Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc4High)
                                    {
                                        icc4MessageData = (byte)(icc4MessageData ^ fHighByte);
                                        icc4High = true;
                                        Icc4SideMenu = "HIGH";

                                        Icc4BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc4BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc4Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc4Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc4Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc4Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc4Low)
                                        {
                                            icc4MessageData = (byte)(icc4MessageData ^ fLowByte);
                                            icc4Low = false;
                                            _icc4Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc4Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc4Med)
                                        {
                                            icc4MessageData = (byte)(icc4MessageData ^ fMedByte);
                                            icc4Med = false;
                                            _icc4Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc4Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc4MessageData = (byte)(icc4MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc4MessageData = (byte)(icc4MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc4On)
                                    {
                                        icc4On = true;
                                        icc4MessageData = (byte)(icc4MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc4On)
                                    {
                                        icc4On = false;
                                        icc4MessageData = (byte)(icc4MessageData ^ fOffByte ^ fOnByte);

                                        Icc4SideMenu = "OFF";
                                        Icc4BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc4BorderBackground = new SolidColorBrush(Colors.Black);


                                        _icc4Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc4Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc4Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc4Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc4Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc4Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc4Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc4Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc4Low)
                                        {
                                            icc4Low = false;
                                            icc4MessageData = (byte)(icc4MessageData ^ fLowByte);
                                        }
                                        if (icc4Med)
                                        {
                                            icc4MessageData = (byte)(icc4MessageData ^ fMedByte);
                                            icc4Med = false;
                                        }
                                        if (icc4High)
                                        {
                                            icc4MessageData = (byte)(icc4MessageData ^ fHighByte);
                                            icc4High = false;
                                        }
                                        CheckAndStopSequentialFlash();
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc4Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc4Page.Vac240V = vac240V;
                                _icc4Page.Vac240A = vac240A;
                                _icc4Page.FlashTriggerV = flashTriggerV;
                                _icc4Page.Vdc24V = vdc24V;
                                _icc4Page.Vdc24A = vdc24A;
                                _icc4Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc4Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc4Page.TriggerPeriod = triggerPeriod;
                                _icc4Page.TriggerCurrent = triggerCurrent;
                                _icc4Page.AnodePulseWidth = anodePulseWidth;
                                _icc4Page.AnodePulseDelay = anodePulseDelay;
                                _icc4Page.BleederV = bleederV;
                                _icc4Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes

                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc4MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc4MessageData, "ICC4");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc4);
                            }
                            break;
                        case byte s when s == icc5:
                            if (icc5Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc5Low)
                                    {
                                        icc5MessageData = (byte)(icc5MessageData ^ fLowByte);
                                        icc5Low = true;
                                        Icc5SideMenu = "LOW";

                                        Icc5BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc5BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc5Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc5Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc5Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc5Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc5Med)
                                        {
                                            icc5MessageData = (byte)(icc5MessageData ^ fMedByte);
                                            icc5Med = false;
                                            _icc5Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc5Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc5High)
                                        {
                                            icc5MessageData = (byte)(icc5MessageData ^ fHighByte);
                                            icc5High = false;
                                            _icc5Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc5Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc5Med)
                                    {
                                        icc5MessageData = (byte)(icc5MessageData ^ fMedByte);
                                        icc5Med = true;
                                        Icc5SideMenu = "MED";

                                        Icc5BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc5BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc5Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc5Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc5Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc5Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc5Low)
                                        {
                                            icc5MessageData = (byte)(icc5MessageData ^ fLowByte);
                                            icc5Low = false;
                                            _icc5Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc5Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc5High)
                                        {
                                            icc5MessageData = (byte)(icc5MessageData ^ fHighByte);
                                            icc5High = false;
                                            _icc5Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc5Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc5High)
                                    {
                                        icc5MessageData = (byte)(icc5MessageData ^ fHighByte);
                                        icc5High = true;
                                        Icc5SideMenu = "HIGH";

                                        Icc5BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc5BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc5Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc5Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc5Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc5Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc5Low)
                                        {
                                            icc5MessageData = (byte)(icc5MessageData ^ fLowByte);
                                            icc5Low = false;
                                            _icc5Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc5Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc5Med)
                                        {
                                            icc5MessageData = (byte)(icc5MessageData ^ fMedByte);
                                            icc5Med = false;
                                            _icc5Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc5Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        CheckAndStartSequentialFlash();
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc5MessageData = (byte)(icc5MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc5MessageData = (byte)(icc5MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc5On)
                                    {
                                        icc5On = true;
                                        icc5MessageData = (byte)(icc5MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc5On)
                                    {
                                        icc5On = false;
                                        icc5MessageData = (byte)(icc5MessageData ^ fOffByte ^ fOnByte);

                                        Icc5SideMenu = "OFF";
                                        Icc5BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc5BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc5Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc5Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc5Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc5Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc5Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc5Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc5Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc5Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc5Low)
                                        {
                                            icc5Low = false;
                                            icc5MessageData = (byte)(icc5MessageData ^ fLowByte);
                                        }
                                        if (icc5Med)
                                        {
                                            icc5MessageData = (byte)(icc5MessageData ^ fMedByte);
                                            icc5Med = false;
                                        }
                                        if (icc5High)
                                        {
                                            icc5MessageData = (byte)(icc5MessageData ^ fHighByte);
                                            icc5High = false;
                                        }
                                        CheckAndStopSequentialFlash();
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc5Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc5Page.Vac240V = vac240V;
                                _icc5Page.Vac240A = vac240A;
                                _icc5Page.FlashTriggerV = flashTriggerV;
                                _icc5Page.Vdc24V = vdc24V;
                                _icc5Page.Vdc24A = vdc24A;
                                _icc5Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc5Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc5Page.TriggerPeriod = triggerPeriod;
                                _icc5Page.TriggerCurrent = triggerCurrent;
                                _icc5Page.AnodePulseWidth = anodePulseWidth;
                                _icc5Page.AnodePulseDelay = anodePulseDelay;
                                _icc5Page.BleederV = bleederV;
                                _icc5Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes

                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc5MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc5MessageData, "ICC5");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc5);
                            }
                            break;
                        case byte s when s == icc6:
                            if (icc6Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc6Low)
                                    {
                                        icc6MessageData = (byte)(icc6MessageData ^ fLowByte);
                                        icc6Low = true;
                                        Icc6SideMenu = "LOW";

                                        Icc6BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc6BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc6Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc6Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc6Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc6Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc6Med)
                                        {
                                            icc6MessageData = (byte)(icc6MessageData ^ fMedByte);
                                            icc6Med = false;
                                            _icc6Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc6Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc6High)
                                        {
                                            icc6MessageData = (byte)(icc6MessageData ^ fHighByte);
                                            icc6High = false;
                                            _icc6Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc6Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc6Med)
                                    {
                                        icc6MessageData = (byte)(icc6MessageData ^ fMedByte);
                                        icc6Med = true;
                                        Icc6SideMenu = "MED";

                                        Icc6BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc6BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc6Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc6Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc6Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc6Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc6Low)
                                        {
                                            icc6MessageData = (byte)(icc6MessageData ^ fLowByte);
                                            icc6Low = false;
                                            _icc6Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc6Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc6High)
                                        {
                                            icc6MessageData = (byte)(icc6MessageData ^ fHighByte);
                                            icc6High = false;
                                            _icc6Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc6Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc6High)
                                    {
                                        icc6MessageData = (byte)(icc6MessageData ^ fHighByte);
                                        icc6High = true;
                                        Icc6SideMenu = "HIGH";

                                        Icc6BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc6BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc6Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc6Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc6Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc6Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc6Low)
                                        {
                                            icc6MessageData = (byte)(icc6MessageData ^ fLowByte);
                                            icc6Low = false;
                                            _icc6Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc6Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc6Med)
                                        {
                                            icc6MessageData = (byte)(icc6MessageData ^ fMedByte);
                                            icc6Med = false;
                                            _icc6Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc6Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc6MessageData = (byte)(icc6MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc6MessageData = (byte)(icc6MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc6On)
                                    {
                                        icc6On = true;
                                        icc6MessageData = (byte)(icc6MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc6On)
                                    {
                                        icc6On = false;
                                        icc6MessageData = (byte)(icc6MessageData ^ fOffByte ^ fOnByte);

                                        Icc6SideMenu = "OFF";
                                        Icc6BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc6BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc6Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc6Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc6Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc6Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc6Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc6Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc6Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc6Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc6Low)
                                        {
                                            icc6Low = false;
                                            icc6MessageData = (byte)(icc6MessageData ^ fLowByte);
                                        }
                                        if (icc6Med)
                                        {
                                            icc6MessageData = (byte)(icc6MessageData ^ fMedByte);
                                            icc6Med = false;
                                        }
                                        if (icc6High)
                                        {
                                            icc6MessageData = (byte)(icc6MessageData ^ fHighByte);
                                            icc6High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc6Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc6Page.Vac240V = vac240V;
                                _icc6Page.Vac240A = vac240A;
                                _icc6Page.FlashTriggerV = flashTriggerV;
                                _icc6Page.Vdc24V = vdc24V;
                                _icc6Page.Vdc24A = vdc24A;
                                _icc6Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc6Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc6Page.TriggerPeriod = triggerPeriod;
                                _icc6Page.TriggerCurrent = triggerCurrent;
                                _icc6Page.AnodePulseWidth = anodePulseWidth;
                                _icc6Page.AnodePulseDelay = anodePulseDelay;
                                _icc6Page.BleederV = bleederV;
                                _icc6Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes

                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc6MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc6MessageData, "ICC6");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc6);
                            }
                            break;
                        case byte s when s == icc7:
                            if (icc7Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc7Low)
                                    {
                                        icc7MessageData = (byte)(icc7MessageData ^ fLowByte);
                                        icc7Low = true;
                                        Icc7SideMenu = "LOW";

                                        Icc7BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc7BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc7Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc7Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc7Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc7Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc7Med)
                                        {
                                            icc7MessageData = (byte)(icc7MessageData ^ fMedByte);
                                            icc7Med = false;
                                            _icc7Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc7Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc7High)
                                        {
                                            icc7MessageData = (byte)(icc7MessageData ^ fHighByte);
                                            icc7High = false;
                                            _icc7Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc7Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc7Med)
                                    {
                                        icc7MessageData = (byte)(icc7MessageData ^ fMedByte);
                                        icc7Med = true;
                                        Icc7SideMenu = "MED";

                                        Icc7BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc7BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc7Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc7Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc7Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc7Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc7Low)
                                        {
                                            icc7MessageData = (byte)(icc7MessageData ^ fLowByte);
                                            icc7Low = false;
                                            _icc7Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc7Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc7High)
                                        {
                                            icc7MessageData = (byte)(icc7MessageData ^ fHighByte);
                                            icc7High = false;
                                            _icc7Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc7Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc7High)
                                    {
                                        icc7MessageData = (byte)(icc7MessageData ^ fHighByte);
                                        icc7High = true;
                                        Icc7SideMenu = "HIGH";

                                        Icc7BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc7BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc7Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc7Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc7Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc7Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc7Low)
                                        {
                                            icc7MessageData = (byte)(icc7MessageData ^ fLowByte);
                                            icc7Low = false;
                                            _icc7Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc7Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc7Med)
                                        {
                                            icc7MessageData = (byte)(icc7MessageData ^ fMedByte);
                                            icc7Med = false;
                                            _icc7Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc7Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc7MessageData = (byte)(icc7MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc7MessageData = (byte)(icc7MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }

                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc7On)
                                    {
                                        icc7On = true;
                                        icc7MessageData = (byte)(icc7MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc7On)
                                    {
                                        icc7On = false;
                                        icc7MessageData = (byte)(icc7MessageData ^ fOffByte ^ fOnByte);

                                        Icc7SideMenu = "OFF";
                                        Icc7BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc7BorderBackground = new SolidColorBrush(Colors.Black);


                                        _icc7Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc7Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc7Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc7Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc7Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc7Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc7Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc7Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc7Low)
                                        {
                                            icc7Low = false;
                                            icc7MessageData = (byte)(icc7MessageData ^ fLowByte);
                                        }
                                        if (icc7Med)
                                        {
                                            icc7MessageData = (byte)(icc7MessageData ^ fMedByte);
                                            icc7Med = false;
                                        }
                                        if (icc7High)
                                        {
                                            icc7MessageData = (byte)(icc7MessageData ^ fHighByte);
                                            icc7High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc7Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc7Page.Vac240V = vac240V;
                                _icc7Page.Vac240A = vac240A;
                                _icc7Page.FlashTriggerV = flashTriggerV;
                                _icc7Page.Vdc24V = vdc24V;
                                _icc7Page.Vdc24A = vdc24A;
                                _icc7Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc7Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc7Page.TriggerPeriod = triggerPeriod;
                                _icc7Page.TriggerCurrent = triggerCurrent;
                                _icc7Page.AnodePulseWidth = anodePulseWidth;
                                _icc7Page.AnodePulseDelay = anodePulseDelay;
                                _icc7Page.BleederV = bleederV;
                                _icc7Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes

                            }
                            // compare cmMessageData to iccMessageData
                            // STATUS = OFF + ALSF
                            // cmMessageData = 162 (A2) (10100010); icc7MessageData = 134 (86) (10000110)
                            if (cmMessageData != icc7MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc7MessageData, "ICC7");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc7);
                            }
                            break;
                        case byte s when s == icc8:
                            if (icc8Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc8Low)
                                    {
                                        icc8MessageData = (byte)(icc8MessageData ^ fLowByte);
                                        icc8Low = true;
                                        Icc8SideMenu = "LOW";

                                        Icc8BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc8BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc8Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc8Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc8Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc8Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc8Med)
                                        {
                                            icc8MessageData = (byte)(icc8MessageData ^ fMedByte);
                                            icc8Med = false;
                                            _icc8Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc8Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc8High)
                                        {
                                            icc8MessageData = (byte)(icc8MessageData ^ fHighByte);
                                            icc8High = false;
                                            _icc8Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc8Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc8Med)
                                    {
                                        icc8MessageData = (byte)(icc8MessageData ^ fMedByte);
                                        icc8Med = true;
                                        Icc8SideMenu = "MED";

                                        Icc8BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc8BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc8Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc8Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc8Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc8Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc8Low)
                                        {
                                            icc8MessageData = (byte)(icc8MessageData ^ fLowByte);
                                            icc8Low = false;
                                            _icc8Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc8Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc8High)
                                        {
                                            icc8MessageData = (byte)(icc8MessageData ^ fHighByte);
                                            icc8High = false;
                                            _icc8Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc8Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc8High)
                                    {
                                        icc8MessageData = (byte)(icc8MessageData ^ fHighByte);
                                        icc8High = true;
                                        Icc8SideMenu = "HIGH";

                                        Icc8BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc8BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc8Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc8Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc8Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc8Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc8Low)
                                        {
                                            icc8MessageData = (byte)(icc8MessageData ^ fLowByte);
                                            icc8Low = false;
                                            _icc8Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc8Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc8Med)
                                        {
                                            icc8MessageData = (byte)(icc8MessageData ^ fMedByte);
                                            icc8Med = false;
                                            _icc8Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc8Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc8MessageData = (byte)(icc8MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc8MessageData = (byte)(icc8MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc8On)
                                    {
                                        icc8On = true;
                                        icc8MessageData = (byte)(icc8MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc8On)
                                    {
                                        icc8On = false;
                                        icc8MessageData = (byte)(icc8MessageData ^ fOffByte ^ fOnByte);

                                        Icc8SideMenu = "OFF";
                                        Icc8BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc8BorderBackground = new SolidColorBrush(Colors.Black);


                                        _icc8Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc8Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc8Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc8Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc8Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc8Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc8Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc8Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc8Low)
                                        {
                                            icc8Low = false;
                                            icc8MessageData = (byte)(icc8MessageData ^ fLowByte);
                                        }
                                        if (icc8Med)
                                        {
                                            icc8MessageData = (byte)(icc8MessageData ^ fMedByte);
                                            icc8Med = false;
                                        }
                                        if (icc8High)
                                        {
                                            icc8MessageData = (byte)(icc8MessageData ^ fHighByte);
                                            icc8High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc8Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc8Page.Vac240V = vac240V;
                                _icc8Page.Vac240A = vac240A;
                                _icc8Page.FlashTriggerV = flashTriggerV;
                                _icc8Page.Vdc24V = vdc24V;
                                _icc8Page.Vdc24A = vdc24A;
                                _icc8Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc8Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc8Page.TriggerPeriod = triggerPeriod;
                                _icc8Page.TriggerCurrent = triggerCurrent;
                                _icc8Page.AnodePulseWidth = anodePulseWidth;
                                _icc8Page.AnodePulseDelay = anodePulseDelay;
                                _icc8Page.BleederV = bleederV;
                                _icc8Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes

                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc8MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc8MessageData, "ICC8");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc8);
                            }
                            break;
                        case byte s when s == icc9:
                            if (icc9Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc9Low)
                                    {
                                        icc9MessageData = (byte)(icc9MessageData ^ fLowByte);
                                        icc9Low = true;
                                        Icc9SideMenu = "LOW";

                                        Icc9BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc9BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc9Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc9Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc9Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc9Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc9Med)
                                        {
                                            icc9MessageData = (byte)(icc9MessageData ^ fMedByte);
                                            icc9Med = false;
                                            _icc9Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc9Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc9High)
                                        {
                                            icc9MessageData = (byte)(icc9MessageData ^ fHighByte);
                                            icc9High = false;
                                            _icc9Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc9Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc9Med)
                                    {
                                        icc9MessageData = (byte)(icc9MessageData ^ fMedByte);
                                        icc9Med = true;
                                        Icc9SideMenu = "MED";

                                        Icc9BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc9BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc9Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc9Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc9Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc9Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc9Low)
                                        {
                                            icc9MessageData = (byte)(icc9MessageData ^ fLowByte);
                                            icc9Low = false;
                                            _icc9Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc9Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc9High)
                                        {
                                            icc9MessageData = (byte)(icc9MessageData ^ fHighByte);
                                            icc9High = false;
                                            _icc9Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc9Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc9High)
                                    {
                                        icc9MessageData = (byte)(icc9MessageData ^ fHighByte);
                                        icc9High = true;
                                        Icc9SideMenu = "HIGH";

                                        Icc9BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc9BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc9Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc9Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc9Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc9Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc9Low)
                                        {
                                            icc9MessageData = (byte)(icc9MessageData ^ fLowByte);
                                            icc9Low = false;
                                            _icc9Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc9Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc9Med)
                                        {
                                            icc9MessageData = (byte)(icc9MessageData ^ fMedByte);
                                            icc9Med = false;
                                            _icc9Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc9Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc9MessageData = (byte)(icc9MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc9MessageData = (byte)(icc9MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc9On)
                                    {
                                        icc9On = true;
                                        icc9MessageData = (byte)(icc9MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc9On)
                                    {
                                        icc9On = false;
                                        icc9MessageData = (byte)(icc9MessageData ^ fOffByte ^ fOnByte);

                                        Icc9SideMenu = "OFF";
                                        Icc9BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc9BorderBackground = new SolidColorBrush(Colors.Black);


                                        _icc9Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc9Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc9Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc9Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc9Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc9Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc9Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc9Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc9Low)
                                        {
                                            icc9Low = false;
                                            icc9MessageData = (byte)(icc9MessageData ^ fLowByte);
                                        }
                                        if (icc9Med)
                                        {
                                            icc9MessageData = (byte)(icc9MessageData ^ fMedByte);
                                            icc9Med = false;
                                        }
                                        if (icc9High)
                                        {
                                            icc9MessageData = (byte)(icc9MessageData ^ fHighByte);
                                            icc9High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc9Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc9Page.Vac240V = vac240V;
                                _icc9Page.Vac240A = vac240A;
                                _icc9Page.FlashTriggerV = flashTriggerV;
                                _icc9Page.Vdc24V = vdc24V;
                                _icc9Page.Vdc24A = vdc24A;
                                _icc9Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc9Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc9Page.TriggerPeriod = triggerPeriod;
                                _icc9Page.TriggerCurrent = triggerCurrent;
                                _icc9Page.AnodePulseWidth = anodePulseWidth;
                                _icc9Page.AnodePulseDelay = anodePulseDelay;
                                _icc9Page.BleederV = bleederV;
                                _icc9Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc9MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc9MessageData, "ICC9");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc9);
                            }
                            break;
                        case byte s when s == icc10:
                            if (icc10Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc10Low)
                                    {
                                        icc10MessageData = (byte)(icc10MessageData ^ fLowByte);
                                        icc10Low = true;
                                        Icc10SideMenu = "LOW";

                                        Icc10BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc10BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc10Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc10Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc10Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc10Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc10Med)
                                        {
                                            icc10MessageData = (byte)(icc10MessageData ^ fMedByte);
                                            icc10Med = false;
                                            _icc10Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc10Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc10High)
                                        {
                                            icc10MessageData = (byte)(icc10MessageData ^ fHighByte);
                                            icc10High = false;
                                            _icc10Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc10Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc10Med)
                                    {
                                        icc10MessageData = (byte)(icc10MessageData ^ fMedByte);
                                        icc10Med = true;
                                        Icc10SideMenu = "MED";

                                        Icc10BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc10BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc10Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc10Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc10Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc10Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc10Low)
                                        {
                                            icc10MessageData = (byte)(icc10MessageData ^ fLowByte);
                                            icc10Low = false;
                                            _icc10Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc10Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc10High)
                                        {
                                            icc10MessageData = (byte)(icc10MessageData ^ fHighByte);
                                            icc10High = false;
                                            _icc10Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc10Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc10High)
                                    {
                                        icc10MessageData = (byte)(icc10MessageData ^ fHighByte);
                                        icc10High = true;
                                        Icc10SideMenu = "HIGH";

                                        Icc10BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc10BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc10Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc10Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc10Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc10Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc10Low)
                                        {
                                            icc10MessageData = (byte)(icc10MessageData ^ fLowByte);
                                            icc10Low = false;
                                            _icc10Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc10Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc10Med)
                                        {
                                            icc10MessageData = (byte)(icc10MessageData ^ fMedByte);
                                            icc10Med = false;
                                            _icc10Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc10Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc10MessageData = (byte)(icc10MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc10MessageData = (byte)(icc10MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc10On)
                                    {
                                        icc10On = true;
                                        icc10MessageData = (byte)(icc10MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc10On)
                                    {
                                        icc10On = false;
                                        icc10MessageData = (byte)(icc10MessageData ^ fOffByte ^ fOnByte);

                                        Icc10SideMenu = "OFF";
                                        Icc10BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc10BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc10Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc10Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc10Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc10Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc10Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc10Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc10Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc10Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc10Low)
                                        {
                                            icc10Low = false;
                                            icc10MessageData = (byte)(icc10MessageData ^ fLowByte);
                                        }
                                        if (icc10Med)
                                        {
                                            icc10MessageData = (byte)(icc10MessageData ^ fMedByte);
                                            icc10Med = false;
                                        }
                                        if (icc10High)
                                        {
                                            icc10MessageData = (byte)(icc10MessageData ^ fHighByte);
                                            icc10High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc10Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc10Page.Vac240V = vac240V;
                                _icc10Page.Vac240A = vac240A;
                                _icc10Page.FlashTriggerV = flashTriggerV;
                                _icc10Page.Vdc24V = vdc24V;
                                _icc10Page.Vdc24A = vdc24A;
                                _icc10Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc10Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc10Page.TriggerPeriod = triggerPeriod;
                                _icc10Page.TriggerCurrent = triggerCurrent;
                                _icc10Page.AnodePulseWidth = anodePulseWidth;
                                _icc10Page.AnodePulseDelay = anodePulseDelay;
                                _icc10Page.BleederV = bleederV;
                                _icc10Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc10MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc10MessageData, "ICC10");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc10);
                            }
                            break;
                        case byte s when s == icc11:
                            if (icc11Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc11Low)
                                    {
                                        icc11MessageData = (byte)(icc11MessageData ^ fLowByte);
                                        icc11Low = true;
                                        Icc11SideMenu = "LOW";

                                        Icc11BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc11BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc11Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc11Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc11Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc11Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc11Med)
                                        {
                                            icc11MessageData = (byte)(icc11MessageData ^ fMedByte);
                                            icc11Med = false;
                                            _icc11Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc11Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc11High)
                                        {
                                            icc11MessageData = (byte)(icc11MessageData ^ fHighByte);
                                            icc11High = false;
                                            _icc11Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc11Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc11Med)
                                    {
                                        icc11MessageData = (byte)(icc11MessageData ^ fMedByte);
                                        icc11Med = true;
                                        Icc11SideMenu = "MED";

                                        Icc11BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc11BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc11Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc11Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc11Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc11Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc11Low)
                                        {
                                            icc11MessageData = (byte)(icc11MessageData ^ fLowByte);
                                            icc11Low = false;
                                            _icc11Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc11Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc11High)
                                        {
                                            icc11MessageData = (byte)(icc11MessageData ^ fHighByte);
                                            icc11High = false;
                                            _icc11Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc11Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc11High)
                                    {
                                        icc11MessageData = (byte)(icc11MessageData ^ fHighByte);
                                        icc11High = true;
                                        Icc11SideMenu = "HIGH";

                                        Icc11BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc11BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc11Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc11Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc11Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc11Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc11Low)
                                        {
                                            icc11MessageData = (byte)(icc11MessageData ^ fLowByte);
                                            icc11Low = false;
                                            _icc11Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc11Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc11Med)
                                        {
                                            icc11MessageData = (byte)(icc11MessageData ^ fMedByte);
                                            icc11Med = false;
                                            _icc11Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc11Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc11MessageData = (byte)(icc11MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc11MessageData = (byte)(icc11MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc11On)
                                    {
                                        icc11On = true;
                                        icc11MessageData = (byte)(icc11MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc11On)
                                    {
                                        icc11On = false;
                                        icc11MessageData = (byte)(icc11MessageData ^ fOffByte ^ fOnByte);

                                        Icc11SideMenu = "OFF";
                                        Icc11BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc11BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc11Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc11Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc11Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc11Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc11Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc11Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc11Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc11Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc11Low)
                                        {
                                            icc11Low = false;
                                            icc11MessageData = (byte)(icc11MessageData ^ fLowByte);
                                        }
                                        if (icc11Med)
                                        {
                                            icc11MessageData = (byte)(icc11MessageData ^ fMedByte);
                                            icc11Med = false;
                                        }
                                        if (icc11High)
                                        {
                                            icc11MessageData = (byte)(icc11MessageData ^ fHighByte);
                                            icc11High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc11Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc11Page.Vac240V = vac240V;
                                _icc11Page.Vac240A = vac240A;
                                _icc11Page.FlashTriggerV = flashTriggerV;
                                _icc11Page.Vdc24V = vdc24V;
                                _icc11Page.Vdc24A = vdc24A;
                                _icc11Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc11Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc11Page.TriggerPeriod = triggerPeriod;
                                _icc11Page.TriggerCurrent = triggerCurrent;
                                _icc11Page.AnodePulseWidth = anodePulseWidth;
                                _icc11Page.AnodePulseDelay = anodePulseDelay;
                                _icc11Page.BleederV = bleederV;
                                _icc11Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc11MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc11MessageData, "ICC11");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc11);
                            }
                            break;
                        case byte s when s == icc12:
                            if (icc12Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc12Low)
                                    {
                                        icc12MessageData = (byte)(icc12MessageData ^ fLowByte);
                                        icc12Low = true;
                                        Icc12SideMenu = "LOW";

                                        Icc12BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc12BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc12Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc12Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc12Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc12Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc12Med)
                                        {
                                            icc12MessageData = (byte)(icc12MessageData ^ fMedByte);
                                            icc12Med = false;
                                            _icc12Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc12Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc12High)
                                        {
                                            icc12MessageData = (byte)(icc12MessageData ^ fHighByte);
                                            icc12High = false;
                                            _icc12Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc12Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc12Med)
                                    {
                                        icc12MessageData = (byte)(icc12MessageData ^ fMedByte);
                                        icc12Med = true;
                                        Icc12SideMenu = "MED";

                                        Icc12BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc12BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc12Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc12Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc12Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc12Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc12Low)
                                        {
                                            icc12MessageData = (byte)(icc12MessageData ^ fLowByte);
                                            icc12Low = false;
                                            _icc12Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc12Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc12High)
                                        {
                                            icc12MessageData = (byte)(icc12MessageData ^ fHighByte);
                                            icc12High = false;
                                            _icc12Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc12Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc12High)
                                    {
                                        icc12MessageData = (byte)(icc12MessageData ^ fHighByte);
                                        icc12High = true;
                                        Icc12SideMenu = "HIGH";

                                        Icc12BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc12BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc12Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc12Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc12Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc12Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc12Low)
                                        {
                                            icc12MessageData = (byte)(icc12MessageData ^ fLowByte);
                                            icc12Low = false;
                                            _icc12Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc12Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc12Med)
                                        {
                                            icc12MessageData = (byte)(icc12MessageData ^ fMedByte);
                                            icc12Med = false;
                                            _icc12Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc12Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc12MessageData = (byte)(icc12MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc12MessageData = (byte)(icc12MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc12On)
                                    {
                                        icc12On = true;
                                        icc12MessageData = (byte)(icc12MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc12On)
                                    {
                                        icc12On = false;
                                        icc12MessageData = (byte)(icc12MessageData ^ fOffByte ^ fOnByte);

                                        Icc12SideMenu = "OFF";
                                        Icc12BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc12BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc12Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc12Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc12Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc12Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc12Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc12Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc12Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc12Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc12Low)
                                        {
                                            icc12Low = false;
                                            icc12MessageData = (byte)(icc12MessageData ^ fLowByte);
                                        }
                                        if (icc12Med)
                                        {
                                            icc12MessageData = (byte)(icc12MessageData ^ fMedByte);
                                            icc12Med = false;
                                        }
                                        if (icc12High)
                                        {
                                            icc12MessageData = (byte)(icc12MessageData ^ fHighByte);
                                            icc12High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc12Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc12Page.Vac240V = vac240V;
                                _icc12Page.Vac240A = vac240A;
                                _icc12Page.FlashTriggerV = flashTriggerV;
                                _icc12Page.Vdc24V = vdc24V;
                                _icc12Page.Vdc24A = vdc24A;
                                _icc12Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc12Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc12Page.TriggerPeriod = triggerPeriod;
                                _icc12Page.TriggerCurrent = triggerCurrent;
                                _icc12Page.AnodePulseWidth = anodePulseWidth;
                                _icc12Page.AnodePulseDelay = anodePulseDelay;
                                _icc12Page.BleederV = bleederV;
                                _icc12Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc12MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc12MessageData, "ICC12");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc12);
                            }
                            break;
                        case byte s when s == icc13:
                            if (icc13Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc13Low)
                                    {
                                        icc13MessageData = (byte)(icc13MessageData ^ fLowByte);
                                        icc13Low = true;
                                        Icc13SideMenu = "LOW";

                                        Icc13BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc13BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc13Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc13Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc13Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc13Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc13Med)
                                        {
                                            icc13MessageData = (byte)(icc13MessageData ^ fMedByte);
                                            icc13Med = false;
                                            _icc13Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc13Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc13High)
                                        {
                                            icc13MessageData = (byte)(icc13MessageData ^ fHighByte);
                                            icc13High = false;
                                            _icc13Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc13Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc13Med)
                                    {
                                        icc13MessageData = (byte)(icc13MessageData ^ fMedByte);
                                        icc13Med = true;
                                        Icc13SideMenu = "MED";

                                        Icc13BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc13BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc13Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc13Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc13Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc13Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc13Low)
                                        {
                                            icc13MessageData = (byte)(icc13MessageData ^ fLowByte);
                                            icc13Low = false;
                                            _icc13Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc13Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc13High)
                                        {
                                            icc13MessageData = (byte)(icc13MessageData ^ fHighByte);
                                            icc13High = false;
                                            _icc13Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc13Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc13High)
                                    {
                                        icc13MessageData = (byte)(icc13MessageData ^ fHighByte);
                                        icc13High = true;
                                        Icc13SideMenu = "HIGH";

                                        Icc13BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc13BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc13Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc13Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc13Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc13Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc13Low)
                                        {
                                            icc13MessageData = (byte)(icc13MessageData ^ fLowByte);
                                            icc13Low = false;
                                            _icc13Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc13Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc13Med)
                                        {
                                            icc13MessageData = (byte)(icc13MessageData ^ fMedByte);
                                            icc13Med = false;
                                            _icc13Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc13Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc13MessageData = (byte)(icc13MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc13MessageData = (byte)(icc13MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc13On)
                                    {
                                        icc13On = true;
                                        icc13MessageData = (byte)(icc13MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc13On)
                                    {
                                        icc13On = false;
                                        icc13MessageData = (byte)(icc13MessageData ^ fOffByte ^ fOnByte);

                                        Icc13SideMenu = "OFF";
                                        Icc13BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc13BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc13Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc13Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc13Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc13Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc13Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc13Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc13Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc13Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc13Low)
                                        {
                                            icc13Low = false;
                                            icc13MessageData = (byte)(icc13MessageData ^ fLowByte);
                                        }
                                        if (icc13Med)
                                        {
                                            icc13MessageData = (byte)(icc13MessageData ^ fMedByte);
                                            icc13Med = false;
                                        }
                                        if (icc13High)
                                        {
                                            icc13MessageData = (byte)(icc13MessageData ^ fHighByte);
                                            icc13High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc13Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc13Page.Vac240V = vac240V;
                                _icc13Page.Vac240A = vac240A;
                                _icc13Page.FlashTriggerV = flashTriggerV;
                                _icc13Page.Vdc24V = vdc24V;
                                _icc13Page.Vdc24A = vdc24A;
                                _icc13Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc13Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc13Page.TriggerPeriod = triggerPeriod;
                                _icc13Page.TriggerCurrent = triggerCurrent;
                                _icc13Page.AnodePulseWidth = anodePulseWidth;
                                _icc13Page.AnodePulseDelay = anodePulseDelay;
                                _icc13Page.BleederV = bleederV;
                                _icc13Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc13MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc13MessageData, "ICC13");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc13);
                            }
                            break;
                        case byte s when s == icc14:
                            if (icc14Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc14Low)
                                    {
                                        icc14MessageData = (byte)(icc14MessageData ^ fLowByte);
                                        icc14Low = true;
                                        Icc14SideMenu = "LOW";

                                        Icc14BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc14BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc14Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc14Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc14Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc14Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc14Med)
                                        {
                                            icc14MessageData = (byte)(icc14MessageData ^ fMedByte);
                                            icc14Med = false;
                                            _icc14Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc14Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc14High)
                                        {
                                            icc14MessageData = (byte)(icc14MessageData ^ fHighByte);
                                            icc14High = false;
                                            _icc14Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc14Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc14Med)
                                    {
                                        icc14MessageData = (byte)(icc14MessageData ^ fMedByte);
                                        icc14Med = true;
                                        Icc14SideMenu = "MED";

                                        Icc14BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc14BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc14Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc14Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc14Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc14Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc14Low)
                                        {
                                            icc14MessageData = (byte)(icc14MessageData ^ fLowByte);
                                            icc14Low = false;
                                            _icc14Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc14Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc14High)
                                        {
                                            icc14MessageData = (byte)(icc14MessageData ^ fHighByte);
                                            icc14High = false;
                                            _icc14Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc14Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc14High)
                                    {
                                        icc14MessageData = (byte)(icc14MessageData ^ fHighByte);
                                        icc14High = true;
                                        Icc14SideMenu = "HIGH";

                                        Icc14BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc14BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc14Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc14Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc14Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc14Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc14Low)
                                        {
                                            icc14MessageData = (byte)(icc14MessageData ^ fLowByte);
                                            icc14Low = false;
                                            _icc14Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc14Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc14Med)
                                        {
                                            icc14MessageData = (byte)(icc14MessageData ^ fMedByte);
                                            icc14Med = false;
                                            _icc14Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc14Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc14MessageData = (byte)(icc14MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc14MessageData = (byte)(icc14MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc14On)
                                    {
                                        icc14On = true;
                                        icc14MessageData = (byte)(icc14MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc14On)
                                    {
                                        icc14On = false;
                                        icc14MessageData = (byte)(icc14MessageData ^ fOffByte ^ fOnByte);

                                        Icc14SideMenu = "OFF";
                                        Icc14BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc14BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc14Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc14Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc14Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc14Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc14Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc14Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc14Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc14Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc14Low)
                                        {
                                            icc14Low = false;
                                            icc14MessageData = (byte)(icc14MessageData ^ fLowByte);
                                        }
                                        if (icc14Med)
                                        {
                                            icc14MessageData = (byte)(icc14MessageData ^ fMedByte);
                                            icc14Med = false;
                                        }
                                        if (icc14High)
                                        {
                                            icc14MessageData = (byte)(icc14MessageData ^ fHighByte);
                                            icc14High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc14Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc14Page.Vac240V = vac240V;
                                _icc14Page.Vac240A = vac240A;
                                _icc14Page.FlashTriggerV = flashTriggerV;
                                _icc14Page.Vdc24V = vdc24V;
                                _icc14Page.Vdc24A = vdc24A;
                                _icc14Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc14Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc14Page.TriggerPeriod = triggerPeriod;
                                _icc14Page.TriggerCurrent = triggerCurrent;
                                _icc14Page.AnodePulseWidth = anodePulseWidth;
                                _icc14Page.AnodePulseDelay = anodePulseDelay;
                                _icc14Page.BleederV = bleederV;
                                _icc14Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc14MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc14MessageData, "ICC14");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc14);
                            }
                            break;
                        case byte s when s == icc15:
                            if (icc15Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc15Low)
                                    {
                                        icc15MessageData = (byte)(icc15MessageData ^ fLowByte);
                                        icc15Low = true;
                                        Icc15SideMenu = "LOW";

                                        Icc15BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc15BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc15Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc15Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc15Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc15Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc15Med)
                                        {
                                            icc15MessageData = (byte)(icc15MessageData ^ fMedByte);
                                            icc15Med = false;
                                            _icc15Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc15Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc15High)
                                        {
                                            icc15MessageData = (byte)(icc15MessageData ^ fHighByte);
                                            icc15High = false;
                                            _icc15Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc15Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc15Med)
                                    {
                                        icc15MessageData = (byte)(icc15MessageData ^ fMedByte);
                                        icc15Med = true;
                                        Icc15SideMenu = "MED";

                                        Icc15BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc15BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc15Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc15Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc15Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc15Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc15Low)
                                        {
                                            icc15MessageData = (byte)(icc15MessageData ^ fLowByte);
                                            icc15Low = false;
                                            _icc15Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc15Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc15High)
                                        {
                                            icc15MessageData = (byte)(icc15MessageData ^ fHighByte);
                                            icc15High = false;
                                            _icc15Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc15Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc15High)
                                    {
                                        icc15MessageData = (byte)(icc15MessageData ^ fHighByte);
                                        icc15High = true;
                                        Icc15SideMenu = "HIGH";

                                        Icc15BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc15BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc15Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc15Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc15Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc15Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc15Low)
                                        {
                                            icc15MessageData = (byte)(icc15MessageData ^ fLowByte);
                                            icc15Low = false;
                                            _icc15Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc15Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc15Med)
                                        {
                                            icc15MessageData = (byte)(icc15MessageData ^ fMedByte);
                                            icc15Med = false;
                                            _icc15Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc15Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc15MessageData = (byte)(icc15MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc15MessageData = (byte)(icc15MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc15On)
                                    {
                                        icc15On = true;
                                        icc15MessageData = (byte)(icc15MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc15On)
                                    {
                                        icc15On = false;
                                        icc15MessageData = (byte)(icc15MessageData ^ fOffByte ^ fOnByte);

                                        Icc15SideMenu = "OFF";
                                        Icc15BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc15BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc15Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc15Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc15Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc15Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc15Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc15Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc15Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc15Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc15Low)
                                        {
                                            icc15Low = false;
                                            icc15MessageData = (byte)(icc15MessageData ^ fLowByte);
                                        }
                                        if (icc15Med)
                                        {
                                            icc15MessageData = (byte)(icc15MessageData ^ fMedByte);
                                            icc15Med = false;
                                        }
                                        if (icc15High)
                                        {
                                            icc15MessageData = (byte)(icc15MessageData ^ fHighByte);
                                            icc15High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc15Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc15Page.Vac240V = vac240V;
                                _icc15Page.Vac240A = vac240A;
                                _icc15Page.FlashTriggerV = flashTriggerV;
                                _icc15Page.Vdc24V = vdc24V;
                                _icc15Page.Vdc24A = vdc24A;
                                _icc15Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc15Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc15Page.TriggerPeriod = triggerPeriod;
                                _icc15Page.TriggerCurrent = triggerCurrent;
                                _icc15Page.AnodePulseWidth = anodePulseWidth;
                                _icc15Page.AnodePulseDelay = anodePulseDelay;
                                _icc15Page.BleederV = bleederV;
                                _icc15Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc15MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc15MessageData, "ICC15");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc15);
                            }
                            break;
                        case byte s when s == icc16:
                            if (icc16Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc16Low)
                                    {
                                        icc16MessageData = (byte)(icc16MessageData ^ fLowByte);
                                        icc16Low = true;
                                        Icc16SideMenu = "LOW";

                                        Icc16BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc16BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc16Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc16Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc16Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc16Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc16Med)
                                        {
                                            icc16MessageData = (byte)(icc16MessageData ^ fMedByte);
                                            icc16Med = false;
                                            _icc16Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc16Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc16High)
                                        {
                                            icc16MessageData = (byte)(icc16MessageData ^ fHighByte);
                                            icc16High = false;
                                            _icc16Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc16Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc16Med)
                                    {
                                        icc16MessageData = (byte)(icc16MessageData ^ fMedByte);
                                        icc16Med = true;
                                        Icc16SideMenu = "MED";

                                        Icc16BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc16BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc16Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc16Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc16Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc16Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc16Low)
                                        {
                                            icc16MessageData = (byte)(icc16MessageData ^ fLowByte);
                                            icc16Low = false;
                                            _icc16Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc16Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc16High)
                                        {
                                            icc16MessageData = (byte)(icc16MessageData ^ fHighByte);
                                            icc16High = false;
                                            _icc16Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc16Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc16High)
                                    {
                                        icc16MessageData = (byte)(icc16MessageData ^ fHighByte);
                                        icc16High = true;
                                        Icc16SideMenu = "HIGH";

                                        Icc16BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc16BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc16Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc16Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc16Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc16Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc16Low)
                                        {
                                            icc16MessageData = (byte)(icc16MessageData ^ fLowByte);
                                            icc16Low = false;
                                            _icc16Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc16Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc16Med)
                                        {
                                            icc16MessageData = (byte)(icc16MessageData ^ fMedByte);
                                            icc16Med = false;
                                            _icc16Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc16Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc16MessageData = (byte)(icc16MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc16MessageData = (byte)(icc16MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc16On)
                                    {
                                        icc16On = true;
                                        icc16MessageData = (byte)(icc16MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc16On)
                                    {
                                        icc16On = false;
                                        icc16MessageData = (byte)(icc16MessageData ^ fOffByte ^ fOnByte);

                                        Icc16SideMenu = "OFF";
                                        Icc16BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc16BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc16Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc16Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc16Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc16Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc16Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc16Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc16Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc16Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc16Low)
                                        {
                                            icc16Low = false;
                                            icc16MessageData = (byte)(icc16MessageData ^ fLowByte);
                                        }
                                        if (icc16Med)
                                        {
                                            icc16MessageData = (byte)(icc16MessageData ^ fMedByte);
                                            icc16Med = false;
                                        }
                                        if (icc16High)
                                        {
                                            icc16MessageData = (byte)(icc16MessageData ^ fHighByte);
                                            icc16High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc16Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc16Page.Vac240V = vac240V;
                                _icc16Page.Vac240A = vac240A;
                                _icc16Page.FlashTriggerV = flashTriggerV;
                                _icc16Page.Vdc24V = vdc24V;
                                _icc16Page.Vdc24A = vdc24A;
                                _icc16Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc16Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc16Page.TriggerPeriod = triggerPeriod;
                                _icc16Page.TriggerCurrent = triggerCurrent;
                                _icc16Page.AnodePulseWidth = anodePulseWidth;
                                _icc16Page.AnodePulseDelay = anodePulseDelay;
                                _icc16Page.BleederV = bleederV;
                                _icc16Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc16MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc16MessageData, "ICC16");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc16);
                            }
                            break;
                        case byte s when s == icc17:
                            if (icc17Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc17Low)
                                    {
                                        icc17MessageData = (byte)(icc17MessageData ^ fLowByte);
                                        icc17Low = true;
                                        Icc17SideMenu = "LOW";

                                        Icc17BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc17BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc17Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc17Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc17Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc17Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc17Med)
                                        {
                                            icc17MessageData = (byte)(icc17MessageData ^ fMedByte);
                                            icc17Med = false;
                                            _icc17Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc17Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc17High)
                                        {
                                            icc17MessageData = (byte)(icc17MessageData ^ fHighByte);
                                            icc17High = false;
                                            _icc17Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc17Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc17Med)
                                    {
                                        icc17MessageData = (byte)(icc17MessageData ^ fMedByte);
                                        icc17Med = true;
                                        Icc17SideMenu = "MED";

                                        Icc17BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc17BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc17Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc17Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc17Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc17Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc17Low)
                                        {
                                            icc17MessageData = (byte)(icc17MessageData ^ fLowByte);
                                            icc17Low = false;
                                            _icc17Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc17Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc17High)
                                        {
                                            icc17MessageData = (byte)(icc17MessageData ^ fHighByte);
                                            icc17High = false;
                                            _icc17Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc17Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc17High)
                                    {
                                        icc17MessageData = (byte)(icc17MessageData ^ fHighByte);
                                        icc17High = true;
                                        Icc17SideMenu = "HIGH";

                                        Icc17BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc17BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc17Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc17Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc17Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc17Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc17Low)
                                        {
                                            icc17MessageData = (byte)(icc17MessageData ^ fLowByte);
                                            icc17Low = false;
                                            _icc17Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc17Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc17Med)
                                        {
                                            icc17MessageData = (byte)(icc17MessageData ^ fMedByte);
                                            icc17Med = false;
                                            _icc17Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc17Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc17MessageData = (byte)(icc17MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc17MessageData = (byte)(icc17MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc17On)
                                    {
                                        icc17On = true;
                                        icc17MessageData = (byte)(icc17MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc17On)
                                    {
                                        icc17On = false;
                                        icc17MessageData = (byte)(icc17MessageData ^ fOffByte ^ fOnByte);

                                        Icc17SideMenu = "OFF";
                                        Icc17BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc17BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc17Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc17Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc17Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc17Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc17Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc17Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc17Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc17Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc17Low)
                                        {
                                            icc17Low = false;
                                            icc17MessageData = (byte)(icc17MessageData ^ fLowByte);
                                        }
                                        if (icc17Med)
                                        {
                                            icc17MessageData = (byte)(icc17MessageData ^ fMedByte);
                                            icc17Med = false;
                                        }
                                        if (icc17High)
                                        {
                                            icc17MessageData = (byte)(icc17MessageData ^ fHighByte);
                                            icc17High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc17Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc17Page.Vac240V = vac240V;
                                _icc17Page.Vac240A = vac240A;
                                _icc17Page.FlashTriggerV = flashTriggerV;
                                _icc17Page.Vdc24V = vdc24V;
                                _icc17Page.Vdc24A = vdc24A;
                                _icc17Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc17Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc17Page.TriggerPeriod = triggerPeriod;
                                _icc17Page.TriggerCurrent = triggerCurrent;
                                _icc17Page.AnodePulseWidth = anodePulseWidth;
                                _icc17Page.AnodePulseDelay = anodePulseDelay;
                                _icc17Page.BleederV = bleederV;
                                _icc17Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc17MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc17MessageData, "ICC17");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc17);
                            }
                            break;
                        case byte s when s == icc18:
                            if (icc18Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc18Low)
                                    {
                                        icc18MessageData = (byte)(icc18MessageData ^ fLowByte);
                                        icc18Low = true;
                                        Icc18SideMenu = "LOW";

                                        Icc18BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc18BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc18Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc18Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc18Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc18Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc18Med)
                                        {
                                            icc18MessageData = (byte)(icc18MessageData ^ fMedByte);
                                            icc18Med = false;
                                            _icc18Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc18Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc18High)
                                        {
                                            icc18MessageData = (byte)(icc18MessageData ^ fHighByte);
                                            icc18High = false;
                                            _icc18Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc18Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc18Med)
                                    {
                                        icc18MessageData = (byte)(icc18MessageData ^ fMedByte);
                                        icc18Med = true;
                                        Icc18SideMenu = "MED";

                                        Icc18BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc18BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc18Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc18Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc18Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc18Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc18Low)
                                        {
                                            icc18MessageData = (byte)(icc18MessageData ^ fLowByte);
                                            icc18Low = false;
                                            _icc18Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc18Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc18High)
                                        {
                                            icc18MessageData = (byte)(icc18MessageData ^ fHighByte);
                                            icc18High = false;
                                            _icc18Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc18Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc18High)
                                    {
                                        icc18MessageData = (byte)(icc18MessageData ^ fHighByte);
                                        icc18High = true;
                                        Icc18SideMenu = "HIGH";

                                        Icc18BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc18BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc18Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc18Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc18Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc18Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc18Low)
                                        {
                                            icc18MessageData = (byte)(icc18MessageData ^ fLowByte);
                                            icc18Low = false;
                                            _icc18Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc18Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc18Med)
                                        {
                                            icc18MessageData = (byte)(icc18MessageData ^ fMedByte);
                                            icc18Med = false;
                                            _icc18Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc18Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc18MessageData = (byte)(icc18MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc18MessageData = (byte)(icc18MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc18On)
                                    {
                                        icc18On = true;
                                        icc18MessageData = (byte)(icc18MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc18On)
                                    {
                                        icc18On = false;
                                        icc18MessageData = (byte)(icc18MessageData ^ fOffByte ^ fOnByte);

                                        Icc18SideMenu = "OFF";
                                        Icc18BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc18BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc18Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc18Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc18Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc18Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc18Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc18Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc18Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc18Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc18Low)
                                        {
                                            icc18Low = false;
                                            icc18MessageData = (byte)(icc18MessageData ^ fLowByte);
                                        }
                                        if (icc18Med)
                                        {
                                            icc18MessageData = (byte)(icc18MessageData ^ fMedByte);
                                            icc18Med = false;
                                        }
                                        if (icc18High)
                                        {
                                            icc18MessageData = (byte)(icc18MessageData ^ fHighByte);
                                            icc18High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc18Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc18Page.Vac240V = vac240V;
                                _icc18Page.Vac240A = vac240A;
                                _icc18Page.FlashTriggerV = flashTriggerV;
                                _icc18Page.Vdc24V = vdc24V;
                                _icc18Page.Vdc24A = vdc24A;
                                _icc18Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc18Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc18Page.TriggerPeriod = triggerPeriod;
                                _icc18Page.TriggerCurrent = triggerCurrent;
                                _icc18Page.AnodePulseWidth = anodePulseWidth;
                                _icc18Page.AnodePulseDelay = anodePulseDelay;
                                _icc18Page.BleederV = bleederV;
                                _icc18Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc18MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc18MessageData, "ICC18");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc18);
                            }
                            break;
                        case byte s when s == icc19:
                            if (icc19Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc19Low)
                                    {
                                        icc19MessageData = (byte)(icc19MessageData ^ fLowByte);
                                        icc19Low = true;
                                        Icc19SideMenu = "LOW";

                                        Icc19BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc19BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc19Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc19Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc19Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc19Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc19Med)
                                        {
                                            icc19MessageData = (byte)(icc19MessageData ^ fMedByte);
                                            icc19Med = false;
                                            _icc19Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc19Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc19High)
                                        {
                                            icc19MessageData = (byte)(icc19MessageData ^ fHighByte);
                                            icc19High = false;
                                            _icc19Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc19Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc19Med)
                                    {
                                        icc19MessageData = (byte)(icc19MessageData ^ fMedByte);
                                        icc19Med = true;
                                        Icc19SideMenu = "MED";

                                        Icc19BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc19BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc19Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc19Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc19Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc19Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc19Low)
                                        {
                                            icc19MessageData = (byte)(icc19MessageData ^ fLowByte);
                                            icc19Low = false;
                                            _icc19Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc19Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc19High)
                                        {
                                            icc19MessageData = (byte)(icc19MessageData ^ fHighByte);
                                            icc19High = false;
                                            _icc19Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc19Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc19High)
                                    {
                                        icc19MessageData = (byte)(icc19MessageData ^ fHighByte);
                                        icc19High = true;
                                        Icc19SideMenu = "HIGH";

                                        Icc19BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc19BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc19Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc19Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc19Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc19Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc19Low)
                                        {
                                            icc19MessageData = (byte)(icc19MessageData ^ fLowByte);
                                            icc19Low = false;
                                            _icc19Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc19Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc19Med)
                                        {
                                            icc19MessageData = (byte)(icc19MessageData ^ fMedByte);
                                            icc19Med = false;
                                            _icc19Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc19Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc19MessageData = (byte)(icc19MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc19MessageData = (byte)(icc19MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc19On)
                                    {
                                        icc19On = true;
                                        icc19MessageData = (byte)(icc19MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc19On)
                                    {
                                        icc19On = false;
                                        icc19MessageData = (byte)(icc19MessageData ^ fOffByte ^ fOnByte);

                                        Icc19SideMenu = "OFF";
                                        Icc19BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc19BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc19Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc19Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc19Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc19Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc19Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc19Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc19Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc19Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc19Low)
                                        {
                                            icc19Low = false;
                                            icc19MessageData = (byte)(icc19MessageData ^ fLowByte);
                                        }
                                        if (icc19Med)
                                        {
                                            icc19MessageData = (byte)(icc19MessageData ^ fMedByte);
                                            icc19Med = false;
                                        }
                                        if (icc19High)
                                        {
                                            icc19MessageData = (byte)(icc19MessageData ^ fHighByte);
                                            icc19High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc19Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc19Page.Vac240V = vac240V;
                                _icc19Page.Vac240A = vac240A;
                                _icc19Page.FlashTriggerV = flashTriggerV;
                                _icc19Page.Vdc24V = vdc24V;
                                _icc19Page.Vdc24A = vdc24A;
                                _icc19Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc19Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc19Page.TriggerPeriod = triggerPeriod;
                                _icc19Page.TriggerCurrent = triggerCurrent;
                                _icc19Page.AnodePulseWidth = anodePulseWidth;
                                _icc19Page.AnodePulseDelay = anodePulseDelay;
                                _icc19Page.BleederV = bleederV;
                                _icc19Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc19MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc19MessageData, "ICC19");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc19);
                            }
                            break;
                        case byte s when s == icc20:
                            if (icc20Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc20Low)
                                    {
                                        icc20MessageData = (byte)(icc20MessageData ^ fLowByte);
                                        icc20Low = true;
                                        Icc20SideMenu = "LOW";

                                        Icc20BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc20BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc20Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc20Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc20Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc20Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc20Med)
                                        {
                                            icc20MessageData = (byte)(icc20MessageData ^ fMedByte);
                                            icc20Med = false;
                                            _icc20Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc20Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc20High)
                                        {
                                            icc20MessageData = (byte)(icc20MessageData ^ fHighByte);
                                            icc20High = false;
                                            _icc20Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc20Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc20Med)
                                    {
                                        icc20MessageData = (byte)(icc20MessageData ^ fMedByte);
                                        icc20Med = true;
                                        Icc20SideMenu = "MED";

                                        Icc20BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc20BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc20Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc20Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc20Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc20Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc20Low)
                                        {
                                            icc20MessageData = (byte)(icc20MessageData ^ fLowByte);
                                            icc20Low = false;
                                            _icc20Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc20Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc20High)
                                        {
                                            icc20MessageData = (byte)(icc20MessageData ^ fHighByte);
                                            icc20High = false;
                                            _icc20Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc20Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc20High)
                                    {
                                        icc20MessageData = (byte)(icc20MessageData ^ fHighByte);
                                        icc20High = true;
                                        Icc20SideMenu = "HIGH";

                                        Icc20BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc20BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc20Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc20Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc20Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc20Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc20Low)
                                        {
                                            icc20MessageData = (byte)(icc20MessageData ^ fLowByte);
                                            icc20Low = false;
                                            _icc20Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc20Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc20Med)
                                        {
                                            icc20MessageData = (byte)(icc20MessageData ^ fMedByte);
                                            icc20Med = false;
                                            _icc20Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc20Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc20MessageData = (byte)(icc20MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc20MessageData = (byte)(icc20MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc20On)
                                    {
                                        icc20On = true;
                                        icc20MessageData = (byte)(icc20MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc20On)
                                    {
                                        icc20On = false;
                                        icc20MessageData = (byte)(icc20MessageData ^ fOffByte ^ fOnByte);

                                        Icc20SideMenu = "OFF";
                                        Icc20BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc20BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc20Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc20Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc20Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc20Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc20Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc20Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc20Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc20Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc20Low)
                                        {
                                            icc20Low = false;
                                            icc20MessageData = (byte)(icc20MessageData ^ fLowByte);
                                        }
                                        if (icc20Med)
                                        {
                                            icc20MessageData = (byte)(icc20MessageData ^ fMedByte);
                                            icc20Med = false;
                                        }
                                        if (icc20High)
                                        {
                                            icc20MessageData = (byte)(icc20MessageData ^ fHighByte);
                                            icc20High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc20Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc20Page.Vac240V = vac240V;
                                _icc20Page.Vac240A = vac240A;
                                _icc20Page.FlashTriggerV = flashTriggerV;
                                _icc20Page.Vdc24V = vdc24V;
                                _icc20Page.Vdc24A = vdc24A;
                                _icc20Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc20Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc20Page.TriggerPeriod = triggerPeriod;
                                _icc20Page.TriggerCurrent = triggerCurrent;
                                _icc20Page.AnodePulseWidth = anodePulseWidth;
                                _icc20Page.AnodePulseDelay = anodePulseDelay;
                                _icc20Page.BleederV = bleederV;
                                _icc20Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc20MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc20MessageData, "ICC20");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc20);
                            }
                            break;
                        case byte s when s == icc21:
                            if (icc21Compat)
                            {
                                // compatibility mode - 25 bytes
                                // update iccMessageData from short data
                                if ((message[6] & 0x01) == 0x01) // LOW
                                {
                                    if (!icc21Low)
                                    {
                                        icc21MessageData = (byte)(icc21MessageData ^ fLowByte);
                                        icc21Low = true;
                                        Icc21SideMenu = "LOW";

                                        Icc21BorderBrush = new SolidColorBrush(Colors.Green);
                                        Icc21BorderBackground = new SolidColorBrush(Colors.Green);
                                        _icc21Page.LowButton = new SolidColorBrush(Colors.Green);
                                        _icc21Page.LowForeground = new SolidColorBrush(Colors.White);
                                        _icc21Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc21Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc21Med)
                                        {
                                            icc21MessageData = (byte)(icc21MessageData ^ fMedByte);
                                            icc21Med = false;
                                            _icc21Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc21Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc21High)
                                        {
                                            icc21MessageData = (byte)(icc21MessageData ^ fHighByte);
                                            icc21High = false;
                                            _icc21Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc21Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x02) == 0x02) // MED
                                {
                                    if (!icc21Med)
                                    {
                                        icc21MessageData = (byte)(icc21MessageData ^ fMedByte);
                                        icc21Med = true;
                                        Icc21SideMenu = "MED";

                                        Icc21BorderBrush = new SolidColorBrush(Colors.Orange);
                                        Icc21BorderBackground = new SolidColorBrush(Colors.Orange);
                                        _icc21Page.MedButton = new SolidColorBrush(Colors.Green);
                                        _icc21Page.MedForeground = new SolidColorBrush(Colors.White);
                                        _icc21Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc21Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc21Low)
                                        {
                                            icc21MessageData = (byte)(icc21MessageData ^ fLowByte);
                                            icc21Low = false;
                                            _icc21Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc21Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc21High)
                                        {
                                            icc21MessageData = (byte)(icc21MessageData ^ fHighByte);
                                            icc21High = false;
                                            _icc21Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                            _icc21Page.HighForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x04) == 0x04) // HIGH
                                {
                                    if (!icc21High)
                                    {
                                        icc21MessageData = (byte)(icc21MessageData ^ fHighByte);
                                        icc21High = true;
                                        Icc21SideMenu = "HIGH";

                                        Icc21BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                                        Icc21BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                                        _icc21Page.HighButton = new SolidColorBrush(Colors.Green);
                                        _icc21Page.HighForeground = new SolidColorBrush(Colors.White);
                                        _icc21Page.OffButton = new SolidColorBrush(Colors.LightGray);
                                        _icc21Page.OffForeground = new SolidColorBrush(Colors.Black);

                                        if (icc21Low)
                                        {
                                            icc21MessageData = (byte)(icc21MessageData ^ fLowByte);
                                            icc21Low = false;
                                            _icc21Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                            _icc21Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        }
                                        if (icc21Med)
                                        {
                                            icc21MessageData = (byte)(icc21MessageData ^ fMedByte);
                                            icc21Med = false;
                                            _icc21Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                            _icc21Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        }
                                    }
                                }
                                if ((message[6] & 0x10) == 0x10) // ALSF
                                {
                                    if (!AlsfMode)
                                    {
                                        icc21MessageData = (byte)(icc21MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = true;
                                    }
                                }
                                else // SSALR
                                {
                                    if (AlsfMode)
                                    {
                                        icc21MessageData = (byte)(icc21MessageData ^ alsfModeByte ^ ssalrModeByte);
                                        AlsfMode = false;
                                    }
                                }
                                if ((message[6] & 0x20) == 0x20) // ON
                                {
                                    if (!icc21On)
                                    {
                                        icc21On = true;
                                        icc21MessageData = (byte)(icc21MessageData ^ fOffByte ^ fOnByte);
                                    }
                                }
                                else // OFF
                                {
                                    if (icc21On)
                                    {
                                        icc21On = false;
                                        icc21MessageData = (byte)(icc21MessageData ^ fOffByte ^ fOnByte);

                                        Icc21SideMenu = "OFF";
                                        Icc21BorderBrush = new SolidColorBrush(Colors.Black);
                                        Icc21BorderBackground = new SolidColorBrush(Colors.Black);

                                        _icc21Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                                        _icc21Page.OffForeground = new SolidColorBrush(Colors.White);
                                        _icc21Page.LowButton = new SolidColorBrush(Colors.LightGray);
                                        _icc21Page.LowForeground = new SolidColorBrush(Colors.Black);
                                        _icc21Page.MedButton = new SolidColorBrush(Colors.LightGray);
                                        _icc21Page.MedForeground = new SolidColorBrush(Colors.Black);
                                        _icc21Page.HighButton = new SolidColorBrush(Colors.LightGray);
                                        _icc21Page.HighForeground = new SolidColorBrush(Colors.Black);

                                        if (icc21Low)
                                        {
                                            icc21Low = false;
                                            icc21MessageData = (byte)(icc21MessageData ^ fLowByte);
                                        }
                                        if (icc21Med)
                                        {
                                            icc21MessageData = (byte)(icc21MessageData ^ fMedByte);
                                            icc21Med = false;
                                        }
                                        if (icc21High)
                                        {
                                            icc21MessageData = (byte)(icc21MessageData ^ fHighByte);
                                            icc21High = false;
                                        }
                                    }
                                }
                                string vac240V = ((message[7] << 8) | message[8]).ToString() + "V";
                                string vac240A = (message[9] * 0.1).ToString();
                                string flashTriggerV = ((message[10] << 8) | message[11]).ToString();
                                string vdc24V = (((message[12] << 8) | message[13]) * 0.1).ToString();
                                string vdc24A = (message[14] * 0.1).ToString();
                                string triggerPulseWidth = (((message[15] << 8) | message[16]) * 0.1).ToString();
                                string triggerPulseDelay = (((message[17] << 8) | message[18]) * 0.1).ToString();
                                string triggerPeriod = ((message[19] << 8) | message[20]).ToString();
                                string triggerCurrent = (((message[21] << 8) | message[22]) * 0.1).ToString();
                                string anodePulseWidth = ((message[23] << 8) | message[24]).ToString();
                                string anodePulseDelay = ((message[25] << 8) | message[26]).ToString();
                                string bleederV = (((message[27] << 8) | message[28]) * 0.1).ToString();
                                string misfires = message[29].ToString();
                                if (message[29] > 7)
                                {
                                    _icc21Page.SubmitFlasherMisfires(misfires);
                                }

                                _icc21Page.Vac240V = vac240V;
                                _icc21Page.Vac240A = vac240A;
                                _icc21Page.FlashTriggerV = flashTriggerV;
                                _icc21Page.Vdc24V = vdc24V;
                                _icc21Page.Vdc24A = vdc24A;
                                _icc21Page.TriggerPulseWidth = triggerPulseWidth;
                                _icc21Page.TriggerPulseDelay = triggerPulseDelay;
                                _icc21Page.TriggerPeriod = triggerPeriod;
                                _icc21Page.TriggerCurrent = triggerCurrent;
                                _icc21Page.AnodePulseWidth = anodePulseWidth;
                                _icc21Page.AnodePulseDelay = anodePulseDelay;
                                _icc21Page.BleederV = bleederV;
                                _icc21Page.FlasherMisfires = misfires;

                            }
                            else
                            {
                                // enhanced mode - 34 bytes
                            }
                            // compare cmMessageData to iccMessageData
                            if (cmMessageData != icc21MessageData)
                            {
                                string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc21MessageData, "ICC21");
                                Avalonia.Threading.Dispatcher.UIThread.Post(() => _homePage.LogText += mismatchInfo);
                                SendCmCommand(icc21);
                            }
                            break;
                        default:
                            _homePage.ShortButton = new SolidColorBrush(Colors.Red);
                            break;
                    }
                    break;
                case byte n when n == CONFIG_RESPONSE: // 0x47
                    _homePage.LogText += "CONFIG_RESPONSE (Message ID: 0x47)\n";
                    switch (source)
                    {
                        case byte s when s == icc1:
                            ReadIcc1Config(message[5], message[6]);
                            break;
                        case byte s when s == icc2:
                            ReadIcc2Config(message[5], message[6]);
                            break;
                        case byte s when s == icc3:
                            ReadIcc3Config(message[5], message[6]);
                            break;
                        case byte s when s == icc4:
                            ReadIcc4Config(message[5], message[6]);
                            break;
                        case byte s when s == icc5:
                            ReadIcc5Config(message[5], message[6]);
                            break;
                        case byte s when s == icc6:
                            ReadIcc6Config(message[5], message[6]);
                            break;
                        case byte s when s == icc7:
                            ReadIcc7Config(message[5], message[6]);
                            break;
                        case byte s when s == icc8:
                            ReadIcc8Config(message[5], message[6]);
                            break;
                        case byte s when s == icc9:
                            ReadIcc9Config(message[5], message[6]);
                            break;
                        case byte s when s == icc10:
                            ReadIcc10Config(message[5], message[6]);
                            break;
                        case byte s when s == icc11:
                            ReadIcc11Config(message[5], message[6]);
                            break;
                        case byte s when s == icc12:
                            ReadIcc12Config(message[5], message[6]);
                            break;
                        case byte s when s == icc13:
                            ReadIcc13Config(message[5], message[6]);
                            break;
                        case byte s when s == icc14:
                            ReadIcc14Config(message[5], message[6]);
                            break;
                        case byte s when s == icc15:
                            ReadIcc15Config(message[5], message[6]);
                            break;
                        case byte s when s == icc16:
                            ReadIcc16Config(message[5], message[6]);
                            break;
                        case byte s when s == icc17:
                            ReadIcc17Config(message[5], message[6]);
                            break;
                        case byte s when s == icc18:
                            ReadIcc18Config(message[5], message[6]);
                            break;
                        case byte s when s == icc19:
                            ReadIcc19Config(message[5], message[6]);
                            break;
                        case byte s when s == icc20:
                            ReadIcc20Config(message[5], message[6]);
                            break;
                        case byte s when s == icc21:
                            ReadIcc21Config(message[5], message[6]);
                            break;
                        default:
                            _homePage.ConfigButton = new SolidColorBrush(Colors.Red);
                            break;
                    }

                    // Track CONFIG_RESPONSE processing for initial scan
                    if (_initialScanComplete && _processedConfigResponses < _expectedConfigResponses)
                    {
                        _processedConfigResponses++;
                        if (_processedConfigResponses == _expectedConfigResponses)
                        {
                            // All CONFIG_RESPONSE messages processed, start sequential flash
                            CheckAndStartSequentialFlash();
                        }
                    }
                    break;
                case byte n when n == ACK: // 0x78
                    _homePage.LogText += "ACKNOWLEDGEMENT RECEIVED for ICC" + sourceString + " (Message ID: 0x78)\n";
                    
                    switch (source)
                    {
                        case byte s when s == icc1:
                            // Change the color of the menu item of the ICC
                            Icc1SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc1PgBackground = new SolidColorBrush(Colors.LightGreen);
                            // Receive configuration (switch) data and update the GUI of the LVICC page
                            if (!icc1Connected)
                            {
                                // increment the counter
                                flashersConnected++;
                                icc1Connected = true;
                                iccs[0] = true;
                            }
                            
                            icc1Rem = true;
                            break;
                        case byte s when s == icc2:
                            Icc2SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc2PgBackground = new SolidColorBrush(Colors.LightGreen);
                            // if it wasn't connected before, increment the connected flashers counter
                            if (!icc2Connected)
                            {
                                flashersConnected++;
                                icc2Connected = true;
                                iccs[1] = true;
                            }
                            
                            icc2Rem = true;
                            break;
                        case byte s when s == icc3:
                            Icc3SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc3PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc3Connected)
                            {
                                flashersConnected++;
                                icc3Connected = true;
                                iccs[2] = true;
                            }
                            
                            icc3Rem = true;
                            break;
                        case byte s when s == icc4:
                            Icc4SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc4PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc4Connected)
                            {
                                flashersConnected++;
                                icc4Connected = true;
                                iccs[3] = true;
                            }

                            icc4Rem = true;
                            break;
                        case byte s when s == icc5:
                            Icc5SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc5PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc5Connected)
                            {
                                flashersConnected++;
                                icc5Connected = true;
                                iccs[4] = true;
                            }
                            
                            icc5Rem = true;
                            break;
                        case byte s when s == icc6:
                            Icc6SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc6PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc6Connected)
                            {
                                flashersConnected++;
                                icc6Connected = true;
                                iccs[5] = true;
                            }

                            icc6Rem = true;
                            break;
                        case byte s when s == icc7:
                            Icc7SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc7PgBackground = new SolidColorBrush(Colors.LightGreen);

                            if (!icc7Connected)
                            {
                                flashersConnected++;
                                icc7Connected = true;
                                iccs[6] = true;
                            }

                            icc7Rem = true;
                            break;
                        case byte s when s == icc8:
                            Icc8SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc8PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc8Connected)
                            {
                                flashersConnected++;
                                icc8Connected = true;
                                iccs[7] = true;
                            }

                            icc8Rem = true;
                            break;
                        case byte s when s == icc9:
                            Icc9SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc9PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc9Connected)
                            {
                                flashersConnected++;
                                icc9Connected = true;
                                iccs[8] = true;
                            }

                            icc9Rem = true;
                            break;
                        case byte s when s == icc10:
                            Icc10SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc10PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc10Connected)
                            {
                                flashersConnected++;
                                icc10Connected = true;
                                iccs[9] = true;
                            }
                            
                            icc10Rem = true;
                            break;
                        case byte s when s == icc11:
                            Icc11SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc11PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc11Connected)
                            {
                                flashersConnected++;
                                icc11Connected = true;
                                iccs[10] = true;
                            }

                            icc11Rem = true;
                            break;
                        case byte s when s == icc12:
                            Icc12SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc12PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc12Connected)
                            {
                                flashersConnected++;
                                icc12Connected = true;
                                iccs[11] = true;
                            }

                            icc12Rem = true;
                            break;
                        case byte s when s == icc13:
                            Icc13SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc13PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc13Connected)
                            {
                                flashersConnected++;
                                icc13Connected = true;
                                iccs[12] = true;
                            }
                            
                            icc13Rem = true;
                            break;
                        case byte s when s == icc14:
                            Icc14SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc14PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc14Connected)
                            {
                                flashersConnected++;
                                icc14Connected = true;
                                iccs[13] = true;
                            }
                            
                            icc14Rem = true;
                            break;
                        case byte s when s == icc15:
                            Icc15SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc15PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc15Connected)
                            {
                                flashersConnected++;
                                icc15Connected = true;
                                iccs[14] = true;
                            }

                            icc15Rem = true;
                            break;
                        case byte s when s == icc16:
                            Icc16SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc16PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc16Connected)
                            {
                                flashersConnected++;
                                icc16Connected = true;
                                iccs[15] = true;
                            }
                            
                            icc16Rem = true;
                            break;
                        case byte s when s == icc17:
                            Icc17SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc17PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc17Connected)
                            {
                                flashersConnected++;
                                icc17Connected = true;
                                iccs[16] = true;
                            }
                            
                            icc17Rem = true;
                            break;
                        case byte s when s == icc18:
                            Icc18SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc18PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc18Connected)
                            {
                                flashersConnected++;
                                icc18Connected = true;
                                iccs[17] = true;
                            }
                            
                            icc18Rem = true;
                            break;
                        case byte s when s == icc19:
                            Icc19SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc19PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc19Connected)
                            {
                                flashersConnected++;
                                icc19Connected = true;
                                iccs[18] = true;
                            }
                            
                            icc19Rem = true;
                            break;
                        case byte s when s == icc20:
                            Icc20SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc20PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc20Connected)
                            {
                                flashersConnected++;
                                icc20Connected = true;
                                iccs[19] = true;
                            }
                            
                            icc20Rem = true;
                            break;
                        case byte s when s == icc21:
                            Icc21SideBackground = new SolidColorBrush(Colors.LightGreen);
                            _homePage.Lvicc21PgBackground = new SolidColorBrush(Colors.LightGreen);
                            if (!icc21Connected)
                            {
                                flashersConnected++;
                                icc21Connected = true;
                                iccs[20] = true;
                            }

                            icc21Rem = true;
                            break;
                        default:
                            _homePage.LogText += "ERROR: ACKNOWLEDGEMENT RECEIVED for unknown ICC address\n";
                            break;
                    }

                    SendConfigDataRequest(source);

                    break;
                default:
                    _homePage.LogText += $"Unknown Message ID: 0x{messageID:X2}\n";
                    break;
            }
        }
        catch (Exception e)
        {
            _homePage.LogText += $"Error processing message: {e.Message}\n";
        }
    }
    
    private void ReadIcc1Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc1On)
            {
                icc1MessageData = (byte)(icc1MessageData ^ fOnByte ^ fOffByte);
                icc1On = true;

                Icc1BorderBrush = new SolidColorBrush(Colors.Green);
                Icc1BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc1PgBackground = new SolidColorBrush(Colors.LightGreen);
                _icc1Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc1Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc1On)
            {
                icc1MessageData = (byte)(icc1MessageData ^ fOnByte ^ fOffByte);
                icc1On = false;

                Icc1BorderBrush = new SolidColorBrush(Colors.Black);
                Icc1BorderBackground = new SolidColorBrush(Colors.Black);
                Icc1SideMenu = "OFF";
                _icc1Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc1Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc1Low)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fLowByte);
                    icc1Low = false;
                    _icc1Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc1Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc1Med)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fMedByte);
                    icc1Med = false;
                    _icc1Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc1Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc1High)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fHighByte);
                    icc1High = false;
                    _icc1Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc1Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc1Low)
            {
                icc1MessageData = (byte)(icc1MessageData ^ fLowByte);
                icc1Low = true;

                Icc1BorderBrush = new SolidColorBrush(Colors.Green);
                Icc1BorderBackground = new SolidColorBrush(Colors.Green);
                Icc1SideMenu = "LOW";
                _icc1Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc1Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc1Med)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fMedByte);
                    icc1Med = false;
                    _icc1Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc1Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc1High)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fHighByte);
                    icc1High = false;
                    _icc1Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc1Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc1Med)
            {
                icc1MessageData = (byte)(icc1MessageData ^ fMedByte);
                icc1Med = true;

                Icc1BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc1BorderBackground = new SolidColorBrush(Colors.Orange);
                Icc1SideMenu = "MED";
                _icc1Page.MedButton = new SolidColorBrush(Colors.Green); 
                _icc1Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc1Low)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fLowByte);
                    icc1Low = false;
                    _icc1Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc1Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc1High)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fHighByte);
                    icc1High = false;
                    _icc1Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc1Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }

            
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc1High)
            {
                icc1MessageData = (byte)(icc1MessageData ^ fHighByte);
                icc1High = true;

                Icc1BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc1BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                Icc1SideMenu = "HIGH";
                _icc1Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc1Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc1Low)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fLowByte);
                    icc1Low = false;
                    _icc1Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc1Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc1Med)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fMedByte);
                    icc1Med = false;
                    _icc1Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc1Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }   
        }
        
        if(cmMessageData != icc1MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc1MessageData, "ICC1");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 1 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc1Page.IsCommandErrorVisible = true;
            _homePage.Lvicc1PgStatus = true;
        }else
        {
            _icc1Page.IsCommandErrorVisible = false;
            _homePage.Lvicc1PgStatus = false;
        }
    }

    private void ReadIcc2Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc2On)
            {
                icc2MessageData = (byte)(icc2MessageData ^ fOnByte ^ fOffByte);
                icc2On = true;

                Icc2BorderBrush = new SolidColorBrush(Colors.Green);
                Icc2BorderBackground = new SolidColorBrush(Colors.Green);
                _icc2Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc2Page.OffForeground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc2PgBackground = new SolidColorBrush(Colors.LightGreen);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc2On)
            {
                icc2MessageData = (byte)(icc2MessageData ^ fOnByte ^ fOffByte);
                icc2On = false;
                Icc2SideMenu = "OFF";

                Icc2BorderBrush = new SolidColorBrush(Colors.Black);
                Icc2BorderBackground = new SolidColorBrush(Colors.Black);
                _icc2Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc2Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc2Low)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fLowByte);
                    icc2Low = false;
                    _icc2Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc2Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc2Med)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fMedByte);
                    icc2Med = false;
                    _icc2Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc2Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc2High)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fHighByte);
                    icc2High = false;
                    _icc2Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc2Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc2Low)
            {
                icc2MessageData = (byte)(icc2MessageData ^ fLowByte);
                icc2Low = true;
                Icc2SideMenu = "LOW";

                Icc2BorderBrush = new SolidColorBrush(Colors.Green);
                Icc2BorderBackground = new SolidColorBrush(Colors.Green);
                _icc2Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc2Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc2Med)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fMedByte);
                    icc2Med = false;
                    _icc2Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc2Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc2High)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fHighByte);
                    icc2High = false;
                    _icc2Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc2Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc2Med)
            {
                icc2MessageData = (byte)(icc2MessageData ^ fMedByte);
                icc2Med = true;
                Icc2SideMenu = "MED";

                Icc2BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc2BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc2Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc2Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc2Low)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fLowByte);
                    icc2Low = false;
                    _icc2Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc2Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc2High)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fHighByte);
                    icc2High = false;
                    _icc2Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc2Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc2High)
            {
                icc2MessageData = (byte)(icc2MessageData ^ fHighByte);
                icc2High = true;
                Icc2SideMenu = "HIGH";

                Icc2BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc2BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc2Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc2Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc2Low)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fLowByte);
                    icc2Low = false;
                    _icc2Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc2Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc2Med)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fMedByte);
                    icc2Med = false;
                    _icc2Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc2Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if (cmMessageData != icc2MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc2MessageData, "ICC2");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 2 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc2Page.IsCommandErrorVisible = true;
            _homePage.Lvicc2PgStatus = true;
        }
        else
        {
            _icc2Page.IsCommandErrorVisible = false;
            _homePage.Lvicc2PgStatus = false;
        }
    }

    private void ReadIcc3Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc3On)
            {
                icc3MessageData = (byte)(icc3MessageData ^ fOnByte ^ fOffByte);
                icc3On = true;

                Icc3BorderBrush = new SolidColorBrush(Colors.Green);
                Icc3BorderBackground = new SolidColorBrush(Colors.Green);
                _icc3Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc3Page.OffForeground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc3PgBackground = new SolidColorBrush(Colors.LightGreen);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc3On)
            {
                icc3MessageData = (byte)(icc3MessageData ^ fOnByte ^ fOffByte);
                icc3On = false;
                Icc3SideMenu = "OFF";

                Icc3BorderBrush = new SolidColorBrush(Colors.Black);
                Icc3BorderBackground = new SolidColorBrush(Colors.Black);
                _icc3Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc3Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc3Low)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fLowByte);
                    icc3Low = false;
                    _icc3Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc3Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc3Med)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fMedByte);
                    icc3Med = false;
                    _icc3Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc3Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc3High)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fHighByte);
                    icc3High = false;
                    _icc3Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc3Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc3Low)
            {
                icc3MessageData = (byte)(icc3MessageData ^ fLowByte);
                icc3Low = true;
                Icc3SideMenu = "LOW";

                Icc3BorderBrush = new SolidColorBrush(Colors.Green);
                Icc3BorderBackground = new SolidColorBrush(Colors.Green);
                _icc3Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc3Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc3Med)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fMedByte);
                    icc3Med = false;
                    _icc3Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc3Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc3High)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fHighByte);
                    icc3High = false;
                    _icc3Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc3Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }


        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc3Med)
            {
                icc3MessageData = (byte)(icc3MessageData ^ fMedByte);
                icc3Med = true;
                Icc3SideMenu = "MED";

                Icc3BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc3BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc3Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc3Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc3Low)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fLowByte);
                    icc3Low = false;
                    _icc3Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc3Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc3High)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fHighByte);
                    icc3High = false;
                    _icc3Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc3Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc3High)
            {
                icc3MessageData = (byte)(icc3MessageData ^ fHighByte);
                icc3High = true;
                Icc3SideMenu = "HIGH";

                Icc3BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc3BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc3Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc3Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc3Low)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fLowByte);
                    icc3Low = false;
                    _icc3Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc3Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc3Med)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fMedByte);
                    icc3Med = false;
                    _icc3Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc3Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }


        }
        if (cmMessageData != icc3MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc3MessageData, "ICC3");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 3 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc3Page.IsCommandErrorVisible = true;
            _homePage.Lvicc3PgStatus = true;
        }
        else
        {
            _icc3Page.IsCommandErrorVisible = false;
            _homePage.Lvicc3PgStatus = false;
        }
    }

    private void ReadIcc4Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc4On)
            {
                icc4MessageData = (byte)(icc4MessageData ^ fOnByte ^ fOffByte);
                icc4On = true;

                Icc4BorderBrush = new SolidColorBrush(Colors.Green);
                Icc4BorderBackground = new SolidColorBrush(Colors.Green);
                _icc4Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc4Page.OffForeground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc4PgBackground = new SolidColorBrush(Colors.LightGreen);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc4On)
            {
                icc4MessageData = (byte)(icc4MessageData ^ fOnByte ^ fOffByte);
                icc4On = false;
                Icc4SideMenu = "OFF";

                Icc4BorderBrush = new SolidColorBrush(Colors.Black);
                Icc4BorderBackground = new SolidColorBrush(Colors.Black);
                _icc4Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc4Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc4Low)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fLowByte);
                    icc4Low = false;
                    _icc4Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc4Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc4Med)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fMedByte);
                    icc4Med = false;
                    _icc4Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc4Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc4High)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fHighByte);
                    icc4High = false;
                    _icc4Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc4Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc4Low)
            {
                icc4MessageData = (byte)(icc4MessageData ^ fLowByte);
                icc4Low = true;
                Icc4SideMenu = "LOW";

                Icc4BorderBrush = new SolidColorBrush(Colors.Green);
                Icc4BorderBackground = new SolidColorBrush(Colors.Green);
                _icc4Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc4Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc4Med)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fMedByte);
                    icc4Med = false;
                    _icc4Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc4Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc4High)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fHighByte);
                    icc4High = false;
                    _icc4Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc4Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc4Med)
            {
                icc4MessageData = (byte)(icc4MessageData ^ fMedByte);
                icc4Med = true;
                Icc4SideMenu = "MED";

                Icc4BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc4BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc4Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc4Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc4Low)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fLowByte);
                    icc4Low = false;
                    _icc4Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc4Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc4High)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fHighByte);
                    icc4High = false;
                    _icc4Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc4Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc4High)
            {
                icc4MessageData = (byte)(icc4MessageData ^ fHighByte);
                icc4High = true;
                Icc4SideMenu = "HIGH";

                Icc4BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc4BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc4Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc4Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc4Low)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fLowByte);
                    icc4Low = false;
                    _icc4Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc4Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc4Med)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fMedByte);
                    icc4Med = false;
                    _icc4Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc4Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if (cmMessageData != icc4MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc4MessageData, "ICC4");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 4 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc4Page.IsCommandErrorVisible = true;
            _homePage.Lvicc4PgStatus = true;
        }
        else
        {
            _icc4Page.IsCommandErrorVisible = false;
            _homePage.Lvicc4PgStatus = false;
        }
    }

    private void ReadIcc5Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc5On)
            {
                icc5MessageData = (byte)(icc5MessageData ^ fOnByte ^ fOffByte);
                icc5On = true;

                Icc5BorderBrush = new SolidColorBrush(Colors.Green);
                Icc5BorderBackground = new SolidColorBrush(Colors.Green);
                _icc5Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc5Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc5On)
            {
                icc5MessageData = (byte)(icc5MessageData ^ fOnByte ^ fOffByte);
                icc5On = false;
                Icc5SideMenu = "OFF";

                Icc5BorderBrush = new SolidColorBrush(Colors.Black);
                Icc5BorderBackground = new SolidColorBrush(Colors.Black);
                _icc5Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc5Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc5Low)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fLowByte);
                    icc5Low = false;
                    _icc5Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc5Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc5Med)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fMedByte);
                    icc5Med = false;
                    _icc5Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc5Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc5High)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fHighByte);
                    icc5High = false;
                    _icc5Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc5Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc5Low)
            {
                icc5MessageData = (byte)(icc5MessageData ^ fLowByte);
                icc5Low = true;
                Icc5SideMenu = "LOW";

                Icc5BorderBrush = new SolidColorBrush(Colors.Green);
                Icc5BorderBackground = new SolidColorBrush(Colors.Green);
                _icc5Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc5Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc5Med)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fMedByte);
                    icc5Med = false;
                    _icc5Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc5Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc5High)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fHighByte);
                    icc5High = false;
                    _icc5Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc5Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc5Med)
            {
                icc5MessageData = (byte)(icc5MessageData ^ fMedByte);
                icc5Med = true;
                Icc5SideMenu = "MED";

                Icc5BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc5BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc5Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc5Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc5Low)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fLowByte);
                    icc5Low = false;
                    _icc5Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc5Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc5High)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fHighByte);
                    icc5High = false;
                    _icc5Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc5Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc5High)
            {
                icc5MessageData = (byte)(icc5MessageData ^ fHighByte);
                icc5High = true;
                Icc5SideMenu = "HIGH";

                Icc5BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc5BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc5Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc5Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc5Low)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fLowByte);
                    icc5Low = false;
                    _icc5Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc5Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc5Med)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fMedByte);
                    icc5Med = false;
                    _icc5Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc5Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if (cmMessageData != icc5MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc5MessageData, "ICC5");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 5 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc5Page.IsCommandErrorVisible = true;
            _homePage.Lvicc5PgStatus = true;
        }
        else
        {
            _icc5Page.IsCommandErrorVisible = false;
            _homePage.Lvicc5PgStatus = false;
        }
    }

    private void ReadIcc6Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc6On)
            {
                icc6MessageData = (byte)(icc6MessageData ^ fOnByte ^ fOffByte);
                icc6On = true;

                Icc6BorderBrush = new SolidColorBrush(Colors.Green);
                Icc6BorderBackground = new SolidColorBrush(Colors.Green);
                _icc6Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc6Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc6On)
            {
                icc6MessageData = (byte)(icc6MessageData ^ fOnByte ^ fOffByte);
                icc6On = false;
                Icc6SideMenu = "OFF";

                Icc6BorderBrush = new SolidColorBrush(Colors.Black);
                Icc6BorderBackground = new SolidColorBrush(Colors.Black);
                _icc6Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc6Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc6Low)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fLowByte);
                    icc6Low = false;
                    _icc6Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc6Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc6Med)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fMedByte);
                    icc6Med = false;
                    _icc6Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc6Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc6High)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fHighByte);
                    icc6High = false;
                    _icc6Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc6Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc6Low)
            {
                icc6MessageData = (byte)(icc6MessageData ^ fLowByte);
                icc6Low = true;
                Icc6SideMenu = "LOW";

                Icc6BorderBrush = new SolidColorBrush(Colors.Green);
                Icc6BorderBackground = new SolidColorBrush(Colors.Green);
                _icc6Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc6Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc6Med)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fMedByte);
                    icc6Med = false;
                    _icc6Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc6Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc6High)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fHighByte);
                    icc6High = false;
                    _icc6Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc6Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc6Med)
            {
                icc6MessageData = (byte)(icc6MessageData ^ fMedByte);
                icc6Med = true;
                Icc6SideMenu = "MED";

                Icc6BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc6BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc6Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc6Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc6Low)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fLowByte);
                    icc6Low = false;
                    _icc6Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc6Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc6High)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fHighByte);
                    icc6High = false;
                    _icc6Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc6Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc6High)
            {
                icc6MessageData = (byte)(icc6MessageData ^ fHighByte);
                icc6High = true;
                Icc6SideMenu = "HIGH";

                Icc6BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc6BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc6Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc6Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc6Low)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fLowByte);
                    icc6Low = false;
                    _icc6Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc6Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc6Med)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fMedByte);
                    icc6Med = false;
                    _icc6Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc6Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if (cmMessageData != icc6MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc6MessageData, "ICC6");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 6 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc6Page.IsCommandErrorVisible = true;
            _homePage.Lvicc6PgStatus = true;
        }
        else
        {
            _icc6Page.IsCommandErrorVisible = false;
            _homePage.Lvicc6PgStatus = false;
        }
        
    }

    private void ReadIcc7Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc7On)
            {
                icc7MessageData = (byte)(icc7MessageData ^ fOnByte ^ fOffByte);
                icc7On = true;

                Icc7BorderBrush = new SolidColorBrush(Colors.Green);
                Icc7BorderBackground = new SolidColorBrush(Colors.Green);
                _icc7Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc7Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc7On)
            {
                icc7MessageData = (byte)(icc7MessageData ^ fOnByte ^ fOffByte);
                icc7On = false;
                Icc7SideMenu = "OFF";

                Icc7BorderBrush = new SolidColorBrush(Colors.Black);
                Icc7BorderBackground = new SolidColorBrush(Colors.Black);
                _icc7Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc7Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc7Low)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fLowByte);
                    icc7Low = false;
                    _icc7Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc7Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc7Med)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fMedByte);
                    icc7Med = false;
                    _icc7Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc7Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc7High)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fHighByte);
                    icc7High = false;
                    _icc7Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc7Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc7Low)
            {
                icc7MessageData = (byte)(icc7MessageData ^ fLowByte);
                icc7Low = true;
                Icc7SideMenu = "LOW";

                Icc7BorderBrush = new SolidColorBrush(Colors.Green);
                Icc7BorderBackground = new SolidColorBrush(Colors.Green);
                _icc7Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc7Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc7Med)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fMedByte);
                    icc7Med = false;
                    _icc7Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc7Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc7High)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fHighByte);
                    icc7High = false;
                    _icc7Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc7Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc7Med)
            {
                icc7MessageData = (byte)(icc7MessageData ^ fMedByte);
                icc7Med = true;
                Icc7SideMenu = "MED";

                Icc7BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc7BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc7Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc7Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc7Low)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fLowByte);
                    icc7Low = false;
                    _icc7Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc7Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc7High)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fHighByte);
                    icc7High = false;
                    _icc7Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc7Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc7High)
            {
                icc7MessageData = (byte)(icc7MessageData ^ fHighByte);
                icc7High = true;
                Icc7SideMenu = "HIGH";

                Icc7BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc7BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc7Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc7Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc7Low)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fLowByte);
                    icc7Low = false;
                    _icc7Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc7Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc7Med)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fMedByte);
                    icc7Med = false;
                    _icc7Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc7Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if (cmMessageData != icc7MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc7MessageData, "ICC7");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 7 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc7Page.IsCommandErrorVisible = true;
            _homePage.Lvicc7PgStatus = true;
        }
        else
        {
            _icc7Page.IsCommandErrorVisible = false;
            _homePage.Lvicc7PgStatus = false;
        }
    }

    private void ReadIcc8Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc8On)
            {
                icc8MessageData = (byte)(icc8MessageData ^ fOnByte ^ fOffByte);
                icc8On = true;

                Icc8BorderBrush = new SolidColorBrush(Colors.Green);
                Icc8BorderBackground = new SolidColorBrush(Colors.Green);
                _icc8Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc8Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc8On)
            {
                icc8MessageData = (byte)(icc8MessageData ^ fOnByte ^ fOffByte);
                icc8On = false;
                Icc8SideMenu = "OFF";

                Icc8BorderBrush = new SolidColorBrush(Colors.Black);
                Icc8BorderBackground = new SolidColorBrush(Colors.Black);
                _icc8Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc8Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc8Low)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fLowByte);
                    icc8Low = false;
                    _icc8Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc8Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc8Med)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fMedByte);
                    icc8Med = false;
                    _icc8Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc8Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc8High)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fHighByte);
                    icc8High = false;
                    _icc8Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc8Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc8Low)
            {
                icc8MessageData = (byte)(icc8MessageData ^ fLowByte);
                icc8Low = true;
                Icc8SideMenu = "LOW";

                Icc8BorderBrush = new SolidColorBrush(Colors.Green);
                Icc8BorderBackground = new SolidColorBrush(Colors.Green);
                _icc8Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc8Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc8Med)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fMedByte);
                    icc8Med = false;
                    _icc8Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc8Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc8High)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fHighByte);
                    icc8High = false;
                    _icc8Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc8Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc8Med)
            {
                icc8MessageData = (byte)(icc8MessageData ^ fMedByte);
                icc8Med = true;
                Icc8SideMenu = "MED";

                Icc8BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc8BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc8Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc8Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc8Low)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fLowByte);
                    icc8Low = false;
                    _icc8Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc8Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc8High)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fHighByte);
                    icc8High = false;
                    _icc8Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc8Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc8High)
            {
                icc8MessageData = (byte)(icc8MessageData ^ fHighByte);
                icc8High = true;
                Icc8SideMenu = "HIGH";

                Icc8BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc8BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc8Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc8Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc8Low)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fLowByte);
                    icc8Low = false;
                    _icc8Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc8Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc8Med)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fMedByte);
                    icc8Med = false;
                    _icc8Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc8Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if (cmMessageData != icc8MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc8MessageData, "ICC8");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 8 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc8Page.IsCommandErrorVisible = true;
            _homePage.Lvicc8PgStatus = true;
        }
        else
        {
            _icc8Page.IsCommandErrorVisible = false;
            _homePage.Lvicc8PgStatus = false;
        }
    }

    private void ReadIcc9Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc9On)
            {
                icc9MessageData = (byte)(icc9MessageData ^ fOnByte ^ fOffByte);
                icc9On = true;

                Icc9BorderBrush = new SolidColorBrush(Colors.Green);
                Icc9BorderBackground = new SolidColorBrush(Colors.Green);
                _icc9Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc9Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc9On)
            {
                icc9MessageData = (byte)(icc9MessageData ^ fOnByte ^ fOffByte);
                icc9On = false;
                Icc9SideMenu = "OFF";

                Icc9BorderBrush = new SolidColorBrush(Colors.Black);
                Icc9BorderBackground = new SolidColorBrush(Colors.Black);
                _icc9Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc9Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc9Low)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fLowByte);
                    icc9Low = false;
                    _icc9Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc9Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc9Med)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fMedByte);
                    icc9Med = false;
                    _icc9Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc9Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc9High)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fHighByte);
                    icc9High = false;
                    _icc9Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc9Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc9Low)
            {
                icc9MessageData = (byte)(icc9MessageData ^ fLowByte);
                icc9Low = true;
                Icc9SideMenu = "LOW";

                Icc9BorderBrush = new SolidColorBrush(Colors.Green);
                Icc9BorderBackground = new SolidColorBrush(Colors.Green);
                _icc9Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc9Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc9Med)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fMedByte);
                    icc9Med = false;
                    _icc9Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc9Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc9High)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fHighByte);
                    icc9High = false;
                    _icc9Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc9Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc9Med)
            {
                icc9MessageData = (byte)(icc9MessageData ^ fMedByte);
                icc9Med = true;
                Icc9SideMenu = "MED";

                Icc9BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc9BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc9Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc9Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc9Low)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fLowByte);
                    icc9Low = false;
                    _icc9Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc9Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc9High)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fHighByte);
                    icc9High = false;
                    _icc9Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc9Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc9High)
            {
                icc9MessageData = (byte)(icc9MessageData ^ fHighByte);
                icc9High = true;
                Icc9SideMenu = "HIGH";

                Icc9BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc9BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc9Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc9Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc9Low)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fLowByte);
                    icc9Low = false;
                    _icc9Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc9Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc9Med)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fMedByte);
                    icc9Med = false;
                    _icc9Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc9Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if (cmMessageData != icc9MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc9MessageData, "ICC9");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 9 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc9Page.IsCommandErrorVisible = true;
            _homePage.Lvicc9PgStatus = true;
        }
        else
        {
            _icc9Page.IsCommandErrorVisible = false;
            _homePage.Lvicc9PgStatus = false;
        }
    }

    private void ReadIcc10Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc10On)
            {
                icc10MessageData = (byte)(icc10MessageData ^ fOnByte ^ fOffByte);
                icc10On = true;

                Icc10BorderBrush = new SolidColorBrush(Colors.Green);
                Icc10BorderBackground = new SolidColorBrush(Colors.Green);
                _icc10Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc10Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc10On)
            {
                icc10MessageData = (byte)(icc10MessageData ^ fOnByte ^ fOffByte);
                icc10On = false;
                Icc10SideMenu = "OFF";

                Icc10BorderBrush = new SolidColorBrush(Colors.Black);
                Icc10BorderBackground = new SolidColorBrush(Colors.Black);
                _icc10Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc10Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc10Low)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fLowByte);
                    icc10Low = false;
                    _icc10Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc10Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc10Med)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fMedByte);
                    icc10Med = false;
                    _icc10Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc10Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc10High)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fHighByte);
                    icc10High = false;
                    _icc10Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc10Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc10Low)
            {
                icc10MessageData = (byte)(icc10MessageData ^ fLowByte);
                icc10Low = true;
                Icc10SideMenu = "LOW";

                Icc10BorderBrush = new SolidColorBrush(Colors.Green);
                Icc10BorderBackground = new SolidColorBrush(Colors.Green);
                _icc10Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc10Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc10Med)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fMedByte);
                    icc10Med = false;
                    _icc10Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc10Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc10High)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fHighByte);
                    icc10High = false;
                    _icc10Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc10Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc10Med)
            {
                icc10MessageData = (byte)(icc10MessageData ^ fMedByte);
                icc10Med = true;
                Icc10SideMenu = "MED";

                Icc10BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc10BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc10Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc10Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc10Low)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fLowByte);
                    icc10Low = false;
                    _icc10Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc10Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc10High)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fHighByte);
                    icc10High = false;
                    _icc10Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc10Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc10High)
            {
                icc10MessageData = (byte)(icc10MessageData ^ fHighByte);
                icc10High = true;
                Icc10SideMenu = "HIGH";

                Icc10BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc10BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc10Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc10Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc10Low)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fLowByte);
                    icc10Low = false;
                    _icc10Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc10Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc10Med)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fMedByte);
                    icc10Med = false;
                    _icc10Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc10Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if (cmMessageData != icc10MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc10MessageData, "ICC10");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 10 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc10Page.IsCommandErrorVisible = true;
            _homePage.Lvicc10PgStatus = true;
        }
        else
        {
            _icc10Page.IsCommandErrorVisible = false;
            _homePage.Lvicc10PgStatus = false;
        }
    }

    private void ReadIcc11Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc11On)
            {
                icc11MessageData = (byte)(icc11MessageData ^ fOnByte ^ fOffByte);
                icc11On = true;

                Icc11BorderBrush = new SolidColorBrush(Colors.Green);
                Icc11BorderBackground = new SolidColorBrush(Colors.Green);
                _icc11Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc11Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc11On)
            {
                icc11MessageData = (byte)(icc11MessageData ^ fOnByte ^ fOffByte);
                icc11On = false;
                Icc11SideMenu = "OFF";

                Icc11BorderBrush = new SolidColorBrush(Colors.Black);
                Icc11BorderBackground = new SolidColorBrush(Colors.Black);
                _icc11Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc11Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc11Low)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fLowByte);
                    icc11Low = false;
                    _icc11Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc11Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc11Med)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fMedByte);
                    icc11Med = false;
                    _icc11Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc11Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc11High)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fHighByte);
                    icc11High = false;
                    _icc11Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc11Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc11Low)
            {
                icc11MessageData = (byte)(icc11MessageData ^ fLowByte);
                icc11Low = true;
                Icc11SideMenu = "LOW";

                Icc11BorderBrush = new SolidColorBrush(Colors.Green);
                Icc11BorderBackground = new SolidColorBrush(Colors.Green);
                _icc11Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc11Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc11Med)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fMedByte);
                    icc11Med = false;
                    _icc11Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc11Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc11High)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fHighByte);
                    icc11High = false;
                    _icc11Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc11Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc11Med)
            {
                icc11MessageData = (byte)(icc11MessageData ^ fMedByte);
                icc11Med = true;
                Icc11SideMenu = "MED";

                Icc11BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc11BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc11Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc11Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc11Low)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fLowByte);
                    icc11Low = false;
                    _icc11Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc11Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc11High)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fHighByte);
                    icc11High = false;
                    _icc11Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc11Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc11High)
            {
                icc11MessageData = (byte)(icc11MessageData ^ fHighByte);
                icc11High = true;
                Icc11SideMenu = "HIGH";

                Icc11BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc11BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc11Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc11Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc11Low)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fLowByte);
                    icc11Low = false;
                    _icc11Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc11Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc11Med)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fMedByte);
                    icc11Med = false;
                    _icc11Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc11Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }

        if (cmMessageData != icc11MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc11MessageData, "ICC11");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 11 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc11Page.IsCommandErrorVisible = true;
            _homePage.Lvicc11PgStatus = true;
        }
        else
        {
            _icc11Page.IsCommandErrorVisible = false;
            _homePage.Lvicc11PgStatus = false;
        }
    }

    private void ReadIcc12Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc12On)
            {
                icc12MessageData = (byte)(icc12MessageData ^ fOnByte ^ fOffByte);
                icc12On = true;

                Icc12BorderBrush = new SolidColorBrush(Colors.Green);
                Icc12BorderBackground = new SolidColorBrush(Colors.Green);
                _icc12Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc12Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc12On)
            {
                icc12MessageData = (byte)(icc12MessageData ^ fOnByte ^ fOffByte);
                icc12On = false;
                Icc12SideMenu = "OFF";

                Icc12BorderBrush = new SolidColorBrush(Colors.Black);
                Icc12BorderBackground = new SolidColorBrush(Colors.Black);
                _icc12Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc12Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc12Low)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fLowByte);
                    icc12Low = false;
                    _icc12Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc12Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc12Med)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fMedByte);
                    icc12Med = false;
                    _icc12Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc12Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc12High)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fHighByte);
                    icc12High = false;
                    _icc12Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc12Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc12Low)
            {
                icc12MessageData = (byte)(icc12MessageData ^ fLowByte);
                icc12Low = true;
                Icc12SideMenu = "LOW";

                Icc12BorderBrush = new SolidColorBrush(Colors.Green);
                Icc12BorderBackground = new SolidColorBrush(Colors.Green);
                _icc12Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc12Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc12Med)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fMedByte);
                    icc12Med = false;
                    _icc12Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc12Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc12High)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fHighByte);
                    icc12High = false;
                    _icc12Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc12Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc12Med)
            {
                icc12MessageData = (byte)(icc12MessageData ^ fMedByte);
                icc12Med = true;
                Icc12SideMenu = "MED";

                Icc12BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc12BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc12Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc12Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc12Low)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fLowByte);
                    icc12Low = false;
                    _icc12Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc12Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc12High)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fHighByte);
                    icc12High = false;
                    _icc12Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc12Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc12High)
            {
                icc12MessageData = (byte)(icc12MessageData ^ fHighByte);
                icc12High = true;
                Icc12SideMenu = "HIGH";

                Icc12BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc12BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc12Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc12Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc12Low)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fLowByte);
                    icc12Low = false;
                    _icc12Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc12Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc12Med)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fMedByte);
                    icc12Med = false;
                    _icc12Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc12Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }

        if (cmMessageData != icc12MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc12MessageData, "ICC12");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 12 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc12Page.IsCommandErrorVisible = true;
            _homePage.Lvicc12PgStatus = true;
        }
        else
        {
            _icc12Page.IsCommandErrorVisible = false;
            _homePage.Lvicc12PgStatus = false;
        }
    }

    private void ReadIcc13Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc13On)
            {
                icc13MessageData = (byte)(icc13MessageData ^ fOnByte ^ fOffByte);
                icc13On = true;

                Icc13BorderBrush = new SolidColorBrush(Colors.Green);
                Icc13BorderBackground = new SolidColorBrush(Colors.Green);
                _icc13Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc13Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc13On)
            {
                icc13MessageData = (byte)(icc13MessageData ^ fOnByte ^ fOffByte);
                icc13On = false;
                Icc13SideMenu = "OFF";

                Icc13BorderBrush = new SolidColorBrush(Colors.Black);
                Icc13BorderBackground = new SolidColorBrush(Colors.Black);
                _icc13Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc13Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc13Low)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fLowByte);
                    icc13Low = false;
                    _icc13Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc13Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc13Med)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fMedByte);
                    icc13Med = false;
                    _icc13Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc13Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc13High)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fHighByte);
                    icc13High = false;
                    _icc13Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc13Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc13Low)
            {
                icc13MessageData = (byte)(icc13MessageData ^ fLowByte);
                icc13Low = true;
                Icc13SideMenu = "LOW";

                Icc13BorderBrush = new SolidColorBrush(Colors.Green);
                Icc13BorderBackground = new SolidColorBrush(Colors.Green);
                _icc13Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc13Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc13Med)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fMedByte);
                    icc13Med = false;
                    _icc13Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc13Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc13High)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fHighByte);
                    icc13High = false;
                    _icc13Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc13Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc13Med)
            {
                icc13MessageData = (byte)(icc13MessageData ^ fMedByte);
                icc13Med = true;
                Icc13SideMenu = "MED";

                Icc13BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc13BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc13Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc13Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc13Low)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fLowByte);
                    icc13Low = false;
                    _icc13Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc13Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc13High)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fHighByte);
                    icc13High = false;
                    _icc13Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc13Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc13High)
            {
                icc13MessageData = (byte)(icc13MessageData ^ fHighByte);
                icc13High = true;
                Icc13SideMenu = "HIGH";

                Icc13BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc13BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc13Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc13Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc13Low)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fLowByte);
                    icc13Low = false;
                    _icc13Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc13Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc13Med)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fMedByte);
                    icc13Med = false;
                    _icc13Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc13Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }

        if (cmMessageData != icc13MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc13MessageData, "ICC13");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 13 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc13Page.IsCommandErrorVisible = true;
            _homePage.Lvicc13PgStatus = true;
        }
        else
        {
            _icc13Page.IsCommandErrorVisible = false;
            _homePage.Lvicc13PgStatus = false;
        }
    }

    private void ReadIcc14Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc14On)
            {
                icc14MessageData = (byte)(icc14MessageData ^ fOnByte ^ fOffByte);
                icc14On = true;

                Icc14BorderBrush = new SolidColorBrush(Colors.Green);
                Icc14BorderBackground = new SolidColorBrush(Colors.Green);
                _icc14Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc14Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc14On)
            {
                icc14MessageData = (byte)(icc14MessageData ^ fOnByte ^ fOffByte);
                icc14On = false;
                Icc14SideMenu = "OFF";

                Icc14BorderBrush = new SolidColorBrush(Colors.Black);
                Icc14BorderBackground = new SolidColorBrush(Colors.Black);
                _icc14Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc14Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc14Low)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fLowByte);
                    icc14Low = false;
                    _icc14Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc14Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc14Med)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fMedByte);
                    icc14Med = false;
                    _icc14Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc14Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc14High)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fHighByte);
                    icc14High = false;
                    _icc14Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc14Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc14Low)
            {
                icc14MessageData = (byte)(icc14MessageData ^ fLowByte);
                icc14Low = true;
                Icc14SideMenu = "LOW";

                Icc14BorderBrush = new SolidColorBrush(Colors.Green);
                Icc14BorderBackground = new SolidColorBrush(Colors.Green);
                _icc14Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc14Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc14Med)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fMedByte);
                    icc14Med = false;
                    _icc14Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc14Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc14High)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fHighByte);
                    icc14High = false;
                    _icc14Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc14Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc14Med)
            {
                icc14MessageData = (byte)(icc14MessageData ^ fMedByte);
                icc14Med = true;
                Icc14SideMenu = "MED";

                Icc14BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc14BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc14Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc14Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc14Low)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fLowByte);
                    icc14Low = false;
                    _icc14Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc14Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc14High)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fHighByte);
                    icc14High = false;
                    _icc14Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc14Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc14High)
            {
                icc14MessageData = (byte)(icc14MessageData ^ fHighByte);
                icc14High = true;
                Icc14SideMenu = "HIGH";

                Icc14BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc14BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc14Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc14Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc14Low)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fLowByte);
                    icc14Low = false;
                    _icc14Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc14Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc14Med)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fMedByte);
                    icc14Med = false;
                    _icc14Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc14Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }

        if (cmMessageData != icc14MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc14MessageData, "ICC14");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 14 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc14Page.IsCommandErrorVisible = true;
            _homePage.Lvicc14PgStatus = true;
        }
        else
        {
            _icc14Page.IsCommandErrorVisible = false;
            _homePage.Lvicc14PgStatus = false;
        }
    }

    private void ReadIcc15Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc15On)
            {
                icc15MessageData = (byte)(icc15MessageData ^ fOnByte ^ fOffByte);
                icc15On = true;

                Icc15BorderBrush = new SolidColorBrush(Colors.Green);
                Icc15BorderBackground = new SolidColorBrush(Colors.Green);
                _icc15Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc15Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc15On)
            {
                icc15MessageData = (byte)(icc15MessageData ^ fOnByte ^ fOffByte);
                icc15On = false;
                Icc15SideMenu = "OFF";

                Icc15BorderBrush = new SolidColorBrush(Colors.Black);
                Icc15BorderBackground = new SolidColorBrush(Colors.Black);
                _icc15Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc15Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc15Low)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fLowByte);
                    icc15Low = false;
                    _icc15Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc15Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc15Med)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fMedByte);
                    icc15Med = false;
                    _icc15Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc15Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc15High)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fHighByte);
                    icc15High = false;
                    _icc15Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc15Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc15Low)
            {
                icc15MessageData = (byte)(icc15MessageData ^ fLowByte);
                icc15Low = true;
                Icc15SideMenu = "LOW";

                Icc15BorderBrush = new SolidColorBrush(Colors.Green);
                Icc15BorderBackground = new SolidColorBrush(Colors.Green);
                _icc15Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc15Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc15Med)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fMedByte);
                    icc15Med = false;
                    _icc15Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc15Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc15High)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fHighByte);
                    icc15High = false;
                    _icc15Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc15Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc15Med)
            {
                icc15MessageData = (byte)(icc15MessageData ^ fMedByte);
                icc15Med = true;
                Icc15SideMenu = "MED";

                Icc15BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc15BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc15Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc15Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc15Low)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fLowByte);
                    icc15Low = false;
                    _icc15Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc15Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc15High)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fHighByte);
                    icc15High = false;
                    _icc15Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc15Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc15High)
            {
                icc15MessageData = (byte)(icc15MessageData ^ fHighByte);
                icc15High = true;
                Icc15SideMenu = "HIGH";

                Icc15BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc15BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc15Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc15Page.HighForeground = new SolidColorBrush(Colors.White);
                if (icc15Low)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fLowByte);
                    icc15Low = false;
                    _icc15Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc15Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc15Med)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fMedByte);
                    icc15Med = false;
                    _icc15Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc15Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }

        if (cmMessageData != icc15MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc15MessageData, "ICC15");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 15 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc15Page.IsCommandErrorVisible = true;
            _homePage.Lvicc15PgStatus = true;
        }
        else
        {
            _icc15Page.IsCommandErrorVisible = false;
            _homePage.Lvicc15PgStatus = false;
        }
    }

    private void ReadIcc16Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc16On)
            {
                icc16MessageData = (byte)(icc16MessageData ^ fOnByte ^ fOffByte);
                icc16On = true;

                Icc16BorderBrush = new SolidColorBrush(Colors.Green);
                Icc16BorderBackground = new SolidColorBrush(Colors.Green);
                _icc16Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc16Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc16On)
            {
                icc16MessageData = (byte)(icc16MessageData ^ fOnByte ^ fOffByte);
                icc16On = false;
                Icc16SideMenu = "OFF";

                Icc16BorderBrush = new SolidColorBrush(Colors.Black);
                Icc16BorderBackground = new SolidColorBrush(Colors.Black);
                _icc16Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc16Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc16Low)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fLowByte);
                    icc16Low = false;
                    _icc16Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc16Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc16Med)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fMedByte);
                    icc16Med = false;
                    _icc16Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc16Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc16High)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fHighByte);
                    icc16High = false;
                    _icc16Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc16Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc16Low)
            {
                icc16MessageData = (byte)(icc16MessageData ^ fLowByte);
                icc16Low = true;
                Icc16SideMenu = "LOW";

                Icc16BorderBrush = new SolidColorBrush(Colors.Green);
                Icc16BorderBackground = new SolidColorBrush(Colors.Green);
                _icc16Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc16Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc16Med)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fMedByte);
                    icc16Med = false;
                    _icc16Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc16Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc16High)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fHighByte);
                    icc16High = false;
                    _icc16Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc16Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc16Med)
            {
                icc16MessageData = (byte)(icc16MessageData ^ fMedByte);
                icc16Med = true;
                Icc16SideMenu = "MED";

                Icc16BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc16BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc16Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc16Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc16Low)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fLowByte);
                    icc16Low = false;
                    _icc16Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc16Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc16High)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fHighByte);
                    icc16High = false;
                    _icc16Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc16Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc16High)
            {
                icc16MessageData = (byte)(icc16MessageData ^ fHighByte);
                icc16High = true;
                Icc16SideMenu = "HIGH";

                Icc16BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc16BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc16Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc16Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc16Low)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fLowByte);
                    icc16Low = false;
                    _icc16Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc16Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc16Med)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fMedByte);
                    icc16Med = false;
                    _icc16Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc16Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }

        if (cmMessageData != icc16MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc16MessageData, "ICC16");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 16 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc16Page.IsCommandErrorVisible = true;
            _homePage.Lvicc16PgStatus = true;
        }
        else
        {
            _icc16Page.IsCommandErrorVisible = false;
            _homePage.Lvicc16PgStatus = false;
        }
    }

    private void ReadIcc17Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc17On)
            {
                icc17MessageData = (byte)(icc17MessageData ^ fOnByte ^ fOffByte);
                icc17On = true;

                Icc17BorderBrush = new SolidColorBrush(Colors.Green);
                Icc17BorderBackground = new SolidColorBrush(Colors.Green);
                _icc17Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc17Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc17On)
            {
                icc17MessageData = (byte)(icc17MessageData ^ fOnByte ^ fOffByte);
                icc17On = false;
                Icc17SideMenu = "OFF";

                Icc17BorderBrush = new SolidColorBrush(Colors.Black);
                Icc17BorderBackground = new SolidColorBrush(Colors.Black);
                _icc17Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc17Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc17Low)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fLowByte);
                    icc17Low = false;
                    _icc17Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc17Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc17Med)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fMedByte);
                    icc17Med = false;
                    _icc17Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc17Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc17High)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fHighByte);
                    icc17High = false;
                    _icc17Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc17Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc17Low)
            {
                icc17MessageData = (byte)(icc17MessageData ^ fLowByte);
                icc17Low = true;
                Icc17SideMenu = "LOW";

                Icc17BorderBrush = new SolidColorBrush(Colors.Green);
                Icc17BorderBackground = new SolidColorBrush(Colors.Green);
                _icc17Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc17Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc17Med)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fMedByte);
                    icc17Med = false;
                    _icc17Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc17Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc17High)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fHighByte);
                    icc17High = false;
                    _icc17Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc17Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc17Med)
            {
                icc17MessageData = (byte)(icc17MessageData ^ fMedByte);
                icc17Med = true;
                Icc17SideMenu = "MED";

                Icc17BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc17BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc17Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc17Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc17Low)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fLowByte);
                    icc17Low = false;
                    _icc17Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc17Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc17High)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fHighByte);
                    icc17High = false;
                    _icc17Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc17Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc17High)
            {
                icc17MessageData = (byte)(icc17MessageData ^ fHighByte);
                icc17High = true;
                Icc17SideMenu = "HIGH";

                Icc17BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc17BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc17Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc17Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc17Low)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fLowByte);
                    icc17Low = false;
                    _icc17Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc17Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc17Med)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fMedByte);
                    icc17Med = false;
                    _icc17Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc17Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }

        if (cmMessageData != icc17MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc17MessageData, "ICC17");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 17 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc17Page.IsCommandErrorVisible = true;
            _homePage.Lvicc17PgStatus = true;
        }
        else
        {
            _icc17Page.IsCommandErrorVisible = false;
            _homePage.Lvicc17PgStatus = false;
        }
    }

    private void ReadIcc18Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc18On)
            {
                icc18MessageData = (byte)(icc18MessageData ^ fOnByte ^ fOffByte);
                icc18On = true;

                Icc18BorderBrush = new SolidColorBrush(Colors.Green);
                Icc18BorderBackground = new SolidColorBrush(Colors.Green);
                _icc18Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc18Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc18On)
            {
                icc18MessageData = (byte)(icc18MessageData ^ fOnByte ^ fOffByte);
                icc18On = false;
                Icc18SideMenu = "OFF";

                Icc18BorderBrush = new SolidColorBrush(Colors.Black);
                Icc18BorderBackground = new SolidColorBrush(Colors.Black);
                _icc18Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc18Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc18Low)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fLowByte);
                    icc18Low = false;
                    _icc18Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc18Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc18Med)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fMedByte);
                    icc18Med = false;
                    _icc18Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc18Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc18High)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fHighByte);
                    icc18High = false;
                    _icc18Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc18Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc18Low)
            {
                icc18MessageData = (byte)(icc18MessageData ^ fLowByte);
                icc18Low = true;
                Icc18SideMenu = "LOW";

                Icc18BorderBrush = new SolidColorBrush(Colors.Green);
                Icc18BorderBackground = new SolidColorBrush(Colors.Green);
                _icc18Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc18Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc18Med)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fMedByte);
                    icc18Med = false;
                    _icc18Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc18Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc18High)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fHighByte);
                    icc18High = false;
                    _icc18Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc18Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc18Med)
            {
                icc18MessageData = (byte)(icc18MessageData ^ fMedByte);
                icc18Med = true;
                Icc18SideMenu = "MED";

                Icc18BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc18BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc18Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc18Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc18Low)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fLowByte);
                    icc18Low = false;
                    _icc18Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc18Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc18High)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fHighByte);
                    icc18High = false;
                    _icc18Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc18Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc18High)
            {
                icc18MessageData = (byte)(icc18MessageData ^ fHighByte);
                icc18High = true;
                Icc18SideMenu = "HIGH";

                Icc18BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc18BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc18Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc18Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc18Low)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fLowByte);
                    icc18Low = false;
                    _icc18Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc18Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc18Med)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fMedByte);
                    icc18Med = false;
                    _icc18Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc18Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }

        if (cmMessageData != icc18MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc18MessageData, "ICC18");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 18 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc18Page.IsCommandErrorVisible = true;
            _homePage.Lvicc18PgStatus = true;
        }
        else
        {
            _icc18Page.IsCommandErrorVisible = false;
            _homePage.Lvicc18PgStatus = false;
        }
    }

    private void ReadIcc19Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc19On)
            {
                icc19MessageData = (byte)(icc19MessageData ^ fOnByte ^ fOffByte);
                icc19On = true;

                Icc19BorderBrush = new SolidColorBrush(Colors.Green);
                Icc19BorderBackground = new SolidColorBrush(Colors.Green);
                _icc19Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc19Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc19On)
            {
                icc19MessageData = (byte)(icc19MessageData ^ fOnByte ^ fOffByte);
                icc19On = false;
                Icc19SideMenu = "OFF";

                Icc19BorderBrush = new SolidColorBrush(Colors.Black);
                Icc19BorderBackground = new SolidColorBrush(Colors.Black);
                _icc19Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc19Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc19Low)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fLowByte);
                    icc19Low = false;
                    _icc19Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc19Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc19Med)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fMedByte);
                    icc19Med = false;
                    _icc19Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc19Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc19High)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fHighByte);
                    icc19High = false;
                    _icc19Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc19Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc19Low)
            {
                icc19MessageData = (byte)(icc19MessageData ^ fLowByte);
                icc19Low = true;
                Icc19SideMenu = "LOW";

                Icc19BorderBrush = new SolidColorBrush(Colors.Green);
                Icc19BorderBackground = new SolidColorBrush(Colors.Green);
                _icc19Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc19Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc19Med)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fMedByte);
                    icc19Med = false;
                    _icc19Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc19Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc19High)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fHighByte);
                    icc19High = false;
                    _icc19Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc19Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc19Med)
            {
                icc19MessageData = (byte)(icc19MessageData ^ fMedByte);
                icc19Med = true;
                Icc19SideMenu = "MED";

                Icc19BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc19BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc19Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc19Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc19Low)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fLowByte);
                    icc19Low = false;
                    _icc19Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc19Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc19High)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fHighByte);
                    icc19High = false;
                    _icc19Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc19Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc19High)
            {
                icc19MessageData = (byte)(icc19MessageData ^ fHighByte);
                icc19High = true;
                Icc19SideMenu = "HIGH";

                Icc19BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc19BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc19Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc19Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc19Low)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fLowByte);
                    icc19Low = false;
                    _icc19Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc19Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc19Med)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fMedByte);
                    icc19Med = false;
                    _icc19Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc19Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }

        if (cmMessageData != icc19MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc19MessageData, "ICC19");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 19 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc19Page.IsCommandErrorVisible = true;
            _homePage.Lvicc19PgStatus = true;
        }
        else
        {
            _icc19Page.IsCommandErrorVisible = false;
            _homePage.Lvicc19PgStatus = false;
        }
    }

    private void ReadIcc20Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc20On)
            {
                icc20MessageData = (byte)(icc20MessageData ^ fOnByte ^ fOffByte);
                icc20On = true;

                Icc20BorderBrush = new SolidColorBrush(Colors.Green);
                Icc20BorderBackground = new SolidColorBrush(Colors.Green);
                _icc20Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc20Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc20On)
            {
                icc20MessageData = (byte)(icc20MessageData ^ fOnByte ^ fOffByte);
                icc20On = false;
                Icc20SideMenu = "OFF";

                Icc20BorderBrush = new SolidColorBrush(Colors.Black);
                Icc20BorderBackground = new SolidColorBrush(Colors.Black);
                _icc20Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc20Page.OffForeground = new SolidColorBrush(Colors.White);
                
                if (icc20Low)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fLowByte);
                    icc20Low = false;
                    _icc20Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc20Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc20Med)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fMedByte);
                    icc20Med = false;
                    _icc20Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc20Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc20High)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fHighByte);
                    icc20High = false;
                    _icc20Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc20Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc20Low)
            {
                icc20MessageData = (byte)(icc20MessageData ^ fLowByte);
                icc20Low = true;
                Icc20SideMenu = "LOW";

                Icc20BorderBrush = new SolidColorBrush(Colors.Green);
                Icc20BorderBackground = new SolidColorBrush(Colors.Green);
                _icc20Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc20Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc20Med)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fMedByte);
                    icc20Med = false;
                    _icc20Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc20Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc20High)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fHighByte);
                    icc20High = false;
                    _icc20Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc20Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc20Med)
            {
                icc20MessageData = (byte)(icc20MessageData ^ fMedByte);
                icc20Med = true;
                Icc20SideMenu = "MED";

                Icc20BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc20BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc20Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc20Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc20Low)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fLowByte);
                    icc20Low = false;
                    _icc20Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc20Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc20High)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fHighByte);
                    icc20High = false;
                    _icc20Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc20Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc20High)
            {
                icc20MessageData = (byte)(icc20MessageData ^ fHighByte);
                icc20High = true;
                Icc20SideMenu = "HIGH";

                Icc20BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc20BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc20Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc20Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc20Low)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fLowByte);
                    icc20Low = false;
                    _icc20Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc20Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc20Med)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fMedByte);
                    icc20Med = false;
                    _icc20Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc20Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }

        if (cmMessageData != icc20MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc20MessageData, "ICC20");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 20 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc20Page.IsCommandErrorVisible = true;
            _homePage.Lvicc20PgStatus = true;
        }
        else
        {
            _icc20Page.IsCommandErrorVisible = false;
            _homePage.Lvicc20PgStatus = false;
        }
    }

    private void ReadIcc21Response(byte message)
    {
        if ((message & fOnByte) == fOnByte)
        {
            if (!icc21On)
            {
                icc21MessageData = (byte)(icc21MessageData ^ fOnByte ^ fOffByte);
                icc21On = true;

                Icc21BorderBrush = new SolidColorBrush(Colors.Green);
                Icc21BorderBackground = new SolidColorBrush(Colors.Green);
                _icc21Page.OffButton = new SolidColorBrush(Colors.LightGray);
                _icc21Page.OffForeground = new SolidColorBrush(Colors.Black);
            }
        }
        if ((message & fOffByte) == fOffByte)
        {
            if (icc21On)
            {
                icc21MessageData = (byte)(icc21MessageData ^ fOnByte ^ fOffByte);
                icc21On = false;
                Icc21SideMenu = "OFF";

                Icc21BorderBrush = new SolidColorBrush(Colors.Black);
                Icc21BorderBackground = new SolidColorBrush(Colors.Black);
                _icc21Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc21Page.OffForeground = new SolidColorBrush(Colors.White);

                if (icc21Low)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fLowByte);
                    icc21Low = false;
                    _icc21Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc21Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc21Med)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fMedByte);
                    icc21Med = false;
                    _icc21Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc21Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc21High)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fHighByte);
                    icc21High = false;
                    _icc21Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc21Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
                if ((message & alsfModeByte) == alsfModeByte)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ alsfModeByte);
                }
                if ((message & ssalrModeByte) == ssalrModeByte)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ ssalrModeByte);
                }
            }
        }
        if ((message & fLowByte) == fLowByte)
        {
            if (!icc21Low)
            {
                icc21MessageData = (byte)(icc21MessageData ^ fLowByte);
                icc21Low = true;
                Icc21SideMenu = "LOW";

                Icc21BorderBrush = new SolidColorBrush(Colors.Green);
                Icc21BorderBackground = new SolidColorBrush(Colors.Green);
                _icc21Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc21Page.LowForeground = new SolidColorBrush(Colors.White);

                if (icc21Med)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fMedByte);
                    icc21Med = false;
                    _icc21Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc21Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc21High)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fHighByte);
                    icc21High = false;
                    _icc21Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc21Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fMedByte) == fMedByte)
        {
            if (!icc21Med)
            {
                icc21MessageData = (byte)(icc21MessageData ^ fMedByte);
                icc21Med = true;
                Icc21SideMenu = "MED";

                Icc21BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc21BorderBackground = new SolidColorBrush(Colors.Orange);
                _icc21Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc21Page.MedForeground = new SolidColorBrush(Colors.White);

                if (icc21Low)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fLowByte);
                    icc21Low = false;
                    _icc21Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc21Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc21High)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fHighByte);
                    icc21High = false;
                    _icc21Page.HighButton = new SolidColorBrush(Colors.LightGray);
                    _icc21Page.HighForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        if ((message & fHighByte) == fHighByte)
        {
            if (!icc21High)
            {
                icc21MessageData = (byte)(icc21MessageData ^ fHighByte);
                icc21High = true;
                Icc21SideMenu = "HIGH";

                Icc21BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc21BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _icc21Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc21Page.HighForeground = new SolidColorBrush(Colors.White);

                if (icc21Low)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fLowByte);
                    icc21Low = false;
                    _icc21Page.LowButton = new SolidColorBrush(Colors.LightGray);
                    _icc21Page.LowForeground = new SolidColorBrush(Colors.Black);
                }
                if (icc21Med)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fMedByte);
                    icc21Med = false;
                    _icc21Page.MedButton = new SolidColorBrush(Colors.LightGray);
                    _icc21Page.MedForeground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        
        if (cmMessageData != icc21MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc21MessageData, "ICC21");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 21 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc21Page.IsCommandErrorVisible = true;
            _homePage.Lvicc21PgStatus = true;
        }
        else
        {
            _icc21Page.IsCommandErrorVisible = false;
            _homePage.Lvicc21PgStatus = false;
        }
    }

    private void ReadIcc1Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc1Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc1Page.RemForeground = new SolidColorBrush(Colors.White);
            _icc1Page.IsCommandErrorVisible = false;
            _homePage.Lvicc1PgStatus = false;
            icc1Rem = true;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc1Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc1Page.RemForeground = new SolidColorBrush(Colors.Black);
            
            icc1Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 1 remote is turned OFF.\n";

            // activate mode error
            _icc1Page.IsCommandErrorVisible = true;
            _homePage.Lvicc1PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc1On)
            {
                icc1On = false;
                Icc1SideMenu = "OFF";
                Icc1BorderBrush = new SolidColorBrush(Colors.Black);
                Icc1BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc1PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc1Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc1Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc1Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc1Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc1Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc1Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc1Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc1Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc1Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc1Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc1Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc1Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc1Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc1Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc1Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc1Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc1Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc1MessageData = (byte)(icc1MessageData ^ fOffByte ^ fOnByte);

                if (icc1Low)
                {
                    icc1Low = false;
                    icc1MessageData = (byte)(icc1MessageData ^ fLowByte);
                }
                if (icc1Med)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fMedByte);
                    icc1Med = false;
                }
                if (icc1High)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fHighByte);
                    icc1High = false;
                }
            }

        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc1On && !icc1Low)
            {
                if (icc1Med)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fMedByte);
                    icc1Med = false;
                }
                if (icc1High)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fHighByte);
                    icc1High = false;
                }
                icc1Low = true;
                Icc1SideMenu = "LOW";
                Icc1SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc1BorderBrush = new SolidColorBrush(Colors.Green);
                Icc1BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc1PgBackground = new SolidColorBrush(Colors.Green);

                _icc1Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc1Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc1Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc1Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc1Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc1Page.HighForeground = new SolidColorBrush(Colors.Black);


                icc1MessageData = (byte)(icc1MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc1On && !icc1Med)
            {
                if (icc1Low)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fLowByte);
                    icc1Low = false;
                }
                if (icc1High)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fHighByte);
                    icc1High = false;
                }
                icc1Med = true;
                Icc1SideMenu = "MED";
                Icc1SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc1BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc1BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc1PgBackground = new SolidColorBrush(Colors.Green);

                _icc1Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc1Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc1Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc1Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc1Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc1Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc1MessageData = (byte)(icc1MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc1On && !icc1High)
            {
                if (icc1Low)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fLowByte);
                    icc1Low = false;
                }
                if (icc1Med)
                {
                    icc1MessageData = (byte)(icc1MessageData ^ fMedByte);
                    icc1Med = false;
                }
                icc1High = true;
                Icc1SideMenu = "HIGH";
                Icc1SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc1BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc1BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc1PgBackground = new SolidColorBrush(Colors.Green);

                _icc1Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc1Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc1Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc1Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc1Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc1Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc1MessageData = (byte)(icc1MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc1Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }else if ((param2 & flashOpen) == 0)
        {
            _icc1Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc1Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        } else if ((param2 & mtConnected) == 0)
        {
            _icc1Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc1Page.ModeStatus = "ALSF";
            _icc1Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc1Page.ModeStatus = "MALSR";
            _icc1Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc1Page.ModeStatus = "LDIN";
            _icc1Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc1Page.ModeStatus = "REIL";
            _icc1Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc1Page.ControlType = "Discrete";
            _icc1Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }else if ((param1 & controlConfig) == 0)
        {
            _icc1Page.ControlType = "Serial";
            _icc1Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc1Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc1Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }else if ((param1 & flasherType) == 0)
        {
            _icc1Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc1Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc1Compat = true;
            _icc1Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc1Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc1Compat = false;
            _icc1Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc1Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc1MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc1MessageData, "ICC1");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 1 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc1Page.IsCommandErrorVisible = true;
            _homePage.Lvicc1PgStatus = true;
        }
        else
        {
            _icc1Page.IsCommandErrorVisible = false;
            _homePage.Lvicc1PgStatus = false;
        }
    }

    private void ReadIcc2Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc2Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc2Page.RemForeground = new SolidColorBrush(Colors.White);
            icc2Rem = true;
            _homePage.Lvicc2PgStatus = false;
            _icc2Page.IsCommandErrorVisible = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc2Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc2Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc2Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 2 remote is turned OFF.\n";

            // activate mode error
            _icc2Page.IsCommandErrorVisible = true;
            _homePage.Lvicc2PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc2On)
            {
                icc2On = false;
                Icc2SideMenu = "OFF";
                Icc2SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc2BorderBrush = new SolidColorBrush(Colors.Black);
                Icc2BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc2PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc2Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc2Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc2Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc2Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc2Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc2Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc2Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc2Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc2Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc2Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc2Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc2Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc2Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc2Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc2Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc2Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc2Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc2MessageData = (byte)(icc2MessageData ^ fOffByte ^ fOnByte);

                if (icc2Low)
                {
                    icc2Low = false;
                    icc2MessageData = (byte)(icc2MessageData ^ fLowByte);
                }
                if (icc2Med)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fMedByte);
                    icc2Med = false;
                }
                if (icc2High)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fHighByte);
                    icc2High = false;
                }
            }
        }       
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc2On && !icc2Low)
            {
                if (icc2Med)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fMedByte);
                    icc2Med = false;
                }
                if (icc2High)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fHighByte);
                    icc2High = false;
                }
                icc2Low = true;
                Icc2SideMenu = "LOW";
                Icc2SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc2BorderBrush = new SolidColorBrush(Colors.Green);
                Icc2BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc2PgBackground = new SolidColorBrush(Colors.Green);

                _icc2Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc2Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc2Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc2Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc2Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc2Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc2MessageData = (byte)(icc2MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc2On && !icc2Med)
            {
                if (icc2Low)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fLowByte);
                    icc2Low = false;
                }
                if (icc2High)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fHighByte);
                    icc2High = false;
                }
                icc2Med = true;
                Icc2SideMenu = "MED";
                Icc2SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc2BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc2BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc2PgBackground = new SolidColorBrush(Colors.Green);

                _icc2Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc2Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc2Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc2Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc2Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc2Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc2MessageData = (byte)(icc2MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc2On && !icc2High)
            {
                if (icc2Low)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fLowByte);
                    icc2Low = false;
                }
                if (icc2Med)
                {
                    icc2MessageData = (byte)(icc2MessageData ^ fMedByte);
                    icc2Med = false;
                }
                icc2High = true;
                Icc2SideMenu = "HIGH";
                Icc2SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc2BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc2BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc2PgBackground = new SolidColorBrush(Colors.Green);

                _icc2Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc2Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc2Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc2Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc2Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc2Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc2MessageData = (byte)(icc2MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc2Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc2Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc2Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc2Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc2Page.ModeStatus = "ALSF";
            _icc2Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc2Page.ModeStatus = "MALSR";
            _icc2Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc2Page.ModeStatus = "LDIN";
            _icc2Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc2Page.ModeStatus = "REIL";
            _icc2Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc2Page.ControlType = "Discrete";
            _icc2Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc2Page.ControlType = "Serial";
            _icc2Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc2Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc2Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc2Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc2Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc2Compat = true;
            _icc2Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc2Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc2Compat = false;
            _icc2Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc2Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc2MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc2MessageData, "ICC2");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 2 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc2Page.IsCommandErrorVisible = true;
            _homePage.Lvicc2PgStatus = true;
        }
        else
        {
            _icc2Page.IsCommandErrorVisible = false;
            _homePage.Lvicc2PgStatus = false;
        }
    }

    private void ReadIcc3Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc3Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc3Page.RemForeground = new SolidColorBrush(Colors.White);
            icc3Rem = true;
            _icc3Page.IsCommandErrorVisible = false;
            _homePage.Lvicc3PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc3Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc3Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc3Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 3 remote is turned OFF.\n";

            // activate mode error
            _icc3Page.IsCommandErrorVisible = true;
            _homePage.Lvicc3PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc3On)
            {
                icc3On = false;
                Icc3SideMenu = "OFF";
                Icc3SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc3BorderBrush = new SolidColorBrush(Colors.Black);
                Icc3BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc3PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc3Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc3Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc3Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc3Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc3Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc3Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc3Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc3Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc3Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc3Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc3Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc3Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc3Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc3Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc3Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc3Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc3Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc3MessageData = (byte)(icc3MessageData ^ fOffByte ^ fOnByte);

                if (icc3Low)
                {
                    icc3Low = false;
                    icc3MessageData = (byte)(icc3MessageData ^ fLowByte);
                }
                if (icc3Med)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fMedByte);
                    icc3Med = false;
                }
                if (icc3High)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fHighByte);
                    icc3High = false;
                }
            }
        }        
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc3On && !icc3Low)
            {
                if (icc3Med)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fMedByte);
                    icc3Med = false;
                }
                if (icc3High)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fHighByte);
                    icc3High = false;
                }
                icc3Low = true;
                Icc3SideMenu = "LOW";
                Icc3SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc3BorderBrush = new SolidColorBrush(Colors.Green);
                Icc3BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc3PgBackground = new SolidColorBrush(Colors.Green);

                _icc3Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc3Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc3Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc3Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc3Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc3Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc3MessageData = (byte)(icc3MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc3On && !icc3Med)
            {
                if (icc3Low)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fLowByte);
                    icc3Low = false;
                }
                if (icc3High)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fHighByte);
                    icc3High = false;
                }
                icc3Med = true;
                Icc3SideMenu = "MED";
                Icc3SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc3BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc3BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc3PgBackground = new SolidColorBrush(Colors.Green);

                _icc3Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc3Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc3Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc3Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc3Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc3Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc3MessageData = (byte)(icc3MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc3On && !icc3High)
            {
                if (icc3Low)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fLowByte);
                    icc3Low = false;
                }
                if (icc3Med)
                {
                    icc3MessageData = (byte)(icc3MessageData ^ fMedByte);
                    icc3Med = false;
                }
                icc3High = true;
                Icc3SideMenu = "HIGH";
                Icc3SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc3BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc3BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc3PgBackground = new SolidColorBrush(Colors.Green);

                _icc3Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc3Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc3Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc3Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc3Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc3Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc3MessageData = (byte)(icc3MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc3Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc3Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc3Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc3Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc3Page.ModeStatus = "ALSF";
            _icc3Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc3Page.ModeStatus = "MALSR";
            _icc3Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc3Page.ModeStatus = "LDIN";
            _icc3Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc3Page.ModeStatus = "REIL";
            _icc3Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc3Page.ControlType = "Discrete";
            _icc3Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc3Page.ControlType = "Serial";
            _icc3Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc3Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc3Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc3Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc3Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc3Compat = true;
            _icc3Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc3Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc3Compat = false;
            _icc3Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc3Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc3MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc3MessageData, "ICC3");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 3 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc3Page.IsCommandErrorVisible = true;
            _homePage.Lvicc3PgStatus = true;
        }
        else
        {
            _icc3Page.IsCommandErrorVisible = false;
            _homePage.Lvicc3PgStatus = false;
        }
    }

    private void ReadIcc4Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc4Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc4Page.RemForeground = new SolidColorBrush(Colors.White);
            icc4Rem = true;
            _icc4Page.IsCommandErrorVisible = false;
            _homePage.Lvicc4PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc4Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc4Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc4Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 4 remote is turned OFF.\n";

            // activate mode error
            _icc4Page.IsCommandErrorVisible = true;
            _homePage.Lvicc4PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc4On)
            {
                icc4On = false;
                Icc4SideMenu = "OFF";
                Icc4SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc4BorderBrush = new SolidColorBrush(Colors.Black);
                Icc4BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc4PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc4Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc4Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc4Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc4Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc4Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc4Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc4Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc4Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc4Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc4Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc4Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc4Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc4Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc4Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc4Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc4Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc4Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc4MessageData = (byte)(icc4MessageData ^ fOffByte ^ fOnByte);

                if (icc4Low)
                {
                    icc4Low = false;
                    icc4MessageData = (byte)(icc4MessageData ^ fLowByte);
                }
                if (icc4Med)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fMedByte);
                    icc4Med = false;
                }
                if (icc4High)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fHighByte);
                    icc4High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc4On && !icc4Low)
            {
                if (icc4Med)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fMedByte);
                    icc4Med = false;
                }
                if (icc4High)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fHighByte);
                    icc4High = false;
                }
                icc4Low = true;
                Icc4SideMenu = "LOW";
                Icc4SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc4BorderBrush = new SolidColorBrush(Colors.Green);
                Icc4BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc4PgBackground = new SolidColorBrush(Colors.Green);

                _icc4Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc4Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc4Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc4Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc4Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc4Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc4MessageData = (byte)(icc4MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc4On && !icc4Med)
            {
                if (icc4Low)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fLowByte);
                    icc4Low = false;
                }
                if (icc4High)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fHighByte);
                    icc4High = false;
                }
                icc4Med = true;
                Icc4SideMenu = "MED";
                Icc4SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc4BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc4BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc4PgBackground = new SolidColorBrush(Colors.Green);

                _icc4Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc4Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc4Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc4Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc4Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc4Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc4MessageData = (byte)(icc4MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc4On && !icc4High)
            {
                if (icc4Low)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fLowByte);
                    icc4Low = false;
                }
                if (icc4Med)
                {
                    icc4MessageData = (byte)(icc4MessageData ^ fMedByte);
                    icc4Med = false;
                }
                icc4High = true;
                Icc4SideMenu = "HIGH";
                Icc4SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc4BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc4BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc4PgBackground = new SolidColorBrush(Colors.Green);

                _icc4Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc4Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc4Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc4Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc4Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc4Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc4MessageData = (byte)(icc4MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc4Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc4Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc4Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc4Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc4Page.ModeStatus = "ALSF";
            _icc4Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc4Page.ModeStatus = "MALSR";
            _icc4Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc4Page.ModeStatus = "LDIN";
            _icc4Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc4Page.ModeStatus = "REIL";
            _icc4Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc4Page.ControlType = "Discrete";
            _icc4Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc4Page.ControlType = "Serial";
            _icc4Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc4Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc4Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc4Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc4Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc4Compat = true;
            _icc4Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc4Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc4Compat = false;
            _icc4Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc4Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc4MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc4MessageData, "ICC4");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 4 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc4Page.IsCommandErrorVisible = true;
            _homePage.Lvicc4PgStatus = true;
        }
        else
        {
            _icc4Page.IsCommandErrorVisible = false;
            _homePage.Lvicc4PgStatus = false;
        }
    }

    private void ReadIcc5Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc5Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc5Page.RemForeground = new SolidColorBrush(Colors.White);
            icc5Rem = true;
            _icc5Page.IsCommandErrorVisible = false;
            _homePage.Lvicc5PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc5Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc5Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc5Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 5 remote is turned OFF.\n";

            // activate mode error
            _icc5Page.IsCommandErrorVisible = true;
            _homePage.Lvicc5PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc5On)
            {
                icc5On = false;
                Icc5SideMenu = "OFF";
                Icc5SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc5BorderBrush = new SolidColorBrush(Colors.Black);
                Icc5BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc5PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc5Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc5Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc5Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc5Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc5Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc5Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc5Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc5Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc5Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc5Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc5Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc5Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc5Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc5Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc5Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc5Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc5Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc5MessageData = (byte)(icc5MessageData ^ fOffByte ^ fOnByte);

                if (icc5Low)
                {
                    icc5Low = false;
                    icc5MessageData = (byte)(icc5MessageData ^ fLowByte);
                }
                if (icc5Med)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fMedByte);
                    icc5Med = false;
                }
                if (icc5High)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fHighByte);
                    icc5High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc5On && !icc5Low)
            {
                if (icc5Med)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fMedByte);
                    icc5Med = false;
                }
                if (icc5High)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fHighByte);
                    icc5High = false;
                }
                icc5Low = true;
                Icc5SideMenu = "LOW";
                Icc5SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc5BorderBrush = new SolidColorBrush(Colors.Green);
                Icc5BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc5PgBackground = new SolidColorBrush(Colors.Green);

                _icc5Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc5Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc5Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc5Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc5Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc5Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc5MessageData = (byte)(icc5MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc5On && !icc5Med)
            {
                if (icc5Low)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fLowByte);
                    icc5Low = false;
                }
                if (icc5High)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fHighByte);
                    icc5High = false;
                }
                icc5Med = true;
                Icc5SideMenu = "MED";
                Icc5SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc5BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc5BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc5PgBackground = new SolidColorBrush(Colors.Green);

                _icc5Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc5Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc5Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc5Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc5Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc5Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc5MessageData = (byte)(icc5MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc5On && !icc5High)
            {
                if (icc5Low)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fLowByte);
                    icc5Low = false;
                }
                if (icc5Med)
                {
                    icc5MessageData = (byte)(icc5MessageData ^ fMedByte);
                    icc5Med = false;
                }
                icc5High = true;
                Icc5SideMenu = "HIGH";
                Icc5SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc5BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc5BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc5PgBackground = new SolidColorBrush(Colors.Green);

                _icc5Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc5Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc5Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc5Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc5Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc5Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc5MessageData = (byte)(icc5MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc5Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc5Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc5Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc5Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc5Page.ModeStatus = "ALSF";
            _icc5Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc5Page.ModeStatus = "MALSR";
            _icc5Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc5Page.ModeStatus = "LDIN";
            _icc5Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc5Page.ModeStatus = "REIL";
            _icc5Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc5Page.ControlType = "Discrete";
            _icc5Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc5Page.ControlType = "Serial";
            _icc5Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc5Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc5Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc5Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc5Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc5Compat = true;
            _icc5Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc5Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc5Compat = false;
            _icc5Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc5Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc5MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc5MessageData, "ICC5");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 5 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc5Page.IsCommandErrorVisible = true;
            _homePage.Lvicc5PgStatus = true;
        }
        else
        {
            _icc5Page.IsCommandErrorVisible = false;
            _homePage.Lvicc5PgStatus = false;
        }
    }

    private void ReadIcc6Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc6Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc6Page.RemForeground = new SolidColorBrush(Colors.White);
            icc6Rem = true;
            _icc6Page.IsCommandErrorVisible = false;
            _homePage.Lvicc6PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc6Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc6Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc6Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 6 remote is turned OFF.\n";

            // activate mode error
            _icc6Page.IsCommandErrorVisible = true;
            _homePage.Lvicc6PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc6On)
            {
                icc6On = false;
                Icc6SideMenu = "OFF";
                Icc6SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc6BorderBrush = new SolidColorBrush(Colors.Black);
                Icc6BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc6PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc6Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc6Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc6Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc6Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc6Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc6Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc6Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc6Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc6Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc6Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc6Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc6Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc6Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc6Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc6Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc6Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc6Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc6MessageData = (byte)(icc6MessageData ^ fOffByte ^ fOnByte);

                if (icc6Low)
                {
                    icc6Low = false;
                    icc6MessageData = (byte)(icc6MessageData ^ fLowByte);
                }
                if (icc6Med)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fMedByte);
                    icc6Med = false;
                }
                if (icc6High)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fHighByte);
                    icc6High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc6On && !icc6Low)
            {
                if (icc6Med)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fMedByte);
                    icc6Med = false;
                }
                if (icc6High)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fHighByte);
                    icc6High = false;
                }
                icc6Low = true;
                Icc6SideMenu = "LOW";
                Icc6SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc6BorderBrush = new SolidColorBrush(Colors.Green);
                Icc6BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc6PgBackground = new SolidColorBrush(Colors.Green);

                _icc6Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc6Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc6Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc6Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc6Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc6Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc6MessageData = (byte)(icc6MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc6On && !icc6Med)
            {
                if (icc6Low)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fLowByte);
                    icc6Low = false;
                }
                if (icc6High)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fHighByte);
                    icc6High = false;
                }
                icc6Med = true;
                Icc6SideMenu = "MED";
                Icc6SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc6BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc6BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc6PgBackground = new SolidColorBrush(Colors.Green);

                _icc6Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc6Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc6Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc6Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc6Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc6Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc6MessageData = (byte)(icc6MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc6On && !icc6High)
            {
                if (icc6Low)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fLowByte);
                    icc6Low = false;
                }
                if (icc6Med)
                {
                    icc6MessageData = (byte)(icc6MessageData ^ fMedByte);
                    icc6Med = false;
                }
                icc6High = true;
                Icc6SideMenu = "HIGH";
                Icc6SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc6BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc6BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc6PgBackground = new SolidColorBrush(Colors.Green);

                _icc6Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc6Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc6Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc6Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc6Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc6Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc6MessageData = (byte)(icc6MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc6Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc6Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc6Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc6Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc6Page.ModeStatus = "ALSF";
            _icc6Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc6Page.ModeStatus = "MALSR";
            _icc6Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc6Page.ModeStatus = "LDIN";
            _icc6Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc6Page.ModeStatus = "REIL";
            _icc6Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc6Page.ControlType = "Discrete";
            _icc6Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc6Page.ControlType = "Serial";
            _icc6Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc6Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc6Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc6Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc6Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc6Compat = true;
            _icc6Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc6Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc6Compat = false;
            _icc6Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc6Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc6MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc6MessageData, "ICC6");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 6 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc6Page.IsCommandErrorVisible = true;
            _homePage.Lvicc6PgStatus = true;
        }
        else
        {
            _icc6Page.IsCommandErrorVisible = false;
            _homePage.Lvicc6PgStatus = false;
        }
    }

    private void ReadIcc7Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc7Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc7Page.RemForeground = new SolidColorBrush(Colors.White);
            icc7Rem = true;
            _icc7Page.IsCommandErrorVisible = false;
            _homePage.Lvicc7PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc7Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc7Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc7Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 7 remote is turned OFF.\n";

            // activate mode error
            _icc7Page.IsCommandErrorVisible = true;
            _homePage.Lvicc7PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc7On)
            {
                icc7On = false;
                Icc7SideMenu = "OFF";
                Icc7SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc7BorderBrush = new SolidColorBrush(Colors.Black);
                Icc7BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc7PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc7Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc7Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc7Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc7Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc7Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc7Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc7Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc7Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc7Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc7Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc7Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc7Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc7Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc7Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc7Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc7Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc7Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc7MessageData = (byte)(icc7MessageData ^ fOffByte ^ fOnByte);

                if (icc7Low)
                {
                    icc7Low = false;
                    icc7MessageData = (byte)(icc7MessageData ^ fLowByte);
                }
                if (icc7Med)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fMedByte);
                    icc7Med = false;
                }
                if (icc7High)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fHighByte);
                    icc7High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc7On && !icc7Low)
            {
                if (icc7Med)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fMedByte);
                    icc7Med = false;
                }
                if (icc7High)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fHighByte);
                    icc7High = false;
                }
                icc7Low = true;
                Icc7SideMenu = "LOW";
                Icc7SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc7BorderBrush = new SolidColorBrush(Colors.Green);
                Icc7BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc7PgBackground = new SolidColorBrush(Colors.Green);

                _icc7Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc7Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc7Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc7Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc7Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc7Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc7MessageData = (byte)(icc7MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc7On && !icc7Med)
            {
                if (icc7Low)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fLowByte);
                    icc7Low = false;
                }
                if (icc7High)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fHighByte);
                    icc7High = false;
                }
                icc7Med = true;
                Icc7SideMenu = "MED";
                Icc7SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc7BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc7BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc7PgBackground = new SolidColorBrush(Colors.Green);

                _icc7Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc7Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc7Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc7Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc7Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc7Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc7MessageData = (byte)(icc7MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc7On && !icc7High)
            {
                if (icc7Low)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fLowByte);
                    icc7Low = false;
                }
                if (icc7Med)
                {
                    icc7MessageData = (byte)(icc7MessageData ^ fMedByte);
                    icc7Med = false;
                }
                icc7High = true;
                Icc7SideMenu = "HIGH";
                Icc7SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc7BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc7BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc7PgBackground = new SolidColorBrush(Colors.Green);

                _icc7Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc7Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc7Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc7Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc7Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc7Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc7MessageData = (byte)(icc7MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc7Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc7Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc7Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc7Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc7Page.ModeStatus = "ALSF";
            _icc7Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc7Page.ModeStatus = "MALSR";
            _icc7Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc7Page.ModeStatus = "LDIN";
            _icc7Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc7Page.ModeStatus = "REIL";
            _icc7Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc7Page.ControlType = "Discrete";
            _icc7Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc7Page.ControlType = "Serial";
            _icc7Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc7Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc7Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc7Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc7Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc7Compat = true;
            _icc7Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc7Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc7Compat = false;
            _icc7Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc7Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }

        if (cmMessageData != icc7MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc7MessageData, "ICC7");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 7 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc7Page.IsCommandErrorVisible = true;
            _homePage.Lvicc7PgStatus = true;
        }
        else
        {
            _icc7Page.IsCommandErrorVisible = false;
            _homePage.Lvicc7PgStatus = false;
        }
    }

    private void ReadIcc8Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc8Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc8Page.RemForeground = new SolidColorBrush(Colors.White);
            icc8Rem = true;
            _icc8Page.IsCommandErrorVisible = false;
            _homePage.Lvicc8PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc8Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc8Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc8Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 8 remote is turned OFF.\n";

            // activate mode error
            _icc8Page.IsCommandErrorVisible = true;
            _homePage.Lvicc8PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc8On)
            {
                icc8On = false;
                Icc8SideMenu = "OFF";
                Icc8SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc8BorderBrush = new SolidColorBrush(Colors.Black);
                Icc8BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc8PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc8Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc8Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc8Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc8Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc8Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc8Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc8Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc8Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc8Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc8Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc8Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc8Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc8Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc8Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc8Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc8Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc8Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc8MessageData = (byte)(icc8MessageData ^ fOffByte ^ fOnByte);

                if (icc8Low)
                {
                    icc8Low = false;
                    icc8MessageData = (byte)(icc8MessageData ^ fLowByte);
                }
                if (icc8Med)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fMedByte);
                    icc8Med = false;
                }
                if (icc8High)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fHighByte);
                    icc8High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc8On && !icc8Low)
            {
                if (icc8Med)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fMedByte);
                    icc8Med = false;
                }
                if (icc8High)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fHighByte);
                    icc8High = false;
                }
                icc8Low = true;
                Icc8SideMenu = "LOW";
                Icc8SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc8BorderBrush = new SolidColorBrush(Colors.Green);
                Icc8BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc8PgBackground = new SolidColorBrush(Colors.Green);

                _icc8Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc8Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc8Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc8Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc8Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc8Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc8MessageData = (byte)(icc8MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc8On && !icc8Med)
            {
                if (icc8Low)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fLowByte);
                    icc8Low = false;
                }
                if (icc8High)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fHighByte);
                    icc8High = false;
                }
                icc8Med = true;
                Icc8SideMenu = "MED";
                Icc8SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc8BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc8BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc8PgBackground = new SolidColorBrush(Colors.Green);

                _icc8Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc8Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc8Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc8Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc8Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc8Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc8MessageData = (byte)(icc8MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc8On && !icc8High)
            {
                if (icc8Low)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fLowByte);
                    icc8Low = false;
                }
                if (icc8Med)
                {
                    icc8MessageData = (byte)(icc8MessageData ^ fMedByte);
                    icc8Med = false;
                }
                icc8High = true;
                Icc8SideMenu = "HIGH";
                Icc8SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc8BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc8BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc8PgBackground = new SolidColorBrush(Colors.Green);

                _icc8Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc8Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc8Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc8Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc8Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc8Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc8MessageData = (byte)(icc8MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc8Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc8Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc8Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc8Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc8Page.ModeStatus = "ALSF";
            _icc8Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc8Page.ModeStatus = "MALSR";
            _icc8Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc8Page.ModeStatus = "LDIN";
            _icc8Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc8Page.ModeStatus = "REIL";
            _icc8Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc8Page.ControlType = "Discrete";
            _icc8Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc8Page.ControlType = "Serial";
            _icc8Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc8Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc8Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc8Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc8Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc8Compat = true;
            _icc8Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc8Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc8Compat = false;
            _icc8Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc8Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc8MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc8MessageData, "ICC8");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 8 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc8Page.IsCommandErrorVisible = true;
            _homePage.Lvicc8PgStatus = true;
        }
        else
        {
            _icc8Page.IsCommandErrorVisible = false;
            _homePage.Lvicc8PgStatus = false;
        }
    }

    private void ReadIcc9Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc9Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc9Page.RemForeground = new SolidColorBrush(Colors.White);
            icc9Rem = true;
            _icc9Page.IsCommandErrorVisible = false;
            _homePage.Lvicc9PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc9Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc9Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc9Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 9 remote is turned OFF.\n";

            // activate mode error
            _icc9Page.IsCommandErrorVisible = true;
            _homePage.Lvicc9PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc9On)
            {
                icc9On = false;
                Icc9SideMenu = "OFF";
                Icc9SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc9BorderBrush = new SolidColorBrush(Colors.Black);
                Icc9BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc9PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc9Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc9Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc9Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc9Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc9Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc9Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc9Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc9Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc9Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc9Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc9Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc9Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc9Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc9Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc9Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc9Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc9Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc9MessageData = (byte)(icc9MessageData ^ fOffByte ^ fOnByte);

                if (icc9Low)
                {
                    icc9Low = false;
                    icc9MessageData = (byte)(icc9MessageData ^ fLowByte);
                }
                if (icc9Med)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fMedByte);
                    icc9Med = false;
                }
                if (icc9High)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fHighByte);
                    icc9High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc9On && !icc9Low)
            {
                if (icc9Med)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fMedByte);
                    icc9Med = false;
                }
                if (icc9High)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fHighByte);
                    icc9High = false;
                }
                icc9Low = true;
                Icc9SideMenu = "LOW";
                Icc9SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc9BorderBrush = new SolidColorBrush(Colors.Green);
                Icc9BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc9PgBackground = new SolidColorBrush(Colors.Green);

                _icc9Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc9Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc9Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc9Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc9Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc9Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc9MessageData = (byte)(icc9MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc9On && !icc9Med)
            {
                if (icc9Low)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fLowByte);
                    icc9Low = false;
                }
                if (icc9High)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fHighByte);
                    icc9High = false;
                }
                icc9Med = true;
                Icc9SideMenu = "MED";
                Icc9SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc9BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc9BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc9PgBackground = new SolidColorBrush(Colors.Green);

                _icc9Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc9Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc9Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc9Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc9Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc9Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc9MessageData = (byte)(icc9MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc9On && !icc9High)
            {
                if (icc9Low)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fLowByte);
                    icc9Low = false;
                }
                if (icc9Med)
                {
                    icc9MessageData = (byte)(icc9MessageData ^ fMedByte);
                    icc9Med = false;
                }
                icc9High = true;
                Icc9SideMenu = "HIGH";
                Icc9SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc9BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc9BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc9PgBackground = new SolidColorBrush(Colors.Green);

                _icc9Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc9Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc9Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc9Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc9Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc9Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc9MessageData = (byte)(icc9MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc9Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc9Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc9Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc9Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc9Page.ModeStatus = "ALSF";
            _icc9Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc9Page.ModeStatus = "MALSR";
            _icc9Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc9Page.ModeStatus = "LDIN";
            _icc9Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc9Page.ModeStatus = "REIL";
            _icc9Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc9Page.ControlType = "Discrete";
            _icc9Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc9Page.ControlType = "Serial";
            _icc9Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc9Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc9Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc9Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc9Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc9Compat = true;
            _icc9Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc9Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc9Compat = false;
            _icc9Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc9Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc9MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc9MessageData, "ICC9");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 9 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc9Page.IsCommandErrorVisible = true;
            _homePage.Lvicc9PgStatus = true;
        }
        else
        {
            _icc9Page.IsCommandErrorVisible = false;
            _homePage.Lvicc9PgStatus = false;
        }
    }

    private void ReadIcc10Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc10Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc10Page.RemForeground = new SolidColorBrush(Colors.White);
            icc10Rem = true;
            _icc10Page.IsCommandErrorVisible = false;
            _homePage.Lvicc10PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc10Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc10Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc10Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 10 remote is turned OFF.\n";

            // activate mode error
            _icc10Page.IsCommandErrorVisible = true;
            _homePage.Lvicc10PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc10On)
            {
                icc10On = false;
                Icc10SideMenu = "OFF";
                Icc10SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc10BorderBrush = new SolidColorBrush(Colors.Black);
                Icc10BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc10PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc10Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc10Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc10Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc10Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc10Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc10Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc10Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc10Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc10Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc10Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc10Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc10Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc10Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc10Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc10Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc10Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc10Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc10MessageData = (byte)(icc10MessageData ^ fOffByte ^ fOnByte);

                if (icc10Low)
                {
                    icc10Low = false;
                    icc10MessageData = (byte)(icc10MessageData ^ fLowByte);
                }
                if (icc10Med)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fMedByte);
                    icc10Med = false;
                }
                if (icc10High)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fHighByte);
                    icc10High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc10On && !icc10Low)
            {
                if (icc10Med)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fMedByte);
                    icc10Med = false;
                }
                if (icc10High)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fHighByte);
                    icc10High = false;
                }
                icc10Low = true;
                Icc10SideMenu = "LOW";
                Icc10SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc10BorderBrush = new SolidColorBrush(Colors.Green);
                Icc10BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc10PgBackground = new SolidColorBrush(Colors.Green);

                _icc10Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc10Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc10Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc10Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc10Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc10Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc10MessageData = (byte)(icc10MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc10On && !icc10Med)
            {
                if (icc10Low)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fLowByte);
                    icc10Low = false;
                }
                if (icc10High)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fHighByte);
                    icc10High = false;
                }
                icc10Med = true;
                Icc10SideMenu = "MED";
                Icc10SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc10BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc10BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc10PgBackground = new SolidColorBrush(Colors.Green);

                _icc10Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc10Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc10Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc10Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc10Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc10Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc10MessageData = (byte)(icc10MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc10On && !icc10High)
            {
                if (icc10Low)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fLowByte);
                    icc10Low = false;
                }
                if (icc10Med)
                {
                    icc10MessageData = (byte)(icc10MessageData ^ fMedByte);
                    icc10Med = false;
                }
                icc10High = true;
                Icc10SideMenu = "HIGH";
                Icc10SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc10BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc10BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc10PgBackground = new SolidColorBrush(Colors.Green);

                _icc10Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc10Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc10Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc10Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc10Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc10Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc10MessageData = (byte)(icc10MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc10Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc10Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc10Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc10Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc10Page.ModeStatus = "ALSF";
            _icc10Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc10Page.ModeStatus = "MALSR";
            _icc10Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc10Page.ModeStatus = "LDIN";
            _icc10Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc10Page.ModeStatus = "REIL";
            _icc10Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc10Page.ControlType = "Discrete";
            _icc10Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc10Page.ControlType = "Serial";
            _icc10Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc10Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc10Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc10Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc10Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc10Compat = true;
            _icc10Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc10Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc10Compat = false;
            _icc10Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc10Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc10MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc10MessageData, "ICC10");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 10 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc10Page.IsCommandErrorVisible = true;
            _homePage.Lvicc10PgStatus = true;
        }
        else
        {
            _icc10Page.IsCommandErrorVisible = false;
            _homePage.Lvicc10PgStatus = false;
        }
    }

    private void ReadIcc11Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc11Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc11Page.RemForeground = new SolidColorBrush(Colors.White);
            icc11Rem = true;
            _icc11Page.IsCommandErrorVisible = false;
            _homePage.Lvicc11PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc11Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc11Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc11Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 11 remote is turned OFF.\n";

            // activate mode error
            _icc11Page.IsCommandErrorVisible = true;
            _homePage.Lvicc11PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc11On)
            {
                icc11On = false;
                Icc11SideMenu = "OFF";
                Icc11SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc11BorderBrush = new SolidColorBrush(Colors.Black);
                Icc11BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc11PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc11Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc11Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc11Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc11Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc11Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc11Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc11Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc11Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc11Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc11Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc11Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc11Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc11Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc11Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc11Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc11Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc11Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc11MessageData = (byte)(icc11MessageData ^ fOffByte ^ fOnByte);

                if (icc11Low)
                {
                    icc11Low = false;
                    icc11MessageData = (byte)(icc11MessageData ^ fLowByte);
                }
                if (icc11Med)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fMedByte);
                    icc11Med = false;
                }
                if (icc11High)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fHighByte);
                    icc11High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc11On && !icc11Low)
            {
                if (icc11Med)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fMedByte);
                    icc11Med = false;
                }
                if (icc11High)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fHighByte);
                    icc11High = false;
                }
                icc11Low = true;
                Icc11SideMenu = "LOW";
                Icc11SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc11BorderBrush = new SolidColorBrush(Colors.Green);
                Icc11BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc11PgBackground = new SolidColorBrush(Colors.Green);

                _icc11Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc11Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc11Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc11Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc11Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc11Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc11MessageData = (byte)(icc11MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc11On && !icc11Med)
            {
                if (icc11Low)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fLowByte);
                    icc11Low = false;
                }
                if (icc11High)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fHighByte);
                    icc11High = false;
                }
                icc11Med = true;
                Icc11SideMenu = "MED";
                Icc11SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc11BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc11BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc11PgBackground = new SolidColorBrush(Colors.Green);

                _icc11Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc11Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc11Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc11Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc11Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc11Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc11MessageData = (byte)(icc11MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc11On && !icc11High)
            {
                if (icc11Low)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fLowByte);
                    icc11Low = false;
                }
                if (icc11Med)
                {
                    icc11MessageData = (byte)(icc11MessageData ^ fMedByte);
                    icc11Med = false;
                }
                icc11High = true;
                Icc11SideMenu = "HIGH";
                Icc11SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc11BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc11BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc11PgBackground = new SolidColorBrush(Colors.Green);

                _icc11Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc11Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc11Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc11Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc11Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc11Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc11MessageData = (byte)(icc11MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc11Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc11Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc11Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc11Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc11Page.ModeStatus = "ALSF";
            _icc11Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc11Page.ModeStatus = "MALSR";
            _icc11Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc11Page.ModeStatus = "LDIN";
            _icc11Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc11Page.ModeStatus = "REIL";
            _icc11Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc11Page.ControlType = "Discrete";
            _icc11Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc11Page.ControlType = "Serial";
            _icc11Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc11Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc11Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc11Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc11Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc11Compat = true;
            _icc11Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc11Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc11Compat = false;
            _icc11Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc11Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc11MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc11MessageData, "ICC11");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 11 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc11Page.IsCommandErrorVisible = true;
            _homePage.Lvicc11PgStatus = true;
        }
        else
        {
            _icc11Page.IsCommandErrorVisible = false;
            _homePage.Lvicc11PgStatus = false;
        }
    }

    private void ReadIcc12Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc12Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc12Page.RemForeground = new SolidColorBrush(Colors.White);
            icc12Rem = true;
            _icc12Page.IsCommandErrorVisible = false;
            _homePage.Lvicc12PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc12Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc12Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc12Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 12 remote is turned OFF.\n";

            // activate mode error
            _icc12Page.IsCommandErrorVisible = true;
            _homePage.Lvicc12PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc12On)
            {
                icc12On = false;
                Icc12SideMenu = "OFF";
                Icc12SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc12BorderBrush = new SolidColorBrush(Colors.Black);
                Icc12BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc12PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc12Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc12Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc12Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc12Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc12Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc12Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc12Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc12Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc12Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc12Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc12Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc12Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc12Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc12Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc12Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc12Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc12Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc12MessageData = (byte)(icc12MessageData ^ fOffByte ^ fOnByte);

                if (icc12Low)
                {
                    icc12Low = false;
                    icc12MessageData = (byte)(icc12MessageData ^ fLowByte);
                }
                if (icc12Med)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fMedByte);
                    icc12Med = false;
                }
                if (icc12High)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fHighByte);
                    icc12High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc12On && !icc12Low)
            {
                if (icc12Med)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fMedByte);
                    icc12Med = false;
                }
                if (icc12High)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fHighByte);
                    icc12High = false;
                }
                icc12Low = true;
                Icc12SideMenu = "LOW";
                Icc12SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc12BorderBrush = new SolidColorBrush(Colors.Green);
                Icc12BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc12PgBackground = new SolidColorBrush(Colors.Green);

                _icc12Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc12Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc12Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc12Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc12Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc12Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc12MessageData = (byte)(icc12MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc12On && !icc12Med)
            {
                if (icc12Low)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fLowByte);
                    icc12Low = false;
                }
                if (icc12High)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fHighByte);
                    icc12High = false;
                }
                icc12Med = true;
                Icc12SideMenu = "MED";
                Icc12SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc12BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc12BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc12PgBackground = new SolidColorBrush(Colors.Green);

                _icc12Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc12Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc12Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc12Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc12Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc12Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc12MessageData = (byte)(icc12MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc12On && !icc12High)
            {
                if (icc12Low)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fLowByte);
                    icc12Low = false;
                }
                if (icc12Med)
                {
                    icc12MessageData = (byte)(icc12MessageData ^ fMedByte);
                    icc12Med = false;
                }
                icc12High = true;
                Icc12SideMenu = "HIGH";
                Icc12SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc12BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc12BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc12PgBackground = new SolidColorBrush(Colors.Green);

                _icc12Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc12Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc12Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc12Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc12Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc12Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc12MessageData = (byte)(icc12MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc12Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc12Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc12Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc12Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc12Page.ModeStatus = "ALSF";
            _icc12Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc12Page.ModeStatus = "MALSR";
            _icc12Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc12Page.ModeStatus = "LDIN";
            _icc12Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc12Page.ModeStatus = "REIL";
            _icc12Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc12Page.ControlType = "Discrete";
            _icc12Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc12Page.ControlType = "Serial";
            _icc12Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc12Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc12Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc12Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc12Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc12Compat = true;
            _icc12Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc12Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc12Compat = false;
            _icc12Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc12Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc12MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc12MessageData, "ICC12");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 12 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc12Page.IsCommandErrorVisible = true;
            _homePage.Lvicc12PgStatus = true;
        }
        else
        {
            _icc12Page.IsCommandErrorVisible = false;
            _homePage.Lvicc12PgStatus = false;
        }
    }

    private void ReadIcc13Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc13Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc13Page.RemForeground = new SolidColorBrush(Colors.White);
            icc13Rem = true;
            _icc13Page.IsCommandErrorVisible = false;
            _homePage.Lvicc13PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc13Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc13Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc13Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 13 remote is turned OFF.\n";

            // activate mode error
            _icc13Page.IsCommandErrorVisible = true;
            _homePage.Lvicc13PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc13On)
            {
                icc13On = false;
                Icc13SideMenu = "OFF";
                Icc13SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc13BorderBrush = new SolidColorBrush(Colors.Black);
                Icc13BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc13PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc13Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc13Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc13Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc13Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc13Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc13Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc13Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc13Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc13Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc13Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc13Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc13Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc13Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc13Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc13Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc13Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc13Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc13MessageData = (byte)(icc13MessageData ^ fOffByte ^ fOnByte);

                if (icc13Low)
                {
                    icc13Low = false;
                    icc13MessageData = (byte)(icc13MessageData ^ fLowByte);
                }
                if (icc13Med)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fMedByte);
                    icc13Med = false;
                }
                if (icc13High)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fHighByte);
                    icc13High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc13On && !icc13Low)
            {
                if (icc13Med)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fMedByte);
                    icc13Med = false;
                }
                if (icc13High)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fHighByte);
                    icc13High = false;
                }
                icc13Low = true;
                Icc13SideMenu = "LOW";
                Icc13SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc13BorderBrush = new SolidColorBrush(Colors.Green);
                Icc13BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc13PgBackground = new SolidColorBrush(Colors.Green);

                _icc13Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc13Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc13Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc13Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc13Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc13Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc13MessageData = (byte)(icc13MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc13On && !icc13Med)
            {
                if (icc13Low)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fLowByte);
                    icc13Low = false;
                }
                if (icc13High)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fHighByte);
                    icc13High = false;
                }
                icc13Med = true;
                Icc13SideMenu = "MED";
                Icc13SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc13BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc13BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc13PgBackground = new SolidColorBrush(Colors.Green);

                _icc13Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc13Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc13Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc13Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc13Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc13Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc13MessageData = (byte)(icc13MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc13On && !icc13High)
            {
                if (icc13Low)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fLowByte);
                    icc13Low = false;
                }
                if (icc13Med)
                {
                    icc13MessageData = (byte)(icc13MessageData ^ fMedByte);
                    icc13Med = false;
                }
                icc13High = true;
                Icc13SideMenu = "HIGH";
                Icc13SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc13BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc13BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc13PgBackground = new SolidColorBrush(Colors.Green);

                _icc13Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc13Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc13Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc13Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc13Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc13Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc13MessageData = (byte)(icc13MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc13Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc13Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc13Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc13Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc13Page.ModeStatus = "ALSF";
            _icc13Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc13Page.ModeStatus = "MALSR";
            _icc13Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc13Page.ModeStatus = "LDIN";
            _icc13Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc13Page.ModeStatus = "REIL";
            _icc13Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc13Page.ControlType = "Discrete";
            _icc13Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc13Page.ControlType = "Serial";
            _icc13Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc13Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc13Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc13Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc13Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc13Compat = true;
            _icc13Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc13Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc13Compat = false;
            _icc13Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc13Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc13MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc13MessageData, "ICC13");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 13 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc13Page.IsCommandErrorVisible = true;
            _homePage.Lvicc13PgStatus = true;
        }
        else
        {
            _icc13Page.IsCommandErrorVisible = false;
            _homePage.Lvicc13PgStatus = false;
        }
    }

    private void ReadIcc14Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc14Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc14Page.RemForeground = new SolidColorBrush(Colors.White);
            icc14Rem = true;
            _icc14Page.IsCommandErrorVisible = false;
            _homePage.Lvicc14PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc14Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc14Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc14Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 14 remote is turned OFF.\n";

            // activate mode error
            _icc14Page.IsCommandErrorVisible = true;
            _homePage.Lvicc14PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc14On)
            {
                icc14On = false;
                Icc14SideMenu = "OFF";
                Icc14SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc14BorderBrush = new SolidColorBrush(Colors.Black);
                Icc14BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc14PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc14Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc14Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc14Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc14Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc14Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc14Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc14Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc14Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc14Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc14Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc14Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc14Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc14Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc14Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc14Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc14Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc14Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc14MessageData = (byte)(icc14MessageData ^ fOffByte ^ fOnByte);

                if (icc14Low)
                {
                    icc14Low = false;
                    icc14MessageData = (byte)(icc14MessageData ^ fLowByte);
                }
                if (icc14Med)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fMedByte);
                    icc14Med = false;
                }
                if (icc14High)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fHighByte);
                    icc14High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc14On && !icc14Low)
            {
                if (icc14Med)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fMedByte);
                    icc14Med = false;
                }
                if (icc14High)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fHighByte);
                    icc14High = false;
                }
                icc14Low = true;
                Icc14SideMenu = "LOW";
                Icc14SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc14BorderBrush = new SolidColorBrush(Colors.Green);
                Icc14BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc14PgBackground = new SolidColorBrush(Colors.Green);

                _icc14Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc14Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc14Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc14Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc14Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc14Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc14MessageData = (byte)(icc14MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc14On && !icc14Med)
            {
                if (icc14Low)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fLowByte);
                    icc14Low = false;
                }
                if (icc14High)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fHighByte);
                    icc14High = false;
                }
                icc14Med = true;
                Icc14SideMenu = "MED";
                Icc14SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc14BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc14BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc14PgBackground = new SolidColorBrush(Colors.Green);

                _icc14Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc14Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc14Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc14Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc14Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc14Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc14MessageData = (byte)(icc14MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc14On && !icc14High)
            {
                if (icc14Low)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fLowByte);
                    icc14Low = false;
                }
                if (icc14Med)
                {
                    icc14MessageData = (byte)(icc14MessageData ^ fMedByte);
                    icc14Med = false;
                }
                icc14High = true;
                Icc14SideMenu = "HIGH";
                Icc14SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc14BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc14BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc14PgBackground = new SolidColorBrush(Colors.Green);

                _icc14Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc14Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc14Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc14Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc14Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc14Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc14MessageData = (byte)(icc14MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc14Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc14Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc14Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc14Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc14Page.ModeStatus = "ALSF";
            _icc14Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc14Page.ModeStatus = "MALSR";
            _icc14Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc14Page.ModeStatus = "LDIN";
            _icc14Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc14Page.ModeStatus = "REIL";
            _icc14Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc14Page.ControlType = "Discrete";
            _icc14Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc14Page.ControlType = "Serial";
            _icc14Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc14Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc14Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc14Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc14Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc14Compat = true;
            _icc14Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc14Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc14Compat = false;
            _icc14Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc14Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc14MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc14MessageData, "ICC14");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 14 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc14Page.IsCommandErrorVisible = true;
            _homePage.Lvicc14PgStatus = true;
        }
        else
        {
            _icc14Page.IsCommandErrorVisible = false;
            _homePage.Lvicc14PgStatus = false;
        }
    }

    private void ReadIcc15Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc15Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc15Page.RemForeground = new SolidColorBrush(Colors.White);
            icc15Rem = true;
            _icc15Page.IsCommandErrorVisible = false;
            _homePage.Lvicc15PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc15Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc15Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc15Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 15 remote is turned OFF.\n";

            // activate mode error
            _icc15Page.IsCommandErrorVisible = true;
            _homePage.Lvicc15PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc15On)
            {
                icc15On = false;
                Icc15SideMenu = "OFF";
                Icc15SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc15BorderBrush = new SolidColorBrush(Colors.Black);
                Icc15BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc15PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc15Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc15Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc15Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc15Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc15Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc15Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc15Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc15Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc15Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc15Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc15Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc15Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc15Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc15Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc15Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc15Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc15Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc15MessageData = (byte)(icc15MessageData ^ fOffByte ^ fOnByte);

                if (icc15Low)
                {
                    icc15Low = false;
                    icc15MessageData = (byte)(icc15MessageData ^ fLowByte);
                }
                if (icc15Med)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fMedByte);
                    icc15Med = false;
                }
                if (icc15High)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fHighByte);
                    icc15High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc15On && !icc15Low)
            {
                if (icc15Med)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fMedByte);
                    icc15Med = false;
                }
                if (icc15High)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fHighByte);
                    icc15High = false;
                }
                icc15Low = true;
                Icc15SideMenu = "LOW";
                Icc15SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc15BorderBrush = new SolidColorBrush(Colors.Green);
                Icc15BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc15PgBackground = new SolidColorBrush(Colors.Green);

                _icc15Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc15Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc15Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc15Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc15Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc15Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc15MessageData = (byte)(icc15MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc15On && !icc15Med)
            {
                if (icc15Low)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fLowByte);
                    icc15Low = false;
                }
                if (icc15High)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fHighByte);
                    icc15High = false;
                }
                icc15Med = true;
                Icc15SideMenu = "MED";
                Icc15SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc15BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc15BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc15PgBackground = new SolidColorBrush(Colors.Green);

                _icc15Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc15Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc15Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc15Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc15Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc15Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc15MessageData = (byte)(icc15MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc15On && !icc15High)
            {
                if (icc15Low)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fLowByte);
                    icc15Low = false;
                }
                if (icc15Med)
                {
                    icc15MessageData = (byte)(icc15MessageData ^ fMedByte);
                    icc15Med = false;
                }
                icc15High = true;
                Icc15SideMenu = "HIGH";
                Icc15SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc15BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc15BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc15PgBackground = new SolidColorBrush(Colors.Green);

                _icc15Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc15Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc15Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc15Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc15Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc15Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc15MessageData = (byte)(icc15MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc15Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc15Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc15Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc15Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc15Page.ModeStatus = "ALSF";
            _icc15Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc15Page.ModeStatus = "MALSR";
            _icc15Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc15Page.ModeStatus = "LDIN";
            _icc15Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc15Page.ModeStatus = "REIL";
            _icc15Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc15Page.ControlType = "Discrete";
            _icc15Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc15Page.ControlType = "Serial";
            _icc15Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc15Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc15Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc15Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc15Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc15Compat = true;
            _icc15Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc15Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc15Compat = false;
            _icc15Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc15Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc15MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc15MessageData, "ICC15");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 15 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc15Page.IsCommandErrorVisible = true;
            _homePage.Lvicc15PgStatus = true;
        }
        else
        {
            _icc15Page.IsCommandErrorVisible = false;
            _homePage.Lvicc15PgStatus = false;
        }
    }

    private void ReadIcc16Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc16Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc16Page.RemForeground = new SolidColorBrush(Colors.White);
            icc16Rem = true;
            _icc16Page.IsCommandErrorVisible = false;
            _homePage.Lvicc16PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc16Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc16Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc16Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 16 remote is turned OFF.\n";

            // activate mode error
            _icc16Page.IsCommandErrorVisible = true;
            _homePage.Lvicc16PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc16On)
            {
                icc16On = false;
                Icc16SideMenu = "OFF";
                Icc16SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc16BorderBrush = new SolidColorBrush(Colors.Black);
                Icc16BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc16PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc16Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc16Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc16Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc16Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc16Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc16Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc16Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc16Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc16Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc16Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc16Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc16Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc16Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc16Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc16Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc16Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc16Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc16MessageData = (byte)(icc16MessageData ^ fOffByte ^ fOnByte);

                if (icc16Low)
                {
                    icc16Low = false;
                    icc16MessageData = (byte)(icc16MessageData ^ fLowByte);
                }
                if (icc16Med)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fMedByte);
                    icc16Med = false;
                }
                if (icc16High)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fHighByte);
                    icc16High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc16On && !icc16Low)
            {
                if (icc16Med)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fMedByte);
                    icc16Med = false;
                }
                if (icc16High)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fHighByte);
                    icc16High = false;
                }
                icc16Low = true;
                Icc16SideMenu = "LOW";
                Icc16SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc16BorderBrush = new SolidColorBrush(Colors.Green);
                Icc16BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc16PgBackground = new SolidColorBrush(Colors.Green);

                _icc16Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc16Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc16Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc16Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc16Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc16Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc16MessageData = (byte)(icc16MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc16On && !icc16Med)
            {
                if (icc16Low)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fLowByte);
                    icc16Low = false;
                }
                if (icc16High)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fHighByte);
                    icc16High = false;
                }
                icc16Med = true;
                Icc16SideMenu = "MED";
                Icc16SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc16BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc16BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc16PgBackground = new SolidColorBrush(Colors.Green);

                _icc16Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc16Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc16Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc16Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc16Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc16Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc16MessageData = (byte)(icc16MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc16On && !icc16High)
            {
                if (icc16Low)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fLowByte);
                    icc16Low = false;
                }
                if (icc16Med)
                {
                    icc16MessageData = (byte)(icc16MessageData ^ fMedByte);
                    icc16Med = false;
                }
                icc16High = true;
                Icc16SideMenu = "HIGH";
                Icc16SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc16BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc16BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc16PgBackground = new SolidColorBrush(Colors.Green);

                _icc16Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc16Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc16Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc16Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc16Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc16Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc16MessageData = (byte)(icc16MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc16Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc16Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc16Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc16Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc16Page.ModeStatus = "ALSF";
            _icc16Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc16Page.ModeStatus = "MALSR";
            _icc16Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc16Page.ModeStatus = "LDIN";
            _icc16Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc16Page.ModeStatus = "REIL";
            _icc16Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc16Page.ControlType = "Discrete";
            _icc16Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc16Page.ControlType = "Serial";
            _icc16Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc16Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc16Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc16Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc16Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc16Compat = true;
            _icc16Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc16Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc16Compat = false;
            _icc16Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc16Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc16MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc16MessageData, "ICC16");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 16 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc16Page.IsCommandErrorVisible = true;
            _homePage.Lvicc16PgStatus = true;
        }
        else
        {
            _icc16Page.IsCommandErrorVisible = false;
            _homePage.Lvicc16PgStatus = false;
        }
    }

    private void ReadIcc17Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc17Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc17Page.RemForeground = new SolidColorBrush(Colors.White);
            icc17Rem = true;
            _icc17Page.IsCommandErrorVisible = false;
            _homePage.Lvicc17PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc17Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc17Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc17Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 17 remote is turned OFF.\n";

            // activate mode error
            _icc17Page.IsCommandErrorVisible = true;
            _homePage.Lvicc17PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc17On)
            {
                icc17On = false;
                Icc17SideMenu = "OFF";
                Icc17SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc17BorderBrush = new SolidColorBrush(Colors.Black);
                Icc17BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc17PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc17Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc17Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc17Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc17Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc17Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc17Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc17Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc17Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc17Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc17Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc17Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc17Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc17Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc17Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc17Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc17Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc17Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc17MessageData = (byte)(icc17MessageData ^ fOffByte ^ fOnByte);

                if (icc17Low)
                {
                    icc17Low = false;
                    icc17MessageData = (byte)(icc17MessageData ^ fLowByte);
                }
                if (icc17Med)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fMedByte);
                    icc17Med = false;
                }
                if (icc17High)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fHighByte);
                    icc17High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc17On && !icc17Low)
            {
                if (icc17Med)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fMedByte);
                    icc17Med = false;
                }
                if (icc17High)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fHighByte);
                    icc17High = false;
                }
                icc17Low = true;
                Icc17SideMenu = "LOW";
                Icc17SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc17BorderBrush = new SolidColorBrush(Colors.Green);
                Icc17BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc17PgBackground = new SolidColorBrush(Colors.Green);

                _icc17Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc17Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc17Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc17Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc17Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc17Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc17MessageData = (byte)(icc17MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc17On && !icc17Med)
            {
                if (icc17Low)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fLowByte);
                    icc17Low = false;
                }
                if (icc17High)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fHighByte);
                    icc17High = false;
                }
                icc17Med = true;
                Icc17SideMenu = "MED";
                Icc17SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc17BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc17BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc17PgBackground = new SolidColorBrush(Colors.Green);

                _icc17Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc17Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc17Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc17Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc17Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc17Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc17MessageData = (byte)(icc17MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc17On && !icc17High)
            {
                if (icc17Low)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fLowByte);
                    icc17Low = false;
                }
                if (icc17Med)
                {
                    icc17MessageData = (byte)(icc17MessageData ^ fMedByte);
                    icc17Med = false;
                }
                icc17High = true;
                Icc17SideMenu = "HIGH";
                Icc17SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc17BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc17BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc17PgBackground = new SolidColorBrush(Colors.Green);

                _icc17Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc17Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc17Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc17Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc17Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc17Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc17MessageData = (byte)(icc17MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc17Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc17Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc17Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc17Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc17Page.ModeStatus = "ALSF";
            _icc17Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc17Page.ModeStatus = "MALSR";
            _icc17Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc17Page.ModeStatus = "LDIN";
            _icc17Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc17Page.ModeStatus = "REIL";
            _icc17Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc17Page.ControlType = "Discrete";
            _icc17Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc17Page.ControlType = "Serial";
            _icc17Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc17Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc17Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc17Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc17Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc17Compat = true;
            _icc17Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc17Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc17Compat = false;
            _icc17Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc17Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc17MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc17MessageData, "ICC17");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 17 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc17Page.IsCommandErrorVisible = true;
            _homePage.Lvicc17PgStatus = true;
        }
        else
        {
            _icc17Page.IsCommandErrorVisible = false;
            _homePage.Lvicc17PgStatus = false;
        }
    }

    private void ReadIcc18Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc18Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc18Page.RemForeground = new SolidColorBrush(Colors.White);
            icc18Rem = true;
            _icc18Page.IsCommandErrorVisible = false;
            _homePage.Lvicc18PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc18Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc18Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc18Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 18 remote is turned OFF.\n";

            // activate mode error
            _icc18Page.IsCommandErrorVisible = true;
            _homePage.Lvicc18PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc18On)
            {
                icc18On = false;
                Icc18SideMenu = "OFF";
                Icc18SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc18BorderBrush = new SolidColorBrush(Colors.Black);
                Icc18BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc18PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc18Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc18Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc18Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc18Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc18Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc18Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc18Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc18Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc18Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc18Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc18Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc18Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc18Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc18Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc18Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc18Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc18Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc18MessageData = (byte)(icc18MessageData ^ fOffByte ^ fOnByte);

                if (icc18Low)
                {
                    icc18Low = false;
                    icc18MessageData = (byte)(icc18MessageData ^ fLowByte);
                }
                if (icc18Med)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fMedByte);
                    icc18Med = false;
                }
                if (icc18High)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fHighByte);
                    icc18High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc18On && !icc18Low)
            {
                if (icc18Med)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fMedByte);
                    icc18Med = false;
                }
                if (icc18High)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fHighByte);
                    icc18High = false;
                }
                icc18Low = true;
                Icc18SideMenu = "LOW";
                Icc18SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc18BorderBrush = new SolidColorBrush(Colors.Green);
                Icc18BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc18PgBackground = new SolidColorBrush(Colors.Green);

                _icc18Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc18Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc18Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc18Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc18Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc18Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc18MessageData = (byte)(icc18MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc18On && !icc18Med)
            {
                if (icc18Low)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fLowByte);
                    icc18Low = false;
                }
                if (icc18High)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fHighByte);
                    icc18High = false;
                }
                icc18Med = true;
                Icc18SideMenu = "MED";
                Icc18SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc18BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc18BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc18PgBackground = new SolidColorBrush(Colors.Green);

                _icc18Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc18Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc18Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc18Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc18Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc18Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc18MessageData = (byte)(icc18MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc18On && !icc18High)
            {
                if (icc18Low)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fLowByte);
                    icc18Low = false;
                }
                if (icc18Med)
                {
                    icc18MessageData = (byte)(icc18MessageData ^ fMedByte);
                    icc18Med = false;
                }
                icc18High = true;
                Icc18SideMenu = "HIGH";
                Icc18SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc18BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc18BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc18PgBackground = new SolidColorBrush(Colors.Green);

                _icc18Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc18Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc18Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc18Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc18Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc18Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc18MessageData = (byte)(icc18MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc18Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc18Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc18Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc18Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc18Page.ModeStatus = "ALSF";
            _icc18Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc18Page.ModeStatus = "MALSR";
            _icc18Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc18Page.ModeStatus = "LDIN";
            _icc18Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc18Page.ModeStatus = "REIL";
            _icc18Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc18Page.ControlType = "Discrete";
            _icc18Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc18Page.ControlType = "Serial";
            _icc18Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc18Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc18Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc18Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc18Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc18Compat = true;
            _icc18Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc18Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc18Compat = false;
            _icc18Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc18Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc18MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc18MessageData, "ICC18");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 18 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc18Page.IsCommandErrorVisible = true;
            _homePage.Lvicc18PgStatus = true;
        }
        else
        {
            _icc18Page.IsCommandErrorVisible = false;
            _homePage.Lvicc18PgStatus = false;
        }
    }

    private void ReadIcc19Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc19Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc19Page.RemForeground = new SolidColorBrush(Colors.White);
            icc19Rem = true;
            _icc19Page.IsCommandErrorVisible = false;
            _homePage.Lvicc19PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc19Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc19Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc19Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 19 remote is turned OFF.\n";

            // activate mode error
            _icc19Page.IsCommandErrorVisible = true;
            _homePage.Lvicc19PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc19On)
            {
                icc19On = false;
                Icc19SideMenu = "OFF";
                Icc19SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc19BorderBrush = new SolidColorBrush(Colors.Black);
                Icc19BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc19PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc19Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc19Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc19Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc19Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc19Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc19Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc19Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc19Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc19Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc19Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc19Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc19Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc19Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc19Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc19Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc19Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc19Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc19MessageData = (byte)(icc19MessageData ^ fOffByte ^ fOnByte);

                if (icc19Low)
                {
                    icc19Low = false;
                    icc19MessageData = (byte)(icc19MessageData ^ fLowByte);
                }
                if (icc19Med)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fMedByte);
                    icc19Med = false;
                }
                if (icc19High)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fHighByte);
                    icc19High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc19On && !icc19Low)
            {
                if (icc19Med)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fMedByte);
                    icc19Med = false;
                }
                if (icc19High)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fHighByte);
                    icc19High = false;
                }
                icc19Low = true;
                Icc19SideMenu = "LOW";
                Icc19SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc19BorderBrush = new SolidColorBrush(Colors.Green);
                Icc19BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc19PgBackground = new SolidColorBrush(Colors.Green);

                _icc19Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc19Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc19Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc19Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc19Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc19Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc19MessageData = (byte)(icc19MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc19On && !icc19Med)
            {
                if (icc19Low)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fLowByte);
                    icc19Low = false;
                }
                if (icc19High)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fHighByte);
                    icc19High = false;
                }
                icc19Med = true;
                Icc19SideMenu = "MED";
                Icc19SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc19BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc19BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc19PgBackground = new SolidColorBrush(Colors.Green);

                _icc19Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc19Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc19Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc19Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc19Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc19Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc19MessageData = (byte)(icc19MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc19On && !icc19High)
            {
                if (icc19Low)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fLowByte);
                    icc19Low = false;
                }
                if (icc19Med)
                {
                    icc19MessageData = (byte)(icc19MessageData ^ fMedByte);
                    icc19Med = false;
                }
                icc19High = true;
                Icc19SideMenu = "HIGH";
                Icc19SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc19BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc19BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc19PgBackground = new SolidColorBrush(Colors.Green);

                _icc19Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc19Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc19Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc19Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc19Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc19Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc19MessageData = (byte)(icc19MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc19Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc19Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc19Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc19Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc19Page.ModeStatus = "ALSF";
            _icc19Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc19Page.ModeStatus = "MALSR";
            _icc19Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc19Page.ModeStatus = "LDIN";
            _icc19Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc19Page.ModeStatus = "REIL";
            _icc19Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc19Page.ControlType = "Discrete";
            _icc19Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc19Page.ControlType = "Serial";
            _icc19Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc19Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc19Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc19Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc19Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc19Compat = true;
            _icc19Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc19Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc19Compat = false;
            _icc19Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc19Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc19MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc19MessageData, "ICC19");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 19 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc19Page.IsCommandErrorVisible = true;
            _homePage.Lvicc19PgStatus = true;
        }
        else
        {
            _icc19Page.IsCommandErrorVisible = false;
            _homePage.Lvicc19PgStatus = false;
        }
    }

    private void ReadIcc20Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc20Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc20Page.RemForeground = new SolidColorBrush(Colors.White);
            icc20Rem = true;
            _icc20Page.IsCommandErrorVisible = false;
            _homePage.Lvicc20PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc20Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc20Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc20Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 20 remote is turned OFF.\n";

            // activate mode error
            _icc20Page.IsCommandErrorVisible = true;
            _homePage.Lvicc20PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc20On)
            {
                icc20On = false;
                Icc20SideMenu = "OFF";
                Icc20SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc20BorderBrush = new SolidColorBrush(Colors.Black);
                Icc20BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc20PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc20Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc20Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc20Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc20Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc20Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc20Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc20Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc20Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc20Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc20Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc20Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc20Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc20Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc20Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc20Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc20Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc20Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc20Rem = false;

                icc20MessageData = (byte)(icc20MessageData ^ fOffByte);
                icc20MessageData = (byte)(icc20MessageData ^ fOnByte);

                if (icc20Low)
                {
                    icc20Low = false;
                    icc20MessageData = (byte)(icc20MessageData ^ fLowByte);
                }
                if (icc20Med)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fMedByte);
                    icc20Med = false;
                }
                if (icc20High)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fHighByte);
                    icc20High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc20On && !icc20Low)
            {
                if (icc20Med)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fMedByte);
                    icc20Med = false;
                }
                if (icc20High)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fHighByte);
                    icc20High = false;
                }
                icc20Low = true;
                Icc20SideMenu = "LOW";
                Icc20SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc20BorderBrush = new SolidColorBrush(Colors.Green);
                Icc20BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc20PgBackground = new SolidColorBrush(Colors.Green);

                _icc20Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc20Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc20Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc20Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc20Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc20Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc20MessageData = (byte)(icc20MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc20On && !icc20Med)
            {
                if (icc20Low)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fLowByte);
                    icc20Low = false;
                }
                if (icc20High)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fHighByte);
                    icc20High = false;
                }
                icc20Med = true;
                Icc20SideMenu = "MED";
                Icc20SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc20BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc20BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc20PgBackground = new SolidColorBrush(Colors.Green);

                _icc20Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc20Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc20Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc20Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc20Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc20Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc20MessageData = (byte)(icc20MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc20On && !icc20High)
            {
                if (icc20Low)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fLowByte);
                    icc20Low = false;
                }
                if (icc20Med)
                {
                    icc20MessageData = (byte)(icc20MessageData ^ fMedByte);
                    icc20Med = false;
                }
                icc20High = true;
                Icc20SideMenu = "HIGH";
                Icc20SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc20BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc20BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc20PgBackground = new SolidColorBrush(Colors.Green);

                _icc20Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc20Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc20Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc20Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc20Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc20Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc20MessageData = (byte)(icc20MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc20Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc20Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc20Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc20Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc20Page.ModeStatus = "ALSF";
            _icc20Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc20Page.ModeStatus = "MALSR";
            _icc20Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc20Page.ModeStatus = "LDIN";
            _icc20Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc20Page.ModeStatus = "REIL";
            _icc20Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc20Page.ControlType = "Discrete";
            _icc20Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc20Page.ControlType = "Serial";
            _icc20Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc20Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc20Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc20Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc20Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc20Compat = true;
            _icc20Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc20Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc20Compat = false;
            _icc20Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc20Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc20MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc20MessageData, "ICC20");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 20 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc20Page.IsCommandErrorVisible = true;
            _homePage.Lvicc20PgStatus = true;
        }
        else
        {
            _icc20Page.IsCommandErrorVisible = false;
            _homePage.Lvicc20PgStatus = false;
        }
    }

    private void ReadIcc21Config(byte param1, byte param2)
    {
        if ((param2 & remoteConfig) == remoteConfig)
        {
            _icc21Page.RemButton = new SolidColorBrush(Colors.Green);
            _icc21Page.RemForeground = new SolidColorBrush(Colors.White);
            icc21Rem = true;
            _icc21Page.IsCommandErrorVisible = false;
            _homePage.Lvicc21PgStatus = false;
        }
        else if ((param2 & remoteConfig) == 0)
        {
            _icc21Page.RemButton = new SolidColorBrush(Colors.LightGray);
            _icc21Page.RemForeground = new SolidColorBrush(Colors.Black);
            icc21Rem = false;
            _homePage.LogText += "\nMODE ERROR: LVICC 21 remote is turned OFF.\n";

            // activate mode error
            _icc21Page.IsCommandErrorVisible = true;
            _homePage.Lvicc21PgStatus = true;
        }
        if ((param2 & offConfig) == offConfig)
        {
            if (icc21On)
            {
                icc21On = false;
                Icc21SideMenu = "OFF";
                Icc21SideBackground = new SolidColorBrush(Colors.LightGray);
                Icc21BorderBrush = new SolidColorBrush(Colors.Black);
                Icc21BorderBackground = new SolidColorBrush(Colors.Black);
                _homePage.Lvicc21PgBackground = new SolidColorBrush(Colors.LightGray);

                _icc21Page.OffButton = new SolidColorBrush(Colors.DarkGray);
                _icc21Page.OffForeground = new SolidColorBrush(Colors.White);
                _icc21Page.RemButton = new SolidColorBrush(Colors.LightGray);
                _icc21Page.RemForeground = new SolidColorBrush(Colors.Black);
                _icc21Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc21Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc21Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc21Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc21Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc21Page.HighForeground = new SolidColorBrush(Colors.Black);
                _icc21Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
                _icc21Page.MtBackground = new SolidColorBrush(Colors.LightGray);
                _icc21Page.ModeBackground = new SolidColorBrush(Colors.LightGray);
                _icc21Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
                _icc21Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
                _icc21Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
                _icc21Page.CompatBackground = new SolidColorBrush(Colors.LightGray);

                icc21MessageData = (byte)(icc21MessageData ^ fOffByte ^ fOnByte);

                if (icc21Low)
                {
                    icc21Low = false;
                    icc21MessageData = (byte)(icc21MessageData ^ fLowByte);
                }
                if (icc21Med)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fMedByte);
                    icc21Med = false;
                }
                if (icc21High)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fHighByte);
                    icc21High = false;
                }
            }
        }
        if ((param2 & lowConfig) == lowConfig)
        {
            if (icc21On && !icc21Low)
            {
                if (icc21Med)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fMedByte);
                    icc21Med = false;
                }
                if (icc21High)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fHighByte);
                    icc21High = false;
                }
                icc21Low = true;
                Icc21SideMenu = "LOW";
                Icc21SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc21BorderBrush = new SolidColorBrush(Colors.Green);
                Icc21BorderBackground = new SolidColorBrush(Colors.Green);
                _homePage.Lvicc21PgBackground = new SolidColorBrush(Colors.Green);

                _icc21Page.LowButton = new SolidColorBrush(Colors.Green);
                _icc21Page.LowForeground = new SolidColorBrush(Colors.White);
                _icc21Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc21Page.MedForeground = new SolidColorBrush(Colors.Black);
                _icc21Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc21Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc21MessageData = (byte)(icc21MessageData ^ fLowByte);

            }
        }
        if ((param2 & medConfig) == medConfig)
        {
            if (icc21On && !icc21Med)
            {
                if (icc21Low)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fLowByte);
                    icc21Low = false;
                }
                if (icc21High)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fHighByte);
                    icc21High = false;
                }
                icc21Med = true;
                Icc21SideMenu = "MED";
                Icc21SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc21BorderBrush = new SolidColorBrush(Colors.Orange);
                Icc21BorderBackground = new SolidColorBrush(Colors.Orange);
                _homePage.Lvicc21PgBackground = new SolidColorBrush(Colors.Green);

                _icc21Page.MedButton = new SolidColorBrush(Colors.Green);
                _icc21Page.MedForeground = new SolidColorBrush(Colors.White);
                _icc21Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc21Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc21Page.HighButton = new SolidColorBrush(Colors.LightGray);
                _icc21Page.HighForeground = new SolidColorBrush(Colors.Black);

                icc21MessageData = (byte)(icc21MessageData ^ fMedByte);

            }
        }
        if ((param2 & highConfig) == highConfig)
        {
            if (icc21On && !icc21High)
            {
                if (icc21Low)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fLowByte);
                    icc21Low = false;
                }
                if (icc21Med)
                {
                    icc21MessageData = (byte)(icc21MessageData ^ fMedByte);
                    icc21Med = false;
                }
                icc21High = true;
                Icc21SideMenu = "HIGH";
                Icc21SideBackground = new SolidColorBrush(Colors.LightGreen);
                Icc21BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                Icc21BorderBackground = new SolidColorBrush(Colors.OrangeRed);
                _homePage.Lvicc21PgBackground = new SolidColorBrush(Colors.Green);

                _icc21Page.HighButton = new SolidColorBrush(Colors.Green);
                _icc21Page.HighForeground = new SolidColorBrush(Colors.White);
                _icc21Page.LowButton = new SolidColorBrush(Colors.LightGray);
                _icc21Page.LowForeground = new SolidColorBrush(Colors.Black);
                _icc21Page.MedButton = new SolidColorBrush(Colors.LightGray);
                _icc21Page.MedForeground = new SolidColorBrush(Colors.Black);

                icc21MessageData = (byte)(icc21MessageData ^ fHighByte);

            }
        }
        if ((param2 & flashOpen) == flashOpen)
        {
            _icc21Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & flashOpen) == 0)
        {
            _icc21Page.FlashHeadBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param2 & mtConnected) == mtConnected)
        {
            _icc21Page.MtBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param2 & mtConnected) == 0)
        {
            _icc21Page.MtBackground = new SolidColorBrush(Colors.LightGray);
        }
        if ((param1 & alsfConfig) == alsfConfig)
        {
            _icc21Page.ModeStatus = "ALSF";
            _icc21Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & malsrConfig) == malsrConfig)
        {
            _icc21Page.ModeStatus = "MALSR";
            _icc21Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & ldinConfig) == ldinConfig)
        {
            _icc21Page.ModeStatus = "LDIN";
            _icc21Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & reilConfig) == reilConfig)
        {
            _icc21Page.ModeStatus = "REIL";
            _icc21Page.ModeBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & controlConfig) == controlConfig)
        {
            _icc21Page.ControlType = "Discrete";
            _icc21Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        else if ((param1 & controlConfig) == 0)
        {
            _icc21Page.ControlType = "Serial";
            _icc21Page.ControlBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & flasherType) == flasherType)
        {
            _icc21Page.ElevatedBackground = new SolidColorBrush(Colors.LightGreen);
            _icc21Page.InPavementBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & flasherType) == 0)
        {
            _icc21Page.ElevatedBackground = new SolidColorBrush(Colors.LightGray);
            _icc21Page.InPavementBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if ((param1 & compatMode) == compatMode)
        {
            icc21Compat = true;
            _icc21Page.CompatBackground = new SolidColorBrush(Colors.LightGreen);
            _icc21Page.EnhancedBackground = new SolidColorBrush(Colors.LightGray);
        }
        else if ((param1 & compatMode) == 0)
        {
            icc21Compat = false;
            _icc21Page.CompatBackground = new SolidColorBrush(Colors.LightGray);
            _icc21Page.EnhancedBackground = new SolidColorBrush(Colors.LightGreen);
        }
        if (cmMessageData != icc21MessageData)
        {
            string mismatchInfo = GetBitMismatchInfo(cmMessageData, icc21MessageData, "ICC21");
            _homePage.LogText += "\nMODE ERROR: CM and LVICC 21 do not match.\n" + mismatchInfo;

            // activate mode error
            _icc21Page.IsCommandErrorVisible = true;
            _homePage.Lvicc21PgStatus = true;
        }
        else
        {
            _icc21Page.IsCommandErrorVisible = false;
            _homePage.Lvicc21PgStatus = false;
        }
    }

    [RelayCommand]
    public void Disconnect(Window popupWindow)
    {
        if (Sp != null && Sp.IsOpen)
        {
            Sp.DataReceived -= SerialDataReceivedEventHandler; // Unhook event handler
            Sp.Close();
            _homePage.LogText = "Disconnected";
            _initialScanComplete = false;
            _expectedConfigResponses = 0;
            _processedConfigResponses = 0;

        }
        popupWindow.Close();

    }

    [RelayCommand]
    public async Task OpenConnectPopup(Window popupWindow)
    {
        var popup = new ConnectPopupView();
        popup.DataContext = this; // Set DataContext directly
        await Dispatcher.UIThread.InvokeAsync(async () =>
        {
            try
            {
                await RefreshPorts();

                await popup.ShowDialog(popupWindow);
            }
            catch (Exception e)
            {
                _homePage.LogText += $"\nOpenConnectPopup error: {e.Message}";
            }
        });
    }

    private void UpdateBorderWidth()
    {
        BorderWidth = SideMenuExpanded ? new GridLength(200.0) : new GridLength(50);
    }

    private void UpdateSideMenuItemWidth()
    {
        SideMenuItemWidth = SideMenuExpanded ? 180.0 : 40.0;
    }

    [RelayCommand]
    public async Task RefreshPorts()
    {
        AvailablePorts.Clear();
        foreach (var port in SerialPort.GetPortNames().OrderBy(p => p))
        {
            AvailablePorts.Add(port);
        }
        SelectedPort = AvailablePorts.FirstOrDefault();

    }

    [RelayCommand]
    private void SideMenuResize()
    {
        SideMenuExpanded = !SideMenuExpanded;
        UpdateBorderWidth();
        UpdateSideMenuItemWidth();
    }

    [RelayCommand]
    public void GoToHome() => CurrentPage = _homePage;

    [RelayCommand]
    public void GoToICC1() => CurrentPage = _icc1Page;

    [RelayCommand]
    public void GoToICC2() => CurrentPage = _icc2Page;
    [RelayCommand]
    public void GoToICC3() => CurrentPage = _icc3Page;
    [RelayCommand]
    public void GoToICC4() => CurrentPage = _icc4Page;
    [RelayCommand]
    public void GoToICC5() => CurrentPage = _icc5Page;
    [RelayCommand]
    public void GoToICC6() => CurrentPage = _icc6Page;
    [RelayCommand]
    public void GoToICC7() => CurrentPage = _icc7Page;
    [RelayCommand]
    public void GoToICC8() => CurrentPage = _icc8Page;
    [RelayCommand]
    public void GoToICC9() => CurrentPage = _icc9Page;
    [RelayCommand]
    public void GoToICC10() => CurrentPage = _icc10Page;
    [RelayCommand]
    public void GoToICC11() => CurrentPage = _icc11Page;
    [RelayCommand]
    public void GoToICC12() => CurrentPage = _icc12Page;
    [RelayCommand]
    public void GoToICC13() => CurrentPage = _icc13Page;
    [RelayCommand]
    public void GoToICC14() => CurrentPage = _icc14Page;
    [RelayCommand]
    public void GoToICC15() => CurrentPage = _icc15Page;
    [RelayCommand]
    public void GoToICC16() => CurrentPage = _icc16Page;
    [RelayCommand]
    public void GoToICC17() => CurrentPage = _icc17Page;
    [RelayCommand]
    public void GoToICC18() => CurrentPage = _icc18Page;
    [RelayCommand]
    public void GoToICC19() => CurrentPage = _icc19Page;
    [RelayCommand]
    public void GoToICC20() => CurrentPage = _icc20Page;
    [RelayCommand]
    public void GoToICC21() => CurrentPage = _icc21Page;
}