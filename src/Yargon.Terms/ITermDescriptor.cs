﻿using System.Collections.Generic;

namespace Yargon.Terms
{
    /// <summary>
    /// Describes a term.
    /// </summary>
    public interface ITermDescriptor
    {
        /// <summary>
        /// Gets the information about the term's children.
        /// </summary>
        /// <value>The information.</value>
        IReadOnlyList<ChildDescriptor> Children { get; }
    }
}
