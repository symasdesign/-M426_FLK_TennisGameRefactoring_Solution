using TennisGameRefactoringSolution;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        public static void CheckAllScores(TennisGame game, int player1Score, int player2Score, String expectedScore)
        {
            int highestScore = Math.Max(player1Score, player2Score);
            for (int i = 0; i < highestScore; i++)
            {
                if (i < player1Score)
                {
                    game.PlayerOneScores();
                }
                if (i < player2Score)
                {
                    game.PlayerTwoScores();
                }
            }
            Assert.AreEqual(expectedScore, game.GetScore());
        }

        [TestMethod]
        [DataRow(0, 0, "Love-All")]
        [DataRow(1, 1, "Fifteen-All")]
        [DataRow(2, 2, "Thirty-All")]
        [DataRow(3, 3, "Deuce")]
        [DataRow(4, 4, "Deuce")]
        [DataRow(1, 0, "Fifteen-Love")]
        [DataRow(0, 1, "Love-Fifteen")]
        [DataRow(2, 0, "Thirty-Love")]
        [DataRow(0, 2, "Love-Thirty")]
        [DataRow(3, 0, "Forty-Love")]
        [DataRow(0, 3, "Love-Forty")]
        [DataRow(4, 0, "Player1 wins")]
        [DataRow(0, 4, "Player2 wins")]
        [DataRow(2, 1, "Thirty-Fifteen")]
        [DataRow(1, 2, "Fifteen-Thirty")]
        [DataRow(3, 1, "Forty-Fifteen")]
        [DataRow(1, 3, "Fifteen-Forty")]
        [DataRow(4, 1, "Player1 wins")]
        [DataRow(1, 4, "Player2 wins")]
        [DataRow(3, 2, "Forty-Thirty")]
        [DataRow(2, 3, "Thirty-Forty")]
        [DataRow(4, 2, "Player1 wins")]
        [DataRow(2, 4, "Player2 wins")]
        [DataRow(4, 3, "Advantage Player1")]
        [DataRow(3, 4, "Advantage Player2")]
        [DataRow(5, 4, "Advantage Player1")]
        [DataRow(4, 5, "Advantage Player2")]
        [DataRow(15, 14, "Advantage Player1")]
        [DataRow(14, 15, "Advantage Player2")]
        [DataRow(6, 4, "Player1 wins")]
        [DataRow(4, 6, "Player2 wins")]
        [DataRow(16, 14, "Player1 wins")]
        [DataRow(14, 16, "Player2 wins")]
        public void CheckAllScoresTennisGame(int player1Score, int player2Score,
            String expectedScore)
        {
            TennisGame game = new("Player1", "Player2");
            CheckAllScores(game, player1Score, player2Score, expectedScore);
        }
    }
}