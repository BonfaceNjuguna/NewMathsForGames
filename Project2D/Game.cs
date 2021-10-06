﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Game
    {
        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();
        Bullet bulletObject = new Bullet();

        List<SceneObject> targets = new List<SceneObject>();

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

            //bullet
            bulletSprite.Load("../Images/bulletBlue_outline.png");
            bulletSprite.SetRotate(90 * (float)(Math.PI / 180.0f));
            bulletSprite.SetPosition(-35, 10);

            //add targets
            SceneObject barrel = new SceneObject();
            barrel.SetPosition(30, 240);

            targets.Add(barrel);

            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);
            bulletObject.AddChild(bulletSprite);

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

                bulletObject.LocalTransform = turretObject.GlobalTransform;
                bulletObject.speed.x = -bulletObject.LocalTransform.m1 * bulletSpeed;
                bulletObject.speed.y = -bulletObject.LocalTransform.m4 * bulletSpeed;
            } 
            bulletObject.Update(deltaTime);

            foreach (SceneObject b in targets)
            {
                var v = new Vector3(b.GlobalTransform.m3, b.GlobalTransform.m6, 0) - 
                new Vector3(bulletObject.GlobalTransform.m3, bulletObject.GlobalTransform.m6, 0);

                float distance = (float)Math.Sqrt(v.x * v.x + v.y * v.y);

                if (distance < 40)
                {
                    b.IsDestroyed = true;
                }

                if (!b.IsDestroyed)
                {
                    DrawCircle((int)b.GlobalTransform.m3, (int)b.GlobalTransform.m6, 40, new Color(255, 0, 0, 255));
                }
            }
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);

            DrawText(fps.ToString(), 10, 10, 14, Color.RED);

            tankObject.Draw();
            bulletObject.Draw();

            EndDrawing();
        }

    }
}