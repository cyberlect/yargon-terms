using System;

namespace Yargon.Terms
{
    /// <summary>
    /// Descriptor for a term child.
    /// </summary>
    public struct ChildDescriptor
    {
        /// <summary>
        /// Gets the name of the child.
        /// </summary>
        /// <value>The name of the child.</value>
        public string Name { get; }

        /// <summary>
        /// Gets whether the child is abstract.
        /// </summary>
        /// <value><see langword="true"/> when the child is abstract;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsAbstract { get; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ChildDescriptor"/> class.
        /// </summary>
        /// <param name="name">The name of the child.</param>
        /// <param name="isAbstract">Whether the child is abstract.</param>
        public ChildDescriptor(string name, bool isAbstract)
        {
            #region Contract
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            #endregion

            this.Name = name;
            this.IsAbstract = isAbstract;
        }
        #endregion

        #region Equality
        /// <inheritdoc />
        public bool Equals(ChildDescriptor other)
        {
            return this.Name == other.Name
                && this.IsAbstract == other.IsAbstract;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hash = 17;
            unchecked
            {
                hash = hash * 29 + this.Name.GetHashCode();
                hash = hash * 29 + this.IsAbstract.GetHashCode();
            }
            return hash;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ChildDescriptor && Equals((ChildDescriptor)obj);

        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="ChildDescriptor"/> objects are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(ChildDescriptor left, ChildDescriptor right) => Object.Equals(left, right);

        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="ChildDescriptor"/> objects are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(ChildDescriptor left, ChildDescriptor right) => !(left == right);
        #endregion

        /// <inheritdoc />
        public override string ToString()
        {
            return (this.IsAbstract ? "abstract " : "") + this.Name;
        }
    }
}
