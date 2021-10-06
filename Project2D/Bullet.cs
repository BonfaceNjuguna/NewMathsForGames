using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matrixclasses;

namespace Project2D
{
    class Bullet : SceneObject
    {

        public Vector3 speed;
        public override void OnUpdate(float deltaTime)
        {
            Translate(speed.x * deltaTime, speed.y * deltaTime);
            UpdateTransform();
        }
    }
}
