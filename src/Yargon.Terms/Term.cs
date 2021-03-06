﻿using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Yargon.Terms.Collections;

namespace Yargon.Terms
{
    /// <summary>
    /// A term.
    /// </summary>
    public partial class Term : ITerm
    {
        /// <summary>
        /// Gets the underlying green term.
        /// </summary>
        /// <value>The underlying green term.</value>
        public IGreenTerm GreenTerm { get; }

        /// <summary>
        /// Gets the underlying green term.
        /// </summary>
        /// <value>The underlying green term.</value>
        IGreenTerm ITerm.GreenTerm => this.GreenTerm;
        
        /// <inheritdoc />
        public IReadOnlyList<ITerm> Children { get; }

        /// <inheritdoc />
        public IReadOnlyList<ITerm> AbstractChildren { get; }

        /// <inheritdoc />
        public int Width => this.GreenTerm.Width;

        /// <inheritdoc />
        public ITerm Parent { get; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Term"/> class.
        /// </summary>
        /// <param name="greenTerm">The underlying green term.</param>
        /// <param name="parent">The parent term; or <see langword="null"/>.</param>
        protected internal Term(IGreenTerm greenTerm, [CanBeNull] ITerm parent)
        {
            #region Contract
            if (greenTerm == null)
                throw new ArgumentNullException(nameof(greenTerm));
            #endregion

            this.GreenTerm = greenTerm;
            this.Parent = parent;
            // ReSharper disable once VirtualMemberCallInConstructor
            this.Children = CreateChildrenList();
            this.AbstractChildren = SubList<ITerm>.CreateFromDescriptor(greenTerm.Descriptor, this.Children);
        }
        #endregion

        #region Equality
        /// <inheritdoc />
        public bool Equals(Term other)
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
        public override bool Equals(object obj) => Equals(obj as Term);

        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="Term"/> objects are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(Term left, Term right) => Object.Equals(left, right);

        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="Term"/> objects are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(Term left, Term right) => !(left == right);
        #endregion

        /// <summary>
        /// Creates the list of children.
        /// </summary>
        /// <returns>The list of children to use.</returns>
        protected virtual IReadOnlyList<ITerm> CreateChildrenList()
        {
            return new ChildrenList(this);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.GreenTerm.ToString();
        }
    }
}
