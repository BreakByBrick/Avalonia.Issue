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

		static IReadOnlyList<Contact>? _basicContacts;

		public static IReadOnlyList<Contact> BasicContacts
		{
			get
			{
				if( _basicContacts == null )
				{
					_basicContacts = GetBasicContacts().ToList().AsReadOnly();
				}

				return _basicContacts;
			}
		}

		static IEnumerable<ReflectableContact> GetReflectableContacts()
		{
			yield return new ReflectableContact();
			yield return new ReflectableContact();
			yield return new ReflectableContact();
			yield return new ReflectableContact();
			yield return new ReflectableContact();
		}

		static IReadOnlyList<ReflectableContact>? _reflectableContacts;

		public static IReadOnlyList<ReflectableContact> ReflectableContacts
		{
			get
			{
				if( _reflectableContacts == null )
				{
					_reflectableContacts = GetReflectableContacts().ToList().AsReadOnly();
				}

				return _reflectableContacts;
			}
		}
	}
}
