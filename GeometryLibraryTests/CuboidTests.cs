namespace GeometryLibraryTests
{
    [TestFixture]
    public class CuboidTests
    {
        [Test]
        public void Test_Create_Cuboid()
        {
            Cuboid cube = new Cuboid(new Vector3[]{
                new Vector3(-0.5f,0.5f,0.5f),
                new Vector3(0.5f,0.5f,0.5f),
                new Vector3(0.5f,-0.5f,0.5f),
                new Vector3(-0.5f,-0.5f,0.5f),
                new Vector3(-0.5f,0.5f,-0.5f),
                new Vector3(0.5f,0.5f,-0.5f),
                new Vector3(0.5f,-0.5f,-0.5f),
                new Vector3(-0.5f,-0.5f,-0.5f),
            });

            Cuboid cube2 = new Cuboid(
                new Vector3(-0.5f,0.5f,0.5f),
                new Vector3(0.5f,0.5f,0.5f),
                new Vector3(0.5f,-0.5f,0.5f),
                new Vector3(-0.5f,-0.5f,0.5f),
                new Vector3(-0.5f,0.5f,-0.5f),
                new Vector3(0.5f,0.5f,-0.5f),
                new Vector3(0.5f,-0.5f,-0.5f),
                new Vector3(-0.5f,-0.5f,-0.5f)
            );

            Assert.IsTrue(cube == cube2);
        }

        [Test]
        public void Test_Centroid_Cuboid()
        {
            Cuboid cube = new Cuboid(new Vector3[]{
                new Vector3(-0.5f,0.5f,0.5f),
                new Vector3(0.5f,0.5f,0.5f),
                new Vector3(0.5f,-0.5f,0.5f),
                new Vector3(-0.5f,-0.5f,0.5f),
                new Vector3(-0.5f,0.5f,-0.5f),
                new Vector3(0.5f,0.5f,-0.5f),
                new Vector3(0.5f,-0.5f,-0.5f),
                new Vector3(-0.5f,-0.5f,-0.5f),
            });
            Assert.That(cube.Centroid, Is.EqualTo(new Vector3(0,0,0)));
        }

        [Test]
        public void Test_Surface_Cube()
        {
            Cuboid cube = new Cuboid(new Vector3[]{
                new Vector3(-0.5f,0.5f,0.5f),
                new Vector3(0.5f,0.5f,0.5f),
                new Vector3(0.5f,-0.5f,0.5f),
                new Vector3(-0.5f,-0.5f,0.5f),
                new Vector3(-0.5f,0.5f,-0.5f),
                new Vector3(0.5f,0.5f,-0.5f),
                new Vector3(0.5f,-0.5f,-0.5f),
                new Vector3(-0.5f,-0.5f,-0.5f),
            });
            Assert.That(cube.SurfaceArea(), Is.EqualTo(6f));
        }
    }
}