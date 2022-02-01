using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMotor : MonoBehaviour
{
    [SerializeField] private bool active;
    public bool Active => active;
    [SerializeField] private List <Slot> slots;
    [SerializeField] private SpawnerSlots spawnerSlots;
    public List<Slot> Slots => slots;
    [SerializeField] private float speed;
    [SerializeField] private float timeActive;
    public float TimeActive => timeActive;
    private float timeNewActive;
   
    void Update()
    {
        if (active)
        {
            spawnerSlots.enabled = true;
            Time.timeScale = 4F;
            foreach (var slot in slots)
            {
                slot.transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
        else if (!active)
        {
            spawnerSlots.enabled = false;
            Time.timeScale = 1;
        }
    }
    /// <summary>
    /// Добавить новый созданный слот в список
    /// </summary>
    /// <param name="slot"></param>
    public void AddListSlot(Slot slot)
    {
        slots.Add(slot);
    }

    /// <summary>
    /// Удалить слот из списка
    /// </summary>
    /// <param name="index"></param>
    public void RemoveSlot(int index)
    {
        slots.RemoveAt(index);
    }
    /// <summary>
    /// сделать машину активной или не активной
    /// </summary>
    /// <param name="a"></param>
    public void SetActiveMotor(bool a)
    {
        active = a;
    }
}
