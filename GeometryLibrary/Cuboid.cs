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

    //Constructor overload that takes individual vectors for each point
    public Cuboid(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Vector3 e, Vector3 f, Vector3 g, Vector3 h) : base(new Vector3[] { a, b, c, d, e, f, g, h }) { }

    //Calculate the surface area of the cuboid
    public override float SurfaceArea()
    {
        Thread.Sleep(1000); //Simulates a time-consuming calculation.
        float result = 0;
        (Vector3, Vector3)[] triangles = Triangles(); //Get an array of triangles that make up the surface of the cuboid
        foreach((Vector3, Vector3) triangle in triangles)
        {
            result += Vector3.Cross(triangle.Item1, triangle.Item2).Magnitude/2f; //Calculate the area of each triangle and add it to the result
        }
        return result;
    }

    //Calculate the volume of the cuboid
    public float Volume()
    {
        float result = 0;

        //The Volume of a Cuboid can be split into 5 Tetrahedrons
        Tetrahedron[] subTetrahedrons = new Tetrahedron[5];

        //Split the cuboid into 5 tetrahedrons and calculate the volume of each one
        subTetrahedrons[0] = new Tetrahedron(_points[0], _points[1], _points[2], _points[5]);
        subTetrahedrons[1] = new Tetrahedron(_points[1], _points[2], _points[3], _points[7]);
        subTetrahedrons[2] = new Tetrahedron(_points[5], _points[6], _points[7], _points[2]);
        subTetrahedrons[3] = new Tetrahedron(_points[4], _points[5], _points[7], _points[0]);
        subTetrahedrons[4] = new Tetrahedron(_points[0], _points[2], _points[5], _points[7]);

        //Add up the volumes of all the tetrahedrons to get the volume of the cuboid
        foreach(Tetrahedron tetrahedron in subTetrahedrons)
        {
            result += tetrahedron.Volume();
        }
        
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