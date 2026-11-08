using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Item item;
    void Start()
    {
        InventoryManager.Instance.AddItem(item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
