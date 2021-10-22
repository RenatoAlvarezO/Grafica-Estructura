using System.Collections.Generic;
using OpenTK;
namespace Estructura
{
    public class Object3D
    {
        private List<Face> ListOfFaces;
        public Vector3 Center;

        public Object3D(List<Face> listOfFaces, Vector3 center)
        {
            ListOfFaces = listOfFaces;
            Center = center;

            foreach (var face in ListOfFaces)
                face.Center = Center;
        }

        public void Draw()
        {
            foreach (var face in ListOfFaces)
                face.Draw();
        }
    }
}