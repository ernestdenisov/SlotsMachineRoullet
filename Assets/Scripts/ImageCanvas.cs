using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCanvas : MonoBehaviour
{
    [SerializeField] private float timeDestroy;
    private void Start()
    {
        Destroy(gameObject, timeDestroy);
    }
}
