using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Yargon.Terms
{
    /// <summary>
    /// A list with only specific elements from another list.
    /// </summary>
    public sealed class SubList<T> : IReadOnlyList<T>
    {
        private readonly IReadOnlyList<T> innerList;
        private readonly IReadOnlyList<int> indices;

        /// <inheritdoc />
        public int Count => this.indices.Count;

        /// <inheritdoc />
        public T this[int index]
        {
            get
            {
                #region Contract
                if (index < 0 || index >= this.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                #endregion

                return this.innerList[this.indices[index]];
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SubList{T}"/> class.
        /// </summary>
        /// <param name="innerList">The inner list.</param>
        /// <param name="indices">The indices.</param>
        internal SubList(IReadOnlyList<T> innerList, IReadOnlyList<int> indices)
        {
            #region Contract
            if (innerList == null)
                throw new ArgumentNullException(nameof(innerList));
            if (indices == null)
                throw new ArgumentNullException(nameof(indices));
            if (indices.Any(i => i < 0 || i >= innerList.Count))
                throw new ArgumentOutOfRangeException(nameof(indices), "One or more indices are not within range.");
            #endregion

            this.innerList = innerList;
            this.indices = indices;
        }
        #endregion

        /// <summary>
        /// Creates a <see cref="SubList{T}"/> from the specified term descriptor.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        /// <param name="source">The source list.</param>
        /// <returns>The resulting list.</returns>
        public static SubList<T> CreateFromDescriptor(ITermDescriptor descriptor, IReadOnlyList<T> source)
        {
            #region Contract
            if (descriptor == null)
                throw new ArgumentNullException(nameof(descriptor));
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (descriptor.Children.Count != source.Count)
                throw new ArgumentException($"Expected the source to have {descriptor.Children.Count} elements, got {source.Count}.", nameof(source));
            #endregion

            var indices = descriptor.Children
                .Select((c, i) => new {child = c, index = i})
                .Where(ci => ci.child.IsAbstract)
                .Select(ci => ci.index)
                .ToArray();
            return new SubList<T>(source, indices);
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this[i];
            }
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
