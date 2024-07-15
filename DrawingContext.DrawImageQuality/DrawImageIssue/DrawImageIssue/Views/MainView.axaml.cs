using System;
using System.Globalization;
using System.IO;
using System.Numerics;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

using static DrawImageIssue.Views.RenderedView2;

namespace DrawImageIssue.Views;

public partial class MainView : UserControl
{
	public MainView()
	{
		InitializeComponent();
	}
}

public class RenderedView : RenderViewBase
{
	public override void Render( DrawingContext context )
	{
		RenderOverride( context );
	}
}

public class RenderedView2 : RenderViewBase
{
	public override void Render( DrawingContext context )
	{
		int renderWidth = 500;
		int renderHeight = 700;

		var size = new Size( renderWidth, renderHeight );
		var pixelSize = new PixelSize( renderWidth, renderHeight );
		var vector = new Avalonia.Vector( 96, 96 );

		using( Avalonia.Media.Imaging.RenderTargetBitmap renderBitmap = new( pixelSize, vector ) )
		using( Avalonia.Media.DrawingContext renderBitmapContext = renderBitmap.CreateDrawingContext() )
		{
			// Rendering bitmap DrawingContext
			RenderOverride( renderBitmapContext );

			// Rendering main DrawingContext
			RenderOverride( context );

			// 1
			context.DrawImage( renderBitmap, new Rect( size ) );

			// 2
			//using( MemoryStream memoryStream = new() )
			//{
			//	renderBitmap.Save( memoryStream );
			//	memoryStream.Seek( 0, SeekOrigin.Begin );

			//	var bitmap = new Avalonia.Media.Imaging.Bitmap( memoryStream );

			//	context.DrawImage( bitmap, new Rect( size ) );
			//}
		}
	}
}

public class RenderViewBase : Control
{
	protected void RenderOverride( DrawingContext context )
	{
		context.PushRenderOptions( new Avalonia.Media.RenderOptions
		{
			BitmapBlendingMode = Avalonia.Media.Imaging.BitmapBlendingMode.Unspecified,
			BitmapInterpolationMode = Avalonia.Media.Imaging.BitmapInterpolationMode.HighQuality,
			EdgeMode = Avalonia.Media.EdgeMode.Antialias,
			TextRenderingMode = Avalonia.Media.TextRenderingMode.Antialias,
		} );

		var rectangleNumber = 5;
		var padding = 10;

		var left = 0;
		var top = 0;
		var rectWidth = 500;
		var rectHeight = 700;

		var penWidth = 0.1;

		for( int i = 0; i < rectangleNumber; i++ )
		{
			left += padding;
			top += padding;
			rectWidth -= padding * 2;
			rectHeight -= padding * 2;

			penWidth += 0.2;

			var pen = new Avalonia.Media.Pen( Avalonia.Media.Brushes.Red, penWidth );
			var rect = new Avalonia.Rect( left, top, rectWidth, rectHeight );
			context.DrawRectangle( null, pen, rect );
		}

		var text = new FormattedText(
			"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
			CultureInfo.CurrentCulture,
			Avalonia.Media.FlowDirection.LeftToRight,
			Typeface.Default,
			12,
			Brushes.Black )
		{
			MaxTextWidth = 350,
		};

		var origin = new Point( ( rectangleNumber + 1 ) * padding, ( rectangleNumber + 1 ) * padding );

		context.DrawText( text, origin );
	}
}
