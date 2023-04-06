namespace GeometryLibrary;
public abstract class Polyhedron : ISurface
{
    protected Vector3[] _points;

    public Polyhedron(Vector3[] points)
    {
        _points = points;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Polyhedron) return this == (Polyhedron)obj;
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        int hash = 7;
        foreach (Vector3 point in _points)
        {
            hash += point.GetHashCode();
        }
        return hash;
    }

    public static bool operator ==(Polyhedron polyhedron1, Polyhedron polyhedron2)
    {
        if (polyhedron1._points.Length != polyhedron2._points.Length) return false;

        List<Vector3> comparePoints = polyhedron2._points.ToList();

        foreach (Vector3 point in polyhedron1._points)
        {
            int indexInCompare = comparePoints.FindIndex(vec => point.Equals(vec));
            if (indexInCompare < 0) return false;
            comparePoints.RemoveAt(indexInCompare);
        }

        return true;
    }

    public static bool operator !=(Polyhedron polyhedron1, Polyhedron polyhedron2)
    {
        return !(polyhedron1 == polyhedron2);
    }

    public Vector3 Centroid()
    {
        Vector3 centroid = new Vector3(0f, 0f, 0f);
        foreach (Vector3 point in _points)
        {
            centroid += point;
        }
        return centroid / (float)_points.Length;
    }

    public void PrintToConsole()
    {
        Console.WriteLine($"object has {_points.Length} points:");
        for(int i = 0; i < _points.Length; i++)
        {
            Console.WriteLine($"    Point {i}: ({_points[i].X}, {_points[i].Y}, {_points[i].Z})");
        }
    }
    public abstract float SurfaceArea();
}