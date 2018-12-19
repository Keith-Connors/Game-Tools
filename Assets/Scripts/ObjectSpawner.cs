using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private string Tag;
    private ObjectPooling _objectPooling;

    private void Start()
    {
        _objectPooling = ObjectPooling.Instance;
        
    }


    private void FixedUpdate()
    {
        _objectPooling.SpawnFromPool("Cube", transform.position, transform.rotation);
    }
}
