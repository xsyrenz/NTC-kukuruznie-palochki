using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private KeyCode selectedButton;
    TextAlignment Text;
    // Start is called before the first frame update
    private void OnGUI()
    {
        if (Event.current.keyCode != KeyCode.None)
        {
            selectedButton= Event.current.keyCode;
        }
    }
    //public IEnumerator SetButton(GameObject button)
    //{

//    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
