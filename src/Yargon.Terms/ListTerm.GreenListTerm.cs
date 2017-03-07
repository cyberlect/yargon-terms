using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Yargon.Terms
{
    partial class ListTerm
    {
        /// <summary>
        /// The green term for the <see cref="ListTerm"/>.
        /// </summary>
        public sealed class GreenListTerm : IGreenTerm
        {
            // TODO
            /// <inheritdoc />
            public ITermDescriptor Descriptor { get; }

            /// <inheritdoc />
            public IReadOnlyList<IGreenTerm> Children { get; }

            // TODO
            /// <inheritdoc />
            public IReadOnlyList<IGreenTerm> AbstractChildren { get; }

            /// <inheritdoc />
            public int Width => this.Children.Sum(c => c.Width);

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="GreenListTerm"/> class.
            /// </summary>
            /// <param name="elements">The elements in the list.</param>
            public GreenListTerm(IReadOnlyList<IGreenTerm> elements)
            {
                #region Contract
                if (elements == null)
                    throw new ArgumentNullException(nameof(elements));
                #endregion

                this.Children = elements;
            }
            #endregion

            /// <inheritdoc />
            ITerm IGreenTerm.ConstructTerm(ITerm parent)
                => ConstructTerm(parent);

            /// <summary>
            /// Constructs a corresponding red term for this term.
            /// </summary>
            /// <param name="parent">The parent term.</param>
            /// <returns>The resulting red term.</returns>
            public ListTerm ConstructTerm(ITerm parent)
                => new ListTerm(this, parent);

            /// <inheritdoc />
            public override string ToString()
            {
                return String.Join("", this.Children);
            }
        }
    }
}
