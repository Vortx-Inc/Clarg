﻿using System;
using System.Diagnostics;
using System.Reflection;

namespace Clarg
{
	[DebuggerDisplay("{Name}")]
	class ParameterDescriptor
	{
		public readonly string Name;
		public readonly Type Type;
		public readonly bool IsEnumerable;
		public readonly bool IsOptional;
		public readonly bool IsParamsArray;
		public readonly ParameterInfo ParameterInfo;

		public ParameterDescriptor(string name, Type type, bool isEnumerable, bool isOptional, bool isParamsArray, ParameterInfo parameterInfo)
		{
			Name = name;
			Type = type;
			IsEnumerable = isEnumerable;
			IsOptional = isOptional;
			IsParamsArray = isParamsArray;
			ParameterInfo = parameterInfo;
		}

		public override bool Equals(object obj)
		{
			if(ReferenceEquals(obj, null))
				return false;

			if(ReferenceEquals(obj, this))
				return true;

			if(obj is ParameterDescriptor)
				return Equals((ParameterDescriptor)obj);

			return base.Equals(obj);
		}

		public bool Equals(ParameterDescriptor obj)
		{
			if(ReferenceEquals(obj, null))
				return false;

			if(ReferenceEquals(obj, this))
				return true;

			return StringComparer.OrdinalIgnoreCase.Equals(obj.Name, Name);
		}

		public override int GetHashCode()
			=> StringComparer.OrdinalIgnoreCase.GetHashCode(Name);

		public static bool operator ==(ParameterDescriptor x, ParameterDescriptor y)
		{
			if(ReferenceEquals(x, null) || ReferenceEquals(y, null))
				return ReferenceEquals(x, null) && ReferenceEquals(y, null);

			if(ReferenceEquals(x, y))
				return true;

			return x.Equals(y);
		}

		public static bool operator !=(ParameterDescriptor x, ParameterDescriptor y)
			=> !(x == y);
	}
}
