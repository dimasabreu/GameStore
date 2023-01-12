using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private static InventoryScript instance;

    public static InventoryScript MyInstance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<InventoryScript>();
            }
            return instance;
        }
    }
    //for debug
    [SerializeField] private Item[] items;

    private void Awake() 
    {
        Bag bag = (Bag)Instantiate(items[0]);
        bag.Initialize(16);
        bag.Use();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
