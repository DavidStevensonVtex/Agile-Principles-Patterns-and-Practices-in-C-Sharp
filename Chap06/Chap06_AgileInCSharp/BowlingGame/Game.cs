using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        private int currentFrame = 1;
        private bool isFirstThrow = true;
        private int score;
        private int [] throws = new int [21] ;
        private int currentThrow;

        public int Score
        {
            get { return ScoreForFrame(currentFrame - 1) ; }
        }
        public int CurrentFrame
        {
            get { return currentFrame; }
        }

        public void Add(int pins)
        {
            throws[currentThrow++] = pins;
            score += pins;

            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (isFirstThrow)
            {
                if (pins == 10)
                    currentFrame++;
                else
                    isFirstThrow = false;
            }
            else
            {
                isFirstThrow = true;
                currentFrame++;
            }

            if (currentFrame > 11)
                currentFrame = 11;
        }

        public int ScoreForFrame(int theFrame)
        {
            int ball = 0;
            int score = 0;
            for (int currentFrame = 0; currentFrame < theFrame; currentFrame++ )
            {
                int firstThrow = throws[ball++];
                if (firstThrow == 10)   // Strike
                {
                    score += 10 + throws[ball] + throws[ball + 1];
                }
                else
                {
                    int secondThrow = throws[ball++];
                    int frameScore = firstThrow + secondThrow;

                    // spare needs next frames first throw
                    if (frameScore == 10)
                        score += frameScore + throws[ball];
                    else
                        score += frameScore;
                }
            }

            return score;
        }
    }
}
