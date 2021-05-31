namespace Assign2
{

    class Vector
    {
        public double x = 0;
        public double y = 0;

        //constructor
        public Vector(double X, double Y)
        {
            x = X;
            y = Y;
        }

        public Vector(Vector V)
        {
            x = V.x;
            y = V.y;
        }

        //add
        public static Vector operator +(Vector V1, Vector V2)
        {
            Vector V = new Vector(V1);
            V.x += V2.x;
            V.y += V2.y;
            return V;
        }

        //sub
        public static Vector operator -(Vector V1, Vector V2)
        {
            Vector V = new Vector(V1);
            V.x -= V2.x;
            V.y -= V2.y;
            return V;
        }

        //scaler multiplication
        public static Vector operator *(Vector V, double d)
        {
            V.x = V.x * d;
            V.y = V.y * d;
            return V;
        }

        //dot product
        public double dot(Vector V)
        {
            return x * V.x + y * V.y;
        }

        //cross product
        public double cross(Vector V)
        {
            return x * V.y - y * V.x;
        }

        //magnitude
        public double mag()
        {
            return Math.Sqrt((x * x + y * y));
        }

        //rotate about origin
        public void rotate(double theta)
        {
            Vector Temp = new Vector(x, y);
            x = Temp.x * Math.Cos(theta) - Temp.y * Math.Sin(theta);
            y = Temp.y * Math.Cos(theta) + Temp.x * Math.Sin(theta);
        }

        //rotate about point
        public void rotate(Vector axis, double theta)
        {
            Vector vector = new Vector(x, y);
            vector = vector - axis;
            vector.rotate(theta);
            vector = vector + axis;
            x = vector.x;
            y = vector.y;
        }

        public void show()
        {
            Console.WriteLine(x.ToString() + " " + y.ToString());
        }
    }


    abstract class Region
    {
        // Check if a point belongs to the region (including its boundary/perimeter)
        public abstract bool contains(Vector V);

        // translate the region by (x,y) units: x unit on X-axis and y units on Y-axis
        public abstract void translate(Vector D);

        // find the centoid for the region
        public abstract Vector centroid();

        // rotate the region by an angle θ (in radians)
        public abstract void rotate(Vector Axis, double angle);
        public void rotate(double angle)
        {
            rotate(centroid(), angle);
        }

        // find the area of a region
        public abstract double area();
    }
    class Circle : Region
    {
        Vector O;
        double r;

        Circle(double X = 0, double Y = 0, double R = 1)
        {
            O.x = X;
            O.y = Y;
            r = R;
        }
        Circle(Vector C, double r)
        {
            this.O = C;
            this.r = r;
        }

        public override bool contains(Vector A)
        {
            Vector C = A - O;

            return (C.mag() <= r) ? true : false;
        }

        public override void translate(Vector A)
        {
            O = O + A;
        }

        public override Vector centroid()
        {
            return O;
        }

        public override void rotate(Vector point, double theta)
        {
            O.rotate(point, theta);
        }

        public override double area()
        {
            return 3.14159 * r * r;

        }
    }


    class Square : Region
    {
        public Vector A, B, C, D;


        public Square(Vector p, Vector q, Vector r, Vector s)
        {
            A = p;
            B = q;
            C = r;
            D = s;
        }
        public Square(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            A.x = x1;
            A.y = y1;
            B.x = x2;
            B.y = y2;
            C.x = x3;
            C.y = y3;
            D.x = x4;
            D.y = y4;
        }

        public override bool contains(Vector X)
        {
            Vector P = X - A, Q = D - A, R = B - A;
            if (P.dot(Q) <= Q.dot(Q) && P.dot(R) <= R.dot(R))
            {
                return true;
            }
            else return false;
        }

        public override void translate(Vector X)
        {
            A += X;
            B += X;
            C += X;
            D += X;
        }

        public override Vector centroid()
        {
            return (A + B + C + D) * (0.25);
        }

        public override void rotate(Vector point, double theta)
        {
            A.rotate(point, theta);
            B.rotate(point, theta);
            C.rotate(point, theta);
            D.rotate(point, theta);

        }

        public override double area()
        {
            Vector X = B - A, Y = D - A;
            return X.mag() * Y.mag();

        }
        public void display()
        {
            A.show();
            B.show();
            C.show();
            D.show();
        }
    }


}