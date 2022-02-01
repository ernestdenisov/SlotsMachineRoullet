using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueController : MonoBehaviour
{
    [SerializeField] private float speed;
    /// <summary>
    /// Максимальная и минимальная скорость
    /// </summary>
    [SerializeField] private float speedMax,speedMin;
    /// <summary>
    /// Замедлитель
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
