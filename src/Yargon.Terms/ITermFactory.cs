using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yargon.Terms
{
    public interface ITermFactory
    {
        ITerm CreateTerm(ITermDescriptor descriptor, IEnumerable<ITerm> children);

        ListTerm CreateList(IEnumerable<ITerm> elements);

        Token CreateToken(string value);

        Num CreateNum(Token literal);
    }
}
