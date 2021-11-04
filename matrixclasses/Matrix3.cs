using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixclasses
{
    public class Matrix3
    {

        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

        public Matrix3()
        {
            m1 = 1; m2 = 0; m3 = 0;
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
        }

        public Matrix3(float m1, float m4, float m7, float m2, float m5, float m8, float m3, float m6, float m9)
        {
            this.m1 = m1;
            this.m4 = m4;
            this.m7 = m7;
            this.m2 = m2;
            this.m5 = m5;
            this.m8 = m8;
            this.m3 = m3;
            this.m6 = m6;
            this.m9 = m9;
        }

        public readonly static Matrix3 identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);

        //transpose
        Matrix3 GetTransposed()
        {
            return new Matrix3(m1, m4, m7,
                               m2, m5, m8,
                               m3, m6, m9);
        }

        //martix multiplication
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            /*return new Matrix3(
                (lhs.m1 * rhs.m1 + lhs.m2 * rhs.m4 + lhs.m3 * rhs.m7), (lhs.m1 * rhs.m2 + lhs.m2 * rhs.m5 + lhs.m3 * rhs.m8), (lhs.m1 * rhs.m3 + lhs.m2 * rhs.m6 + lhs.m3 * rhs.m9),
                (lhs.m4 * rhs.m1 + lhs.m5 * rhs.m4 + lhs.m6 * rhs.m7), (lhs.m4 * rhs.m2 + lhs.m5 * rhs.m5 + lhs.m6 * rhs.m8), (lhs.m4 * rhs.m3 + lhs.m5 * rhs.m6 + lhs.m6 * rhs.m9),
                (lhs.m7 * rhs.m1 + lhs.m8 * rhs.m4 + lhs.m9 * rhs.m7), (lhs.m7 * rhs.m2 + lhs.m8 * rhs.m5 + lhs.m9 * rhs.m8), (lhs.m7 * rhs.m3 + lhs.m8 * rhs.m6 + lhs.m9 * rhs.m9)
                );*/

            var m1 = (lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3);
            var m2 = (lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6);
            var m3 = (lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9);

            var m4 = (lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3);
            var m5 = (lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6);
            var m6 = (lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9);

            var m7 = (lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3);
            var m8 = (lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6);
            var m9 = (lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9);

            return new Matrix3(m1, m4, m7, m2, m5, m8, m3, m6, m9);
        }

        //matrix vector multiplication
        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(
                (lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z),
                (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z),
                (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z)
                );
        }

        public void Set(Matrix3 m)
        {
            this.m1 = m.m1; this.m2 = m.m2; this.m3 = m.m3;
            this.m4 = m.m4; this.m5 = m.m5; this.m6 = m.m6;
            this.m7 = m.m7; this.m8 = m.m8; this.m9 = m.m9;
        }
        public void Set(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
        {
            this.m1 = m1; this.m2 = m2; this.m3 = m3;
            this.m4 = m4; this.m5 = m5; this.m6 = m6;
            this.m7 = m7; this.m8 = m8; this.m9 = m9;
        }

        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0;
            m4 = 0; m5 = y; m6 = 0;
            m7 = 0; m8 = 0; m9 = z;
        }
        public void SetScaled(Vector3 v)
        {
            m1 = v.x; m2 = 0; m3 = 0;
            m4 = 0; m5 = v.y; m6 = 0;
            m7 = 0; m8 = 0; m9 = v.z;
        }
        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);
            Set(this * m);
        }
        public void Scale(Vector3 v)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(v.x, v.y, v.z);
            Set(this * m);
        }

        //rotation x
        public void SetRotateX(double radians)
        {
            Set
            (
                1, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(radians),
                0, (float)-Math.Sin(radians), (float)Math.Cos(radians)
            );
        }

        //rotation y
        public void SetRotateY(double radians)
        {
            Set
            (
                (float)Math.Cos(radians), 0, -(float)Math.Sin(radians),
                0, 1, 0,
                (float)Math.Sin(radians), 0, (float)Math.Cos(radians)
            );
        }

        //rotation z
        public void SetRotateZ(double radians)
        {
            Set
            (
                (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1
            );
        }

        //rotation x
        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);
            Set(this * m);
        }

        //rotation y
        public void RotateY(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);
            Set(this * m);
        }

        //rotation z
        public void RotateZ(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);
            Set(this * m);
        }
        public void SetRotated(float pitch, float yaw, float roll)
        {
            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);
            Set(z * y * x);
        }

        //translation
        public void SetTranslation(float x, float y)
        {
            m3 = x; m6 = y; m9 = 1;
        }

        //translation
        public void Translate(float x, float y)
        {
            m3 += x; m6 += y;
        }

        //translate
        public void Translate(Vector3 v)
        {
            m3 += v.x; m6 += v.y; m9 += v.z;
        }
    }
}
