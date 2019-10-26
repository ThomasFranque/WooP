using System;
using System.Collections.Generic;
using System.Text;

namespace WoopWoop
{
	class Battle
	{
		private Monster _mon1;
		private int _mon1Hp;

		private Monster _mon2;
		private int _mon2Hp;

		private bool BattleEnd { get => !(_mon1Hp > 0 && _mon1Hp > 0); }

		public Battle(Monster mon1, Monster mon2)
		{
			_mon1 = mon1;
			_mon2 = mon2;
		}

		public void Start()
		{
			_mon1Hp = _mon1.IVs.HP;
			_mon2Hp = _mon2.IVs.HP;

			do 
			{
				_mon2Hp -= _mon1.IVs.Attack;
				if (BattleEnd) break;
				_mon1Hp -= _mon2.IVs.Attack;
			} 
			while (!BattleEnd);

			string msg = _mon1Hp > 0 ? "Mon 1 wins" : "Mon 2 wins";

			Console.WriteLine(msg);
		}
	}
}
