using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crosshair : MonoBehaviour
{
    [SerializeField] Slider horizontal;
    [SerializeField] Slider vertical;
    bool CalibrationMode = false;

    void Start()
    {
        CalibrationMode = true;
        float repeatRate = 0.1f; // Saniye başı çağırma hızı
        InvokeRepeating("UpdateWithInterval", 0f, repeatRate);
    }
    [SerializeField] GameObject ArEyes_L;
    [SerializeField] GameObject ArEyes_R;

    public float top = 0;
    public float bot = 0;
    public float right = 0;
    public float left = 0;
    public float LeftBot = 0;
    public float RightBot = 0;
    public float RightTop = 0;
    public float LeftTop = 0;
    public float RightLeftHalfTop = 0;
    public float RightLeftHalfBot = 0;
    public float LeftTopHalf = 0;
    public float LeftBotHalf = 0;
    public float RightBotHalf = 0;
    public float RightTopHalf = 0;
    public float MiddleY = 0;
    public float MiddleX = 0;
    public float RightTopBot = 0;
    public float LeftTopBot = 0;

    public GameObject[] CalibrationPos;

    int index = 0;
   
    private void UpdateWithInterval()
    {
        if (!CalibrationMode)
        {
            CalculateCrosshairPosition();
        }
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnButtonClick();
        }       
    }
    

    public void OnButtonClick()
    {
        if (index == 0)
        {
            top = ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].SetActive(false);
            index++;
            CalibrationPos[index].SetActive(true);
        }
        else if (index == 1)
        {
            bot = ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 2)
        {
            right = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 3)
        {
            left = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 4)
        {
            LeftBot = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 5)
        {
            LeftBotHalf = ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 6)
        {
            LeftTop = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 7)
        {
            LeftTopHalf = ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 8)
        {
            RightBot = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 9)
        {
            RightBotHalf = ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 10)
        {
            RightTopHalf = ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 11)
        {
            MiddleY = ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 12)
        {
            MiddleX = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 13)
        {
            LeftTopBot = ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 14)
        {
            RightTopBot = ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 15)
        {
            RightTop = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 16)
        {
            RightLeftHalfBot = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].SetActive(false); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 17)
        {
            RightLeftHalfTop = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].SetActive(false); index++;
        }
        else if (index >= 18)
        {
            CalibrationMode = false;

        }
    }

    void CalculateCrosshairPosition()
    {
        float NegativeOranX = 960 / left;
        var x = ArEyes_R.transform.localRotation.y * NegativeOranX;

        float NegativeOranY = 536 / bot;
        var y = ArEyes_R.transform.localRotation.x * NegativeOranY;


        float OranX = 960 / right;
        var w = ArEyes_R.transform.localRotation.y * OranX;

        float OranY = 536 / top;
        var k = ArEyes_R.transform.localRotation.x * OranY;

        //Sol
        if (ArEyes_R.transform.localRotation.y <= MiddleX)
        {
            Debug.Log("sol");

            //alt
            if (ArEyes_R.transform.localRotation.x >= MiddleY)
            {
                Debug.Log("solAlt");
                NegativeOranX = 960 / LeftBot;
                x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 536 / LeftBotHalf;
                y = ArEyes_R.transform.localRotation.x * NegativeOranY;

                ////sol alt sol
                //if (ArEyes_R.transform.localRotation.y <=LeftTopBot )
                //{
                //    OranX = 960 / RightLeftHalfBot;
                //    x = ArEyes_R.transform.localRotation.y * OranX;

                //    OranY = 536 / LeftTopBot;
                //    y = ArEyes_R.transform.localRotation.x * OranY;
                //}
                ////Sol alt sağ
                //else
                //{
                //    OranX = 960 / RightLeftHalfBot;
                //    x = ArEyes_R.transform.localRotation.y * OranX;

                //    OranY = 536 / LeftTopBot;
                //    y = ArEyes_R.transform.localRotation.x * OranY;

                //}

                transform.localPosition = new Vector3(-x, -y, transform.localPosition.z);
            }
            //üst
            else
            {
                Debug.Log("solÜst");
                NegativeOranX = 960 / LeftTop;
                x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 536 / LeftTopHalf;
                y = ArEyes_R.transform.localRotation.x * NegativeOranY;

                transform.localPosition = new Vector3(-x, y, transform.localPosition.z);
            }

        }
        //sağ
        else
        {
            Debug.Log("Sağ");
            //alt
            if (ArEyes_R.transform.localRotation.x >= MiddleY)
            {
                Debug.Log("SağAlt");
                NegativeOranX = 960 / RightBot;
                x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 536 / RightBotHalf;
                y = ArEyes_R.transform.localRotation.x * NegativeOranY;

                transform.localPosition = new Vector3(x, -y, transform.localPosition.z);
            }
            //üst
            else
            {
                Debug.Log("SağÜst");
                NegativeOranX = 960 / RightTop;
                x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 536 / RightTopHalf;
                y = ArEyes_R.transform.localRotation.x * NegativeOranY;

                transform.localPosition = new Vector3(x, y, transform.localPosition.z);
            }

            
        }
    }


    //public void ChangePos()
    //{
    //    transform.localPosition = new Vector3( horizontal.value, vertical.value);
    //}
}
