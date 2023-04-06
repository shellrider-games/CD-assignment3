using GeometryLibrary;
using System.Diagnostics;
internal class Program
{
    public delegate T SurfaceGenerator<T>() where T : ISurface;
    private static void Main(string[] args)
    {
        Random random = new Random();
        List<ISurface> geometricObjects = new List<ISurface>();

        Tetrahedron[] tetrahedra = GenerateSurfaces<Tetrahedron>(5, RandomTetrahedronGenerator);
        Cuboid[] cuboids = GenerateSurfaces<Cuboid>(5, RandomCuboidGenerator);
        Cylinder[] cylinders = GenerateSurfaces<Cylinder>(5, RandomCylinderGenerator);
        geometricObjects.AddRange(tetrahedra);
        geometricObjects.AddRange(cuboids);
        geometricObjects.AddRange(cylinders);

        geometricObjects = geometricObjects.OrderBy(_ => random.Next()).ToList();

        Console.WriteLine("Start calculating surfaces synchronously...");
        Stopwatch stopwatch = Stopwatch.StartNew();
        PrintSurfaceAreas(geometricObjects);
        stopwatch.Stop();
        Console.WriteLine($"Calculating surfaces synchronously took {stopwatch.ElapsedMilliseconds}ms");

        Console.WriteLine("Start calculating surfaces asynchronously...");
        stopwatch = Stopwatch.StartNew();
        PrintSurfaceAreasAsync(geometricObjects);
        stopwatch.Stop();
        Console.WriteLine($"Calculating surfaces asynchronously took {stopwatch.ElapsedMilliseconds}ms");
    }

    private static void PrintSurfaceAreas(List<ISurface> list)
    {
        List<ISurface> copy = new List<ISurface>(list);
        Dictionary<ISurface, float> areas = new Dictionary<ISurface, float>();
        List<ISurface> clusterdTetras = new List<ISurface>();
        while (copy.Count > 0)
        {
            ISurface element = copy.First();
            if (element is Tetrahedron)
            {
                List<Tetrahedron> tetrahedrons = new List<Tetrahedron>();
                foreach (ISurface obj in copy)
                {
                    if (obj is Tetrahedron)
                    {
                        tetrahedrons.Add((Tetrahedron)obj);
                    }
                }
                foreach (Tetrahedron tetrahedron in tetrahedrons)
                {
                    areas.Add(tetrahedron, tetrahedron.SurfaceArea());
                    clusterdTetras.Add(tetrahedron);
                    copy.Remove(tetrahedron);
                }
            }
            else
            {
                areas.Add(element, element.SurfaceArea());
                clusterdTetras.Add(element);
                copy.Remove(element);
            }
        }

        foreach (ISurface element in clusterdTetras)
        {
            WriteSurfaceAreaOf(element, areas[element]);
        }
    }

    public static void PrintSurfaceAreasAsync(List<ISurface> list)
    {
        List<Task> tasks = new List<Task>();

        List<ISurface> copy = new List<ISurface>(list);
        Dictionary<ISurface, float> areas = new Dictionary<ISurface, float>();
        List<ISurface> clusterdTetras = new List<ISurface>();

        while (copy.Count > 0)
        {
            ISurface element = copy.First();
            if (element is Tetrahedron)
            {
                List<Tetrahedron> tetrahedrons = new List<Tetrahedron>();
                foreach (ISurface obj in copy)
                {
                    if (obj is Tetrahedron)
                    {
                        tetrahedrons.Add((Tetrahedron)obj);
                    }
                }
                foreach (Tetrahedron tetrahedron in tetrahedrons)
                {
                    clusterdTetras.Add(tetrahedron);
                    copy.Remove(tetrahedron);
                }
            }
            else
            {
                clusterdTetras.Add(element);
                copy.Remove(element);
            }
        }

        foreach (ISurface element in clusterdTetras)
        {
            tasks.Add(Task.Run(() => areas[element] = element.SurfaceArea()));
        }

        Task.WaitAll(tasks.ToArray());
        foreach (ISurface element in clusterdTetras)
        {
            WriteSurfaceAreaOf(element, areas[element]);
        }

    }

    private static void WriteSurfaceAreaOf(ISurface obj, float area)
    {
        switch (obj)
        {
            case Cuboid:
                Console.WriteLine($"Cuboid: {area}");
                break;
            case Tetrahedron:
                Console.WriteLine($"Tetrahedron: {area}");
                break;
            case Cylinder:
                Console.WriteLine($"Cylinder: {area}");
                break;
            default:
                Console.WriteLine($"Unclear: {area}");
                break;
        }
    }

    private static float RandomFloatBetween(float min, float max)
    {
        float randomNumber = new Random().NextSingle();
        randomNumber *= max - min;
        randomNumber += min;
        return randomNumber;
    }

    private static T[] GenerateSurfaces<T>(uint amount, SurfaceGenerator<T> generator) where T : ISurface
    {
        T[] result = new T[amount];
        for (int i = 0; i < amount; i++)
        {
            result[i] = generator();
        }
        return result;
    }

    private static Tetrahedron RandomTetrahedronGenerator()
    {
        Vector3[] points = new Vector3[]{
                new Vector3(
                    RandomFloatBetween(-10,10),
                    RandomFloatBetween(-10,10),
                    RandomFloatBetween(-10,10)
                ),
                new Vector3(
                    RandomFloatBetween(-10,10),
                    RandomFloatBetween(-10,10),
                    RandomFloatBetween(-10,10)
                ),
                new Vector3(
                    RandomFloatBetween(-10,10),
                    RandomFloatBetween(-10,10),
                    RandomFloatBetween(-10,10)
                ),
                new Vector3(
                    RandomFloatBetween(-10,10),
                    RandomFloatBetween(-10,10),
                    RandomFloatBetween(-10,10)
                )
            };
        return new Tetrahedron(points);
    }

    private static Cuboid RandomCuboidGenerator()
    {
        float depth = RandomFloatBetween(0.1f, 10f);
        float height = RandomFloatBetween(0.1f, 10f);
        float width = RandomFloatBetween(0.1f, 10f);
        float sheer = RandomFloatBetween(-3f, 3f);

        Vector3 a = new Vector3(
            RandomFloatBetween(-10, 10),
            RandomFloatBetween(-10, 10),
            RandomFloatBetween(-10, 10)
        );
        Vector3 b = a + new Vector3(width, 0, sheer);
        Vector3 c = b + new Vector3(0, depth, 0);
        Vector3 d = a + new Vector3(0, depth, 0);

        Vector3 e = a - new Vector3(0, 0, height);
        Vector3 f = b - new Vector3(0, 0, height);
        Vector3 g = c - new Vector3(0, 0, height);
        Vector3 h = d - new Vector3(0, 0, height);

        return new Cuboid(a, b, c, d, e, f, g, h);
    }

    private static Cylinder RandomCylinderGenerator()
    {
        Vector3 top = new Vector3(
            RandomFloatBetween(-10, 10),
            RandomFloatBetween(-10, 10),
            RandomFloatBetween(-10, 10)
        );
        Vector3 bottom = new Vector3(
            RandomFloatBetween(-10, 10),
            RandomFloatBetween(-10, 10),
            RandomFloatBetween(-10, 10)
        );
        return new Cylinder(bottom, top, RandomFloatBetween(0.5f, 4f));
    }
}