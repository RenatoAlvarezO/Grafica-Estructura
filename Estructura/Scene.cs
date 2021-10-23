using System;
using System.Collections.Generic;

namespace Estructura
{
    public class Scene
    {
        private List<Object3D> listOfObject3Ds;

        public Scene(List<Object3D> listOfObject3Ds)
        {
            this.listOfObject3Ds = listOfObject3Ds;
        }

        public void Draw(int TextureType)
        {
            foreach (var object3D in listOfObject3Ds)
                object3D.Draw(TextureType);

        }
    }
}