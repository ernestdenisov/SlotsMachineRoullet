using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueController : MonoBehaviour
{
    [SerializeField] private float speed;
    /// <summary>
    /// ������������ � ����������� ��������
    /// </summary>
    [SerializeField] private float speedMax,speedMin;
    /// <summary>
    /// �����������
    /// </summary>
    [SerializeField] private float retarder;
    [SerializeField] private bool activeTape;
    public bool ActiveTape => activeTape;
    public delegate void DelegateStop();
    public event DelegateStop OnStopTape;
    private void Start()
    {
        speed = Random.Range(speedMin, speedMax);
    }

    /*
    если у тебя только 2 варианта развития событий например activeTape и !activeTape, то лучше
    использовать if (activeTape) {} else {}
    вместо if(activeTape) {} else if (!activeTape) {}
    */
    private void Update()
    {
        if (activeTape)
        {
           
            if (speed > 0)
            {
                speed -= Time.deltaTime * retarder;
            }
            else if (speed <= 0)
            {
                activeTape = false;
                
                OnStopTape();
            }
           
            transform.Rotate(0, 0, speed * Time.deltaTime);
            Time.timeScale = 5;
        }
        else if(!activeTape)
        {
            AudioManager.Instance.StopTapeWork();
            Time.timeScale = 1f;
            speed = 0;
        }
    }
    public void NewPlay()
    {
        AudioManager.Instance.PlayTapeWork();
        speed = Random.Range(speedMin, speedMax);
        activeTape = true;
    }
}
