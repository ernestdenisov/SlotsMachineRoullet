using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    [SerializeField] private SlotMachine slotMachine;
    [SerializeField] private TorqueController torqueController;
    [SerializeField] private Button autoSpin, maxBet, minus, plus;
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
