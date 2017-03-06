using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Virtlink.Utilib.Collections;

namespace Yargon.Terms
{
    /// <summary>
    /// A token.
    /// </summary>
    public partial struct Token : ITerm
    {
        /// <summary>
        /// Gets the underlying green term.
        /// </summary>
        /// <value>The underlying green term.</value>
        public Green GreenTerm { get; }

        /// <summary>
        /// Gets the underlying green term.
        /// </summary>
        /// <value>The underlying green term.</value>
        IGreenTerm ITerm.GreenTerm => this.GreenTerm;

        /// <summary>
        /// Gets the value of the token.
        /// </summary>
        /// <value>The value of the token.</value>
        public string Value => this.GreenTerm.Value;

        // TODO: TokenType
        
        /// <inheritdoc />
        IReadOnlyList<ITerm> ITerm.Children => Virtlink.Utilib.Collections.List.Empty<ITerm>();

        /// <inheritdoc />
        IReadOnlyList<ITerm> ITerm.AbstractChildren => Virtlink.Utilib.Collections.List.Empty<ITerm>();

        /// <inheritdoc />
        public int Width => this.GreenTerm.Width;

        /// <inheritdoc />
        public ITerm Parent { get; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="greenTerm">The underlying green term.</param>
        /// <param name="parent">The parent term; or <see langword="null"/>.</param>
        public Token(Green greenTerm, [CanBeNull] ITerm parent)
        {
            #region Contract
            if (greenTerm == null)
                throw new ArgumentNullException(nameof(greenTerm));
            #endregion

            this.GreenTerm = greenTerm;
            this.Parent = parent;
        }
        #endregion

        #region Equality
        /// <inheritdoc />
        public bool Equals(Token other)
        {
            return this.GreenTerm == other.GreenTerm
                   && Object.Equals(this.Parent, other.Parent);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hash = 17;
            unchecked
            {
                hash = hash * 29 + this.GreenTerm.GetHashCode();
                hash = hash * 29 + this.Parent?.GetHashCode() ?? 0;
            }
            return hash;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Token && Equals((Token)obj);

        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="Token"/> objects are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(Token left, Token right) => Object.Equals(left, right);

        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="Token"/> objects are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(Token left, Token right) => !(left == right);
        #endregion

        /// <inheritdoc />
        public override string ToString()
        {
            return this.Value;
        }
    }
}
