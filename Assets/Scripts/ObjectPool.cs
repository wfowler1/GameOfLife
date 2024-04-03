using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [NonSerialized] public GameObject poolObject;

    private Stack<GameObject> pool = new Stack<GameObject>();


    public GameObject GetObject()
    {
        if (pool.Count > 0)
        {
            GameObject go = pool.Pop();
            go.isStatic = false;
            go.SetActive(true);
            return go;
        }

        return Instantiate(poolObject, transform);
    }

    public void PoolObject(GameObject go)
    {
        pool.Push(go);
        go.SetActive(false);
    }

    public void Flush()
    {
        pool.Clear();
    }
}
