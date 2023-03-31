namespace GeometryLibraryTests
{
    [TestFixture]
    public class Vector3Tests
    {
        [Test]
        public void Can_Create_Vector()
        {
            Vector3 testVector = new Vector3(0f,0f,0f);
            Assert.That(testVector.X, Is.EqualTo(0.0f));
            Assert.That(testVector.Y, Is.EqualTo(0.0f));
            Assert.That(testVector.Z, Is.EqualTo(0.0f));
            Assert.That(testVector, Is.EqualTo(new Vector3(0f, 0f, 0f)));
        }

        [Test]
        public void Can_Subtract_Vectors()
        {
            Vector3 nullVector = new Vector3(0f, 0f, 0f);
            Vector3 testVector = new Vector3(1f, 2f, 3f);
            Assert.That(nullVector - testVector, Is.EqualTo(new Vector3(-1f, -2f, -3f)));
        }

        [Test]
        public void Can_Add_Vectors()
        {
            Vector3 vector1 = new Vector3(1f, 2f, 3f);
            Vector3 vector2 = new Vector3(4f, 5f, 6f);
            Assert.That(vector1+vector2, Is.EqualTo(new Vector3(5f,7f,9f)));
        }

        [Test]
        public void Can_Divide_Vector_By_Scalar()
        {
            Vector3 vector = new Vector3(2f, 2f, 2f);
            Assert.That(vector/2, Is.EqualTo(new Vector3(1f, 1f, 1f)));
        }

        [Test]
        public void Test_Vector_Cross_Product()
        {
            Vector3 vector1 = new Vector3(0f,3f,0f);
            Vector3 vector2 = new Vector3(3f, 0f, 0f);

            Vector3 vector3 = new Vector3(1f, 1f, 0f);
            Vector3 vector4 = new Vector3(2f, 4f, 3f);
 
            Assert.That(Vector3.Cross(vector1, vector2), Is.EqualTo(new Vector3(0f, 0f, -9f)));
            Assert.That(Vector3.Cross(vector3, vector4), Is.EqualTo(new Vector3(3f, -3f, 2f)));
        }

        [Test]
        public void Test_Vector_Dot_Product()
        {
            Vector3 vector1 = new Vector3(1f, 3f, -5f);
            Vector3 vector2 = new Vector3(4f, -2f, -1f);

            Assert.That(Vector3.Dot(vector1, vector2), Is.EqualTo(3f));
        }
    }
}