using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button[] actionButtons;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            ActionButtonOnClick(0);
        }
        if(Keyboard.current.numpad2Key.wasPressedThisFrame)
        {
            ActionButtonOnClick(1);
        }
        if(Keyboard.current.numpad2Key.wasPressedThisFrame)
        {
            ActionButtonOnClick(2);
        }
    }
    
    private void ActionButtonOnClick(int btnIndex)
    {
        actionButtons[btnIndex].onClick.Invoke();
    }
}
