using System.Collections.ObjectModel;

namespace DataGridIssue.ViewModels;

public class MainViewModel : ViewModelBase
{
	public ObservableCollection<ReflectableContact> ReflectableContacts { get; } = new ObservableCollection<ReflectableContact>( ViewModels.Contacts.ReflectableContacts );
	//public DataGridCollectionView ReflectableContacts { get; } = new DataGridCollectionView( ViewModels.Contacts.ReflectableContacts );
}
