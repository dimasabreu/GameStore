using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] private Sprite icon;

    [SerializeField] private int stackSize;

    private SlotScript slot;

    public Sprite Icon { 
        get => icon; 
    }
    public int StackSize { 
        get => stackSize; 
        }
    protected SlotScript Slot 
    { 
        get => slot; 
        set => slot = value; 
    }
}
