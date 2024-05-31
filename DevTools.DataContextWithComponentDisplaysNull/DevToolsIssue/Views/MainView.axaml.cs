using System;

using Avalonia.Controls;
using Avalonia.Input;

namespace DevToolsIssue.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

	private void OnPointerPressed( object? sender, PointerPressedEventArgs e )
	{
        var tb = ( TextBlock )sender;
        var vm = tb.DataContext;
	}
}
