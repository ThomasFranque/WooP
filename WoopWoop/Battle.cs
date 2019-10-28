using System;
using System.Threading;

namespace WoopWoop
{
	class Battle
	{
		private Monster _mon1;
		private int _mon1Hp;

		private Monster _mon2;
		private int _mon2Hp;

		private bool BattleEnd 
        { get => !(_mon1Hp > 0 && _mon2Hp > 0); }

		public Battle(Monster mon1, Monster mon2)
		{
			_mon1 = mon1;
			_mon2 = mon2;
		}

		public void Start()
		{
			_mon1Hp = _mon1.IVs.HP;
			_mon2Hp = _mon2.IVs.HP;

            Monster fastest;
            Monster slowest;

            ShowInterface(_mon1, _mon2, _mon1Hp, _mon2Hp);
            Thread.Sleep(850);
            do 
			{
                fastest = GetFasterMon(_mon1, _mon2);
                slowest = _mon1 == fastest ? _mon2 : _mon1;

                TurnOf(fastest);
                ShowInterface(_mon1, _mon2, _mon1Hp, _mon2Hp);
                Thread.Sleep(1000);
                if (BattleEnd) break;
                TurnOf(slowest);
                ShowInterface(_mon1, _mon2, _mon1Hp, _mon2Hp);
                Thread.Sleep(1000);

                //_mon2Hp -= _mon1.IVs.Attack;
                //if (BattleEnd) break;
                //_mon1Hp -= _mon2.IVs.Attack;
            }
            while (!BattleEnd);

			string msg = _mon1Hp > 0 ? "Mon 1 wins" : "Mon 2 wins";

			Console.WriteLine("\n " + msg);
		}

        private void TurnOf(Monster mon)
        {
            if (mon == _mon1) Attack(_mon1, _mon2, ref _mon2Hp);
            else Attack(_mon2, _mon1, ref _mon1Hp);            
        }

        private static void Attack(Monster attacker, Monster victim, ref int targetHP)
        {
            float finalDmg;
            float defPercentage;

            defPercentage = (100 * victim.IVs.Defense) / 300;

            finalDmg = attacker.IVs.Attack - (attacker.IVs.Attack * defPercentage);

            targetHP -= (int)Math.Round(finalDmg, 0);

            if (targetHP < 0) targetHP = 0;
        }

        private static Monster GetFasterMon(Monster mon1, Monster mon2)
        {
            Monster fasterMon = null;

            int mon1S = mon1.IVs.Speed;
            int mon2S = mon2.IVs.Speed;

            if (mon1S == mon2S)
            {
                Random rand = new Random();

                double decision = rand.NextDouble();

                fasterMon = decision < 0.5 ? mon1 : mon2;
            }

            else if (mon1S < mon2S)
                fasterMon = mon2;
            else
                fasterMon = mon1;

            return fasterMon;
        }

        private static void ShowInterface
            (Monster mon1, Monster mon2, int mon1Hp, int mon2Hp)
        {
            Console.Clear();
            Console.WriteLine(
                $"{mon1.CustomName}\n" +
                $"HP: {mon1Hp}\n\n" +
                $"{mon2.CustomName}\n" +
                $"HP: {mon2Hp}");
        }
	}
}