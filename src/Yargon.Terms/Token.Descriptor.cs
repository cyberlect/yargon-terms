using System.Collections.Generic;
using Virtlink.Utilib.Collections;

namespace Yargon.Terms
{
    partial struct Token
    {
        /// <summary>
        /// The descriptor.
        /// </summary>
        public static ITermDescriptor Descriptor { get; } = new TokenDescriptor();

        /// <summary>
        /// The descriptor.
        /// </summary>
        private sealed class TokenDescriptor : ITermDescriptor
        {
            /// <inheritdoc />
            public string Name => "Token";

            /// <inheritdoc />
            public IReadOnlyList<ChildDescriptor> Children => Virtlink.Utilib.Collections.List.Empty<ChildDescriptor>();
        }
    }
}
