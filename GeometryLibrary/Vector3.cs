namespace GeometryLibrary;
//A struct representing a three-dimensional vector
public struct Vector3
{
    //Constructor that takes X, Y, and Z components
    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    //Properties for accessing the X, Y, and Z components
    public float X { get; }
    public float Y { get; }
    public float Z { get; }

    //Property that calculates and returns the magnitude (length) of the vector
    public float Magnitude
    {
        get
        {
            return MathF.Sqrt(MathF.Pow(X,2) + MathF.Pow(Y,2) + MathF.Pow(Z,2));
        }
    }

    //Subtract operator overload that subtracts one vector from another
    public static Vector3 operator -(Vector3 minuend, Vector3 subtrahend)
    {
        return new Vector3(
            minuend.X - subtrahend.X,
            minuend.Y - subtrahend.Y,
            minuend.Z - subtrahend.Z
        );
    }

    //Add operator overload that adds two vectors
    public static Vector3 operator +(Vector3 addend1, Vector3 addend2)
    {
        return new Vector3(
            addend1.X + addend2.X,
            addend1.Y + addend2.Y,
            addend1.Z + addend2.Z
        );
    }

    //Divide operator overload that divides a vector by a scalar value
    public static Vector3 operator /(Vector3 vector, float scalar)
    {
        return new Vector3(
            vector.X / scalar,
            vector.Y / scalar,
            vector.Z / scalar
        );
    }

    //Method that calculates and returns the cross product of two vectors
    public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
    {
        return new Vector3(
            vector1.Y * vector2.Z - vector1.Z * vector2.Y,
            vector1.Z * vector2.X - vector1.X * vector2.Z,
            vector1.X * vector2.Y - vector1.Y * vector2.X
        );
    }

    //Method that normalizes a vector to have a magnitude of 1
    public static Vector3 Normalize(Vector3 vector)
    {
        return new Vector3(
            vector.X / vector.Magnitude,
            vector.Y / vector.Magnitude,
            vector.Z / vector.Magnitude
        );
    }

    //Method that calculates and returns the dot product of two vectors
    public static float Dot(Vector3 vector1, Vector3 vector2) => vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;

}
