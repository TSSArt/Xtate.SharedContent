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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

#if !NET5_0_OR_GREATER
using System.ComponentModel;
using JetBrains.Annotations;

namespace System.Runtime.CompilerServices
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[UsedImplicitly]
	internal static class IsExternalInit { }
}
#endif