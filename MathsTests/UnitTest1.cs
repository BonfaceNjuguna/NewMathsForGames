using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using matrixclasses;

namespace MathsTests
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void Matrix3_Set()
        {
            Matrix3 m = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix3 n = new Matrix3();
            n.Set(m);
            Assert.IsTrue(n.m1 == 1);
        }

        [TestMethod]
        public void Matrix3_Scale()
        {
            Matrix3 s = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            s.Scale(2, 2, 3);
            Assert.IsTrue(s.m9 == 27);
        }

        [TestMethod]
        public void Matrix3_Translate()
        {
            Matrix3 t = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            t.Translate(2, 3);
            Assert.IsTrue(t.m9 == 9);
        }
    }
}
