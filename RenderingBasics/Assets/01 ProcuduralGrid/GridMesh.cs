using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridMesh : MonoBehaviour
{

    public int xSize, ySize;

    private void Awake()
    {
        Generate();
    }


    private void Generate()
    {
        var mesh = new Mesh();
        var vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        var uv = new Vector2[vertices.Length];
        var triangles = new int[xSize * ySize * 2 * 3];
        var tangents= new Vector4[vertices.Length];


        #region fill vertices and uv
        for (int i = 0, k = 0; i < ySize + 1; i++)
        {
            for (int j = 0; j < xSize + 1; j++, k++)
            {
                vertices[k] = new Vector3(j, i, 0);
                tangents[k] = new Vector4(0f, 1f, 0f, 1f);
                uv[k]=new Vector2((float)j/xSize,(float)i/ySize);
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.tangents = tangents;
        #endregion
        #region fill triangles

        //fill grid
        // grid cell 
        // p+(x+1) |         |p+1+(x+1) 
        //         |  m , n  |                p= (x+1)*n+m 
        //        p|         |p+1 

        for (int j = 0, quad = 0; j < ySize; j++)
        {
            for (int i = 0; i < xSize; i++, quad++)
            {
                var triIndexBase = quad * 6;
                var p = (xSize + 1) * j + i;
                triangles[triIndexBase + 0] = p;
                triangles[triIndexBase + 1] = p + (xSize + 1);
                triangles[triIndexBase + 2] = p + 1;
                triangles[triIndexBase + 3] = p + 1;
                triangles[triIndexBase + 4] = p + (xSize + 1);
                triangles[triIndexBase + 5] = p + 1 + (xSize + 1);
            }

        }

        #endregion
        #region fill mesh  

        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.name = "Procedural Mesh";

        #endregion



        GetComponent<MeshFilter>().mesh = mesh;
    }


    void Start()
    {

    }

    void Update()
    {

    }
}
