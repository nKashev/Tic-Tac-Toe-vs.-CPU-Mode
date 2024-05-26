using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToeWPF
{
    class ArtificialIntelligence
    {
        public const string AI_SYMBOL = Constants.O_SYMBOL;
        public const string ENEMY_SYMBOL = Constants.X_SYMBOL;

        public static void performEasyMove(List<Button> buttons)
        {
            List<Button> notClicked = new List<Button>();

            foreach (Button button in buttons)
            {
                if (button.IsEnabled == true)
                {
                    notClicked.Add(button);
                }
            }

            Random random = new Random();
            int index = random.Next(0, notClicked.Count);
            Button move = notClicked.ElementAt(index);

            performMove(move);
        }

        public static void performHardMove(List<Button> buttons)
        {
            if (possibleWin(buttons))
            {
                return;
            }
            else if (avoidEnemyWin(buttons))
            {
                return;
            }

            performEasyMove(buttons);
            //else
            //{
            //    prepareWin(buttons);
            //}
        }

        private static bool possibleWin(List<Button> buttons)
        {
            if (checkForHorizontalWin(buttons))
            {
                return true;
            }
            else if (checkForVerticalWin(buttons))
            {
                return true;
            }
            else if (checkForDiagonalWin(buttons))
            {
                return true;
            }

            return false;
        }

        private static bool avoidEnemyWin(List<Button> buttons)
        {
            if (checkForEnemyHorizontalWin(buttons))
            {
                return true;
            }
            else if (checkForEnemyVerticalWin(buttons))
            {
                return true;
            }
            else if (checkForEnemyDiagonalWin(buttons))
            {
                return true;
            }

            return false;
        }

        private static void prepareWin(List<Button> buttons)
        {

        }

        /******************
         * HELPER METHODS *
         ******************/
        private static bool isAi(Button button)
        {
            if (button.Content.Equals(AI_SYMBOL))
            {
                return true;
            }

            return false;
        }

        private static bool isEnemy(Button button)
        {
            if (button.Content.Equals(ENEMY_SYMBOL))
            {
                return true;
            }

            return false;
        }

        private static void performMove(Button button)
        {
            button.Content = AI_SYMBOL;
            button.IsEnabled = false;
        }

        /***********************************
         * OUTSOURCED LOGIC - WINNING MOVE *
         ***********************************/
        private static bool checkForHorizontalWin(List<Button> buttons)
        {
            for (int i = 0; i < 3; i++)
            {
                Button firstButton = buttons.ElementAt(i * 3);
                Button secondButton = buttons.ElementAt((i * 3) + 1);
                Button thirdButton = buttons.ElementAt((i * 3) + 2);

                if (isAi(firstButton) && isAi(secondButton))
                {
                    if (thirdButton.IsEnabled == true)
                    {
                        performMove(thirdButton);
                        return true;
                    }
                }
                else if (isAi(firstButton) && isAi(thirdButton))
                {
                    if (secondButton.IsEnabled == true)
                    {
                        performMove(secondButton);
                        return true;
                    }
                }
                else if (isAi(secondButton) && isAi(thirdButton))
                {
                    if (firstButton.IsEnabled == true)
                    {
                        performMove(firstButton);
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool checkForVerticalWin(List<Button> buttons)
        {
            for (int i = 0; i < 3; i++)
            {
                Button firstButton = buttons.ElementAt(i);
                Button secondButton = buttons.ElementAt(i + 3);
                Button thirdButton = buttons.ElementAt(i + (2 * 3));

                if (isAi(firstButton) && isAi(secondButton))
                {
                    if (thirdButton.IsEnabled == true)
                    {
                        performMove(thirdButton);
                        return true;
                    }
                }
                else if (isAi(firstButton) && isAi(thirdButton))
                {
                    if (secondButton.IsEnabled == true)
                    {
                        performMove(secondButton);
                        return true;
                    }
                }
                else if (isAi(secondButton) && isAi(thirdButton))
                {
                    if (firstButton.IsEnabled == true)
                    {
                        performMove(firstButton);
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool checkForDiagonalWin(List<Button> buttons)
        {
            Button topLeft = buttons.ElementAt(0);
            Button topRight = buttons.ElementAt(2);
            Button center = buttons.ElementAt(4);
            Button bottomLeft = buttons.ElementAt(6);
            Button bottomRight = buttons.ElementAt(8);

            if (checkTopLeftToBottomRight(topLeft, center, bottomRight))
            {
                return true;
            }
            else if (checkBottomLeftToTopRight(bottomLeft, center, topRight))
            {
                return true;
            }

            return false;
        }

        private static bool checkTopLeftToBottomRight(Button topLeft, Button center, Button bottomRight)
        {
            if (isAi(topLeft) && isAi(center))
            {
                if (bottomRight.IsEnabled == true)
                {
                    performMove(bottomRight);
                    return true;
                }
            }
            else if (isAi(topLeft) && isAi(bottomRight))
            {
                if (center.IsEnabled == true)
                {
                    performMove(center);
                    return true;
                }
            }
            else if (isAi(center) && isAi(bottomRight))
            {
                if (topLeft.IsEnabled == true)
                {
                    performMove(topLeft);
                    return true;
                }
            }

            return false;
        }

        private static bool checkBottomLeftToTopRight(Button bottomLeft, Button center, Button topRight)
        {
            if (isAi(bottomLeft) && isAi(center))
            {
                if (topRight.IsEnabled == true)
                {
                    performMove(topRight);
                    return true;
                }
            }
            else if (isAi(bottomLeft) && isAi(topRight))
            {
                if (center.IsEnabled == true)
                {
                    performMove(center);
                    return true;
                }
            }
            else if (isAi(center) && isAi(topRight))
            {
                if (bottomLeft.IsEnabled == true)
                {
                    performMove(bottomLeft);
                    return true;
                }
            }

            return false;
        }

        /**********************************
         * OUTSOURCED LOGIC - AVOID ENEMY *
         **********************************/
        private static bool checkForEnemyHorizontalWin(List<Button> buttons)
        {
            for (int i = 0; i < 3; i++)
            {
                Button firstButton = buttons.ElementAt(i * 3);
                Button secondButton = buttons.ElementAt((i * 3) + 1);
                Button thirdButton = buttons.ElementAt((i * 3) + 2);

                if (isEnemy(firstButton) && isEnemy(secondButton))
                {
                    if (thirdButton.IsEnabled == true)
                    {
                        performMove(thirdButton);
                        return true;
                    }
                }
                else if (isEnemy(firstButton) && isEnemy(thirdButton))
                {
                    if (secondButton.IsEnabled == true)
                    {
                        performMove(secondButton);
                        return true;
                    }
                }
                else if (isEnemy(secondButton) && isEnemy(thirdButton))
                {
                    if (firstButton.IsEnabled == true)
                    {
                        performMove(firstButton);
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool checkForEnemyVerticalWin(List<Button> buttons)
        {
            for (int i = 0; i < 3; i++)
            {
                Button firstButton = buttons.ElementAt(i);
                Button secondButton = buttons.ElementAt(i + 3);
                Button thirdButton = buttons.ElementAt(i + (2 * 3));

                if (isEnemy(firstButton) && isEnemy(secondButton))
                {
                    if (thirdButton.IsEnabled == true)
                    {
                        performMove(thirdButton);
                        return true;
                    }
                }
                else if (isEnemy(firstButton) && isEnemy(thirdButton))
                {
                    if (secondButton.IsEnabled == true)
                    {
                        performMove(secondButton);
                        return true;
                    }
                }
                else if (isEnemy(secondButton) && isEnemy(thirdButton))
                {
                    if (firstButton.IsEnabled == true)
                    {
                        performMove(firstButton);
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool checkForEnemyDiagonalWin(List<Button> buttons)
        {
            Button topLeft = buttons.ElementAt(0);
            Button topRight = buttons.ElementAt(2);
            Button center = buttons.ElementAt(4);
            Button bottomLeft = buttons.ElementAt(6);
            Button bottomRight = buttons.ElementAt(8);

            if (checkEnemyTopLeftToBottomRight(topLeft, center, bottomRight))
            {
                return true;
            }
            else if (checkEnemyBottomLeftToTopRight(bottomLeft, center, topRight))
            {
                return true;
            }

            return false;
        }

        private static bool checkEnemyTopLeftToBottomRight(Button topLeft, Button center, Button bottomRight)
        {
            if (isEnemy(topLeft) && isEnemy(center))
            {
                if (bottomRight.IsEnabled == true)
                {
                    performMove(bottomRight);
                    return true;
                }
            }
            else if (isEnemy(topLeft) && isEnemy(bottomRight))
            {
                if (center.IsEnabled == true)
                {
                    performMove(center);
                    return true;
                }
            }
            else if (isEnemy(center) && isEnemy(bottomRight))
            {
                if (topLeft.IsEnabled == true)
                {
                    performMove(topLeft);
                    return true;
                }
            }

            return false;
        }

        private static bool checkEnemyBottomLeftToTopRight(Button bottomLeft, Button center, Button topRight)
        {
            if (isEnemy(bottomLeft) && isEnemy(center))
            {
                if (topRight.IsEnabled == true)
                {
                    performMove(topRight);
                    return true;
                }
            }
            else if (isEnemy(bottomLeft) && isEnemy(topRight))
            {
                if (center.IsEnabled == true)
                {
                    performMove(center);
                    return true;
                }
            }
            else if (isEnemy(center) && isEnemy(topRight))
            {
                if (bottomLeft.IsEnabled == true)
                {
                    performMove(bottomLeft);
                    return true;
                }
            }

            return false;
        }
    }
}
