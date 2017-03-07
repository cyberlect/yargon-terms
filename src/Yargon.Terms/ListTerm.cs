using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Yargon.Terms.Collections;

namespace Yargon.Terms
{
    /// <summary>
    /// A list of terms.
    /// </summary>
    public sealed partial class ListTerm : ITerm, IReadOnlyList<ITerm>
    {
        /// <inheritdoc />
        public ITerm Parent { get; }

        /// <summary>
        /// Gets the underlying green term.
        /// </summary>
        /// <value>The underlying green term.</value>
        internal GreenListTerm GreenTerm { get; }

        /// <inheritdoc />
        IGreenTerm ITerm.GreenTerm => this.GreenTerm;

        /// <inheritdoc />
        public int Count => this.Children.Count;

        /// <inheritdoc />
        public ITerm this[int index]
        {
            get
            {
                #region Contract
                if (index < 0 || index >= this.Count)
                    throw new ArgumentNullException(nameof(index));
                #endregion

                return this.Children[index];
            }
        }

        public IReadOnlyList<ITerm> Children { get; }

        // TODO
        public IReadOnlyList<ITerm> AbstractChildren { get; }

        /// <inheritdoc />
        public int Width => this.GreenTerm.Width;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ListTerm"/> class.
        /// </summary>
        /// <param name="greenTerm">The underlying green term.</param>
        /// <param name="parent">The parent term;
        /// or <see langword="null"/> when the term has no parent.</param>
        internal ListTerm(GreenListTerm greenTerm, [CanBeNull] ITerm parent)
        {
            #region Contract
            if (greenTerm == null)
                throw new ArgumentNullException(nameof(greenTerm));
            #endregion

            this.GreenTerm = greenTerm;
            this.Parent = parent;
            this.Children = new TermChildrenList(this);
        }
        #endregion

        /// <inheritdoc />
        public IEnumerator<ITerm> GetEnumerator()
        {
            return this.Children.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
