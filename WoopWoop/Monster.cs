using System;
using System.Collections.Generic;
using System.Text;

namespace WoopWoop
{
    abstract class Monster
    {
        public abstract IVS IVs                 { get; protected set; }
        public abstract EntityTypes EntityTypes { get; }
		public virtual string CustomName        { get; }
        public virtual byte Level               { get; }
        public virtual float XP                 { get; }

		public void LevelUp()
		{
			IVs = IVS.LevelUp(IVs);
		}

        public override bool Equals(object obj)
        {
            Monster monsterObj = obj as Monster;
            if (monsterObj == null) return false;
            return monsterObj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return EntityTypes.Type1.GetHashCode() ^ 
                EntityTypes.Type2.GetHashCode() ^ 
                CustomName.GetHashCode() ^
                Level.GetHashCode()^
                XP.GetHashCode();
        }
    }
}
