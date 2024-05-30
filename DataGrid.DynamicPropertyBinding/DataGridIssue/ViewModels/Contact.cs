using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataGridIssue.ViewModels
{
	public class Contact : INotifyDataErrorInfo, INotifyPropertyChanged
	{
		string _name = string.Empty;

		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				if( string.IsNullOrWhiteSpace( value ) )
					SetError( nameof( Name ), "Name Required" );
				else
					SetError( nameof( Name ), null );

				OnPropertyChanged( nameof( Name ) );
			}
		}

		Dictionary<string, List<string>> _errorLookup = new Dictionary<string, List<string>>();

		protected void SetError( string propertyName, string? error )
		{
			if( string.IsNullOrEmpty( error ) )
			{
				if( _errorLookup.Remove( propertyName ) )
					OnErrorsChanged( propertyName );
			}
			else
			{
				if( _errorLookup.TryGetValue( propertyName, out var errorList ) )
				{
					errorList.Clear();
					errorList.Add( error! );
				}
				else
				{
					var errors = new List<string> { error! };
					_errorLookup.Add( propertyName, errors );
				}

				OnErrorsChanged( propertyName );
			}
		}

		public bool HasErrors => _errorLookup.Count > 0;

		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
		public event PropertyChangedEventHandler? PropertyChanged;

		void OnErrorsChanged( string propertyName )
		{
			ErrorsChanged?.Invoke( this, new DataErrorsChangedEventArgs( propertyName ) );
		}
		protected void OnPropertyChanged( string propertyName )
		{
			PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
		}

		public IEnumerable GetErrors( string? propertyName )
		{
			if( propertyName is { } && _errorLookup.TryGetValue( propertyName, out var errorList ) )
				return errorList;
			else
				return Array.Empty<object>();
		}
	}
}
