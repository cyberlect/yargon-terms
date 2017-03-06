using System;
using System.Collections.Generic;
using Virtlink.Utilib.Collections;

namespace Yargon.Terms
{
    partial struct Token
    {
        /// <summary>
        /// The green term.
        /// </summary>
        public struct Green : IGreenTerm
        {
            /// <inheritdoc />
            ITermDescriptor IGreenTerm.Descriptor => Token.Descriptor;

            /// <summary>
            /// Gets the value of the token.
            /// </summary>
            /// <value>The value of the token.</value>
            public string Value { get; }

            // TODO: TokenType

            /// <inheritdoc />
            IReadOnlyList<IGreenTerm> IGreenTerm.Children => Virtlink.Utilib.Collections.List.Empty<IGreenTerm>();

            /// <inheritdoc />
            IReadOnlyList<IGreenTerm> IGreenTerm.AbstractChildren => Virtlink.Utilib.Collections.List.Empty<IGreenTerm>();

            /// <inheritdoc />
            public int Width => this.Value.Length;

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="Green"/> class.
            /// </summary>
            /// <param name="value">The value of the token.</param>
            public Green(string value)
            {
                #region Contract
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                #endregion

                this.Value = value;
            }
            #endregion

            #region Equality
            /// <inheritdoc />
            public bool Equals(Green other)
            {
                return this.Value == other.Value;
            }

            /// <inheritdoc />
            public override int GetHashCode()
            {
                int hash = 17;
                unchecked
                {
                    hash = hash * 29 + this.Value.GetHashCode();
                }
                return hash;
            }

            /// <inheritdoc />
            public override bool Equals(object obj) => obj is Green && Equals((Green)obj);

            /// <summary>
            /// Returns a value that indicates whether two specified <see cref="Token"/> objects are equal.
            /// </summary>
            /// <param name="left">The first object to compare.</param>
            /// <param name="right">The second object to compare.</param>
            /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal;
            /// otherwise, <see langword="false"/>.</returns>
            public static bool operator ==(Green left, Green right) => Object.Equals(left, right);

            /// <summary>
            /// Returns a value that indicates whether two specified <see cref="Token"/> objects are not equal.
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
            public Token ConstructTerm(ITerm parent)
                => new Token(this, parent);

            /// <inheritdoc />
            public override string ToString()
            {
                return this.Value;
            }
        }
    }
}
