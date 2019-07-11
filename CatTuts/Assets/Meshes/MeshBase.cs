using UnityEngine;

namespace Meshes
{
    public class MeshBase : MonoBehaviour
    {
        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;
        private void Awake()
        {
            _meshFilter = AddEssentialComponent<MeshFilter>();//hold mesh
            _meshRenderer = AddEssentialComponent<MeshRenderer>();//configure how to render
        }

        TComponent AddEssentialComponent<TComponent>() where  TComponent: Component
        {
            var component = GetComponent<TComponent>();
            if (component == null)
            {
                component = gameObject.AddComponent<TComponent>();
            }
            return component;
        }
    }
}
