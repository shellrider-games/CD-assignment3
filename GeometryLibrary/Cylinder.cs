namespace GeometryLibrary;

public class Cylinder : ISurface, IVolume
{
    private Vector3 _base1;
    private Vector3 _base2;
    private float _radius;

    public Cylinder(Vector3 base1, Vector3 base2, float radius)
    {
        _base1 = base1;
        _base2 = base2;
        _radius = radius;
    }

    public static bool operator== (Cylinder cylinder1, Cylinder cylinder2)
    {
        return(
            cylinder1._radius == cylinder2._radius &&
            (cylinder1._base1.Equals(cylinder2._base1) && cylinder1._base2.Equals(cylinder2._base2)) ||
            (cylinder1._base2.Equals(cylinder2._base1) && cylinder1._base1.Equals(cylinder2._base2))
        );
    }

    public static bool operator!= (Cylinder cylinder1, Cylinder cylinder2)
    {
        return !(cylinder1 == cylinder2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Cylinder) return this == (Cylinder)obj;
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        int code = 13;
        code += _base1.GetHashCode();
        code += _base2.GetHashCode();
        code += _radius.GetHashCode();
        return code;
    }

    public float Height()
    {
        return (_base2-_base1).Magnitude;
    }

    public float SurfaceArea()
    {
        return 2 * MathF.PI * _radius * (_radius + Height());
    }

    public float Volume()
    {
        throw new NotImplementedException();
    }
}