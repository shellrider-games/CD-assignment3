namespace GeometryLibraryTests
{
    [TestFixture]
    public class TetrahedronTests
    {
        [Test]
        public void Can_Create_Tetrahedron()
        {
            Tetrahedron test = new Tetrahedron(new Vector3[] {
                new Vector3(0f,1f,0f),
                new Vector3(0.707f,0f,0f),
                new Vector3(-0.707f,0f,0f),
                new Vector3(0f,0f,1f)
            });

            Tetrahedron test2 = new Tetrahedron(
                new Vector3(0f,1f,0f),
                new Vector3(0.707f,0f,0f),
                new Vector3(-0.707f,0f,0f),
                new Vector3(0f,0f,1f)
            );

            Assert.That(test, Is.EqualTo(test2));
        }

        [Test]
        public void Test_TetrahedronEquality()
        {
            Tetrahedron test1 = new Tetrahedron(new Vector3[] {
                new Vector3(0f,1f,0f),
                new Vector3(0.707f,0f,0f),
                new Vector3(-0.707f,0f,0f),
                new Vector3(0f,0f,1f)
            });

            Tetrahedron test2 = new Tetrahedron(new Vector3[] {
                new Vector3(0f,0f,1f),
                new Vector3(0f,1f,0f),
                new Vector3(0.707f,0f,0f),
                new Vector3(-0.707f,0f,0f)
            });

            Assert.IsTrue(test1 == test2);
        }

        [Test]
        public void Test_TetrahedronCentroid()
        {
            Tetrahedron test = new Tetrahedron(new Vector3[] {
                new Vector3(5,-7, 0),
                new Vector3(1, 5, 3),
                new Vector3(4, -6, 3),
                new Vector3(6, -4, 2)
            });

            Assert.That(test.Centroid(), Is.EqualTo(new Vector3(4, -3, 2)));
        }

        [Test]
        public void Test_TetrahedronSurfaceArea()
        {
            Tetrahedron test = new Tetrahedron(
                new Vector3(0,1,0),
                new Vector3(0.707f,0,0),
                new Vector3(-0.707f,0, 0),
                new Vector3(0, 0, 1)
            );

            Tetrahedron test2 = new Tetrahedron(
                new Vector3(4,2,-1),
                new Vector3(-4,2,0),
                new Vector3(5,3,0),
                new Vector3(2,-3,0)
            );

            Assert.That(MathF.Round(test.SurfaceArea(),3), Is.EqualTo(2.828f));
            Assert.That(test2.SurfaceArea(), Is.EqualTo(55.59344147f));
        }
    }
}