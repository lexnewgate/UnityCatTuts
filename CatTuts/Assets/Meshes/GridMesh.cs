using UnityEngine;

namespace Meshes
{
    public class GridMesh : MeshBase
    {


        private Vector3 []_verticesPos;

        void Start()
        {
            
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawSphere(Vector3.zero, 1);
        }

    }
}
