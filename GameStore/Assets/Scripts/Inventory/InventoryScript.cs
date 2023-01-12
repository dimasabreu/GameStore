using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private static InventoryScript instance;
    private List<Bag> bags = new List<Bag>();

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

    public void OpenClose()
    {
        bool closedBag = bags.Find(x => !x.MyBagScript.IsOPen);

        foreach (Bag bag in bags)
        {
            if (bag.MyBagScript.IsOPen != closedBag)
            {
                bag.MyBagScript.OpenClose();
            }
        }
    }

}
