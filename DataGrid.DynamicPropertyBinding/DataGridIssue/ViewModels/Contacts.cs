using System.Collections.Generic;
using System.Linq;

namespace DataGridIssue.ViewModels
{
	internal static class Contacts
	{
		static IEnumerable<Contact> GetBasicContacts()
		{
			yield return new Contact() { Name = "Name1" };
			yield return new Contact() { Name = "Name2" };
			yield return new Contact() { Name = "Name3" };
			yield return new Contact() { Name = "Name4" };
			yield return new Contact() { Name = "Name5" };
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
			yield return new ReflectableContact() { Name = "Name1", Surname = "Surname1" };
			yield return new ReflectableContact() { Name = "Name2", Surname = "Surname2" };
			yield return new ReflectableContact() { Name = "Name3", Surname = "Surname3" };
			yield return new ReflectableContact() { Name = "Name4", Surname = "Surname4" };
			yield return new ReflectableContact() { Name = "Name5", Surname = "Surname5" };
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
