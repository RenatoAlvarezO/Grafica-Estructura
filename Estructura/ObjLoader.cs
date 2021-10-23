using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using OpenTK;

namespace Estructura
{
    public class ObjLoader
    {
        public static Object3D loadObj(string path, Vector3 center)
        {
            List<Vector3> vertices = new List<Vector3>();
            List<Vector3> textureVertices = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();

            List<Color> colors = new List<Color>();
            colors.Add(Color.Aqua);
            colors.Add(Color.Gold);
            colors.Add(Color.Fuchsia);
            colors.Add(Color.Red);
            colors.Add(Color.Navy);
            colors.Add(Color.Lime);
            colors.Add(Color.White);
            colors.Add(Color.Blue);


            List<Face> faces = new List<Face>();
            List<uint> textureIndices = new List<uint>();
            List<uint> normalIndices = new List<uint>();

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Unable to open \"" + path + "\", does not exist.");
            }

            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    List<string> words = new List<string>(streamReader.ReadLine().ToLower().Split(' '));
                    words.RemoveAll(s => s == string.Empty);

                    if (words.Count == 0)
                        continue;

                    string type = words[0];
                    words.RemoveAt(0);

                    switch (type)
                    {
                        // vertex
                        case "v":
                            vertices.Add(new Vector3(float.Parse(words[0], CultureInfo.InvariantCulture),
                                float.Parse(words[1], CultureInfo.InvariantCulture),
                                float.Parse(words[2], CultureInfo.InvariantCulture)));
                            break;

                        case "vt":
                            textureVertices.Add(new Vector3(float.Parse(words[0], CultureInfo.InvariantCulture),
                                float.Parse(words[1], CultureInfo.InvariantCulture),
                                words.Count < 3 ? 0 : float.Parse(words[2], CultureInfo.InvariantCulture)));
                            break;

                        case "vn":
                            normals.Add(
                                new Vector3(float.Parse(words[0], CultureInfo.InvariantCulture),
                                    float.Parse(words[1], CultureInfo.InvariantCulture),
                                    float.Parse(words[2], CultureInfo.InvariantCulture)));
                            break;

                        // face
                        case "f":
                            List<Vector3> faceVertices = new List<Vector3>();
                            foreach (string w in words)
                            {
                                if (w.Length == 0)
                                    continue;

                                string[] comps = w.Split('/');

                                // subtract 1: indices start from 1, not 0
                                int index = int.Parse(comps[0]) - 1;
                                faceVertices.Add(new Vector3(vertices[index].X, vertices[index].Y, vertices[index].Z));

                                if (comps.Length > 1 && comps[1].Length != 0)
                                    textureIndices.Add(uint.Parse(comps[1]) - 1);

                                if (comps.Length > 2)
                                    normalIndices.Add(uint.Parse(comps[2]) - 1);
                            }

                            faces.Add(new Face(faceVertices, colors[faces.Count % colors.Count], center));

                            break;
                    }
                }

                return new Object3D(faces, center);
            }
        }
    }
}