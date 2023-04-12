using GeometryLibrary;
using System.Diagnostics;
internal class Program
{
    //Generic delegate I use to be able to reuse the code in Generate Surfaces, I inject the generator function of the shape I want to create
    public delegate T SurfaceGenerator<T>() where T : ISurface;
    private static void Main(string[] args)
    {
        Random random = new Random();
        List<ISurface> geometricObjects = new List<ISurface>();

        geometricObjects.AddRange(GenerateSurfaces<Tetrahedron>(5, RandomTetrahedronGenerator));
        geometricObjects.AddRange(GenerateSurfaces<Cuboid>(5, RandomCuboidGenerator));
        geometricObjects.AddRange(GenerateSurfaces<Cylinder>(5, RandomCylinderGenerator));

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

    //function to print all surface areas
    private static void PrintSurfaceAreas(List<ISurface> list)
    {
        // Create a copy of the input list and initialize an empty dictionary to store the surface areas of each element.
        List<ISurface> copy = new List<ISurface>(list);
        Dictionary<ISurface, float> areas = new Dictionary<ISurface, float>();

        // Create an empty list to store all elements with tetrahedrons clustered together.
        List<ISurface> clusterdTetras = new List<ISurface>();
        while (copy.Count > 0)
        {
            // Select the first element in the copy to be processed.
            ISurface element = copy.First();
            // If the element is a tetrahedron, add its surface area to the areas dictionary and cluster it together with other tetrahedrons.
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
            //If the element is not a tetrahedron, simply add its surface area to the areas dictionary
            else
            {
                areas.Add(element, element.SurfaceArea());
                clusterdTetras.Add(element);
                copy.Remove(element);
            }
        }

        //Iterate over the clustered elements and print out their surface areas using the areas dictionary.
        foreach (ISurface element in clusterdTetras)
        {
            WriteSurfaceAreaOf(element, areas[element]);
        }
    }

    public static void PrintSurfaceAreasAsync(List<ISurface> list)
    {
        List<Task> tasks = new List<Task>();

        List<ISurface> copy = new List<ISurface>(list); //create copy we go through to cluster Tetrahedrons
        float[] areas = new float[list.Count]; //store areas in this array
        List<ISurface> clusterdTetras = new List<ISurface>(); //We store the right order here

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
        
        for (int i = 0; i < clusterdTetras.Count; i++)
        {
            int index = i; // we need to copy the index so that it is available in the Thread even when it was overwritten
            tasks.Add(Task.Run(() => areas[index] = clusterdTetras[index].SurfaceArea()));
        }

        Task.WaitAll(tasks.ToArray()); //Wait for All areas to be calculated

        for (int i = 0; i < clusterdTetras.Count; i++)
        {
            WriteSurfaceAreaOf(clusterdTetras[i], areas[i]); //Print in correct order.
        }

    }

    //Helper function to write type and area of object to console
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

    //helper function to get a random float between two values
    private static float RandomFloatBetween(float min, float max)
    {
        float randomNumber = new Random().NextSingle();
        randomNumber *= max - min;
        randomNumber += min;
        return randomNumber;
    }

    //Generic function that generates an given amount of ISurface objects using the provided generator function.
    private static T[] GenerateSurfaces<T>(uint amount, SurfaceGenerator<T> generator) where T : ISurface
    {
        T[] result = new T[amount];
        for (int i = 0; i < amount; i++)
        {
            result[i] = generator();
        }
        return result;
    }


    //Generator function to generate a randomized Tetrahedron.
    private static Tetrahedron RandomTetrahedronGenerator()
    {
        Vector3[] points = new Vector3[]{
                RandomVector3(),
                RandomVector3(),
                RandomVector3(),
                RandomVector3()
            };
        return new Tetrahedron(points);
    }

    //Generator function to generate a randomized Cuboid.
    private static Cuboid RandomCuboidGenerator()
    {
        float depth = RandomFloatBetween(0.1f, 10f);
        float height = RandomFloatBetween(0.1f, 10f);
        float width = RandomFloatBetween(0.1f, 10f);
        float sheer = RandomFloatBetween(-3f, 3f);

        Vector3 a = RandomVector3();
        Vector3 b = a + new Vector3(width, 0, sheer);
        Vector3 c = b + new Vector3(0, depth, 0);
        Vector3 d = a + new Vector3(0, depth, 0);

        Vector3 e = a - new Vector3(0, 0, height);
        Vector3 f = b - new Vector3(0, 0, height);
        Vector3 g = c - new Vector3(0, 0, height);
        Vector3 h = d - new Vector3(0, 0, height);

        return new Cuboid(a, b, c, d, e, f, g, h);
    }

    //Generator function to generate a randomized cylinder
    private static Cylinder RandomCylinderGenerator()
    {
        Vector3 top = RandomVector3();
        Vector3 bottom = RandomVector3();
        return new Cylinder(bottom, top, RandomFloatBetween(0.5f, 4f));
    }

    //helper function to generate a Vector 3 with random values
    private static Vector3 RandomVector3()
    {
        return new Vector3(
            RandomFloatBetween(-10, 10),
            RandomFloatBetween(-10, 10),
            RandomFloatBetween(-10, 10)
        );
    }
}