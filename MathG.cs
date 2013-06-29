using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameClasses
{
    public static class MathG
    {
        public static float AngleToRadian(float angle)
        {
            return (float)(Math.PI * angle / 180.0);
        }

        public static float RadianToDegree(double angle)
        {
            return (float)(angle * (180.0 / Math.PI));
        }
        public static Vector2 AngleToVector(float angle)
        {
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }

        public static float VectorToAngle(Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }
        public static float VectorToAngle(Vector2 vector, Vector2 vector2)
        {
            return (float)(Math.Atan2(vector2.Y - vector.Y, vector2.X - vector.X) * 180 / Math.PI);
        }

        public static float Distance(float x1, float y1, float x2, float y2)
        {
            //      ______________________
            //d = _/ (x2-x1)^2 + (y2-y1)^2
            //

            //Our end result
            float result = 0;
            //Take x2-x1, then square it
            double part1 = Math.Pow((x2 - x1), 2);
            //Take y2-y1, then sqaure it
            double part2 = Math.Pow((y2 - y1), 2);
            //Add both of the parts together
            double underRadical = part1 + part2;
            //Get the square root of the parts
            result = (float)Math.Sqrt(underRadical);
            //Return our result
            return result;
        }
    }
}
