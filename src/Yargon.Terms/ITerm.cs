using System.Collections.Generic;
using JetBrains.Annotations;

namespace Yargon.Terms
{
    /// <summary>
    /// A term.
    /// </summary>
    /// <remarks>
    /// (Red) terms are part of the (temporary) tree and store information about themselves,
    /// and any information derivable from their descendants or ancestors.
    /// </remarks>
    public interface ITerm
    {
        /// <summary>
        /// Gets the underlying green term.
        /// </summary>
        /// <value>The underlying green term.</value>
        IGreenTerm GreenTerm { get; }

        /// <summary>
        /// Gets a list of all child terms of this term,
        /// both concrete terms and abstract terms.
        /// </summary>
        /// <value>A list of concrete and abstract child terms.</value>
        IReadOnlyList<ITerm> Children { get; }

        /// <summary>
        /// Gets a list of all abstract child terms of this term.
        /// </summary>
        /// <value>A list of abstract child terms.</value>
        IReadOnlyList<ITerm> AbstractChildren { get; }

        /// <summary>
        /// Gets the number of input characters that this term describes.
        /// </summary>
        /// <value>The input width.</value>
        int Width { get; }


        /// <summary>
        /// Gets the parent term.
        /// </summary>
        /// <value>The parent term; or <see langword="null"/> when this is the root term.</value>
        [CanBeNull]
        ITerm Parent { get; }
    }
}
