using System;

namespace WoopWoop
{
    class Program
    {
        static void Main(string[] args)
        {
			Program prog = new Program();

			prog.Game();
        }

		public void Game()
		{
			Battle battle;

			Monster t1 = new Mons.Squirtle();
			Monster t2 = new Mons.Squirtle();

			battle = new Battle(t1, t2);

			battle.Start();
		}
	}
}
