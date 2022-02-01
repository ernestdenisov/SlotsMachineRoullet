using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCalculate : MonoBehaviour
{
    [SerializeField] private Calculate calculate1,calculate2,calculate3;
    [SerializeField] private SlotMotor slotMotor;
    [SerializeField] private SlotMachine slotMachine;
    public SlotMotor GetSlotMotor => slotMotor;
    

    private void Update()
    {
        if(slotMotor.Active)
        {
            
        }
        else if(!slotMotor.Active)
        {
           
        }
    }
    /// <summary>
    /// Сравниваем индексы слотов
    /// </summary>
    public void CheckSlots()
    {
        if (slotMachine.ActiveSlotMachine == false)
        {
            if (calculate1.Index == calculate2.Index && calculate1.Index == calculate3.Index)
            {
                print("выиграли");
                switch(calculate1.Index)
                {
                    case 0:
                        Wallet.Instance.WinCash(100);
                        break;
                    case 1:
                        Wallet.Instance.WinCash(200);
                        break;
                    case 2:
                        Wallet.Instance.WinCash(300);
                        break;
                    case 3:
                        Wallet.Instance.WinCash(500);
                        break;
                    case 4:
                        Wallet.Instance.WinCash(1000);
                        break;
                    case 5:
                        Wallet.Instance.WinCash(2500);
                        break;
                }
            }
            else
            {
                Wallet.Instance.LoseCash();
            }
        }
    }
}
