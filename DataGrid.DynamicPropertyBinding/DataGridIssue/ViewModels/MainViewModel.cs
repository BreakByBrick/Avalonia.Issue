using System.Collections.ObjectModel;

namespace DataGridIssue.ViewModels;

public class MainViewModel : ViewModelBase
{
	public ObservableCollection<Contact> Contacts { get; } = new ObservableCollection<Contact>( ViewModels.Contacts.BasicContacts );
	//public DataGridCollectionView Contacts { get; } = new DataGridCollectionView( ViewModels.Contacts.BasicContacts );

	public ObservableCollection<ReflectableContact> ReflectableContacts { get; } = new ObservableCollection<ReflectableContact>( ViewModels.Contacts.ReflectableContacts );
	//public DataGridCollectionView ReflectableContacts { get; } = new DataGridCollectionView( ViewModels.Contacts.ReflectableContacts );
}
