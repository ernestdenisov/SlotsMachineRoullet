using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySlot : MonoBehaviour
{
    [SerializeField] private SlotMotor slotMotor;

    private void OnTriggerStay2D(Collider2D collision)
    {
        var c = collision.GetComponent<Slot>();
        
        Destroy(c.gameObject);
        slotMotor.RemoveSlot(slotMotor.Slots.IndexOf(c));
    }
}
