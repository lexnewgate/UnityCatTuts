using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class CreateSpace : MonoBehaviour
{
    public int dimension;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                for (int k = 0; k < dimension; k++)
                {
                   CreateElement(i,j,k); 
                }
            }
        }
    }

    void CreateElement(int i,int j,int k)
    {
        var element = Object.Instantiate(prefab);
        element.transform.position = GetCoordinate(i, j, k);
        element.GetComponent<MeshRenderer>().material.color= new Color((float)i/dimension,(float)j/dimension,(float)k/dimension);
    }

    Vector3 GetCoordinate(int i,int j,int k)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
