using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : SingletonBase<LevelManager>
{
    [SerializeField] private Chip chip;
    [SerializeField] private TorqueController tape;
    [SerializeField] private Pointer pointer;
    [SerializeField] private Camera camera;

    private Vector3 posStartCam;
    public Vector3 cameraStartPos => posStartCam;
    private void Start()
    {
        posStartCam = camera.transform.position;
        chip.OnSelectIndex += Chip_OnSelectIndex;
        tape.OnStopTape += Tape_OnStopTape;
    }

    private void Tape_OnStopTape()
    {
        pointer.CalculateScore();

        /*
        лучше написать

        if (chip.chipIndex == pointer.Index)
        {
            Wallet.Instance.WinCash(Wallet.Instance.Bet * 5);
        }
        else if (pointer.Colot == chip.ColorChip)
        {
            print("������");
            Wallet.Instance.WinCash(Wallet.Instance.Bet * 2);
        }
        else
        {
            Wallet.Instance.LoseCash();
            print("���������");
        }
        */
        if(chip.chipIndex == pointer.Index || pointer.Colot == chip.ColorChip)
        {
            if (pointer.Colot == chip.ColorChip)
            {
                print("������");
                Wallet.Instance.WinCash(Wallet.Instance.Bet * 2);
            }
            if(chip.chipIndex == pointer.Index)
            {
                Wallet.Instance.WinCash(Wallet.Instance.Bet * 5);
            }
        }
        else
        {
            Wallet.Instance.LoseCash();
            print("���������");
        }
        
        StartCoroutine(CorStopTape());
    }
    IEnumerator CorStopTape()
    {
        yield return new WaitForSeconds(1f);
        camera.transform.position = posStartCam;
        chip.enabled = true;
    }
    private void Chip_OnSelectIndex()
    {
        tape.NewPlay();
        StartCoroutine(CorCameraAndChip());
    }
    IEnumerator CorCameraAndChip()
    {
        yield return new WaitForSeconds(1f);
        chip.enabled = false;
        camera.transform.position = new Vector3(tape.transform.position.x + 2, tape.transform.position.y, camera.transform.position.z);
    }
}
