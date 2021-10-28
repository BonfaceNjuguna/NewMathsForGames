using System;

namespace matrixclasses
{
    public class Vector3
    {
        public float x, y, z;
        private float v1;
        private float v2;
        private float v3;

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Vector3(float x3d, float y3d, float z3d)
        {
            x = x3d;
            y = y3d;
            z = z3d;
        }

        public Vector3(float x3d, float y3d, float z3d, float v1, float v2, float v3) : this(x3d, y3d, z3d)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        //addition
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        //subtraction
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        //vector scalar multiplication
        public static Vector3 operator *(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.x * scalar, lhs.y * scalar, lhs.z * scalar);
        }
        public static Vector3 operator *(float scalar, Vector3 lhs)
        {
            return new Vector3(lhs.x * scalar, lhs.y * scalar, lhs.z * scalar);
        }
        public static Vector3 operator /(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.x / scalar, lhs.y / scalar, lhs.z / scalar);
        }

        //vector scalar division
        public static Vector3 operator /(float scalar, Vector3 lhs)
        {
            return new Vector3(lhs.x / scalar, lhs.y / scalar, lhs.z / scalar);
        }
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z);
        }

        //vector normalization
        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
            this.z /= m;
        }
        public Vector3 GetNormalised()
        {
            return (this / Magnitude());
        }

        //distance
        public float Distance(Vector3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }

        //dot product
        public float Dot(Vector3 other)
        {
            return this.x * other.x + this.y * other.y + this.z * other.z;
        }

        //cross product
        public Vector3 Cross(Vector3 other)
        {
            return new Vector3(
                this.y * other.z - this.z * other.y,
                this.z * other.x - this.x * other.z,
                this.x * other.y - this.y * other.x);
        }
    }
}