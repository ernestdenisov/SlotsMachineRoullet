using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    [SerializeField] private SlotMachine slotMachine;
    [SerializeField] private TorqueController torqueController;
    [SerializeField] private Button autoSpin, maxBet, minus, plus;

    /*
    может лучше сделать метод

    private void changeInteractivity(bool flag) {
        autoSpin.interactable = flag;
        maxBet.interactable = flag;
        minus.interactable = flag;
        plus.interactable = flag;
    }

    ещё вариант, создать массив с элементами, которым надо обновить интерактивность

    Button[] buttons = new Button[] {autoSpin, maxBet, minus, plus}
    private void changeInteractivity(bool flag) {
        foreach (Button btn in buttons) {
            btn.interactable = flag;
        }
    }

    дальше код можно уменьшить до

    private void Update()
    {
        if (slotMachine)
        {
            if (slotMachine.ActiveSlotMachine)
            {
                changeInteractivity(false);
            }
            if (!slotMachine.ActiveSlotMachine)
            {
                changeInteractivity(true);
            }
        }
        if (torqueController)
        {
            if (torqueController.ActiveTape)
            {
                changeInteractivity(false);
            }
            if (!torqueController.ActiveTape)
            {
                changeInteractivity(true);
            }
        }
    }

    или

    private void Update()
    {
        if (slotMachine)
        {
            const bool flag = slotMachine.ActiveSlotMachine ? false : true;
            changeInteractivity(flag);
        }
        if (torqueController)
        {
            const bool flag = itorqueController.ActiveTape ? false : true;
            changeInteractivity(flag);
        }
    }

    или

    private void Update()
    {
        if (slotMachine || torqueController)
        {
            var bool flag = slotMachine.ActiveSlotMachine ? false : true;
            changeInteractivity(flag);
        }
    }
    */
    private void Update()
    {
        if (slotMachine)
        {
            if (slotMachine.ActiveSlotMachine)
            {
                autoSpin.interactable = false;
                maxBet.interactable = false;
                minus.interactable = false;
                plus.interactable = false;
            }
            if (!slotMachine.ActiveSlotMachine)
            {
                autoSpin.interactable = true;
                maxBet.interactable = true;
                minus.interactable = true;
                plus.interactable = true;
            }
        }
        if(torqueController)
        {
            if(torqueController.ActiveTape)
            {
                autoSpin.interactable = false;
                maxBet.interactable = false;
                minus.interactable = false;
                plus.interactable = false;
            }
            if(!torqueController.ActiveTape)
            {
                autoSpin.interactable = true;
                maxBet.interactable = true;
                minus.interactable = true;
                plus.interactable = true;
            }
        }
    }
}
