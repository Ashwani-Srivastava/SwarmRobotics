namespace Assign2
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector V1 = new Vector(0, 0);
            Vector V2 = new Vector(10, 0);
            Vector V3 = new Vector(10, 10);
            Vector V4 = new Vector(0, 10);



            Square S = new Square(V1, V2, V3, V4);

            Console.WriteLine(V4.mag());
            Console.WriteLine(S.area());
            Console.WriteLine(S.contains(new Vector(1, 9)));
            // S.translate(new Vector(-1, -5));
            S.display();
            Console.WriteLine(S.contains(new Vector(1, 9)));
            S.rotate(V3, 3.14159 / 4);
            S.display();
            Console.ReadKey();
        }
    }
}