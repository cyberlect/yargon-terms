using System;
using System.Collections.Generic;
using System.Linq;

namespace Yargon.Terms
{
    partial class Num
    {
        /// <summary>
        /// The green Num term constructor.
        /// </summary>
        public sealed class Green : IGreenTerm
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
