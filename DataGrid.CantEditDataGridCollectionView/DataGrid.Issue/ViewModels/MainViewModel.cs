using System.Collections.ObjectModel;

using Avalonia.Collections;

namespace DataGrid.Issue.ViewModels;

public class MainViewModel : ViewModelBase
{
	public ObservableCollection<Contact> ContactsObservableCollection { get; } = new ObservableCollection<Contact>( ViewModels.Contacts.ContactCollection );

	public DataGridCollectionView ContactsCollectionView { get; } = new DataGridCollectionView( ViewModels.Contacts.ContactCollection );
}
