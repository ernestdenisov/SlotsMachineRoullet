using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexTable : MonoBehaviour
{
    [SerializeField] private Chip chip;
    [SerializeField] private int index;

    public int Index => index;
    private Vector3 startPos;
    private void Start()
    {
        startPos = chip.transform.position;
        index = Int32.Parse (gameObject.name);
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        chip.SetIndex(index);
        StartCoroutine(CorStartPos());
    }
    IEnumerator CorStartPos()
    {
        yield return new WaitForSeconds(3f);
        chip.transform.position = startPos;
    }
}
