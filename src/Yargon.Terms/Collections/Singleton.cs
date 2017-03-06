using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace Yargon.Terms.Collections
{
    /// <summary>
    /// A singleton collection.
    /// </summary>
    /// <typeparam name="T">The type of element in the collection.</typeparam>
    public sealed class Singleton<T> : IReadOnlyList<T>
    {
        [CanBeNull]
        private readonly T element0;

        /// <inheritdoc />
        public int Count => 1;

        /// <inheritdoc />
        [CanBeNull]
        public T this[int index]
        {
            get
            {
                #region Contract
                if (index < 0 || index >= 1)
                    throw new ArgumentOutOfRangeException(nameof(index));
                #endregion

                return this.element0;
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Singleton{T}"/> class.
        /// </summary>
        /// <param name="value">The only element in the collection.</param>
        public Singleton([CanBeNull] T value)
        {
            this.element0 = value;
        }
        #endregion

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            yield return this.element0;
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
