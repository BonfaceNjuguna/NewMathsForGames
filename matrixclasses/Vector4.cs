using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixclasses
{
    public class Vector4
    {
        public float x, y, z, w;

        public Vector4()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 0;
        }

        public Vector4(float x3d, float y3d, float z3d, float w3d)
        {
            x = x3d;
            y = y3d;
            z = z3d;
            w = w3d;
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        //subtraction
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        //vector scalar multiplication
        public static Vector4 operator *(Vector4 lhs, float scalar)
        {
            return new Vector4(lhs.x * scalar, lhs.y * scalar, lhs.z * scalar, lhs.w * scalar);
        }
        public static Vector4 operator *(float scalar, Vector4 lhs)
        {
            return new Vector4(lhs.x * scalar, lhs.y * scalar, lhs.z * scalar, lhs.w * scalar);
        }

        //vector scalar division
        public static Vector4 operator /(float scalar, Vector4 lhs)
        {
            return new Vector4(lhs.x / scalar, lhs.y / scalar, lhs.z / scalar, lhs.w / scalar);
        }
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }
        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z + w * w);
        }

        //vector normalization
        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
            this.z /= m;
            this.w /= w;
        }

        //distance
        public float Distance(Vector4 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            float diffW = w - other.w;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ + diffW * diffW);
        }

        //dot product
        public float Dot(Vector4 other)
        {
            return this.x * other.x + this.y * other.y + this.z * other.z + this.w * other.w;
        }

        //cross product
        public Vector4 Cross(Vector4 other)
        {
            return new Vector4(
                this.y * other.z - this.z * other.y,
                this.z * other.x - this.x * other.z,
                this.x * other.y - this.y * other.x,
                this.w * other.w - this.w * other.w);
        }
    }
}
