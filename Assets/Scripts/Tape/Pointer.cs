using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pointer : MonoBehaviour
{
    [System.Serializable] public class Cell
    {
       public Vector2 range;
        public int bonus;
        public string colorCell;

    }
    [SerializeField] private int index;
    public int Index => index;
    [SerializeField] private string color;
    public string Colot => color;
    [SerializeField] private TorqueController tape;
    [SerializeField] private List<Cell> cells;
    //[SerializeField] private List <Pointer> pointers;
    [Header("Dinamically in Inspector")]


    [SerializeField] private float angularZ;
    /// <summary>
    /// ����� ������� � ������� ����� 36
    /// </summary>
    private int lenght;
    

    public delegate void DelegateCalculateScore();
    public event DelegateCalculateScore OnCalculate;
    
    private void Awake()
    {
        lenght = 360 / cells.Count;
        
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].range = new Vector2( i * lenght, (i + 1) * lenght);
        }
    }
    private void Start()
    {
        OnCalculate += CalculateScore;
    }
    private void Update()
    {
        angularZ = tape.transform.eulerAngles.z;
       
        if(!tape.ActiveTape)
        {
            OnCalculate();
        }
    }
    public void CalculateScore()
    {
        foreach (var c in cells)
        {
            if(c.range.x < angularZ && c.range.y > angularZ) // сильно этот и следующий if отличаются?))
            {
                color = c.colorCell;
            }
            if(c.range.x < angularZ && c.range.y > angularZ)
            {
                index = c.bonus;
                break;
            }
        }
    }
}
