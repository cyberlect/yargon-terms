using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Yargon.Terms
{
    /// <summary>
    /// The Num term constructor.
    /// </summary>
    public sealed partial class Num : ITerm
    {
        /// <summary>
        /// Gets the underlying green term.
        /// </summary>
        /// <value>The underlying green term.</value>
        private Green GreenTerm { get; }

        private readonly ChildrenList children;

        /// <summary>
        /// Gets the literal.
        /// </summary>
        public Token Literal => this.children.Literal;

        /// <inheritdoc />
        public IReadOnlyList<ITerm> Children => this.children;

        /// <inheritdoc />
        public IReadOnlyList<ITerm> AbstractChildren { get; }

        /// <inheritdoc />
        public int Width => this.GreenTerm.Width;

        /// <inheritdoc />
        public ITerm Parent { get; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Num"/> class.
        /// </summary>
        /// <param name="greenTerm">The underlying green term.</param>
        /// <param name="parent">The parent term; or <see langword="null"/>.</param>
        public Num(Green greenTerm, [CanBeNull] ITerm parent)
        {
            #region Contract
            if (greenTerm == null)
                throw new ArgumentNullException(nameof(greenTerm));
            #endregion

            this.GreenTerm = greenTerm;
            this.Parent = parent;
            this.children = new ChildrenList(this);
            this.AbstractChildren = new SubList<ITerm>(this.Children, new int[] { });
        }
        #endregion

        #region Equality
        /// <inheritdoc />
        public bool Equals(Num other)
        {
            return !Object.ReferenceEquals(other, null)
                && Object.Equals(this.GreenTerm, other.GreenTerm)
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
        public override bool Equals(object obj) => Equals(obj as Num);

        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="Num"/> objects are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(Num left, Num right) => Object.Equals(left, right);

        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="Num"/> objects are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(Num left, Num right) => !(left == right);
        #endregion

        /// <summary>
        /// Deconstructs the term.
        /// </summary>
        public void Deconstruct()
        {
            
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.GreenTerm.ToString();
        }
    }
}
