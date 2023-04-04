namespace GeometryLibrary;

public class Cuboid : Polyhedron, IVolume
{
    ///<summary>
    ///Cuboid constructor. This class extends the <c>Polyhedron</c> class.
    ///We assume that the points are given in order representing points A to H 
    ///The planes of the cuboid are defined by {A,B,C,D}, {A,B,F,E}, {B,C,G,F},
    ///{D,C,G,H}, {D,A,E,H} and {E,F,G,H}. Given those constraints the provided
    ///methods will work as expected
    ///</summary>
    public Cuboid(Vector3[] points) : base(points) { }
    public Cuboid(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Vector3 e, Vector3 f, Vector3 g, Vector3 h) : base(new Vector3[] { a, b, c, d, e, f, g, h }) { }

    public override float SurfaceArea()
    {
        float result = 0;
        (Vector3, Vector3)[] triangles = Triangles();
        foreach((Vector3, Vector3) triangle in triangles)
        {
            result += Vector3.Cross(triangle.Item1, triangle.Item2).Magnitude/2f;
        }
        return result;
    }

    public float Volume()
    {
        float result = 0;

        //bottom face
        float bottomSurfaceArea = BottomSurfaceArea();

        Vector3 edgeEA = _points[0]-_points[4];
        float heightBottom = Vector3.Dot(Vector3.Cross(_points[7]-_points[4] ,_points[5]-_points[4]),edgeEA);

        Console.WriteLine(heightBottom);
        result += (1f/3f) * bottomSurfaceArea * heightBottom;

        return result;
    }

    public float BottomSurfaceArea()
    {
        float result = 0;
        (Vector3, Vector3)[] bottomSurface = new (Vector3, Vector3)[2];

        bottomSurface[0] = (_points[5]-_points[4],_points[7]-_points[4]);
        bottomSurface[1] = (_points[5]-_points[6],_points[7]-_points[6]);

        result += Vector3.Cross(bottomSurface[0].Item1, bottomSurface[0].Item2).Magnitude/2f;
        result += Vector3.Cross(bottomSurface[1].Item1, bottomSurface[1].Item2).Magnitude/2f;


        return result;
    }

    private (Vector3, Vector3)[] Triangles()
    {
        //A cuboid's surface consists of 12 triangles
        (Vector3, Vector3)[] triangles = new (Vector3, Vector3)[6*2];
        triangles[0] = (_points[0]-_points[1],_points[2]-_points[1]);
        triangles[1] = (_points[2]-_points[3],_points[0]-_points[3]);

        triangles[2] = (_points[0]-_points[1],_points[5]-_points[1]);
        triangles[3] = (_points[0]-_points[4],_points[5]-_points[4]);

        triangles[4] = (_points[6]-_points[5],_points[1]-_points[5]);
        triangles[5] = (_points[1]-_points[2],_points[6]-_points[2]);

        triangles[6] = (_points[2]-_points[6],_points[7]-_points[6]);
        triangles[7] = (_points[2]-_points[3],_points[7]-_points[3]);

        triangles[8] = (_points[7]-_points[3],_points[0]-_points[3]);
        triangles[9] = (_points[7]-_points[4],_points[0]-_points[4]);

        triangles[10] = (_points[5]-_points[4],_points[7]-_points[4]);
        triangles[11] = (_points[5]-_points[6],_points[7]-_points[6]);

        return triangles;
    }
}