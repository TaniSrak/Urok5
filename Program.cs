using System.Numerics;
using System.Timers;

namespace Urok5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 2, b = 4;
            A ad = new A(3, 2.0f);
            Console.WriteLine(ad + 2.4f);

            //Task1
            Point aa = new  Point();
            Point bb = new Point();
            aa.X = 10;
            aa.Y = 10;
            bb.X = 10;
            bb.Y = 10;

            //Task2
            Rectangle rectangel = new Rectangle(5, 10);
            Square square = new Square { Length = 7 };
            Rectangle rectSqyare = square;

            //task3
            Shop laptop = new Shop(3);
            laptop[0] = new LapTop
            {
                Vendor = "Samsung",
                Price = 5200
            };
            laptop[1] = new LapTop
            {
                Vendor = "Iphone",
                Price = 4700
            };
            laptop[2] = new LapTop
            {
                Vendor = "Asus",
                Price = 3500
            };
            Console.WriteLine(laptop[1].ToString());
            Console.ReadKey();

            //Task4
            Employee employee1 = new Employee("Иванов Иван Иванович", new DateTime(1990, 5, 15),
                "+78882224455", "ivan123@gmail.com", "Программист", "Разработка ПО", 50000);
            Employee employee2 = new Employee("Иванов2 Иван2 Иванович2", new DateTime(1992, 5, 15),
                "+72222224455", "ivan@gmail.com", "Программист", "Разработка ПО", 80000);

            Console.WriteLine(employee1.ToString());
            Console.WriteLine(employee2.ToString());
            employee2.Salary =  employee2 + 5000.0m;
            Console.WriteLine(employee1.Equals(employee2));
            Console.ReadKey();

        }
    }

    //перегрузка
    public class A
    {
        public int Abc { get; set; }
        public float Bbc { get; set; }
        public A(int Abc, float Bbc) 
        {
            this.Abc = Abc;
            this.Bbc = Bbc;
        }

        //перегрузка операторов математики
        public static float operator +(A a, float b) { return a.Abc + b; }
        public static float operator +(A a, A b) { return a.Abc + b.Abc; }

        //перегрузка операторов сравнения
        public static bool operator >(A a, A b)
        {
            if(a.Abc > b.Abc) return true;
            else return false;
         }       
        public static bool operator <(A a, A b) 
        {
            if (a.Abc > b.Abc) return false;
            else return true;
        }
        //перегрузка унарных операторов
        public static A operator++(A a) { a.Abc++;  return a; }
        public static A operator --(A a) { a.Abc--; return a; }
        public static A operator -(A a) { a.Abc = -a.Abc; return a; }

        // перегрузка true/false
        public static bool operator true(A a) { return a.Abc == 0; }
        public static bool operator false(A a) { return a.Abc != 0; }

        //перегрузка логического и/или
        public static A operator &(A a, A b) { return a; }

        //перегрузка преобразований
        //public static implicit operator Point(A a) { } //неявное
        //public static explicit operator Point(A a) { } //явное

        //перегрузка индексатора
        //this[тип_аргумента] {get; set;}

    }

    //Task1
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point() { }
        public static Point operator &(Point a, Point b)
        {
            if ((a.X != 0 && a.Y != 0) && (b.X != 0 && b.Y != 0))
            {
                return b;
            }
            return new Point();
        }
        //перегрузка на тру фолс обязательна, чтобы заработало
        public static bool operator true(Point p)
        {
            return p.X != 0 || p.Y != 0 ? false : true;
        }
        public static bool operator false(Point p)
        {
            return p.X != 0 || p.Y != 0 ? false : true;
        }

    }

    //task2 перегрузка преобразований 
    
    class Rectangle //неявное implicit
    { 
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }

        public static implicit operator Rectangle(Square s)
        {
            return new Rectangle (s.Length * 2, s.Length);
        }
    }
    class Square
    {
        public int Length { get; set; }
    }

    //Task3 перегрузка индексатора
    public class LapTop
    {
        public string Vendor { get; set; } = "";
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{Vendor} {Price}";
        }
    }

    public class Shop
    {
        LapTop[] laptopArr;
        public Shop(int size)
        {
            laptopArr = new LapTop[size];
        }
        public LapTop this[int index]
        {
            get
            {
                if(index >= 0 && index < laptopArr.Length)
                {
                    return laptopArr[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                laptopArr[index] = value;
            }

        }

    }
}
