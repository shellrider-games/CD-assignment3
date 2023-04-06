namespace GeometryLibrary;

public class Cylinder : ISurface, IVolume
{
    private Vector3 _base1;
    private Vector3 _base2;
    private float _radius; //The radius of the cylinder

    //Constructor for creating a new Cylinder object with given base points and radius
    public Cylinder(Vector3 base1, Vector3 base2, float radius)
    {
        _base1 = base1;
        _base2 = base2;
        _radius = radius;
    }

    //Overload Equality operator for comparing two Cylinder objects
    public static bool operator== (Cylinder cylinder1, Cylinder cylinder2)
    {
        return(
            cylinder1._radius == cylinder2._radius &&  //Check if the radius is equal
            (cylinder1._base1.Equals(cylinder2._base1) && cylinder1._base2.Equals(cylinder2._base2)) ||
            (cylinder1._base2.Equals(cylinder2._base1) && cylinder1._base1.Equals(cylinder2._base2))
        );
    }

    public static bool operator!= (Cylinder cylinder1, Cylinder cylinder2)
    {
        return !(cylinder1 == cylinder2);
    }

    //Overrides the Equals method to compare two Cylinder objects
    public override bool Equals(object? obj)
    {
        if(obj is Cylinder) return this == (Cylinder)obj; //If the object is a Cylinder, compare it with this object
        return base.Equals(obj);
    }

    //Overrides the GetHashCode method to generate a hash code for the Cylinder object
    public override int GetHashCode()
    {
        int code = 13;
        code += _base1.GetHashCode();
        code += _base2.GetHashCode();
        code += _radius.GetHashCode();
        return code;
    }

    //Returns the height of the cylinder
    public float Height()
    {
        return (_base2-_base1).Magnitude;
    }

    public float BottomArea()
    {
        return _radius * _radius * MathF.PI;
    }

    //Returns the surface area of the cylinder
    public float SurfaceArea()
    {
        Thread.Sleep(1000); //Simulates a time-consuming calculation.
        return 2 * MathF.PI * _radius * (_radius + Height());
    }

    //Returns the volume of the cylinder
    public float Volume()
    {
        float l = MathF.Abs(Vector3.Dot(new Vector3(0,0,1), _base2-_base1)); // Calculates the length of the cylinder
        return BottomArea()*l;
    }

}