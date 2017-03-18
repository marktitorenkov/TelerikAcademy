namespace Minesweeper
{
	public partial class Minesweeper
	{
		public class HighScore
		{
			string name;
			int score;

			public HighScore(string име, int то4ки)
			{
				this.name = име;
				this.score = то4ки;
			}

			public string Name
			{
				get { return name; }
				set { name = value; }
			}

			public int Score
			{
				get { return score; }
				set { score = value; }
			}
		}
	}
}
