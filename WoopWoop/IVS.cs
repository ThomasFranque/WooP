using System;
using System.Collections.Generic;
using System.Text;

namespace WoopWoop
{
    struct IVS
    {
        private Random rand;
        private float luckModifier;

        private byte attack;
        public byte Attack => attack;

        private byte specialAttack;
        public byte SpecialAttack => specialAttack;

        private byte defense;
        public byte Defense => defense;

        private byte specialDefense;
        public byte SpecialDefense => specialDefense;

        public IVS(float luckModifier = 0.0f)
        {
            rand = new Random();
            this.luckModifier = luckModifier;

            attack = (byte)rand.Next(0, 12);
        
            specialAttack = (byte)rand.Next(0, 12);

            defense = (byte)rand.Next(0, 12);

            specialDefense = (byte)rand.Next(0, 12);

            // 2 + 2 / luckmodifier = 3
        }

        public void LevelUp(byte currentLvl)
        {
            // check upcoming lvl
            byte upcomingLvl = (byte)(currentLvl + 1);

            // Finish later
        }
    }
}
