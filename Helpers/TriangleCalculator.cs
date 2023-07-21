using System;
using System.Collections.Generic;
using System.Linq;

namespace Triangles.Helpers
{
    public static class TriangleCalculator
    {
        public static string CalculateSideClassification(double side1, double side2, double side3)
        {
            if (side1 == side2 && side2 == side3)
                return "Equilateral";

            if (side1 != side2 && side2 != side3 && side1 != side3)
                return "Scalene";

            return "Isosceles";
        }

        public static string CalculateAngleClassification(double side1, double side2, double side3)
        {
            var sidesSquared = new[] { side1 * side1, side2 * side2, side3 * side3 };
            var longestSideSquared = sidesSquared.Max();
            var sumOtherSidesSquared = sidesSquared.Sum() - longestSideSquared;

            return (sumOtherSidesSquared == longestSideSquared) ? "Right" : (sumOtherSidesSquared < longestSideSquared) ? "Obtuse" : "Acute";
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
