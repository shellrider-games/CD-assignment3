namespace GeometryLibraryTests
{
    [TestFixture]
    public class CylinderTests
    {
        [Test]
        public void Test_Create_Cylinder()
        {
            Cylinder cylinder1 = new Cylinder(new Vector3(0,0,0), new Vector3(0,0,2), 1f);
            Cylinder cylinder2 = new Cylinder(new Vector3(0,0,2), new Vector3(0,0,0), 1f);

            Assert.True(cylinder1 == cylinder2);
        }
        [Test]
        public void Test_Cylinder_Height()
        {
            Cylinder cylinder1 = new Cylinder(new Vector3(0,0,0), new Vector3(0,0,2), 1f);
            Assert.That(cylinder1.Height(), Is.EqualTo(2f));
        }
        [Test]
        public void Test_Cylinder_SurfaceArea()
        {
            Cylinder cylinder1 = new Cylinder(new Vector3(0,0,0), new Vector3(0,0,2), 1f);
            Assert.That(cylinder1.SurfaceArea(), Is.EqualTo(18.8495559f));
        }

        [Test]
        public void Test_Cylinder_Volume()
        {
            Cylinder cylinder1 = new Cylinder(new Vector3(0,0,0), new Vector3(0,0,2), 1f);
            Assert.That(cylinder1.Volume(), Is.EqualTo(6.28318531f));
        }

        [Test]
        public void Test_Cylinder_BottomArea()
        {
            Cylinder cylinder1 = new Cylinder(new Vector3(0,0,0), new Vector3(0,0,2), 1f);
            Assert.That(cylinder1.BottomArea(), Is.EqualTo(MathF.PI));
        }
    }
}