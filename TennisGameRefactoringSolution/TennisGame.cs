using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGameRefactoringSolution
{
    public class TennisGame
    {
        private int m_playerOneScore = 0;
        private int m_playerTwoScore = 0;
        private String m_playerTwoName;
        private String m_playerOneName;

        public TennisGame(String playerOneName, String playerTwoName)
        {
            m_playerOneName = playerOneName;
            m_playerTwoName = playerTwoName;
        }

        public String GetScore()
        {

            if (HasWinner())
            {
                return PlayerWithHighestScore() + " wins";
            }

            if (HasAdvantage())
            {
                return "Advantage " + PlayerWithHighestScore();
            }

            if (IsDeuce())
                return "Deuce";

            if (m_playerOneScore == m_playerTwoScore)
            {
                return TranslateScore(m_playerOneScore) + "-All";
            }

            return TranslateScore(m_playerOneScore) + "-" + TranslateScore(m_playerTwoScore);
        }

        private bool IsDeuce()
        {
            return m_playerOneScore >= 3 && m_playerTwoScore == m_playerOneScore;
        }

        private String PlayerWithHighestScore()
        {
            if (m_playerOneScore > m_playerTwoScore)
            {
                return m_playerOneName;
            }
            else
            {
                return m_playerTwoName;
            }
        }

        private bool HasWinner()
        {
            if (m_playerTwoScore >= 4 && m_playerTwoScore >= m_playerOneScore + 2)
                return true;
            if (m_playerOneScore >= 4 && m_playerOneScore >= m_playerTwoScore + 2)
                return true;
            return false;
        }

        private bool HasAdvantage()
        {
            if (m_playerTwoScore >= 4 && m_playerTwoScore == m_playerOneScore + 1)
                return true;
            if (m_playerOneScore >= 4 && m_playerOneScore == m_playerTwoScore + 1)
                return true;

            return false;

        }

        public void PlayerOneScores()
        {
            m_playerOneScore++;
        }

        public void PlayerTwoScores()
        {
            m_playerTwoScore++;
        }

        private static String TranslateScore(int score)
        {
            switch (score)
            {
                case 3:
                    return "Forty";
                case 2:
                    return "Thirty";
                case 1:
                    return "Fifteen";
                case 0:
                    return "Love";
            }
            throw new InvalidExpressionException("Illegal score: " + score);
        }
    }
}
