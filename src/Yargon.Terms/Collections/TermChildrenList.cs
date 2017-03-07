using System;
using System.Diagnostics;

namespace Yargon.Terms.Collections
{
    /// <summary>
    /// A list of red children.
    /// </summary>
    public sealed class TermChildrenList : WeakConstructedList<ITerm>
    {
        /// <summary>
        /// The owner of this list.
        /// </summary>
        private ITerm Owner { get; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TermChildrenList"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TermChildrenList(ITerm owner)
            : base(owner.GreenTerm.Descriptor.Children.Count)
        {
            #region Contract
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));
            #endregion

            this.Owner = owner;
        }
        #endregion

        /// <inheritdoc />
        protected override ITerm BuildElement(int index)
        {
            #region Contract
            Debug.Assert(index >= 0 && index < this.Count);
            #endregion

            return this.Owner.GreenTerm.Children[index].ConstructTerm(this.Owner);
        }
    }
}
