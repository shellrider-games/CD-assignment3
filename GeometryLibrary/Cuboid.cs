namespace GeometryLibrary;

public class Cuboid : Polyhedron
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
        throw new NotImplementedException();
    }
}