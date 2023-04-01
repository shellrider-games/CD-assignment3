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

        [Test]
        public void TestEqualsOperator()
        {
            BasePolyhedron test1 = new BasePolyhedron(new Vector3[]{
                new Vector3(0f,1f,0f),
                new Vector3(0.7f,0f,0f),
                new Vector3(-0.7f,0f,0f),
                new Vector3(0f,0f,1f)
            });

            BasePolyhedron test2 = new BasePolyhedron(new Vector3[]{
                new Vector3(0f,0f,1f),
                new Vector3(-0.7f,0f,0f),
                new Vector3(0.7f,0f,0f),
                new Vector3(0f,1f,0f)
            });

            BasePolyhedron test3 = new BasePolyhedron(new Vector3[]{
                new Vector3(0f,2f,1f),
                new Vector3(-0.7f,0f,0f),
                new Vector3(0.7f,0f,0f),
                new Vector3(0f,1f,0f)
            });

            Assert.That(test1, Is.EqualTo(test2));
            Assert.IsTrue(test1 == test2);
            Assert.IsFalse(test1 == test3);
        }
    }
}