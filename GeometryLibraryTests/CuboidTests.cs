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

        [Test]
        public void Test_Surface_Cuboid()
        {
            Cuboid cuboid = new Cuboid(new Vector3[]{
                new Vector3(-0.858227f,-0.907245f,0.756414f),
                new Vector3(2.37286f,-0.907245f,0.672945f),
                new Vector3(2.08237f,1.06583f,1.16701f),
                new Vector3(-1.05237f,1.06583f,1.16701f),
                new Vector3(-0.943518f,-0.907245f,-1.04674f),
                new Vector3(2.16075f,-0.907245f,-1.04674f),
                new Vector3(1.30668f,1.09312f,-1.68679f),
                new Vector3(-1.13085f,1.09312f,-1.68679f),
            });

            Cuboid cuboid2 = new Cuboid(new Vector3[]{
                new Vector3(-0.34329f,-0.870595f,0.866248f),
                new Vector3(1.46298f,-0.870595f,0.866248f),
                new Vector3(1.01123f,0.858149f,-0.030544f),
                new Vector3(-0.795039f,0.858149f,-0.030544f),
                new Vector3(-1.24306f,-0.870595f,-0.919927f),
                new Vector3(0.563215f,-0.870595f,-0.919927f),
                new Vector3(0.563215f,0.858149f,-0.919927f),
                new Vector3(-1.24306f,0.858149f,-0.919927f),
            });

            Assert.That(MathF.Round(cuboid.SurfaceArea(),2), Is.EqualTo(35.29f));
            Assert.That(MathF.Round(cuboid2.SurfaceArea(),2), Is.EqualTo(16.65f));
        }

        // [Test]
        // public void Test_Volume_Cube()
        // {
        //     Cuboid cube = new Cuboid(new Vector3[]{
        //         new Vector3(-0.5f,0.5f,0.5f),
        //         new Vector3(0.5f,0.5f,0.5f),
        //         new Vector3(0.5f,-0.5f,0.5f),
        //         new Vector3(-0.5f,-0.5f,0.5f),
        //         new Vector3(-0.5f,0.5f,-0.5f),
        //         new Vector3(0.5f,0.5f,-0.5f),
        //         new Vector3(0.5f,-0.5f,-0.5f),
        //         new Vector3(-0.5f,-0.5f,-0.5f),
        //     });
        //     Assert.That(cube.Volume(), Is.EqualTo(1f));
        // }

        [Test]
        public void Test_Bottom_Surface_Cube()
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

            Assert.That(cube.BottomSurfaceArea(), Is.EqualTo(1f));
        }
        
    }
   
}