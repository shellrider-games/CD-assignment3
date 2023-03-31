namespace GeometryLibrary;
public abstract class Polyhedron : ISurface
{
    private Vector3[] _points;

    public Polyhedron(Vector3[] points){
        _points = points;
    }

    public Vector3 Centroid()
    {
        Vector3 centroid = new Vector3(0f, 0f, 0f);
        foreach(Vector3 point in _points)
        {
            centroid += point;
        }
        return centroid/_points.Length;
    }
    public abstract float SurfaceArea();
}