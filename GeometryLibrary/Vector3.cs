namespace GeometryLibrary;
public struct Vector3
{
    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public float X { get; }
    public float Y { get; }
    public float Z { get; }

    public float Magnitude
    {
        get
        {
            return MathF.Sqrt(MathF.Pow(X,2) + MathF.Pow(Y,2) + MathF.Pow(Z,2));
        }
    }

    public static Vector3 operator -(Vector3 minuend, Vector3 subtrahend)
    {
        return new Vector3(
            minuend.X - subtrahend.X,
            minuend.Y - subtrahend.Y,
            minuend.Z - subtrahend.Z
        );
    }

    public static Vector3 operator +(Vector3 addend1, Vector3 addend2)
    {
        return new Vector3(
            addend1.X + addend2.X,
            addend1.Y + addend2.Y,
            addend1.Z + addend2.Z
        );
    }

    public static Vector3 operator /(Vector3 vector, float scalar)
    {
        return new Vector3(
            vector.X / scalar,
            vector.Y / scalar,
            vector.Z / scalar
        );
    }

    public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
    {
        return new Vector3(
            vector1.Y * vector2.Z - vector1.Z * vector2.Y,
            vector1.Z * vector2.X - vector1.X * vector2.Z,
            vector1.X * vector2.Y - vector1.Y * vector2.X
        );
    }

    public static float Dot(Vector3 vector1, Vector3 vector2) => vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;

}
