using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryScript : MonoBehaviour
{
    private int openBags = 0;
    private int countBags = 0;
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

    
    [SerializeField] private BagButton[] bagButtons;
    //for debug
    [SerializeField] private Item[] items;

    public bool CanAddBag
    {
        get
        {
            return bags.Count < 4;
        }
    }
    private void Awake() 
    {
        Bag bag = (Bag)Instantiate(items[0]);
        bag.Initialize(16);
        bag.Use();
    }

    private void Update() {
        
        bool isJKeyPress = Keyboard.current.jKey.isPressed;
        if(isJKeyPress)
        {
            countBags += 1;
            if(countBags == 1)
            {
                Bag bag = (Bag)Instantiate(items[0]);
                bag.Initialize(16);
                bag.Use();
            }
        }
        else
        {
            countBags = 0;
        }

        bool isBKeyPress = Keyboard.current.bKey.isPressed;
        {
            if (isBKeyPress)
            {
                openBags += 1;
                if(openBags == 1)
                {
                    InventoryScript.MyInstance.OpenClose();
                }
            }
            else
            {
                openBags = 0;
            }
            
        }
    }
    
        
    
    
    public void AddBag(Bag bag)
    {
        foreach (BagButton bagButton in bagButtons)
        {
            if(bagButton.MyBag == null)
            {
                bagButton.MyBag = bag;
                bags.Add(bag);
                break;
            }
        }
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
