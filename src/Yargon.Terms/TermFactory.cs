using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yargon.Terms
{
    /// <summary>
    /// A term factory.
    /// </summary>
    public class TermFactory
    {
        public ITerm CreateConstructor(ITermDescriptor descriptor, IEnumerable<ITerm> children)
        {
            var childrenList = children.ToList();
            if (descriptor == Num.Descriptor)
                return CreateNum((Token)childrenList[0]);
            else if (descriptor == Token.Descriptor)
                // FIXME: ToString is not correct. A string term maybe?
                // Or treat Tokens as a special case?
                return CreateToken(childrenList[0].ToString());
            else
                return CreateTerm(descriptor, childrenList);
        }

        public ListTerm CreateList(IEnumerable<ITerm> elements)
        {
            return new ListTerm.GreenListTerm(elements.Select(t => t.GreenTerm).ToList()).ConstructTerm(null);
        }

        public Token CreateToken(string value)
        {
            return new Token.Green(value).ConstructTerm(null);
        }

        public Num CreateNum(Token literal)
        {
            return new Num.Green(literal.GreenTerm).ConstructTerm(null);
        }

        public Term CreateTerm(ITermDescriptor descriptor, IEnumerable<ITerm> children)
        {
            return new Term.Green(descriptor, children.Select(t => t.GreenTerm).ToList()).ConstructTerm(null);
        }
    }
}
