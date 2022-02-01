using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform pointToSpawn;
    [SerializeField] private Transform positionParent;
    [SerializeField] private T[] prefab;
    [SerializeField] private T newSlot;
    public T NewSlot => newSlot;
    public T GetNewInstance()
    {
        Vector3 pos = new Vector3(pointToSpawn.position.x, pointToSpawn.position.y,
            pointToSpawn.position.z);
        newSlot = Instantiate(prefab[Random.Range(0,prefab.Length)], pos, Quaternion.identity, positionParent);
        return newSlot;
    }
}
