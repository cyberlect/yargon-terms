using System.Collections.Generic;
using JetBrains.Annotations;

namespace Yargon.Terms
{
    /// <summary>
    /// The Num term constructor.
    /// </summary>
    public sealed partial class Num : Term
    {
        /// <summary>
        /// Gets the underlying green term.
        /// </summary>
        /// <value>The underlying green term.</value>
        private new Green GreenTerm => (Green) base.GreenTerm;
        
        /// <summary>
        /// Gets the literal.
        /// </summary>
        public Token Literal => this.InnerChildren.Literal;

        /// <summary>
        /// Gets the inner children list.
        /// </summary>
        /// <value>The inner children list.</value>
        private ChildrenList InnerChildren => (ChildrenList)this.Children;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Num"/> class.
        /// </summary>
        /// <param name="greenTerm">The underlying green term.</param>
        /// <param name="parent">The parent term; or <see langword="null"/>.</param>
        public Num(Green greenTerm, [CanBeNull] ITerm parent)
            : base(greenTerm, parent)
        {
            // Nothing to do.
        }
        #endregion

        /// <inheritdoc />
        protected override IReadOnlyList<ITerm> CreateChildrenList()
        {
            return new ChildrenList(this);
        }
        
        /// <summary>
        /// Deconstructs the term.
        /// </summary>
        public void Deconstruct()
        {
            
        }
    }
}
