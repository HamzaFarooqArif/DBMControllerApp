using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChosenColorScript : MonoBehaviour
{
    private InterfaceDBM interfaceDBM = null;
    void Start()
    {
        interfaceDBM = (InterfaceDBM)GameObject.Find("Driver").GetComponent(typeof(InterfaceDBM));
    }

    // Update is called once per frame
    void Update()
    {
        List<float> hsv = null;
        if (transform.parent.name.Equals("ColorPickerUpper1"))
        {
            hsv = interfaceDBM.getColor(0, 1);
        }
        else if(transform.parent.name.Equals("ColorPickerLower1"))
        {
            hsv = interfaceDBM.getColor(0, 0);
        }
        else if (transform.parent.name.Equals("ColorPickerUpper2"))
        {
            hsv = interfaceDBM.getColor(1, 1);
        }
        else if (transform.parent.name.Equals("ColorPickerLower2"))
        {
            hsv = interfaceDBM.getColor(1, 0);
        }
        if (hsv != null)
        {
            Color clr = Color.HSVToRGB(hsv[0] / 255, hsv[1] / 255, hsv[2] / 255);
            this.gameObject.GetComponent<Image>().color = clr;
        }
        
    }
}
