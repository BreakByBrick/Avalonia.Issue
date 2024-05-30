using System.Collections.Generic;
using System.Linq;

namespace DataGrid.Issue.ViewModels
{
	internal static class Contacts
	{
		static IEnumerable<Contact> GetBasicContacts()
		{
			yield return new Contact();
			yield return new Contact();
			yield return new Contact();
			yield return new Contact();
			yield return new Contact();
		}

		static IReadOnlyList<Contact>? _contactCollection;

		public static IReadOnlyList<Contact> ContactCollection
		{
			get
			{
				if( _contactCollection == null )
				{
					_contactCollection = GetBasicContacts().ToList().AsReadOnly();
				}

				return _contactCollection;
			}
		}
	}
}
