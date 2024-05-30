using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;

namespace DataGrid.DynamicPropertyBinding.Views;

public partial class MainView : UserControl
{
	public MainView()
	{
		InitializeComponent();
	}
}

public class CustomDataGridTextColumn : DataGridBoundColumn
{
	public CustomDataGridTextColumn()
	{
		BindingTarget = TextBox.TextProperty;
		Binding = new Binding( "Name" );
	}

	protected override Control GenerateEditingElementDirect( DataGridCell cell, object dataItem )
	{
		var textBlock = new TextBox();
		//textBlock.Bind( TextBox.TextProperty, new Binding( "TextBox", BindingMode.TwoWay )
		//{
		//	Converter = new Converter()
		//} );
		return textBlock;
	}

	protected override Control GenerateElement( DataGridCell cell, object dataItem )
	{
		var textBlock = new TextBlock() { Text = "t" };
		//textBlock.Bind( TextBlock.TextProperty, new Binding() );
		return textBlock;
	}

	protected override object PrepareCellForEdit( Control editingElement, RoutedEventArgs editingEventArgs )
	{
		return string.Empty;
	}
}
