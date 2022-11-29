using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveLimit : MonoBehaviour
{
    private void Start()
    {
        CreateInvertedMeshCollider();
        //gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Istrue");
            gameObject.SetActive(true);
        }
    }

    public void CreateInvertedMeshCollider()
    {
        RemoveExistingColliders();

        InvertMesh();

        gameObject.AddComponent<MeshCollider>();
    }

    private void RemoveExistingColliders()
    {
        Collider[] colliders = GetComponents<Collider>();
        for (int i = 0; i < colliders.Length; i++)
            DestroyImmediate(colliders[i]);
    }

    private void InvertMesh()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }
}
