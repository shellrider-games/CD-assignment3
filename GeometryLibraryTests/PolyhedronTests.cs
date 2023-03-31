namespace GeometryLibraryTests
{
    [TestFixture]
    public class PolyhedronTests
    {
        internal class BasePolyhedron : Polyhedron
        {
            public BasePolyhedron(Vector3[] points) : base(points)
            {
            }

            public override float SurfaceArea()
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void TestCentroidFunction()
        {
            BasePolyhedron test = new BasePolyhedron(new Vector3[]{
                new Vector3(1f,1f,-1f),
                new Vector3(1f,-1f,-1f),
                new Vector3(-1f,1f,-1f),
                new Vector3(-1f,-1f,-1f),
                new Vector3(1f,1f,1f),
                new Vector3(1f,-1f,1f),
                new Vector3(-1f,1f,1f),
                new Vector3(-1f,-1f,1f),
            });

            Assert.That(test.Centroid(), Is.EqualTo(new Vector3(0f, 0f, 0f)));
        }
    }
}