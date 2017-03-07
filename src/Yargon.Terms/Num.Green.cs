using System;
using System.Collections.Generic;
using System.Linq;
using Virtlink.Utilib.Collections;
using Yargon.Terms.Collections;

namespace Yargon.Terms
{
    partial class Num
    {
        /// <summary>
        /// The green Num term constructor.
        /// </summary>
        public new sealed class Green : IGreenTerm
        {
            private readonly GreenChildrenList children;

            /// <inheritdoc />
            ITermDescriptor IGreenTerm.Descriptor => Num.Descriptor;

            /// <summary>
            /// Gets the literal.
            /// </summary>
            public Token.Green Literal => this.children.Literal;

            /// <inheritdoc />
            public IReadOnlyList<IGreenTerm> Children => this.children;

            /// <inheritdoc />
            public IReadOnlyList<IGreenTerm> AbstractChildren { get; }

            /// <inheritdoc />
            public int Width => this.Children.Sum(c => c.Width);

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="Green"/> class.
            /// </summary>
            /// <param name="literal">The literal.</param>
            public Green(Token.Green literal)
            {
                this.children = new GreenChildrenList(literal);
                this.AbstractChildren = new SubList<IGreenTerm>(this.Children, new int[] { });
            }
            #endregion

            #region Equality
            /// <inheritdoc />
            public bool Equals(Green other)
            {
                return !Object.ReferenceEquals(other, null)
                       && ListComparer<IGreenTerm>.Default.Equals(this.Children, other.Children);
            }

            /// <inheritdoc />
            public override int GetHashCode()
            {
                int hash = 17;
                unchecked
                {
                    hash = hash * 29 + ListComparer<IGreenTerm>.Default.GetHashCode(this.Children);
                }
                return hash;
            }

            /// <inheritdoc />
            public override bool Equals(object obj) => Equals(obj as Green);

            /// <summary>
            /// Returns a value that indicates whether two specified <see cref="Green"/> objects are equal.
            /// </summary>
            /// <param name="left">The first object to compare.</param>
            /// <param name="right">The second object to compare.</param>
            /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal;
            /// otherwise, <see langword="false"/>.</returns>
            public static bool operator ==(Green left, Green right) => Object.Equals(left, right);

            /// <summary>
            /// Returns a value that indicates whether two specified <see cref="Green"/> objects are not equal.
            /// </summary>
            /// <param name="left">The first object to compare.</param>
            /// <param name="right">The second object to compare.</param>
            /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal;
            /// otherwise, <see langword="false"/>.</returns>
            public static bool operator !=(Green left, Green right) => !(left == right);
            #endregion

            /// <inheritdoc />
            ITerm IGreenTerm.ConstructTerm(ITerm parent)
                => ConstructTerm(parent);

            /// <inheritdoc />
            public Num ConstructTerm(ITerm parent)
                => new Num(this, parent);

            /// <inheritdoc />
            public override string ToString()
            {
                return String.Join("", this.Children);
            }
        }
    }
}
