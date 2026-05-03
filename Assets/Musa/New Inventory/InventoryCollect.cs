using UnityEngine;
using UnityEngine.UI;
public class InventoryCollect : MonoBehaviour
{
    public GameObject inventoryUI, slotPanel_1,slotPanel_2,slotPanel_3; // Reference to the inventory UI GameObject
    public int itemCount = 0; // Counter to track the number of items collected
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInventoryUI();
    }

   
    void UpdateInventoryUI()
    {
        if(itemCount>=1)
        {
            inventoryUI.SetActive(true);
            slotPanel_2.SetActive(true);
               if(itemCount==1)
                {
                    slotPanel_2.SetActive(true);
                }
                if(itemCount==2)
                {
                    slotPanel_3.SetActive(true);
                }
                if(itemCount==3)
                {
                    slotPanel_3.SetActive(true);
                }
        }
              
            
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            Debug.Log("Interacting with Item!");
            itemCount++; 
            Destroy(other.gameObject); // Destroy the item after collecting it
            
        }
    }


}
    
    
    






