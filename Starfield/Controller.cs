﻿using System;
using System.Drawing;

namespace Starfield
{
    public class Controller
    {
        private Star[] stars;
        public Random random = new Random();
        
        public void InitStars(int count, int fieldWidth, int fieldHeight)
        {
            stars = new Star[count];

            for (int i = 0; i < count; i++)
            {
                stars[i] = new Star(random);
                stars[i].UpdateCoordinations(random, fieldWidth, fieldHeight);
            }
        }

        public void RefreshField(Graphics graphics, int fieldWidth, int fieldHeight)
        {
            foreach (var star in stars)
            {
                star.Draw(graphics, fieldWidth, fieldHeight);
                star.Move(random, fieldWidth, fieldHeight);
            }
        }
    }
}
