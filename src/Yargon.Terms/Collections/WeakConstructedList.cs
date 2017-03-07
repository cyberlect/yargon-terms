using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Yargon.Terms.Collections
{
    /// <summary>
    /// Base class for a list that can build its own elements.
    /// </summary>
    public abstract class WeakConstructedList<T> : IReadOnlyList<T>
        where T : class
    {
        private readonly WeakReference<T>[] references;

        /// <inheritdoc />
        public int Count => this.references.Length;

        /// <inheritdoc />
        public T this[int index]
        {
            get
            {
                #region Contract
                if (index < 0 || index >= this.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                #endregion

                return GetOrCreateElement(index);
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="WeakConstructedList{T}"/> class.
        /// </summary>
        /// <param name="count">The number of elements.</param>
        protected WeakConstructedList(int count)
        {
            #region Contract
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            #endregion

            this.references = new WeakReference<T>[count];
        }
        #endregion

        /// <summary>
        /// Gets the element at the specified index;
        /// or creates and stores a new element.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get.</param>
        /// <returns>The element.</returns>
        /// <remarks>
        /// This method is thread-safe.
        /// </remarks>
        private T GetOrCreateElement(int index)
        {
            #region Contract
            Debug.Assert(index >= 0 && index < this.Count);
            #endregion

            T value;
            WeakReference<T> currentReference = this.references[index];
            if (currentReference == null || !currentReference.TryGetTarget(out value))
            {
                var newValue = BuildElement(index);
                var newReference = new WeakReference<T>(newValue);
                while (true)
                {
                    if (Interlocked.CompareExchange(ref this.references[index], newReference, currentReference) == currentReference)
                    {
                        // Got to set our own value.
                        value = newValue;
                        break;
                    }
                    else if (currentReference != null && currentReference.TryGetTarget(out value))
                    {
                        // Got a value set by someone else.
                        break;
                    }
                }
                
            }
            return value;
        }

        /// <summary>
        /// Builds the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get.</param>
        /// <returns>The built element.</returns>
        protected abstract T BuildElement(int index);

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
