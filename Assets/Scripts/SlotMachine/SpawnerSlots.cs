using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSlots : Factory<Slot>
{
    [SerializeField]private SlotMotor slotMotor;
    [SerializeField] private float timer;
    private float startTimer;
    private void Awake()
    {
        startTimer = timer;
    }
    private void Update()
    {
        if (slotMotor.TimeActive > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                GetNewInstance();
                if (NewSlot.GetComponent<Slot>());
                {
                    slotMotor.AddListSlot(NewSlot);
                }
                timer = startTimer;
            }
        }
    }
}
