using System.Collections.Generic;
using Virtlink.Utilib.Collections;

namespace Yargon.Terms
{
    partial struct Token
    {
        /// <summary>
        /// The descriptor.
        /// </summary>
        private static TokenDescriptor Descriptor { get; } = new TokenDescriptor();

        /// <summary>
        /// The descriptor.
        /// </summary>
        private sealed class TokenDescriptor : ITermDescriptor
        {
            /// <inheritdoc />
            public IReadOnlyList<ChildDescriptor> Children => List.Empty<ChildDescriptor>();
        }
    }
}
