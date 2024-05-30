using System;
using System.Globalization;
using System.Reflection;

namespace DataGridIssue.ViewModels
{
	public class ReflectableContact : Contact, IReflectableType
	{
		string _surname = string.Empty;

		public string Surname
		{
			get => _surname;
			set
			{
				_surname = value;
				if( string.IsNullOrWhiteSpace( value ) )
					SetError( nameof( Surname ), "Surname Required" );
				else
					SetError( nameof( Surname ), null );

				OnPropertyChanged( nameof( Surname ) );
			}

		}

		public TypeInfo GetTypeInfo()
		{
			return new DynamicTypeInfo();
		}

		private class DynamicTypeInfo : TypeInfo
		{
			protected override PropertyInfo GetPropertyImpl( string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types,
				ParameterModifier[] modifiers )
			{
				switch( name )
				{
					case "Name":
					case "DynamicName":
						return new DynamicPropertyInfo();
				}

				return null;
			}

			#region Not Supported

			public override Assembly Assembly { get; }

			public override string AssemblyQualifiedName { get; }

			public override Type BaseType { get; }

			public override string FullName { get; }

			public override Guid GUID { get; }

			public override Module Module { get; }

			public override string Namespace { get; }

			public override Type UnderlyingSystemType { get; }

			public override string Name { get; }

			public override ConstructorInfo[] GetConstructors( BindingFlags bindingAttr )
			{
				throw new NotSupportedException();
			}

			public override object[] GetCustomAttributes( bool inherit )
			{
				throw new NotSupportedException();
			}

			public override object[] GetCustomAttributes( Type attributeType, bool inherit )
			{
				throw new NotSupportedException();
			}

			public override Type GetElementType()
			{
				throw new NotSupportedException();
			}

			public override EventInfo GetEvent( string name, BindingFlags bindingAttr )
			{
				throw new NotSupportedException();
			}

			public override EventInfo[] GetEvents( BindingFlags bindingAttr )
			{
				throw new NotSupportedException();
			}

			public override FieldInfo GetField( string name, BindingFlags bindingAttr )
			{
				throw new NotSupportedException();
			}

			public override FieldInfo[] GetFields( BindingFlags bindingAttr )
			{
				throw new NotSupportedException();
			}

			public override Type GetInterface( string name, bool ignoreCase )
			{
				throw new NotSupportedException();
			}

			public override Type[] GetInterfaces()
			{
				throw new NotSupportedException();
			}

			public override MemberInfo[] GetMembers( BindingFlags bindingAttr )
			{
				throw new NotSupportedException();
			}

			public override MethodInfo[] GetMethods( BindingFlags bindingAttr )
			{
				throw new NotSupportedException();
			}

			public override Type GetNestedType( string name, BindingFlags bindingAttr )
			{
				throw new NotSupportedException();
			}

			public override Type[] GetNestedTypes( BindingFlags bindingAttr )
			{
				throw new NotSupportedException();
			}

			public override PropertyInfo[] GetProperties( BindingFlags bindingAttr )
			{
				throw new NotSupportedException();
			}

			public override object InvokeMember( string name, BindingFlags invokeAttr, Binder binder, object target, object[] args,
				ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters )
			{
				throw new NotSupportedException();
			}

			public override bool IsDefined( Type attributeType, bool inherit )
			{
				throw new NotSupportedException();
			}

			protected override TypeAttributes GetAttributeFlagsImpl()
			{
				throw new NotSupportedException();
			}

			protected override ConstructorInfo GetConstructorImpl( BindingFlags bindingAttr, Binder binder, CallingConventions callConvention,
				Type[] types, ParameterModifier[] modifiers )
			{
				throw new NotSupportedException();
			}

			protected override MethodInfo GetMethodImpl( string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention,
				Type[] types, ParameterModifier[] modifiers )
			{
				throw new NotSupportedException();
			}


			protected override bool HasElementTypeImpl()
			{
				throw new NotSupportedException();
			}

			protected override bool IsArrayImpl()
			{
				throw new NotSupportedException();
			}

			protected override bool IsByRefImpl()
			{
				throw new NotSupportedException();
			}

			protected override bool IsCOMObjectImpl()
			{
				throw new NotSupportedException();
			}

			protected override bool IsPointerImpl()
			{
				throw new NotSupportedException();
			}

			protected override bool IsPrimitiveImpl()
			{
				throw new NotSupportedException();
			}

			#endregion
		}

		private class DynamicPropertyInfo : PropertyInfo
		{
			public override bool CanRead => true;

			public override bool CanWrite => true;

			public override Type PropertyType => typeof( string );

			public override string Name => "Name";

			public override object GetValue( object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture )
			{
				return "DynamicNameValue";
			}

			public override void SetValue( object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture )
			{
			}

			#region NotSupported

			public override PropertyAttributes Attributes { get; }

			public override Type DeclaringType { get; }

			public override Type ReflectedType { get; }

			public override MethodInfo[] GetAccessors( bool nonPublic )
			{
				throw new NotSupportedException();
			}

			public override object[] GetCustomAttributes( bool inherit )
			{
				throw new NotSupportedException();
			}

			public override object[] GetCustomAttributes( Type attributeType, bool inherit )
			{
				throw new NotSupportedException();
			}

			public override MethodInfo GetGetMethod( bool nonPublic )
			{
				throw new NotSupportedException();
			}

			public override ParameterInfo[] GetIndexParameters()
			{
				throw new NotSupportedException();
			}

			public override MethodInfo GetSetMethod( bool nonPublic )
			{
				throw new NotSupportedException();
			}

			public override bool IsDefined( Type attributeType, bool inherit )
			{
				throw new NotSupportedException();
			}

			#endregion
		}
	}
}
