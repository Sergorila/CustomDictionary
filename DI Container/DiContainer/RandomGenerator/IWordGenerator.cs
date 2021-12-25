using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainer
{
    public interface IWordGenerator
    {
        string RandomWord { get; }
        string GenerateWord();
    }
}
