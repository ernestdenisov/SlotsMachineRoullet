using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    [SerializeField] private AudioSource slotMachineWork,tapeWork,winAudio,loseAudio;
    
    public void PlayAudioSlotMachineWork()
    {
        slotMachineWork.Play();
    }
    public void StopAudioSlotMachine()
    {
        slotMachineWork.Stop();
    }
    public void PlayTapeWork()
    {
        tapeWork.Play();
    }
    public void StopTapeWork()
    {
        tapeWork.Stop();
    }
    public void WinAudio()
    {
        winAudio.Play();
    }
    public void LoseAudio()
    {
        loseAudio.Play();
    }
}
