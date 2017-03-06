using System;
using System.Collections;
using System.Collections.Generic;

namespace Yargon.Terms
{
    partial class Num
    {
        private sealed class GreenChildrenList : IReadOnlyList<IGreenTerm>
        {
            /// <summary>
            /// Gets the literal.
            /// </summary>
            /// <value>The literal.</value>
            public Token.Green Literal { get; }

            /// <inheritdoc />
            public int Count => 1;

            /// <inheritdoc />
            public IGreenTerm this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0:
                            return this.Literal;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(index));
                    }
                }
            }

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="GreenChildrenList"/> class.
            /// </summary>
            /// <param name="literal">The literal.</param>
            public GreenChildrenList(Token.Green literal)
            {
                this.Literal = literal;
            }
            #endregion

            /// <inheritdoc />
            public IEnumerator<IGreenTerm> GetEnumerator()
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
