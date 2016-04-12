using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intersection
{
    [TestClass]
    public class IntersectionTest
    {
        public struct Point
        {
            public int x;
            public int y;
        public Point(int x, int y)
           {
                this.x=x;
                this.y=y;
           }
        }
        public enum Direction
        {
            up,
            down,
            left,
            right
        }

        [TestMethod]
        public void CheckCrossRoadsTest1()
        {
            var segment = new Point[] { new Point(2, 0), new Point(1, 0), new Point(1, 1), new Point (1,0)};
            var firstPoint = new Point(1, 0);
            var secondPoint = new Point(2, 3);
            Assert.AreEqual(true, CheckCrossRoads(firstPoint, segment));
            Assert.AreEqual(false, CheckCrossRoads(secondPoint, segment));
         }

        [TestMethod]
        public void DetermineIntersectionForPoints1And1Test()
        {
            var direction = new Direction[] { Direction.right, Direction.up, Direction.right, Direction.up, Direction.left, Direction.down };
            Assert.AreEqual(new Point(1, 1), DetermineFirstIntersection(direction));
        }

        
        bool CheckCrossRoads (Point point, Point[] segment)
        {
           
           for (int i=0; i<segment.Length; i++)
            {
                if ((segment[i].x == point.x) && (segment[i].y == point.y))
                      return true;
            }
            return false;
        }

       Point DetermineFirstIntersection (Direction[] direction)
        {
            Point origin = new Point(0, 0);
            Point[] segment = new Point[] {new Point (0,0)};
            Point point = segment[0];

            for (int i = 0; i < direction.Length; i++)
            {
                switch (direction[i])
                {
                    case Direction.up:   point = new Point(point.x, point.y + 1);
                        break;
                    case Direction.down: point = new Point(point.x, point.y - 1);
                        break;
                    case Direction.right:point = new Point(point.x + 1, point.y);
                        break;
                    case Direction.left: point = new Point(point.x - 1, point.y);
                        break;
                }

                if (CheckCrossRoads(point,segment))
                {
                    return point;
                }
                else
                {
                    Array.Resize(ref segment, segment.Length + 1);
                    segment[segment.Length - 1] = point;
                }
              }
            return origin;

        }



    }
}
