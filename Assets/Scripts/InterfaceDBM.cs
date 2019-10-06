using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceDBM : MonoBehaviour
{
    private static List<string> cameraList;
    private List<float> upperColor1;
    private List<float> lowerColor1;
    private List<float> upperColor2;
    private List<float> lowerColor2;

    //Camera Functions---------------------------------------------------------------------
    public bool updateCameraList()
    {
        if (cameraList == null)
        {
            cameraList = new List<string>();
        }

        bool cameraAdded = false;
        WebCamDevice[] devices = WebCamTexture.devices;
        cameraList.Clear();
        for (int i = 0; i < devices.Length; i++)
        {
            cameraList.Add(devices[i].name);
            cameraAdded = true;
        }
        return cameraAdded;
    }
    public List<string> getCameraList()
    {
        updateCameraList();
        List<string> result = cameraList;
        return result;
    }
    //Colorspace Functions---------------------------------------------------------------------

    private bool constructColorSpace()
    {
        bool result = false;
        if (upperColor1 == null)
        {
            upperColor1 = new List<float>();
            upperColor1.Add(0);
            upperColor1.Add(0);
            upperColor1.Add(0);
            result = true;
        }
        if (lowerColor1 == null)
        {
            lowerColor1 = new List<float>();
            lowerColor1.Add(0);
            lowerColor1.Add(0);
            lowerColor1.Add(0);
            result = true;
        }
        if (upperColor2 == null)
        {
            upperColor2 = new List<float>();
            upperColor2.Add(0);
            upperColor2.Add(0);
            upperColor2.Add(0);
            result = true;
        }
        if (lowerColor2 == null)
        {
            lowerColor2 = new List<float>();
            lowerColor2.Add(0);
            lowerColor2.Add(0);
            lowerColor2.Add(0);
            result = true;
        }
        return result;
    }
    public bool setColorSpace(int camIdx, int colorIdx, int hue = -1, int sat = -1, int val = -1)
    {
        constructColorSpace();

        bool result = false;
        if(camIdx == 0)
        {
            if (colorIdx == 1)
            {
                if (hue > -1) upperColor1[0] = hue;
                if (sat > -1) upperColor1[1] = sat;
                if (val > -1) upperColor1[2] = val;
                result = true;
            }
            else if (colorIdx == 0)
            {
                if (hue > -1) lowerColor1[0] = hue;
                if (sat > -1) lowerColor1[1] = sat;
                if (val > -1) lowerColor1[2] = val;
                result = true;
            }
        }
        else if (camIdx == 1)
        {
            if (colorIdx == 1)
            {
                if (hue > -1) upperColor2[0] = hue;
                if (sat > -1) upperColor2[1] = sat;
                if (val > -1) upperColor2[2] = val;
                result = true;
            }
            else if (colorIdx == 0)
            {
                if (hue > -1) lowerColor2[0] = hue;
                if (sat > -1) lowerColor2[1] = sat;
                if (val > -1) lowerColor2[2] = val;
                result = true;
            }
        }
        return result;
    }
    public List<float> getColor(int camIdx, int colorIdx)
    {
        constructColorSpace();

        List<float> result = new List<float>();
        if(camIdx == 0)
        {
            if (colorIdx == 1)
            {
                result = upperColor1;
                return result;
            }
            else if (colorIdx == 0)
            {
                result = lowerColor1;
                return result;
            }
        }
        else if (camIdx == 1)
        {
            if (colorIdx == 1)
            {
                result = upperColor2;
                return result;
            }
            else if (colorIdx == 0)
            {
                result = lowerColor2;
                return result;
            }
        }
        return null;
    }
    public float getColorParam(int camIdx, int colorIdx, int hsvIdx)
    {
        constructColorSpace();
        float result = -1;
        if(camIdx == 0)
        {
            if (colorIdx == 1)
            {
                if (hsvIdx == 0) result = upperColor1[0];
                if (hsvIdx == 1) result = upperColor1[1];
                if (hsvIdx == 2) result = upperColor1[2];
            }
            else if (colorIdx == 0)
            {
                if (hsvIdx == 0) result = lowerColor1[0];
                if (hsvIdx == 1) result = lowerColor1[1];
                if (hsvIdx == 2) result = lowerColor1[2];
            }
        }
        else if (camIdx == 1)
        {
            if (colorIdx == 1)
            {
                if (hsvIdx == 0) result = upperColor2[0];
                if (hsvIdx == 1) result = upperColor2[1];
                if (hsvIdx == 2) result = upperColor2[2];
            }
            else if (colorIdx == 0)
            {
                if (hsvIdx == 0) result = lowerColor2[0];
                if (hsvIdx == 1) result = lowerColor2[1];
                if (hsvIdx == 2) result = lowerColor2[2];
            }
        }
        return result;
    }
}
