namespace GeometryLibrary;

//This code defines a Tetrahedron class which inherits from the Polyhedron class and implements the IVolume interface.
public class Tetrahedron : Polyhedron, IVolume
{
    //Constructor that takes an array of 4 Vector3 points and passes it to the base Polyhedron constructor.
    public Tetrahedron(Vector3[] points) : base(points) { }
    
    //Constructor that takes 4 Vector3 points and creates an array to pass to the base Polyhedron constructor.
    public Tetrahedron(Vector3 a, Vector3 b, Vector3 c, Vector3 d) : base(new Vector3[] { a, b, c, d }) { }

    //Overrides the abstract SurfaceArea method from the base Polyhedron class.
    //Calculates the surface area of the tetrahedron by calculating the area of each face.
    public override float SurfaceArea()
    {
        Thread.Sleep(1000); //Simulates a time-consuming calculation.
        float result = 0;

        //Calculates the area of each face using the cross product of two vectors.
        (Vector3, Vector3) triangle1 = (_points[1] - _points[0], _points[2] - _points[0]);
        (Vector3, Vector3) triangle2 = (_points[1] - _points[0], _points[3] - _points[0]);
        (Vector3, Vector3) triangle3 = (_points[2] - _points[0], _points[3] - _points[0]);
        (Vector3, Vector3) triangle4 = (_points[2] - _points[1], _points[3] - _points[1]);

        result += Vector3.Cross(triangle1.Item1, triangle1.Item2).Magnitude / 2f;
        result += Vector3.Cross(triangle2.Item1, triangle2.Item2).Magnitude / 2f;
        result += Vector3.Cross(triangle3.Item1, triangle3.Item2).Magnitude / 2f;
        result += Vector3.Cross(triangle4.Item1, triangle4.Item2).Magnitude / 2f;

        return result;
    }

    //Implements the Volume method from the IVolume interface.
    public float Volume()
    {
        (Vector3, Vector3) baseTriangle = (_points[1] - _points[0], _points[2] - _points[0]);  //Calculates the base triangle of the tetrahedron.
        Vector3 edgeAD = _points[3] - _points[0]; //Calculates one of the edges that connects the apex to the base.
        Vector3 surfaceCross = Vector3.Cross(baseTriangle.Item1, baseTriangle.Item2); //Calculates the surface normal of the base triangle.
        float surfaceBase = surfaceCross.Magnitude / 2f; //Calculates the area of the base triangle.
        float height = MathF.Abs(Vector3.Dot(Vector3.Normalize(surfaceCross), edgeAD)); //Calculates the height of the pyramid.
        return (1f / 3f) * surfaceBase * height; //Calculates and returns the volume of the tetrahedron using the pyramid formula.

    }
}