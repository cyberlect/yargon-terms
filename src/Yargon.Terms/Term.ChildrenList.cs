using System;
using System.Collections;
using System.Collections.Generic;

namespace Yargon.Terms
{
    partial class Term
    {
        /// <summary>
        /// A list of red children.
        /// </summary>
        private sealed class ChildrenList : IReadOnlyList<ITerm>
        {
            /// <summary>
            /// The owner of this list.
            /// </summary>
            private ITerm Owner { get; }

            /// <summary>
            /// The constructed red terms, if any.
            /// </summary>
            private readonly ITerm[] terms;

            /// <inheritdoc />
            public int Count => this.terms.Length;

            /// <inheritdoc />
            public ITerm this[int index]
            {
                get
                {
                    #region Contract
                    if (index < 0 || index >= this.Count)
                        throw new ArgumentOutOfRangeException(nameof(index));
                    #endregion

                    if (this.terms[index] == null)
                    {
                        this.terms[index] = this.Owner.GreenTerm.Children[index].ConstructTerm(this.Owner);
                    }
                    return this.terms[index];
                }
            }

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="ChildrenList"/> class.
            /// </summary>
            /// <param name="owner">The owner.</param>
            public ChildrenList(ITerm owner)
            {
                #region Contract
                if (owner == null)
                    throw new ArgumentNullException(nameof(owner));
                #endregion

                this.Owner = owner;
                this.terms = new ITerm[owner.GreenTerm.Descriptor.Children.Count];
            }
            #endregion

            /// <inheritdoc />
            public IEnumerator<ITerm> GetEnumerator()
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
}
