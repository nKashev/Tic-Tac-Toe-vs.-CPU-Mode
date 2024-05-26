using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeWPF
{
    class GameStatus
    {
        public bool gameOver;
        public bool tie;
        public string winner;

        public GameStatus()
        {
            gameOver = false;
            tie = false;
            winner = null;
        }
        public GameStatus(bool gameOver, string winner, bool tie)
        {
            this.gameOver = gameOver;
            this.winner = winner;
            this.tie = tie;
        }

        public void setGameOver(bool gameOver)
        {
            this.gameOver = gameOver;
        }

        public bool isGameOver()
        {
            return gameOver;
        }

        public void setWinner(string winner)
        {
            this.winner = winner;
        }

        public string getWinner()
        {
            return winner;
        }

        public bool isTie()
        {
            return tie;
        }

        public void setTie(bool tie)
        {
            this.tie = tie;
        }
    }
}
