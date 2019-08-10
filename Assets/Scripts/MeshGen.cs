﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour
{

    public GameObject protoObject;
    public Material defaultMaterial;
    private Dictionary<string, Mesh> meshes;

    // Start is called before the first frame update
    public virtual void Start()
    {
        meshes = new Dictionary<string, Mesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Mesh GetCachedMesh(string key)
    {
        if(meshes.ContainsKey(key))
        {
            return meshes[key];
        } else
        {
            return null;
        }
    }

    public Mesh CacheMesh(string key, Mesh mesh)
    {
        meshes[key] = mesh;
        return mesh;
    }

    public GameObject GetObject(Mesh mesh, Transform parent, Material material)
    {
        GameObject obj = GameObject.Instantiate(protoObject, parent);
        obj.GetComponent<MeshFilter>().mesh = mesh;
        obj.GetComponent<MeshRenderer>().material = material;

        MeshCollider collider = obj.GetComponent<MeshCollider>();
        if(collider != null)
        {
            collider.sharedMesh = mesh;
        }
        return obj;
    }
}
