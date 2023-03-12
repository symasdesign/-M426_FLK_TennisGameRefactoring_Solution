namespace TennisGameRefactoringSolution {
    public class TennisGame {
        private int playerOneScore = 0;
        private int playerTwoScore = 0;
        private string playerTwoName;
        private string playerOneName;

        public TennisGame(string playerOneName, string playerTwoName) {
            this.playerOneName = playerOneName;
            this.playerTwoName = playerTwoName;
        }

        public string GetScore() {

            if (HasWinner()) {
                return PlayerWithHighestScore() + " wins";
            }

            if (HasAdvantage()) {
                return "Advantage " + PlayerWithHighestScore();
            }

            if (IsDeuce())
                return "Deuce";

            if (playerOneScore == playerTwoScore) {
                return TranslateScore(playerOneScore) + "-All";
            }

            return TranslateScore(playerOneScore) + "-" + TranslateScore(playerTwoScore);
        }

        private bool IsDeuce() {
            return playerOneScore >= 3 && playerTwoScore == playerOneScore;
        }

        private String PlayerWithHighestScore() {
            if (playerOneScore > playerTwoScore) {
                return playerOneName;
            } else {
                return playerTwoName;
            }
        }

        private bool HasWinner() {
            if (playerTwoScore >= 4 && playerTwoScore >= playerOneScore + 2)
                return true;
            if (playerOneScore >= 4 && playerOneScore >= playerTwoScore + 2)
                return true;
            return false;
        }

        private bool HasAdvantage() {
            if (playerTwoScore >= 4 && playerTwoScore == playerOneScore + 1)
                return true;
            if (playerOneScore >= 4 && playerOneScore == playerTwoScore + 1)
                return true;

            return false;

        }

        public void PlayerOneScores() {
            playerOneScore++;
        }

        public void PlayerTwoScores() {
            playerTwoScore++;
        }

        private static string TranslateScore(int score) {
            switch (score) {
                case 3:
                    return "Forty";
                case 2:
                    return "Thirty";
                case 1:
                    return "Fifteen";
                case 0:
                    return "Love";
            }
            throw new Exception("Illegal score: " + score);
        }
    }
}