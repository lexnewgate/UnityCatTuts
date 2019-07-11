using UnityEngine;

namespace Meshes.Demos.GridMesh
{
    public class App : MonoBehaviour
    {
        public int xSize;
        public int ySize;
        void Start()
        {
             var gridMeshGo=new GameObject("GridMesh");
             gridMeshGo.AddComponent<Meshes.GridMesh>();
        }

        void Update()
        {
        
        }
    }
}
