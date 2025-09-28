// Copyright © 2019-2025 Sergii Artemenko
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

using System;
using System.Diagnostics;

namespace JetBrains.Annotations
{
    /// <summary>
    ///     Indicates that the decorated class is instantiated by the IoC container and prevents ReSharper warnings about
    ///     unused classes. This attribute is intended solely for ReSharper and does not provide IoC functionality.
    /// </summary>
    [MeansImplicitUse(ImplicitUseTargetFlags.Itself)]
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class InstantiatedByIoCAttribute : Attribute { }

    /// <summary>
    ///     Indicates that the decorated method is called by the IoC container, and prevents ReSharper warnings about unused
    ///     methods. This attribute is intended solely for ReSharper and does not provide IoC functionality.
    /// </summary>
    [MeansImplicitUse(ImplicitUseTargetFlags.Itself)]
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class CalledByIoCAttribute : Attribute { }

    /// <summary>
    ///     Indicates that the decorated method is used by the IoC container to set a property, and prevents ReSharper warnings
    ///     about unused methods or properties. This attribute is intended solely for ReSharper and does not provide IoC
    ///     functionality.
    /// </summary>
    [MeansImplicitUse(ImplicitUseTargetFlags.Itself)]
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class SetByIoCAttribute : Attribute { }
}