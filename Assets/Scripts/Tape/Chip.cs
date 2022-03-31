using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    [SerializeField] private int indexChip;
    [SerializeField] private string color;
    public string ColorChip => color;
    public int chipIndex => indexChip;
    public delegate void OnSelectChipIndex();
    public event OnSelectChipIndex OnSelectIndex;
   
    private void Update()
    {
        /*
        лучше перенос длинных строк делать так:

        var screenPoint
            = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

        или

        var screenPoint = new Vector3(
            Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z
        );
                
        или

        var screenPoint = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            -Camera.main.transform.position.z
        );

        но может в СиРешётке другой стиль переноса, но мне последние 2 варианта кажутся максимально читабельными
        */
        var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                  -Camera.main.transform.position.z);
        screenPoint = Camera.main.ScreenToWorldPoint(screenPoint);

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.transform.position = screenPoint;
        }
    }
    public void SetColor(string col)
    {
        OnSelectIndex();
        color = col;
    }
    public void SetIndex(int newIndexChip)
    {
        OnSelectIndex();
        indexChip = newIndexChip;
    }
}
