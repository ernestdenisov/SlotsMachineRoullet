using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private SlotMotor slotMotor,slotMotor1,slotMotor2;
    [SerializeField] private Animator lever;
    [SerializeField] private bool activeSlotMachine;
    public bool ActiveSlotMachine => activeSlotMachine;
    [SerializeField] private float timer;
    private float startTimer;

    private void Start()
    {
        startTimer = timer;
    }
    private void Update()
    {
        if(timer < 0)
        {
            activeSlotMachine = false;
            AudioManager.Instance.PlayAudioSlotMachineWork();
        }
        if (activeSlotMachine)
        {
           
            timer -= Time.deltaTime;
            StartPlaySlotMachine();
           
        }
    }
    public void StartPlaySlotMachine()
    {
            slotMotor.SetActiveMotor(true);
            slotMotor1.SetActiveMotor(true);
            slotMotor2.SetActiveMotor(true);
    }
    public void AutoSpin()
    {
        lever.Play("@Lever");
        timer = startTimer;
        activeSlotMachine = true;
    }
}
