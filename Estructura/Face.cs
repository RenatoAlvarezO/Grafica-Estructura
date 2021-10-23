using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Estructura
{
    public class Face
    {
        private List<Vector3> ListOfVertices;
        public Color Color;
        public Vector3 Center;

        public Face(List<Vector3> listOfVertices, Color color, Vector3 center)
        {
            ListOfVertices = listOfVertices;
            Color = color;
            Center = center;
        }

        public void Draw(int TextureType)
        {
            GL.Color4(Color);
            GL.Begin((PrimitiveType) TextureType);
            // GL.Begin((PrimitiveType) 2);
            foreach (var vertex in ListOfVertices)
            {
                GL.Vertex3(vertex.X + Center.X, vertex.Y + Center.Y, vertex.Z + Center.Z);
            }

            GL.End();
            GL.Flush();
        }
    }
}