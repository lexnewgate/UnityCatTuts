using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
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
            Gizmos.DrawSphere(transform.TransformPoint(vertex),.1f);
        }
    }


    private async void Generate()
    {
        _mesh=new Mesh();
      
        
       
       //fill vertices 
       _vertices=new Vector3[(xSize+1)*(ySize+1)];
       for (int i = 0,k=0; i < ySize+1; i++)
       {
           for (int j = 0; j < xSize+1; j++ ,k++)
           {
               _vertices[k] =new Vector3(j,i,0);
//               await new WaitForSeconds(.2f);
           } 
       }
       
       //fill tris
       _tris = new int[6 * xSize ];
//       _tris[0] = 0;
//       _tris[1] = xSize ;
//       _tris[2] = 1;
       for (int vi = 0,quad=0; quad<xSize ; quad++,vi+=6)
       {
           _tris[vi] = vi;
           _tris[vi + 4] = _tris[vi + 1] = xSize + 1 + vi;
           _tris[vi + 3] = _tris[vi + 2] = 1 + vi;
           _tris[vi + 5] = xSize + 2 + vi;
       }
       
       _mesh.vertices = _vertices;
        _mesh.triangles = _tris;
          GetComponent<MeshFilter>().mesh = _mesh;
        _mesh.name = "Procedural Mesh";
    }
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
