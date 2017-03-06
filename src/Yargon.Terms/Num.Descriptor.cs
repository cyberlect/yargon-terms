using System.Collections.Generic;

namespace Yargon.Terms
{
    partial class Num
    {
        /// <summary>
        /// The descriptor.
        /// </summary>
        private static NumDescriptor Descriptor { get; } = new NumDescriptor();

        /// <summary>
        /// The descriptor.
        /// </summary>
        private sealed class NumDescriptor : ITermDescriptor
        {
            /// <inheritdoc />
            public IReadOnlyList<ChildDescriptor> Children { get; } = new[]
            {
                new ChildDescriptor("literal", false)
            };
        }
    }
}
