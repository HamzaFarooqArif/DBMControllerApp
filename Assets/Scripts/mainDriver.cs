using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using UnityEngine.UI;
using System.Threading;
public class mainDriver : MonoBehaviour
{
    private InterfaceDBM interfaceDBM = null;
    Thread t1;
    Thread t2;

    //VideoCapture Capture1;

    //private VideoCapture _capture1 = null;
    void Start()
    {
        interfaceDBM = (InterfaceDBM)GameObject.Find("Driver").GetComponent(typeof(InterfaceDBM));
        CvInvoke.UseOpenCL = false;
        //t1 = new Thread(ProcessFrame1);
        //t2 = new Thread(ProcessFrame2);


        //Capture1 = new VideoCapture(0);

        //GameObject.Find("UpperChosenColor").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        //interfaceDBM.updateCameraList();
        //interfaceDBM.setColorSpace(0, 0, hue: 60, sat:255, val:255);
        //interfaceDBM.setColorSpace(0, 1, hue: 120, sat: 255, val: 255);

        //Debug.Log(interfaceDBM.getColorParam(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFrame1();
        ProcessFrame2();
    }

    private void ProcessFrame1()
    {
        
        if (interfaceDBM.Capture1 != null)
        {
            Image<Bgr, byte> frame1 = interfaceDBM.Capture1.QueryFrame().ToImage<Bgr, byte>();//interfaceDBM.Capture1.QueryFrame().ToImage<Bgr, byte>();
            Image<Bgr, Byte> frame1Copy = frame1.Clone();
            frame1Copy._SmoothGaussian(11);
            Image<Hsv, byte> frame1HSV = frame1Copy.Convert<Hsv, byte>();
            if (interfaceDBM.cam1Preview)
            {
                CvInvoke.Imshow("Frame1", frame1HSV);
            }
            else
            {
                CvInvoke.DestroyWindow("Frame1");
            }
        }
        
        

    }
    private void ProcessFrame2()
    {
        if (interfaceDBM.Capture2 != null)
        {
            Image<Bgr, byte> frame2 = interfaceDBM.Capture2.QueryFrame().ToImage<Bgr, byte>();
            Image<Bgr, Byte> frame2Copy = frame2.Clone();
            frame2Copy._SmoothGaussian(11);
            Image<Hsv, byte> frame2HSV = frame2Copy.Convert<Hsv, byte>();
            if (interfaceDBM.cam2Preview)
            {
                CvInvoke.Imshow("Frame2", frame2HSV);
            }
            else
            {
                CvInvoke.DestroyWindow("Frame2");
            }

        }
    }

    void OnApplicationQuit()
    {
        CvInvoke.DestroyAllWindows();
    }
}
