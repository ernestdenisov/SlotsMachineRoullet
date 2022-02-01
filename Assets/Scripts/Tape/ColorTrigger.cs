using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    [SerializeField] private string color;
    [SerializeField] private Chip chip;
    private Vector3 startPos;

    private void Start()
    {
        startPos = chip.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        chip.SetColor(color);
        StartCoroutine(CorStartPos());
    }
    IEnumerator CorStartPos()
    {
        yield return new WaitForSeconds(3f);
        chip.transform.position = startPos;
    }
}
