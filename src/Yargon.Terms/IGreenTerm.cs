using System.Collections.Generic;

namespace Yargon.Terms
{
    /// <summary>
    /// A green term.
    /// </summary>
    /// <remarks>
    /// Green terms are part of the DAG and may only store information about themselves,
    /// or information derivable from their descendants.
    /// </remarks>
    public interface IGreenTerm
    {
        /// <summary>
        /// Gets the descriptor for this term.
        /// </summary>
        /// <value>The descriptor.</value>
        ITermDescriptor Descriptor { get; }

        /// <summary>
        /// Gets a list of all child terms of this term,
        /// both concrete terms and abstract terms.
        /// </summary>
        /// <value>A list of concrete and abstract child terms.</value>
        IReadOnlyList<IGreenTerm> Children { get; }

        /// <summary>
        /// Gets a list of all abstract child terms of this term.
        /// </summary>
        /// <value>A list of abstract child terms.</value>
        IReadOnlyList<IGreenTerm> AbstractChildren { get; }

        /// <summary>
        /// Gets the number of input characters that this term describes.
        /// </summary>
        /// <value>The input width.</value>
        int Width { get; }

        /// <summary>
        /// Constructs a corresponding red term for this term.
        /// </summary>
        /// <param name="parent">The parent term.</param>
        /// <returns>The resulting red term.</returns>
        ITerm ConstructTerm(ITerm parent);
    }
}
