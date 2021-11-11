using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixclasses
{
    public class Matrix4
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

        public Matrix4()
        {
            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = 1; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = 1; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        public Matrix4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
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
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m14 = m14;
            this.m15 = m15;
            this.m16 = m16;
        }

        public readonly static Matrix4 identity = new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1);

        //martix multiplication
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            var m1 = (lhs.m1 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m9 * rhs.m3 + lhs.m13 * rhs.m4);
            var m2 = (lhs.m2 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m10 * rhs.m3 + lhs.m14 * rhs.m4);
            var m3 = (lhs.m3 * rhs.m1 + lhs.m7 * rhs.m2 + lhs.m11 * rhs.m3 + lhs.m15 * rhs.m4);
            var m4 = (lhs.m4 * rhs.m1 + lhs.m8 * rhs.m2 + lhs.m12 * rhs.m3 + lhs.m16 * rhs.m4);

            var m5 = (lhs.m1 * rhs.m5 + lhs.m5 * rhs.m6 + lhs.m9 * rhs.m7 + lhs.m13 * rhs.m8);
            var m6 = (lhs.m2 * rhs.m5 + lhs.m6 * rhs.m6 + lhs.m10 * rhs.m7 + lhs.m14 * rhs.m8);
            var m7 = (lhs.m3 * rhs.m5 + lhs.m7 * rhs.m6 + lhs.m11 * rhs.m7 + lhs.m15 * rhs.m8);
            var m8 = (lhs.m4 * rhs.m5 + lhs.m8 * rhs.m6 + lhs.m12 * rhs.m7 + lhs.m16 * rhs.m8);

            var m9 = (lhs.m1 * rhs.m9 + lhs.m5 * rhs.m10 + lhs.m9 * rhs.m11 + lhs.m13 * rhs.m12);
            var m10 = (lhs.m2 * rhs.m9 + lhs.m6 * rhs.m10 + lhs.m10 * rhs.m11 + lhs.m14 * rhs.m12);
            var m11 = (lhs.m3 * rhs.m9 + lhs.m7 * rhs.m10 + lhs.m11 * rhs.m11 + lhs.m15 * rhs.m12);
            var m12 = (lhs.m4 * rhs.m9 + lhs.m8 * rhs.m10 + lhs.m12 * rhs.m11 + lhs.m16 * rhs.m12);

            var m13 = (lhs.m1 * rhs.m13 + lhs.m5 * rhs.m14 + lhs.m9 * rhs.m15 + lhs.m13 * rhs.m16);
            var m14 = (lhs.m2 * rhs.m13 + lhs.m6 * rhs.m14 + lhs.m10 * rhs.m15 + lhs.m14 * rhs.m16);
            var m15 = (lhs.m3 * rhs.m13 + lhs.m7 * rhs.m14 + lhs.m11 * rhs.m15 + lhs.m15 * rhs.m16);
            var m16 = (lhs.m4 * rhs.m13 + lhs.m8 * rhs.m14 + lhs.m12 * rhs.m15 + lhs.m16 * rhs.m16);

            return new Matrix4(m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16);


        }

        //matrix vector multiplication
        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4(
                (lhs.m1 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m9 * rhs.z) + (lhs.m13 * rhs.w),
                (lhs.m2 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m10 * rhs.z) + (lhs.m14 * rhs.w),
                (lhs.m3 * rhs.x) + (lhs.m7 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m15 * rhs.w),
                (lhs.m4 * rhs.x) + (lhs.m8 * rhs.y) + (lhs.m12 * rhs.z) + (lhs.m16 * rhs.w)
                );
        }

        public void Set(Matrix4 m)
        {
            this.m1 = m.m1; this.m2 = m.m2; this.m3 = m.m3; this.m4 = m.m4;
            this.m5 = m.m5; this.m6 = m.m6; this.m7 = m.m7; this.m8 = m.m8;
            this.m9 = m.m9; this.m10 = m.m10; this.m11 = m.m11; this.m12 = m.m12;
            this.m13 = m.m13; this.m14 = m.m14; this.m15 = m.m15; this.m16 = m.m16;
        }
        public void Set(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
        {
            this.m1 = m1; this.m2 = m2; this.m3 = m3; this.m4 = m4;
            this.m5 = m5; this.m6 = m6; this.m7 = m7; this.m8 = m8;
            this.m9 = m9; this.m10 = m10; this.m11 = m11; this.m12 = m12;
            this.m13 = m13; this.m14 = m14; this.m15 = m15; this.m16 = m16;
        }

        public void SetScaled(float x, float y, float z, float w)
        {
            m1 = x; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = w;
        }
        public void SetScaled(Vector4 v)
        {

            m1 = v.x; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = v.y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = v.z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = v.w;
        }
        public void Scale(float x, float y, float z, float w)
        {
            Matrix4 m = new Matrix4();
            m.SetScaled(x, y, z, w);
            Set(this * m);
        }
        public void Scale(Vector4 v)
        {
            Matrix4 m = new Matrix4();
            m.SetScaled(v.x, v.y, v.z, v.w);
            Set(this * m);
        }

        //rotation x
        public void SetRotateX(double radians)
        {
            Set
            (
                1, 0, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                0, -(float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 0, 1
            );
        }

        //rotation y
        public void SetRotateY(double radians)
        {
            Set
            (
                (float)Math.Cos(radians), 0, -(float)Math.Sin(radians), 0,
                0, 1, 0, 0,
                (float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1
            );
        }

        //rotation z
        public void SetRotateZ(double radians)
        {
            Set
            (
                (float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0,
                -(float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
        }

        //rotation x
        public void RotateX(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateX(radians);
            Set(this * m);
        }

        //rotation y
        public void RotateY(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateY(radians);
            Set(this * m);
        }

        //rotation z
        public void RotateZ(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateZ(radians);
            Set(this * m);
        }
        public void SetRotated(float pitch, float yaw, float roll)
        {
            Matrix4 x = new Matrix4();
            Matrix4 y = new Matrix4();
            Matrix4 z = new Matrix4();
            Matrix4 w = new Matrix4();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);
            Set(z * y * x);
        }

        //translation
        public void SetTranslation(float x, float y, float z)
        {
            m4 = x; m8 = y; m12 = z; m16 = 1;
        }

        //translation
        public void Translate(float x, float y, float z)
        {
            m4 += x; m8 += y; m12 += z;
        }

        //translate
        public void Translate(Vector4 v)
        {
            m4 += v.x; m8 += v.y; m12 += v.z; m16 += 1;
        }
    }
}
