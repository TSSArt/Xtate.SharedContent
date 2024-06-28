﻿// ReSharper disable All

/* Copyright © 2019-2024 Sergii Artemenko

This file is part of the Xtate project. <https://xtate.net/>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0005 // Using directive is unnecessary
#pragma warning disable IDE0290 // Use primary constructor

#define INTERNAL_NULLABLE_ATTRIBUTES

#if NETSTANDARD2_0 || NETCOREAPP2_0 || NETCOREAPP2_1 || NETCOREAPP2_2 || NET45 || NET451 || NET452 || NET6 || NET461 || NET462 || NET47 || NET471 || NET472 || NET48

// https://github.com/dotnet/corefx/blob/48363ac826ccf66fbe31a5dcb1dc2aab9a7dd768/src/Common/src/CoreLib/System/Diagnostics/CodeAnalysis/NullableAttributes.cs

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Diagnostics.CodeAnalysis
{
	/// <summary>Specifies that null is allowed as an input even if the corresponding type disallows it.</summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property)]
#if INTERNAL_NULLABLE_ATTRIBUTES
	internal
#else
    public
#endif
		sealed class AllowNullAttribute : Attribute { }

	/// <summary>Specifies that null is disallowed as an input even if the corresponding type allows it.</summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property)]
#if INTERNAL_NULLABLE_ATTRIBUTES
	internal
#else
    public
#endif
		sealed class DisallowNullAttribute : Attribute { }

	/// <summary>Specifies that an output may be null even if the corresponding type disallows it.</summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue)]
#if INTERNAL_NULLABLE_ATTRIBUTES
	internal
#else
    public
#endif
		sealed class MaybeNullAttribute : Attribute { }

	/// <summary>Specifies that an output will not be null even if the corresponding type allows it.</summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue)]
#if INTERNAL_NULLABLE_ATTRIBUTES
	internal
#else
    public
#endif
		sealed class NotNullAttribute : Attribute { }

	/// <summary>
	///     Specifies that when a method returns <see cref="ReturnValue" />, the parameter may be null even if the
	///     corresponding type disallows it.
	/// </summary>
	/// <remarks>Initializes the attribute with the specified return value condition.</remarks>
	[AttributeUsage(AttributeTargets.Parameter)]
	[ExcludeFromCodeCoverage]
#if INTERNAL_NULLABLE_ATTRIBUTES
	internal
#else
    public
#endif
		sealed class MaybeNullWhenAttribute : Attribute
	{
		/// <summary>
		///     Specifies that when a method returns <see cref="ReturnValue" />, the parameter may be null even if the
		///     corresponding type disallows it.
		/// </summary>
		/// <remarks>Initializes the attribute with the specified return value condition.</remarks>
		/// <param name="returnValue">
		///     The return value condition. If the method returns this value, the associated parameter may be null.
		/// </param>
		public MaybeNullWhenAttribute(bool returnValue)
		{
			ReturnValue = returnValue;
		}

		/// <summary>Gets the return value condition.</summary>
		public bool ReturnValue { get; }
	}

	/// <summary>
	///     Specifies that when a method returns <see cref="ReturnValue" />, the parameter will not be null even if the
	///     corresponding type allows it.
	/// </summary>
	/// <remarks>Initializes the attribute with the specified return value condition.</remarks>
	[AttributeUsage(AttributeTargets.Parameter)]
	[ExcludeFromCodeCoverage]
#if INTERNAL_NULLABLE_ATTRIBUTES
	internal
#else
    public
#endif
		sealed class NotNullWhenAttribute : Attribute
	{
		/// <summary>
		///     Specifies that when a method returns <see cref="ReturnValue" />, the parameter will not be null even if the
		///     corresponding type allows it.
		/// </summary>
		/// <remarks>Initializes the attribute with the specified return value condition.</remarks>
		/// <param name="returnValue">
		///     The return value condition. If the method returns this value, the associated parameter will not be null.
		/// </param>
		public NotNullWhenAttribute(bool returnValue)
		{
			ReturnValue = returnValue;
		}

		/// <summary>Gets the return value condition.</summary>
		public bool ReturnValue { get; }
	}

	/// <summary>Specifies that the output will be non-null if the named parameter is non-null.</summary>
	/// <remarks>Initializes the attribute with the associated parameter name.</remarks>
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue, AllowMultiple = true)]
	[ExcludeFromCodeCoverage]
#if INTERNAL_NULLABLE_ATTRIBUTES
	internal
#else
    public
#endif
		sealed class NotNullIfNotNullAttribute : Attribute
	{
		/// <summary>Specifies that the output will be non-null if the named parameter is non-null.</summary>
		/// <remarks>Initializes the attribute with the associated parameter name.</remarks>
		/// <param name="parameterName">
		///     The associated parameter name.  The output will be non-null if the argument to the parameter specified is non-null.
		/// </param>
		public NotNullIfNotNullAttribute(string parameterName)
		{
			ParameterName = parameterName;
		}

		/// <summary>Gets the associated parameter name.</summary>
		public string ParameterName { get; }
	}

	/// <summary>Applied to a method that will never return under any circumstance.</summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ExcludeFromCodeCoverage]
#if INTERNAL_NULLABLE_ATTRIBUTES
	internal
#else
    public
#endif
		sealed class DoesNotReturnAttribute : Attribute { }

	/// <summary>Specifies that the method will not return if the associated Boolean parameter is passed the specified value.</summary>
	/// <remarks>Initializes the attribute with the specified parameter value.</remarks>
	[AttributeUsage(AttributeTargets.Parameter)]
	[ExcludeFromCodeCoverage]
#if INTERNAL_NULLABLE_ATTRIBUTES
	internal
#else
    public
#endif
		sealed class DoesNotReturnIfAttribute : Attribute
	{
		/// <summary>Specifies that the method will not return if the associated Boolean parameter is passed the specified value.</summary>
		/// <remarks>Initializes the attribute with the specified parameter value.</remarks>
		/// <param name="parameterValue">
		///     The condition parameter value. Code after the method will be considered unreachable by diagnostics if the argument
		///     to
		///     the associated parameter matches this value.
		/// </param>
		public DoesNotReturnIfAttribute(bool parameterValue)
		{
			ParameterValue = parameterValue;
		}

		/// <summary>Gets the condition parameter value.</summary>
		public bool ParameterValue { get; }
	}
}
#endif