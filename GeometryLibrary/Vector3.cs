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

    public static Vector3 operator-(Vector3 minuend, Vector3 subtrahend)
    {
        return new Vector3(
            minuend.X-subtrahend.X,
            minuend.Y-subtrahend.Y,
            minuend.Z-subtrahend.Z
        );
    }

    public static Vector3 operator+(Vector3 addend1, Vector3 addend2)
    {
        return new Vector3(
            addend1.X + addend2.X,
            addend1.Y + addend2.Y,
            addend1.Z + addend2.Z
        );
    }
}
