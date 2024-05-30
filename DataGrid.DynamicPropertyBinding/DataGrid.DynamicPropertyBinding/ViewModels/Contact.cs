using System.ComponentModel;

namespace DataGrid.DynamicPropertyBinding.ViewModels
{
	public class Contact //: INotifyPropertyChanged
	{
		string _name = string.Empty;

		public string Name
		{
			get => _name;

			set
			{
				if( _name != value )
				{
					_name = value;
					OnPropertyChanged( nameof( Name ) );
				}
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		private void OnPropertyChanged( string propertyName )
		{
			PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
		}
	}
}
