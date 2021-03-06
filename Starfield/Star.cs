﻿using System;
using System.Drawing;

namespace Starfield
{
    public class Star
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        private int Speed;
        private const int MINSPEED = 10;
        private const int MAXSPEED = 30;

        private const int MINSIZE = 1;
        private const int MAXSIZE = 10;

        public Star(Random random)
        {
            this.Speed = random.Next(MINSPEED, MAXSPEED);
        }

        public void Draw(Graphics graphics, int fieldWidth, int fieldHeight)
        {
            float starSize = ChangeCoordinateSystem(this.Z, 0, fieldWidth, MAXSIZE, MINSIZE);

            float x = ChangeCoordinateSystem(this.X / this.Z, 0, 1, 0, fieldWidth) + fieldWidth / 2;
            float y = ChangeCoordinateSystem(this.Y / this.Z, 0, 1, 0, fieldHeight) + fieldHeight / 2;

            graphics.FillEllipse(Brushes.AliceBlue, x, y, starSize, starSize);
        }

        public void Move(Random random, int fieldWidth, int fieldHeight)
        {
            this.Z -= this.Speed;
            if (this.Z < 1)
            {
                this.UpdateCoordinations(random, fieldWidth, fieldHeight);
            }
        }

        private float ChangeCoordinateSystem(float n, float start1, float stop1, float start2, float stop2)
        {
            return ((n - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }

        public void UpdateCoordinations(Random random, int fieldWidth, int fieldHeight)
        {
            this.X = random.Next(-fieldWidth, fieldWidth);
            this.Y = random.Next(-fieldHeight, fieldHeight);
            this.Z = random.Next(1, fieldWidth);
        }
    }    
}
