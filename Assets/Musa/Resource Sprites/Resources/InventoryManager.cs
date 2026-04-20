using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotsHolder;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;

    public List<ItemClass> items = new List<ItemClass>();

    private GameObject[] slots; 
    public void Start()
    {
        slots = new GameObject[slotsHolder.transform.childCount];
        //set all the slots
        for (int i = 0; i < slotsHolder.transform.childCount; i++)
            slots[i] = slotsHolder.transform.GetChild(i).gameObject;

        ReFreshUI();

        Add(itemToAdd);
        Remove(itemToRemove);
    }

    public void ReFreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Image img = slots[i].transform.GetChild(0).GetComponent<Image>();
            
             if (i < items.Count && items[i] != null)
            {
                img.enabled = true;
                img.sprite = items[i].itemIcon;
            }
            else
            {
                img.sprite=null;
                img.enabled = false;
            }
        }
    }
    public void Add(ItemClass item)
    {    
         items.Add(item);
        ReFreshUI();
    }

    public void Remove(ItemClass item)
    {
        items.Remove(item);
        ReFreshUI();
    }
    public void SelectSlot(int index)
    {
        Debug.Log("Clicked slot:" + index);
    }
}
