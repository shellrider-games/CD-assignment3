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

            Tetrahedron test2 = new Tetrahedron(
                new Vector3(0, 0, 0),
                new Vector3(4, 0, 0),
                new Vector3(2, 3, 2),
                new Vector3(2, 0, 4)
            );

            Assert.That(test.Centroid(), Is.EqualTo(new Vector3(4, -3, 2)));
            Assert.That(test2.Centroid(), Is.EqualTo(new Vector3(2, 0.75f, 1.5f)));

            
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

            Tetrahedron test3 = new Tetrahedron(
                new Vector3(0, 0, 0),
                new Vector3(4, 0, 0),
                new Vector3(2, 3, 2),
                new Vector3(2, 0, 4)
            );

            Tetrahedron test4 = new Tetrahedron(new Vector3[] {
                new Vector3(5,-7, 0),
                new Vector3(1, 5, 3),
                new Vector3(4, -6, 3),
                new Vector3(6, -4, 2)
            });

            Assert.That(MathF.Round(test.SurfaceArea(),3), Is.EqualTo(2.828f));
            Assert.That(test2.SurfaceArea(), Is.EqualTo(55.59344147f));
            Assert.That(MathF.Round(test3.SurfaceArea(),3), Is.EqualTo(29.211f));
            Assert.That(MathF.Round(test4.SurfaceArea(),3), Is.EqualTo(52.606f));
        }

        [Test]
        public void Test_TetrahedronVolume()
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

            Assert.That(MathF.Round(test.Volume(),3), Is.EqualTo(0.236f));
            Assert.That(MathF.Round(test2.Volume(),3), Is.EqualTo(8.500f));
        }
    }
}