using System;
using System.Linq;

class Triangle
{
    //fields
    private double sideA;
    private double sideB;
    private double sideC;
    private double altitude;
    private int angleDegrees;

    //constructors
    public Triangle(double sideA,double sideB,int angleValue)
    {
        this.SideA = sideA;
        this.SideB = sideB;
        this.AngleDegrees = angleValue;
    }
    public Triangle(double sideA, double sideB, double sideC)
    {
        this.SideA = sideA;
        this.SideB = sideB;
        this.SideC = sideC;
    }
    public Triangle(double side, double altitude)
    {
        this.SideA = side;
        this.Altitude = altitude;
    }

    //properties
    public int AngleDegrees
    {
        get
        {
            return this.angleDegrees;
        }
        set
        {
            this.angleDegrees = value;
        }
    }
    public double SideA
    {
        get
        {
            return this.sideA;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Negative length exception");
            }
            this.sideA = value;
        }
    }
    public double SideB
    {
        get
        {
            return this.sideB;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Negative length exception");
            }
            this.sideB = value;
        }
    }
    public double SideC
    {
        get
        {
            return this.sideC;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Negative length exception");
            }
            this.sideC = value;
        }
    }
    public double Altitude
    {
        get
        {
            return this.altitude;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Negative length exception");
            }
            this.altitude = value;
        }
    }

    //methods for calculating surface of current triangle
    public double TriangleSurfaceByTwoSidesAndAngle()
    {
        double surface = (this.SideA * this.SideB * Math.Sin(Math.PI / 180 * this.AngleDegrees)) / 2.0;

        return surface;
    }
    public double TriangleSufraceBySideAndAlt()
    {
        return (this.SideA * this.Altitude) / 2.0;
    }
    public double TriangleSurfaceByThreeSides()
    {
        double halfPerimeter = (this.sideA + this.SideB + this.sideC) / 2;
        double surface = Math.Sqrt(halfPerimeter * (halfPerimeter - this.sideA) * (halfPerimeter - this.sideB)
            * (halfPerimeter - this.sideC));
        return surface;
    }
}

class Calculations
{
    static void Main()
    {
        Console.WriteLine("Choose type of triangle surface calculation:");
        Console.WriteLine("1.For calculating by a side and an Altitude");
        Console.WriteLine("2.For calculating by three sides");
        Console.WriteLine("3.For calculating by two sides and the angle between the");

        int typeCalculation = int.Parse(Console.ReadLine());
        string[] triangleParameters;
        double surfaceTriangle = 0;
        switch (typeCalculation)
        {
            case 1:
                Console.WriteLine("Please enter side and altitude of the triangle separated by space");
                //read input parameters for the tringle
                triangleParameters = Console.ReadLine().Split(' ').ToArray();
                double sideA = double.Parse(triangleParameters[0]);
                double altitude = double.Parse(triangleParameters[1]);
                //initialize triangle object and use method to calculate surface
                var triangle = new Triangle(sideA, altitude);
                surfaceTriangle = triangle.TriangleSufraceBySideAndAlt();
                break;
            case 2:
                Console.WriteLine("Please enter the three sides of the triangle separated by space");
                //read input parameters for the tringle
                triangleParameters = Console.ReadLine().Split(' ').ToArray();
                sideA = double.Parse(triangleParameters[0]);
                double sideB = double.Parse(triangleParameters[1]);
                double sideC = double.Parse(triangleParameters[2]);
                //initialize triangle object and use method to calculate surface
                triangle = new Triangle(sideA, sideB,sideC);
                surfaceTriangle = triangle.TriangleSurfaceByThreeSides();
                break;
            case 3:
                Console.WriteLine("Please enter two sides of the triangle and angle between them separated by space");
                //read input parameters for the tringle
                triangleParameters = Console.ReadLine().Split(' ').ToArray();
                sideA = double.Parse(triangleParameters[0]);
                sideB = double.Parse(triangleParameters[1]);
                int angleValue = int.Parse(triangleParameters[2]);
                //initialize triangle object and use method to calculate surface
                triangle = new Triangle(sideA, sideB, angleValue);
                surfaceTriangle = triangle.TriangleSurfaceByTwoSidesAndAngle();
                break;
                
        }

        Console.WriteLine("The surface of the triangle is {0:f2}",surfaceTriangle);
    }
}

