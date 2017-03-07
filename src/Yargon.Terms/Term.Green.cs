using System;
using System.Collections.Generic;
using System.Linq;
using Virtlink.Utilib.Collections;
using Yargon.Terms.Collections;

namespace Yargon.Terms
{
    partial class Term
    {
        /// <summary>
        /// The green Num term constructor.
        /// </summary>
        public sealed class Green : IGreenTerm
        {
            private readonly ITermDescriptor descriptor;

            /// <inheritdoc />
            ITermDescriptor IGreenTerm.Descriptor => this.descriptor;

            /// <inheritdoc />
            public IReadOnlyList<IGreenTerm> Children { get; }

            /// <inheritdoc />
            public IReadOnlyList<IGreenTerm> AbstractChildren { get; }

            /// <inheritdoc />
            public int Width => this.Children.Sum(c => c.Width);

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="Green"/> class.
            /// </summary>
            /// <param name="descriptor">The term descriptor.</param>
            /// <param name="children">The children of this term.</param>
            public Green(ITermDescriptor descriptor, IReadOnlyList<IGreenTerm> children)
            {
                #region Contract
                if (descriptor == null)
                    throw new ArgumentNullException(nameof(descriptor));
                if (children == null)
                    throw new ArgumentNullException(nameof(children));
                if (children.Any(c => c == null))
                    throw new ArgumentException("One or more children are null.", nameof(children));
                if (descriptor.Children.Count != children.Count)
                    throw new ArgumentException($"Expected {descriptor.Children.Count} children, got {children.Count}.", nameof(children));
                #endregion

                this.descriptor = descriptor;
                this.Children = children.ToArray();
                this.AbstractChildren = SubList<IGreenTerm>.CreateFromDescriptor(descriptor, this.Children);
            }
            #endregion

            #region Equality
            /// <inheritdoc />
            public bool Equals(Green other)
            {
                return !Object.ReferenceEquals(other, null)
                    && Object.Equals(this.descriptor, other.descriptor)
                    && ListComparer<IGreenTerm>.Default.Equals(this.Children, other.Children);
            }

            /// <inheritdoc />
            public override int GetHashCode()
            {
                int hash = 17;
                unchecked
                {
                    hash = hash * 29 + this.descriptor.GetHashCode();
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
            public Term ConstructTerm(ITerm parent)
                => new Term(this, parent);

            /// <inheritdoc />
            public override string ToString()
            {
                return String.Join("", this.Children);
            }
        }
    }
}
