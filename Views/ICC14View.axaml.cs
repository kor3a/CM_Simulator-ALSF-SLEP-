using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CM_Simulator.ViewModels;

namespace CM_Simulator.Views;

public partial class ICC14View : UserControl
{
    public ICC14View()
    {
        InitializeComponent();
        var flasherMisfiresTextBox = this.FindControl<TextBox>("FlasherMisfiresTextBox");
        var startByteTextBox = this.FindControl<TextBox>("StartByteTextBox");
        var destinationByteTextBox = this.FindControl<TextBox>("DestinationByteTextBox");
        var sourceByteTextBox = this.FindControl<TextBox>("SourceByteTextBox");
        var endByteTextBox = this.FindControl<TextBox>("EndByteTextBox");
        if (flasherMisfiresTextBox != null)
        {
            flasherMisfiresTextBox.KeyDown += FlasherMisfire_KeyDown;
            flasherMisfiresTextBox.LostFocus += FlasherMisfire_LostFocus;
        }
        if (startByteTextBox != null)
        {
            startByteTextBox.KeyDown += StartByte_KeyDown;
            startByteTextBox.LostFocus += StartByte_LostFocus;
        }
        if (destinationByteTextBox != null)
        {
            destinationByteTextBox.KeyDown += DestinationByte_KeyDown;
            destinationByteTextBox.LostFocus += DestinationByte_LostFocus;
        }
        if (sourceByteTextBox != null)
        {
            sourceByteTextBox.KeyDown += SourceByte_KeyDown;
            sourceByteTextBox.LostFocus += SourceByte_LostFocus;
        }
        if (endByteTextBox != null)
        {
            endByteTextBox.KeyDown += EndByte_KeyDown;
            endByteTextBox.LostFocus += EndByte_LostFocus;
        }
    }

    private void FlasherMisfiresTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void FlasherMisfire_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && sender is TextBox textBox)
        {
            if (this.DataContext is ICC14ViewModel vm)
            {
                vm.SubmitFlasherMisfiresCommand.Execute(textBox.Text);
                e.Handled = true;

                textBox.IsEnabled = false;
                textBox.IsEnabled = true;

            }
        }
    }

    private void FlasherMisfire_LostFocus(object? sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            if (this.DataContext is ICC14ViewModel vm)
            {
                vm.SubmitFlasherMisfiresCommand.Execute(textBox.Text);
                e.Handled = true;

                textBox.IsEnabled = false;
                textBox.IsEnabled = true;
            }
        }
    }

    private void StartByte_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && sender is TextBox textBox)
        {
            if (this.DataContext is ICC14ViewModel vm)
            {
                vm.SubmitStartByteCommand.Execute(textBox.Text);
                e.Handled = true;

                textBox.IsEnabled = false;
                textBox.IsEnabled = true;

            }
        }
    }

    private void StartByte_LostFocus(object? sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            if (this.DataContext is ICC14ViewModel vm)
            {
                vm.SubmitStartByteCommand.Execute(textBox.Text);
                e.Handled = true;

                textBox.IsEnabled = false;
                textBox.IsEnabled = true;
            }
        }
    }

    private void DestinationByte_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && sender is TextBox textBox)
        {
            if (this.DataContext is ICC14ViewModel vm)
            {
                vm.SubmitDestinationByteCommand.Execute(textBox.Text);
                e.Handled = true;

                textBox.IsEnabled = false;
                textBox.IsEnabled = true;

            }
        }
    }

    private void DestinationByte_LostFocus(object? sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            if (this.DataContext is ICC14ViewModel vm)
            {
                vm.SubmitDestinationByteCommand.Execute(textBox.Text);
                e.Handled = true;

                textBox.IsEnabled = false;
                textBox.IsEnabled = true;
            }
        }
    }
    private void SourceByte_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && sender is TextBox textBox)
        {
            if (this.DataContext is ICC14ViewModel vm)
            {
                vm.SubmitSourceByteCommand.Execute(textBox.Text);
                e.Handled = true;

                textBox.IsEnabled = false;
                textBox.IsEnabled = true;

            }
        }
    }

    private void SourceByte_LostFocus(object? sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            if (this.DataContext is ICC14ViewModel vm)
            {
                vm.SubmitSourceByteCommand.Execute(textBox.Text);
                e.Handled = true;

                textBox.IsEnabled = false;
                textBox.IsEnabled = true;
            }
        }
    }

    private void EndByte_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && sender is TextBox textBox)
        {
            if (this.DataContext is ICC14ViewModel vm)
            {
                vm.SubmitEndByteCommand.Execute(textBox.Text);
                e.Handled = true;

                textBox.IsEnabled = false;
                textBox.IsEnabled = true;

            }
        }
    }

    private void EndByte_LostFocus(object? sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            if (this.DataContext is ICC14ViewModel vm)
            {
                vm.SubmitEndByteCommand.Execute(textBox.Text);
                e.Handled = true;

                textBox.IsEnabled = false;
                textBox.IsEnabled = true;
            }
        }
    }
}