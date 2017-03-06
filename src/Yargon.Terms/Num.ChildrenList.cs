using System;
using System.Collections;
using System.Collections.Generic;

namespace Yargon.Terms
{
    partial class Num
    {
        private sealed class ChildrenList : IReadOnlyList<ITerm>
        {
            private readonly Num owner;
            private Token? literal;

            public Token Literal
            {
                get
                {
                    if (this.literal == null)
                    {
                        this.literal = this.owner.GreenTerm.Literal.ConstructTerm(this.owner);
                    }
                    return this.literal.Value;
                }
            }

            /// <inheritdoc />
            public int Count => 1;

            /// <inheritdoc />
            public ITerm this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0: return this.Literal;
                        default: throw new ArgumentOutOfRangeException(nameof(index));
                    }
                }
            }

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="ChildrenList"/> class.
            /// </summary>
            /// <param name="owner">The owner.</param>
            public ChildrenList(Num owner)
            {
                this.owner = owner;
            }
            #endregion

            /// <inheritdoc />
            public IEnumerator<ITerm> GetEnumerator()
            {
                yield return this.Literal;
            }

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
