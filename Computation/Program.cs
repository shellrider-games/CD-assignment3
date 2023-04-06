using GeometryLibrary;
internal class Program
{
    private static void Main(string[] args)
    {
        Tetrahedron[] tetrahedra = RandomTetrahedra(5);
        foreach(Tetrahedron tetra in tetrahedra)
        {
            tetra.PrintToConsole();
        }
        Cuboid[] cuboids = RandomCuboids(5);
        foreach(Cuboid cuboid in cuboids)
        {
            cuboid.PrintToConsole();
        }
    }

    private static float RandomFloatBetween(float min, float max)
    {
        float randomNumber = new Random().NextSingle();
        randomNumber *= max-min;
        randomNumber += min;
        return randomNumber;
    }

    private static Tetrahedron[] RandomTetrahedra(uint amount)
    {
        Random random = new Random();
        Tetrahedron[] result = new Tetrahedron[amount];
        for(int i = 0; i < amount; i++)
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
            result[i] = new Tetrahedron(points);
        }
        return result;
    }

    private static Cuboid[] RandomCuboids(uint amount)
    {
        Random random = new Random();
        Cuboid[] result = new Cuboid[amount];
        for(int i = 0; i < amount; i++)
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

            Vector3 b = a + new Vector3(width,0, sheer);
            Vector3 c = b + new Vector3(0, depth, 0);
            Vector3 d = a + new Vector3(0, depth, 0);

            Vector3 e = a - new Vector3(0,0,height);
            Vector3 f = b - new Vector3(0,0,height);

            Vector3 g = c -new Vector3(0,0,height);
            Vector3 h = d -new Vector3(0,0,height);

            result[i] = new Cuboid(a,b,c,d,e,f,g,h);

        }
        return result;
    }
}