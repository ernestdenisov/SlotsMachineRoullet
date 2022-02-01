using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate : MonoBehaviour
{
    [SerializeField] private int index;
    public int Index => index;
    [SerializeField] private GeneralCalculate generalCalculate;
    [SerializeField] private SlotMotor slotMotor;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        slotMotor.SetActiveMotor(false);
        var c = collision.GetComponent<Slot>().Index;
        index = c;
        if (generalCalculate)
        {
            generalCalculate.CheckSlots();
        }
    }
}
