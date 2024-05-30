using System.Collections.Generic;
using System.Linq;

namespace DataGridIssue.ViewModels
{
	internal static class Contacts
	{
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
