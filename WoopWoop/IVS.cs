﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WoopWoop
{
    struct IVS
    {
		private const byte ENCOUNTER_LEVEL_IV_FACTOR	= 2;
		private const byte MAX_BONUS_HP_GAIN			= 5;
		private const byte MIN_BONUS_HP_GAIN			= 1;
		private const byte MAX_STAT_GAIN				= 4;
		private const byte MIN_STAT_GAIN				= 1;

        private int _hp;
        public int HP => _hp;

        private int _attack;
        public int Attack => _attack;

        private int _specialAttack;
        public int SpecialAttack => _specialAttack;

        private int _defense;
        public int Defense => _defense;

        private int _specialDefense;
        public int SpecialDefense => _specialDefense;

        private int _speed;
        public int Speed => _speed;

        public IVS(byte lvl)
        {
			Random rand = new Random();

			int maxStatNum = lvl * ENCOUNTER_LEVEL_IV_FACTOR + 2;
			int minStatNum = maxStatNum - MAX_STAT_GAIN;
			if (minStatNum < 1) minStatNum = 1;

			_hp =				rand.Next(minStatNum, maxStatNum + 10);

            _attack =			rand.Next(minStatNum, maxStatNum);
        
            _specialAttack =	rand.Next(minStatNum, maxStatNum);

            _defense =			rand.Next(minStatNum, maxStatNum);

            _specialDefense =	rand.Next(minStatNum, maxStatNum);

            _speed          =   rand.Next(minStatNum, maxStatNum);
        }

		public IVS
            (int hp, int atk, int spAtk, int def, int spDef, int speed)
		{
			_hp = hp;

			_attack = atk;

			_specialAttack = spAtk;

			_defense = def;

			_specialDefense = spDef;

            _speed = speed;
        }

		public static IVS LevelUp(IVS ivsToLvl)
		{
			Random rand = new Random();

			int hp		= 0;
			int atk		= 0;
			int spAtk	= 0;
			int def		= 0;
			int spDef	= 0;
            int speed   = 0;

			hp =
				ivsToLvl.HP + rand.Next(MIN_STAT_GAIN, MAX_STAT_GAIN) +
				rand.Next(MIN_BONUS_HP_GAIN, MAX_BONUS_HP_GAIN);
			atk = 
				ivsToLvl.Attack + rand.Next(MIN_STAT_GAIN, MAX_STAT_GAIN);
			spAtk = 
				ivsToLvl.SpecialAttack + rand.Next(MIN_STAT_GAIN, MAX_STAT_GAIN);
			def = 
				ivsToLvl.Defense + rand.Next(MIN_STAT_GAIN, MAX_STAT_GAIN);
			spDef = 
				ivsToLvl.SpecialDefense + rand.Next(MIN_STAT_GAIN, MAX_STAT_GAIN);
            speed = 
				ivsToLvl.Speed + rand.Next(MIN_STAT_GAIN, MAX_STAT_GAIN);

            if (hp >= 300) hp = 300;
            if (atk >= 300) atk = 300;
            if (spAtk >= 300) spAtk = 300;
            if (def >= 300) def = 300;
            if (spDef >= 300) spDef = 300;
            if (speed >= 300) speed = 300;

			return new IVS(hp, atk, spAtk, def, spDef, speed);
		}

		public override string ToString() =>
			$"Max HP ..... {HP}\n" +
			$"Attack ..... {Attack}\n" +
			$"SpAttack ... {SpecialAttack}\n" +
			$"Defense .... {Defense}\n" +
			$"SpDefense .. {SpecialDefense}" +
            $"Speed ...... {Speed}";
	}
}
