using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crosshair : MonoBehaviour
{
    public float movementThreshold = 25.0f;
    float detectionInterval = 0.2f;
    float smoothTime = 0.1f;

    float lastDetectionTime = 0;

    Vector3 lastPosition;
    Vector3 targetPosition;
    Vector3 velocity;

    bool CalibrationMode = false;


    void Start()
    {
        CalibrationMode = true;
        float repeatRate = 0.1f; // Saniye başı çağırma hızı
        InvokeRepeating("UpdateWithInterval", 0f, repeatRate);
        lastPosition = transform.localPosition;
        targetPosition = lastPosition;
        velocity = Vector3.zero;
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
            top = -ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = top.ToString();
            index++;
            CalibrationPos[index].SetActive(true);
        }
        else if (index == 1)
        {
            bot = -ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = bot.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 2)
        {
            right = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = right.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 3)
        {
            left = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = left.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 4)
        {
            LeftBot = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = LeftBot.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 5)
        {
            LeftBotHalf = -ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = LeftBotHalf.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 6)
        {
            LeftTop = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = LeftTop.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 7)
        {
            LeftTopHalf = -ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = LeftTopHalf.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 8)
        {
            RightBot = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightBot.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 9)
        {
            RightBotHalf = -ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightBotHalf.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 10)
        {
            RightTopHalf = -ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightTopHalf.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 11)
        {
            MiddleY = -ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = MiddleY.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 12)
        {
            MiddleX = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = MiddleX.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 13)
        {
            LeftTopBot = -ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = LeftTopBot.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 14)
        {
            RightTopBot = -ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightTopBot.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 15)
        {
            RightTop = ArEyes_R.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightTop.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 16)
        {
            RightLeftHalfBot = -ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightLeftHalfBot.ToString();index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 17)
        {
            RightLeftHalfTop = -ArEyes_R.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightLeftHalfTop.ToString();index++;
        }
        else if (index >= 18)
        {
            CalibrationMode = false;

        }
    }

    void CalculateCrosshairPosition()
    {
        if (Time.time - lastDetectionTime >= detectionInterval)
        {
            float NegativeOranX = 110 / left;
        var x = ArEyes_R.transform.localRotation.y * NegativeOranX;

        float NegativeOranY = 100 / bot;
        var y = -ArEyes_R.transform.localRotation.x * NegativeOranY;


        float OranX = 110 / right;
        var w = ArEyes_R.transform.localRotation.y * OranX;

        float OranY = 100 / top;
        var k = -ArEyes_R.transform.localRotation.x * OranY;

        //orta
        if ((ArEyes_R.transform.localRotation.y <= RightTopBot && ArEyes_R.transform.localRotation.y >= LeftTopBot) && (-ArEyes_R.transform.localRotation.x <= RightLeftHalfBot && -ArEyes_R.transform.localRotation.x >= RightLeftHalfTop))
        {
            Debug.Log("orta");
            //orta sol
            if (ArEyes_R.transform.localRotation.y <= MiddleX)
            {
                //orta üst
                if (-ArEyes_R.transform.localRotation.x <= RightLeftHalfTop && -ArEyes_R.transform.localRotation.x >= MiddleY)
                {
                    Debug.Log("orta Sol Üst");
                    NegativeOranX = 55 / LeftTop;
                    x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                    NegativeOranY = 50 / LeftTopHalf;
                    y = ArEyes_R.transform.localRotation.x * NegativeOranY;
                    x = Mathf.Clamp(x, 0, 55);
                    y = Mathf.Clamp(y, 0, 50);
                    if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                    {

                        targetPosition = new Vector3(-x, -y, transform.localPosition.z);
                        lastDetectionTime = Time.time;
                    }
                    transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
                    lastPosition = transform.localPosition;
                }
                //orta alt
                else if (-ArEyes_R.transform.localRotation.x >= RightLeftHalfBot && -ArEyes_R.transform.localRotation.x <= MiddleY)
                {
                    Debug.Log("orta sol alt");
                    NegativeOranX = 55 / LeftTop;
                    x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                    NegativeOranY = 50 / LeftTopHalf;
                    y = ArEyes_R.transform.localRotation.x * NegativeOranY;
                    x = Mathf.Clamp(x, 0, 55);
                    y = Mathf.Clamp(y, 0, 50);
                    if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                    {

                        targetPosition = new Vector3(-x, y, transform.localPosition.z);
                        lastDetectionTime = Time.time;
                    }
                    transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
                    lastPosition = transform.localPosition;
                }

            }
            //orta sağ
            else
            {
                //orta üst
                if (-ArEyes_R.transform.localRotation.x <= RightLeftHalfTop && -ArEyes_R.transform.localRotation.x >= MiddleY)
                {
                    Debug.Log("orta sağ üst");
                    NegativeOranX = 55 / LeftTop;
                    x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                    NegativeOranY = 50 / LeftTopHalf;
                    y = ArEyes_R.transform.localRotation.x * NegativeOranY;
                    x = Mathf.Clamp(x, 0, 55);
                    y = Mathf.Clamp(y, 0, 50);
                    if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                    {

                        targetPosition = new Vector3(x, -y, transform.localPosition.z);
                        lastDetectionTime = Time.time;
                    }
                    transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
                    lastPosition = transform.localPosition;
                }
                //orta alt
                else if (-ArEyes_R.transform.localRotation.x >= RightLeftHalfBot && -ArEyes_R.transform.localRotation.x <= MiddleY)
                {
                    Debug.Log("orta sağ alt");
                    NegativeOranX = 55 / LeftTop;
                    x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                    NegativeOranY = 50 / LeftTopHalf;
                    y = ArEyes_R.transform.localRotation.x * NegativeOranY;
                    x = Mathf.Clamp(x, 0, 55);
                    y = Mathf.Clamp(y, 0, 50);
                    if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                    {

                        targetPosition = new Vector3(x, -y, transform.localPosition.z);
                        lastDetectionTime = Time.time;
                    }
                    transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
                    lastPosition = transform.localPosition;
                }
            }


        }
        //Sol
        else
        if (ArEyes_R.transform.localRotation.y <= MiddleX)
        {
            Debug.Log("sol");


            //alt
            if (-ArEyes_R.transform.localRotation.x >= MiddleY)
            {
                Debug.Log("solAlt");
                NegativeOranX = 110 / LeftBot;
                x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 100 / LeftBotHalf;
                y = ArEyes_R.transform.localRotation.x * NegativeOranY;
                x = Mathf.Clamp(x, 0, 110);
                y = Mathf.Clamp(y, 0, 100);
                if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                {

                    targetPosition = new Vector3(-x, y, transform.localPosition.z);
                    lastDetectionTime = Time.time;
                }
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
                lastPosition = transform.localPosition;
            }
            //üst
            else
            {
                Debug.Log("solÜst");
                NegativeOranX = 110 / LeftTop;
                x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 100 / LeftTopHalf;
                y = ArEyes_R.transform.localRotation.x * NegativeOranY;
                x = Mathf.Clamp(x, 0, 110);
                y = Mathf.Clamp(y, 0, 100);
                if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                {

                    targetPosition = new Vector3(-x, -y, transform.localPosition.z);
                    lastDetectionTime = Time.time;
                }
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
                lastPosition = transform.localPosition;
            }

        }
        //sağ
        else
        {
            Debug.Log("Sağ");
            //alt
            if (-ArEyes_R.transform.localRotation.x >= MiddleY)
            {
                Debug.Log("SağAlt");
                NegativeOranX = 110 / RightBot;
                x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 100 / RightBotHalf;
                y = ArEyes_R.transform.localRotation.x * NegativeOranY;
                x = Mathf.Clamp(x, 0, 110);
                y = Mathf.Clamp(y, 0, 100);
                if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                {

                    targetPosition = new Vector3(x, y, transform.localPosition.z);
                    lastDetectionTime = Time.time;
                }
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
                lastPosition = transform.localPosition;
            }
            //üst
            else
            {
                Debug.Log("SağÜst");
                NegativeOranX = 110 / RightTop;
                x = ArEyes_R.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 100 / RightTopHalf;
                y = ArEyes_R.transform.localRotation.x * NegativeOranY;
                x = Mathf.Clamp(x, 0, 110);
                y = Mathf.Clamp(y, 0, 100);

                if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                {
                    targetPosition = new Vector3(x, -y, transform.localPosition.z);
                    lastDetectionTime = Time.time;
                }
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
                lastPosition = transform.localPosition;
            }


        }

        }
    }
   
}
