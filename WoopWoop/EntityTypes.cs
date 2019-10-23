using System;
using System.Collections.Generic;
using System.Text;

namespace WoopWoop
{
    struct EntityTypes
    {
        public Typings Type1 { get; }
        public Typings Type2 { get; }

        public EntityTypes(Typings type1, Typings type2)
        {
            Type1 = type1;
            Type2 = type2;
        }
    }
}
