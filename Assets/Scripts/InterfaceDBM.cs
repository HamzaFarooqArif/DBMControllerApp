using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceDBM : MonoBehaviour
{
    private static List<KeyValuePair<int, string>> cameraList;
    private List<float> upperColor;
    private List<float> lowerColor;
    
    //Camera Functions---------------------------------------------------------------------
    public bool updateCameraList()
    {
        if (cameraList == null)
        {
            cameraList = new List<KeyValuePair<int, string>>();
        }

        bool cameraAdded = false;
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            cameraList.Add(new KeyValuePair<int, string>(i, devices[i].name));
            cameraAdded = true;
        }
        return cameraAdded;
    }
    public KeyValuePair<int, string> getCameraAtIndex(int idx)
    {
        if (idx > cameraList.Count - 1) return new KeyValuePair<int, string>(-1, null);
        if (idx < 0) return new KeyValuePair<int, string>(-1, null);

        KeyValuePair<int, string> result = new KeyValuePair<int, string>(cameraList[idx].Key, cameraList[idx].Value);

        return result;
    }
    //Colorspace Functions---------------------------------------------------------------------

    private bool constructColorSpace()
    {
        bool result = false;
        if (upperColor == null)
        {
            upperColor = new List<float>();
            upperColor.Add(0);
            upperColor.Add(0);
            upperColor.Add(0);
            result = true;
        }
        if (lowerColor == null)
        {
            lowerColor = new List<float>();
            lowerColor.Add(0);
            lowerColor.Add(0);
            lowerColor.Add(0);
            result = true;
        }
        return result;
    }
    public bool setColorSpace(int colorIdx, int hue = -1, int sat = -1, int val = -1)
    {
        constructColorSpace();

        bool result = false;
        
        if (colorIdx == 1)
        {
            if (hue > -1) upperColor[0] = hue;
            if (sat > -1) upperColor[1] = sat;
            if (val > -1) upperColor[2] = val;
            result = true;
        }
        else if (colorIdx == 0)
        {
            if (hue > -1) lowerColor[0] = hue;
            if (sat > -1) lowerColor[1] = sat;
            if (val > -1) lowerColor[2] = val;
            result = true;
        }
        
        return result;
    }
    public List<float> getColor(int colorIdx)
    {
        constructColorSpace();

        List<float> result = new List<float>();
        if (colorIdx == 1)
        {
            result = upperColor;
            return result;
        }
        else if (colorIdx == 0)
        {
            result = lowerColor;
            return result;
        }
        else return null;
    }
    public float getColorParam(int colorIdx, int hsvIdx)
    {
        constructColorSpace();
        float result = -1;
        if (colorIdx == 1)
        {
            if (hsvIdx == 0) result = upperColor[0];
            if (hsvIdx == 1) result = upperColor[1];
            if (hsvIdx == 2) result = upperColor[2];
        }
        else if (colorIdx == 0)
        {
            if (hsvIdx == 0) result = lowerColor[0];
            if (hsvIdx == 1) result = lowerColor[1];
            if (hsvIdx == 2) result = lowerColor[2];
        }
        
        return result;
    }
}
