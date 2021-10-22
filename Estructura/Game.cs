using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Estructura
{
    public class Game : GameWindow
    {
        // private House _house;
        private Face _face;
        private Object3D _object3D;

        private Scene _scene;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState inputKey = Keyboard.GetState();
            GL.Rotate(1, 0.0f, 1f, 0.0f);
            if (inputKey.IsKeyDown(Key.W))
            {
                while (Keyboard.GetState().IsKeyDown(Key.W)) ;
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            Color backgroundColor = Color.FromArgb(255, 65, 87, 63);
            GL.ClearColor(backgroundColor);

            
            //  Lista de Vertices para las Caras, esto hace un cuadrado
            List<Vector3> vertices = new List<Vector3>();
            vertices.Add(new Vector3(50f, 0f, 0f));
            vertices.Add(new Vector3(50f, 50f, 0f));
            vertices.Add(new Vector3(0f, 50f, 0f));
            vertices.Add(new Vector3(0.0f, 0f, 0f));

            List<Vector3> vertices2 = new List<Vector3>();
            vertices2.Add(new Vector3(0.0f, 50f, 0f));
            vertices2.Add(new Vector3(0.0f, 50f, 50f));
            vertices2.Add(new Vector3(0f, 0f, 50f));
            vertices2.Add(new Vector3(0f, 0.0f, 0f));


            List<Face> faces2 = new List<Face>();
            faces2.Add(new Face(vertices, Color.Aqua, new Vector3(0f, 0f, 0f)));
            faces2.Add(new Face(vertices2, Color.Gold, new Vector3(0f, 0f, 0f)));


            List<Object3D> objects = new List<Object3D>();
            objects.Add(new Object3D(faces, new Vector3(0f, 0f, 0f)));
            objects.Add(new Object3D(faces2, new Vector3(50f, 50f, 0f)));
            
            _scene = new Scene(objects);
            
            int orthoSize = 200;
            GL.Ortho(-orthoSize, orthoSize, -orthoSize, orthoSize, -orthoSize, orthoSize);
            GL.Rotate(10, 0.2f, 0.1f, 0.1f);
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            _scene.Draw();
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}