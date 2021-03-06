using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    public class Game
    {
        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();
        //Bullet bulletObject = new Bullet();

        List<SceneObject> targets = new List<SceneObject>();
        List<Bullet> projectiles = new List<Bullet>(); //bullet

        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();
        SpriteObject bulletSprite = new SpriteObject();

        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;
        private Texture2D background;

        private matrixclasses.Matrix3 bulletmatrix; //here we initiated a Matrix3 from the matrixclasses linb

        public Game()
        {
        }

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            //tank
            tankSprite.Load("../Images/tankBlue.png");
            tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            tankSprite.SetPosition(tankSprite.Width / 2.0f, -tankSprite.Height / 2.0f);

            //turrent
            turretSprite.Load("../Images/barrelBlue_outline.png");
            turretSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            turretSprite.SetPosition(0, -turretSprite.Width / 2.0f);

            //background
            Texture2D background = LoadTexture("../Images/dirt.png");

            //bullet
            bulletSprite.Load("../Images/bulletBlue_outline.png"); //loading the bullet
            bulletSprite.SetRotate(90 * (float)(Math.PI / 180.0f)); //set the right rotate angle

            bulletmatrix = new matrixclasses.Matrix3(); //create a new matrix3 for bulletmatrix
            bulletmatrix.SetTranslation(-turretSprite.Height, 0.0f);

            var matrix = new matrixclasses.Matrix3();//create a new matrix3 for var matrix
            matrix.SetTranslation(-bulletSprite.Height / 2.0f, bulletSprite.Width / 2.0f);
            bulletSprite.LocalTransform = matrix * bulletSprite.LocalTransform;


            //add targets
            SceneObject barrel = new SceneObject();
            barrel.SetPosition(30, 240);

            SceneObject barrel2 = new SceneObject();
            barrel2.SetPosition(530, 340);

            SceneObject barrel3 = new SceneObject();
            barrel3.SetPosition(350, 250);

            targets.Add(barrel);
            targets.Add(barrel2);
            targets.Add(barrel3);

            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);

            tankObject.SetPosition(200, 200);
        }

        public void Shutdown()
        {
        }

        public void Update()
        {
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;

            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            lastTime = currentTime;

            //game logic here
            //tank turn right
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(deltaTime);
            }
            //tank move forward
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector3 facing = new Vector3(tankObject.LocalTransform.m1, tankObject.LocalTransform.m4, 1) * deltaTime * -100;
                tankObject.Translate(facing.x, facing.y);
            }
            //tank move backwards
            if (IsKeyDown(KeyboardKey.KEY_S))
            {

                Vector3 facing = new Vector3(tankObject.LocalTransform.m1, tankObject.LocalTransform.m4, 1) * deltaTime * 100;
                tankObject.Translate(facing.x, facing.y);
            }
            //tank rotates left
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(-deltaTime);
            }
            //turrent rotate left
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(deltaTime);
            }
            //turrent rotate right
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(-deltaTime);
            }
            //shoot
            if (IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                float bulletSpeed = 100;
                Bullet b = new Bullet(); //create a new bullet
                b.LocalTransform = turretObject.GlobalTransform; //assign the localtransform for the new bullet to the turrents globaltransform
                b.speed.x = -b.LocalTransform.m1 * bulletSpeed; //bullet speed
                b.speed.y = -b.LocalTransform.m4 * bulletSpeed;

                b.LocalTransform = b.LocalTransform * bulletmatrix;
                b.AddChild(new SpriteObject(bulletSprite));
                projectiles.Add(b);
            }

            foreach (var bullet in projectiles)
            {
                bullet.Update(deltaTime);

                foreach (SceneObject b in targets)
                {

                    var v = new Vector3(b.GlobalTransform.m3, b.GlobalTransform.m6, 0) -
                    new Vector3(bullet.GlobalTransform.m3, bullet.GlobalTransform.m6, 0);

                    float distance = (float)Math.Sqrt(v.x * v.x + v.y * v.y);

                    if (distance < 35)
                    {
                        b.IsDestroyed = true;
                    }
                }
            }
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);

            DrawTexture(background, 640, 480, Color.WHITE);

            DrawText(fps.ToString(), 10, 10, 14, Color.RED);

            tankObject.Draw();

            foreach (var b in projectiles)
            {
                b.Draw();
            }

            foreach (SceneObject b in targets)
            {
                if (!b.IsDestroyed)
                {
                    DrawCircle((int)b.GlobalTransform.m3, (int)b.GlobalTransform.m6, 40, new Color(255, 0, 0, 255));
                }
            }

            EndDrawing();
        }

    }
}
