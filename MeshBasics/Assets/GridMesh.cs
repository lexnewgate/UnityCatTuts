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
               await new WaitForSeconds(0.05f);
           } 
       }
       
       
//       _tris = new int[3];
       
       // grid cell 
       // p+(x+1) |         |p+1+(x+1) 
       //         |  m , n  |                p= (x+1)*n+m 
       //        p|         |p+1 
       
       
       
        
       
       
       
       
      
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
