using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxScript : MonoBehaviour
{
    private InterfaceDBM interfaceDBM = null;
    private InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        interfaceDBM = (InterfaceDBM)GameObject.Find("Driver").GetComponent(typeof(InterfaceDBM));
        inputField = this.gameObject.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.parent.parent.name.Equals("ColorPickerUpper1"))
        {
            List<float> clr = interfaceDBM.getColor(0, 1);
            string hueVal = clr[0].ToString();
            string satVal = clr[1].ToString();
            string valVal = clr[2].ToString();
            if (this.transform.name.Equals("HueValue"))
            {
                inputField.text = hueVal;
            }
            else if (this.transform.name.Equals("SaturationValue"))
            {
                inputField.text = satVal;
            }
            else if (this.transform.name.Equals("LightnessValue"))
            {
                inputField.text = valVal;
            }
        }
        else if (this.transform.parent.parent.name.Equals("ColorPickerLower1"))
        {
            List<float> clr = interfaceDBM.getColor(0, 0);
            string hueVal = clr[0].ToString();
            string satVal = clr[1].ToString();
            string valVal = clr[2].ToString();
            if (this.transform.name.Equals("HueValue"))
            {
                inputField.text = hueVal;
            }
            else if (this.transform.name.Equals("SaturationValue"))
            {
                inputField.text = satVal;
            }
            else if (this.transform.name.Equals("LightnessValue"))
            {
                inputField.text = valVal;
            }
        }
        if (this.transform.parent.parent.name.Equals("ColorPickerUpper2"))
        {
            List<float> clr = interfaceDBM.getColor(1, 1);
            string hueVal = clr[0].ToString();
            string satVal = clr[1].ToString();
            string valVal = clr[2].ToString();
            if (this.transform.name.Equals("HueValue"))
            {
                inputField.text = hueVal;
            }
            else if (this.transform.name.Equals("SaturationValue"))
            {
                inputField.text = satVal;
            }
            else if (this.transform.name.Equals("LightnessValue"))
            {
                inputField.text = valVal;
            }
        }
        else if (this.transform.parent.parent.name.Equals("ColorPickerLower2"))
        {
            List<float> clr = interfaceDBM.getColor(1, 0);
            string hueVal = clr[0].ToString();
            string satVal = clr[1].ToString();
            string valVal = clr[2].ToString();
            if (this.transform.name.Equals("HueValue"))
            {
                inputField.text = hueVal;
            }
            else if (this.transform.name.Equals("SaturationValue"))
            {
                inputField.text = satVal;
            }
            else if (this.transform.name.Equals("LightnessValue"))
            {
                inputField.text = valVal;
            }
        }
    }
}
