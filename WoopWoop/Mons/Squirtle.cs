using System;
using System.Collections.Generic;
using System.Text;

namespace WoopWoop.Mons
{
    class Squirtle : Monster
    {
        public override EntityTypes EntityTypes { get; }

        public override IVS IVs { get; protected set; }

        public Squirtle(string name) : base(name)
        {
            EntityTypes = 
                new EntityTypes(Typings.Water, Typings.None);

            IVs = new IVS(1);
        }
    }
}
