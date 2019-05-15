using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridMesh : MonoBehaviour
{

    public int xSize, ySize;

    private Vector3[] _vertices;
    private int[] _tris;
    private Mesh _mesh;

    private void Awake()
    {
        Generate();
    }

    private void OnDrawGizmos()
    {
        if (_vertices == null)
            return;

        foreach (var vertex in _vertices)
        {
            Gizmos.DrawSphere(transform.TransformPoint(vertex), .1f);
        }
    }


    private async void Generate()
    {
        _mesh = new Mesh();
        _mesh.name = "Procedural Mesh";
        GetComponent<MeshFilter>().mesh = _mesh;
        _vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        _tris = new int[xSize * ySize * 2 * 3];
              //fill vertices 
        for (int i = 0, k = 0; i < ySize + 1; i++)
        {
            for (int j = 0; j < xSize + 1; j++, k++)
            {
                _vertices[k] = new Vector3(j, i, 0);
            }
        }
       _mesh.vertices = _vertices;



        //fill grid
        // grid cell 
        // p+(x+1) |         |p+1+(x+1) 
        //         |  m , n  |                p= (x+1)*n+m 
        //        p|         |p+1 

        for (int i = 0, quad = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++, quad++)
            {
                var triIndexBase = quad * 6;
                var p = (xSize + 1) * j + i;
                _tris[triIndexBase + 0] = p;
                _tris[triIndexBase + 1] = p + (xSize + 1);
                _tris[triIndexBase + 2] = p + 1;
                _tris[triIndexBase + 3] = p + 1;
                _tris[triIndexBase + 4] = p + (xSize + 1);
                _tris[triIndexBase + 5] = p + 1 + (xSize + 1);

                await new WaitForSeconds(0.05f);
               _mesh.triangles = _tris;
            }
        }

        _mesh.triangles = _tris;

    }


    void Start()
    {

    }

    void Update()
    {

    }
}
