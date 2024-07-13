﻿// Copyright © 2019-2024 Sergii Artemenko
// 
// This file is part of the Xtate project. <https://xtate.net/>
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

// ReSharper disable All

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
#pragma warning disable IDE0090 // Use 'new(...)'
#pragma warning disable CS1591  // Missing XML comment for publicly visible type or member

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

#if (NETSTANDARD && !NETSTANDARD2_1) || !NETCOREAPP3_0_OR_GREATER
namespace System
{
	[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
	internal readonly struct Index : IEquatable<Index>
	{
		private readonly int _value;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Index(int value, bool fromEnd = false)
		{
			if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));

			_value = fromEnd ? ~value : value;
		}

		private Index(int value) => _value = value;

		public static Index Start => new Index(0);

		public static Index End => new Index(~0);

		public int Value => _value < 0 ? ~_value : _value;

		public bool IsFromEnd => _value < 0;

	#region Interface IEquatable<Index>

		public bool Equals(Index other) => _value == other._value;

	#endregion

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Index FromStart(int value)
		{
			if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));

			return new Index(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Index FromEnd(int value)
		{
			if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));

			return new Index(~value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetOffset(int length) => IsFromEnd ? _value + length + 1 : _value;

		public override bool Equals(object? value) => value is Index index && _value == index._value;

		public override int GetHashCode() => _value;

		public static implicit operator Index(int value) => FromStart(value);

		public override string ToString() => IsFromEnd ? @"^" + (uint) Value : ((uint) Value).ToString();
	}

	[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
	internal readonly struct Range : IEquatable<Range>
	{
		public Range(Index start, Index end)
		{
			Start = start;
			End = end;
		}

		public Index Start { get; }

		public Index End { get; }

		public static Range All => new Range(Index.Start, Index.End);

	#region Interface IEquatable<Range>

		public bool Equals(Range other) => other.Start.Equals(Start) && other.End.Equals(End);

	#endregion

		public override bool Equals(object? value) => value is Range r && r.Start.Equals(Start) && r.End.Equals(End);

		public override int GetHashCode() => Start.GetHashCode() * 31 + End.GetHashCode();

		public override string ToString() => Start + @".." + End;

		public static Range StartAt(Index start) => new Range(start, Index.End);

		public static Range EndAt(Index end) => new Range(Index.Start, end);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (int Offset, int Length) GetOffsetAndLength(int length)
		{
			var start = Start.IsFromEnd ? length - Start.Value : Start.Value;
			var end = End.IsFromEnd ? length - End.Value : End.Value;

			if ((uint) end > (uint) length || (uint) start > (uint) end)
			{
				throw new ArgumentOutOfRangeException(nameof(length));
			}

			return (start, end - start);
		}
	}
}

#endif