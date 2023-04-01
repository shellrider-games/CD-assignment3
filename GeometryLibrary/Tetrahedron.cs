namespace GeometryLibrary;

public class Tetrahedron : Polyhedron
{
    public Tetrahedron(Vector3[] points) : base(points) {}
    public Tetrahedron(Vector3 a, Vector3 b, Vector3 c, Vector3 d) : base(new Vector3[] {a, b, c, d}) {}

    public override float SurfaceArea()
    {
        float result = 0;
        
        (Vector3, Vector3) triangle1 = (_points[1]-_points[0] , _points[2]-_points[0]) ;
        (Vector3, Vector3) triangle2 = (_points[1]-_points[0] , _points[3]-_points[0]) ;
        (Vector3, Vector3) triangle3 = (_points[2]-_points[0] , _points[3]-_points[0]) ;
        (Vector3, Vector3) triangle4 = (_points[2]-_points[1] , _points[3]-_points[1]) ;

        result += Vector3.Cross(triangle1.Item1, triangle1.Item2).Magnitude/2f;
        result += Vector3.Cross(triangle2.Item1, triangle2.Item2).Magnitude/2f;
        result += Vector3.Cross(triangle3.Item1, triangle3.Item2).Magnitude/2f;
        result += Vector3.Cross(triangle4.Item1, triangle4.Item2).Magnitude/2f;


        return result;
    }
}