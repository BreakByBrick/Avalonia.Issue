using System.Collections.Generic;
using System.Linq;

namespace DataGrid.DynamicPropertyBinding.ViewModels
{
	internal static class Contacts
	{
		static IEnumerable<Contact> GetBasicContacts()
		{
			yield return new Contact() { Name = "NameValue" };
			yield return new Contact() { Name = "NameValue" };
			yield return new Contact() { Name = "NameValue" };
			yield return new Contact() { Name = "NameValue" };
			yield return new Contact() { Name = "NameValue" };
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
			yield return new ReflectableContact() { Name = "NameValue" };
			yield return new ReflectableContact() { Name = "NameValue" };
			yield return new ReflectableContact() { Name = "NameValue" };
			yield return new ReflectableContact() { Name = "NameValue" };
			yield return new ReflectableContact() { Name = "NameValue" };
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
