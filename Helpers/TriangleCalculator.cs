using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles.Helpers
{
    public static class TriangleCalculator
    {
        public static string CalculateSideClassification(double side1, double side2, double side3)
        {
            if (side1 == side2 && side2 == side3)
                return "Equilateral";
            else if (side1 != side2 && side2 != side3 && side1 != side3)
                return "Scalene";
            else
                return "Isosceles";
        }

        public static string CalculateAngleClassification(double side1, double side2, double side3)
        {
            // Calculate squares
            double a2 = side1 * side1;
            double b2 = side2 * side2;
            double c2 = side3 * side3;

            // Identify the longest side
            double longestSide2 = Math.Max(Math.Max(a2, b2), c2);

            // Pythagorean theorem: a^2 + b^2 = c^2 for a right triangle
            if (longestSide2 == a2)
                return (b2 + c2 == a2) ? "Right" : ((b2 + c2 < a2) ? "Obtuse" : "Acute");
            else if (longestSide2 == b2)
                return (a2 + c2 == b2) ? "Right" : ((a2 + c2 < b2) ? "Obtuse" : "Acute");
            else
                return (a2 + b2 == c2) ? "Right" : ((a2 + b2 < c2) ? "Obtuse" : "Acute");
        }

        public static List<double> CalculateAngleValues(double side1, double side2, double side3)
        {
            // Using the law of cosines to calculate each angle
            double angle1 = Math.Acos((side2 * side2 + side3 * side3 - side1 * side1) / (2 * side2 * side3));
            double angle2 = Math.Acos((side1 * side1 + side3 * side3 - side2 * side2) / (2 * side1 * side3));
            double angle3 = Math.PI - angle1 - angle2;

            // Convert from radians to degrees
            angle1 = angle1 * (180.0 / Math.PI);
            angle2 = angle2 * (180.0 / Math.PI);
            angle3 = angle3 * (180.0 / Math.PI);

            return new List<double> { angle1, angle2, angle3 };
        }
    }

}
