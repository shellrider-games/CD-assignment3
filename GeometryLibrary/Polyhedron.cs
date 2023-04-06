namespace GeometryLibrary;

//Polyhedron is an abstract class for 3D objects with flat polygonal faces
public abstract class Polyhedron : ISurface
{
    //_points is an array of Vector3 objects representing the vertices of the polyhedron
    protected Vector3[] _points;

    //Constructor for Polyhedron that takes an array of Vector3 objects as input
    public Polyhedron(Vector3[] points)
    {
        _points = points;
    }

    //Override the Equals method to compare two Polyhedron objects
    public override bool Equals(object? obj)
    {
        if (obj is Polyhedron) return this == (Polyhedron)obj;
        return base.Equals(obj);
    }

    //Override the GetHashCode method to generate a hash code for the Polyhedron object
    public override int GetHashCode()
    {
        int hash = 7;
        foreach (Vector3 point in _points)
        {
            hash += point.GetHashCode();
        }
        return hash;
    }

    //Override the == operator to compare two Polyhedron objects for equality
    public static bool operator ==(Polyhedron polyhedron1, Polyhedron polyhedron2)
    {
        //Check if the two polyhedrons have different numbers of vertices
        if (polyhedron1._points.Length != polyhedron2._points.Length) return false;

        //Create a copy of polyhedron2's vertices to keep track of which ones have been compared
        List<Vector3> comparePoints = polyhedron2._points.ToList();

        //Compare each vertex of polyhedron1 with the vertices of polyhedron2
        foreach (Vector3 point in polyhedron1._points)
        {
            //Find the index of the vertex in comparePoints that is equal to the current vertex in polyhedron1
            int indexInCompare = comparePoints.FindIndex(vec => point.Equals(vec));
            //If the vertex is not found in comparePoints, the polyhedrons are not equal
            if (indexInCompare < 0) return false;
            //Remove the vertex from comparePoints to mark it as compared
            comparePoints.RemoveAt(indexInCompare);
        }
        //If all vertices have been compared, the polyhedrons are equal
        return true;
    }

    //Override the != operator to compare two Polyhedron objects for inequality
    public static bool operator !=(Polyhedron polyhedron1, Polyhedron polyhedron2)
    {
        return !(polyhedron1 == polyhedron2);
    }

    //Calculate and return the centroid of the Polyhedron object
    public Vector3 Centroid()
    {
        Vector3 centroid = new Vector3(0f, 0f, 0f);
        foreach (Vector3 point in _points)
        {
            centroid += point;
        }
        return centroid / (float)_points.Length;
    }

    //Print the vertices of the Polyhedron object to the console
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