using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadCrosshair : MonoBehaviour
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
    [SerializeField] GameObject Head;

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
            top = Head.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = top.ToString();
            index++;
            CalibrationPos[index].SetActive(true);
        }
        else if (index == 1)
        {
            bot = Head.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = bot.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 2)
        {
            right = Head.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = right.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 3)
        {
            left = Head.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = left.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 4)
        {
            LeftBot = Head.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = LeftBot.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 5)
        {
            LeftBotHalf = Head.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = LeftBotHalf.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 6)
        {
            LeftTop = Head.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = LeftTop.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 7)
        {
            LeftTopHalf = Head.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = LeftTopHalf.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 8)
        {
            RightBot = Head.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightBot.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 9)
        {
            RightBotHalf = Head.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightBotHalf.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 10)
        {
            RightTopHalf = Head.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightTopHalf.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 11)
        {
            MiddleY = Head.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = MiddleY.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 12)
        {
            MiddleX = Head.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = MiddleX.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 13)
        {
            LeftTopBot = Head.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = LeftTopBot.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 14)
        {
            RightTopBot = Head.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightTopBot.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 15)
        {
            RightTop = Head.transform.localRotation.y;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightTop.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 16)
        {
            RightLeftHalfBot = Head.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightLeftHalfBot.ToString(); index++; CalibrationPos[index].SetActive(true);
        }
        else if (index == 17)
        {
            RightLeftHalfTop = Head.transform.localRotation.x;
            CalibrationPos[index].transform.GetComponentInChildren<Text>().text = RightLeftHalfTop.ToString(); index++;
        }
        else if (index >= 18)
        {
            CalibrationMode = false;

        }
    }

    void CalculateCrosshairPosition()
    {
        //if (Time.time - lastDetectionTime >= detectionInterval)
        //{
        float NegativeOranX = 960 / left;
        var x = Head.transform.localRotation.y * NegativeOranX;

        float NegativeOranY = 536 / bot;
        var y = Head.transform.localRotation.x * NegativeOranY;


        float OranX = 960 / right;
        var w = Head.transform.localRotation.y * OranX;

        float OranY = 536 / top;
        var k = Head.transform.localRotation.x * OranY;

        ////orta
        //if ((Head.transform.localRotation.y >= RightTopBot && Head.transform.localRotation.y <= LeftTopBot) && (Head.transform.localRotation.x >= RightLeftHalfBot && Head.transform.localRotation.x <= RightLeftHalfTop))
        //{
        //    Debug.Log("orta");
        //    //orta sol
        //    if (Head.transform.localRotation.y <= MiddleX)
        //    {
        //        //orta üst
        //        if (Head.transform.localRotation.x <= RightLeftHalfTop && Head.transform.localRotation.x >= MiddleY)
        //        {
        //            Debug.Log("orta Sol Üst");
        //            NegativeOranX = 480 / (LeftTop + MiddleX);
        //            x = Head.transform.localRotation.y * NegativeOranX;

        //            NegativeOranY = 255 / (LeftTopHalf + MiddleY);
        //            y = Head.transform.localRotation.x * NegativeOranY;
        //            x = Mathf.Clamp(x, 0, 480);
        //            y = Mathf.Clamp(y, 0, 255);
        //            if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
        //            {

        //                targetPosition = new Vector3(-x, -y, transform.localPosition.z);
        //                lastDetectionTime = Time.time;
        //            }
        //            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
        //            lastPosition = transform.localPosition;
        //        }
        //        //orta alt
        //        else if (Head.transform.localRotation.x >= RightLeftHalfBot && Head.transform.localRotation.x <= MiddleY)
        //        {
        //            Debug.Log("orta sol alt");
        //            NegativeOranX = 480 / (LeftTop + MiddleX);
        //            x = Head.transform.localRotation.y * NegativeOranX;

        //            NegativeOranY = 255 / (LeftTopHalf + MiddleY);
        //            y = Head.transform.localRotation.x * NegativeOranY;
        //            x = Mathf.Clamp(x, 0, 480);
        //            y = Mathf.Clamp(y, 0, 255);
        //            if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
        //            {

        //                targetPosition = new Vector3(-x, y, transform.localPosition.z);
        //                lastDetectionTime = Time.time;
        //            }
        //            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
        //            lastPosition = transform.localPosition;
        //        }

        //    }
        //    //orta sağ
        //    else
        //    {
        //        //orta üst
        //        if (Head.transform.localRotation.x <= RightLeftHalfTop && Head.transform.localRotation.x >= MiddleY)
        //        {
        //            Debug.Log("orta sağ üst");
        //            NegativeOranX = 480 / (LeftTop + MiddleX);
        //            x = Head.transform.localRotation.y * NegativeOranX;

        //            NegativeOranY = 255 / (LeftTopHalf + MiddleY);
        //            y = Head.transform.localRotation.x * NegativeOranY;
        //            x = Mathf.Clamp(x, 0, 480);
        //            y = Mathf.Clamp(y, 0, 255);
        //            if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
        //            {

        //                targetPosition = new Vector3(x, -y, transform.localPosition.z);
        //                lastDetectionTime = Time.time;
        //            }
        //            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
        //            lastPosition = transform.localPosition;
        //        }
        //        //orta alt
        //        else if (Head.transform.localRotation.x >= RightLeftHalfBot && Head.transform.localRotation.x <= MiddleY)
        //        {
        //            Debug.Log("orta sağ alt");
        //            NegativeOranX = 480 / (LeftTop + MiddleX);
        //            x = Head.transform.localRotation.y * NegativeOranX;

        //            NegativeOranY = 255 / (LeftTopHalf + MiddleY);
        //            y = Head.transform.localRotation.x * NegativeOranY;
        //            x = Mathf.Clamp(x, 0, 480);
        //            y = Mathf.Clamp(y, 0, 255);
        //            if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
        //            {

        //                targetPosition = new Vector3(x, -y, transform.localPosition.z);
        //                lastDetectionTime = Time.time;
        //            }
        //            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
        //            lastPosition = transform.localPosition;
        //        }
        //    }


        //}
        ////Sol
        //else
        if (Head.transform.localRotation.y <= MiddleX)
        {
            Debug.Log("sol");


            //alt
            if (Head.transform.localRotation.x >= MiddleY)
            {
                Debug.Log("solAlt");
                NegativeOranX = 960 / (LeftBot + MiddleX);
                x = Head.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 536 /(LeftBotHalf + MiddleY);
                y = Head.transform.localRotation.x * NegativeOranY;
                x = Mathf.Clamp(x, 0, 960);
                y = Mathf.Clamp(y, 0, 536);
                if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                {

                    targetPosition = new Vector3(-x, -y, transform.localPosition.z);
                    lastDetectionTime = Time.time;
                }
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
                lastPosition = transform.localPosition;
            }
            //üst
            else
            {
                Debug.Log("solÜst");
                NegativeOranX = 960 / (LeftTop + MiddleX);
                x = Head.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 536 / (LeftTopHalf + MiddleY);
                y = Head.transform.localRotation.x * NegativeOranY;
                x = Mathf.Clamp(x, 0, 960);
                y = Mathf.Clamp(y, 0, 536);
                if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                {

                    targetPosition = new Vector3(-x, y, transform.localPosition.z);
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
            if (Head.transform.localRotation.x >= MiddleY)
            {
                Debug.Log("SağAlt");
                NegativeOranX = 960 / (RightBot + MiddleX);
                x = Head.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 536 /( RightBotHalf + MiddleY);
                y = Head.transform.localRotation.x * NegativeOranY;
                x = Mathf.Clamp(x, 0, 960);
                y = Mathf.Clamp(y, 0, 536);
                if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                {

                    targetPosition = new Vector3(x, -y, transform.localPosition.z);
                    lastDetectionTime = Time.time;
                }
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
                lastPosition = transform.localPosition;
            }
            //üst
            else
            {
                Debug.Log("SağÜst");
                NegativeOranX = 960 / (RightTop + MiddleX);
                x = Head.transform.localRotation.y * NegativeOranX;

                NegativeOranY = 536 / (RightTopHalf + MiddleY);
                y = Head.transform.localRotation.x * NegativeOranY;
                x = Mathf.Clamp(x, 0, 960);
                y = Mathf.Clamp(y, 0, 536);

                if (Mathf.Abs(x - transform.localPosition.x) > movementThreshold || Mathf.Abs(y - transform.localPosition.y) > movementThreshold || Time.time - lastDetectionTime >= detectionInterval)
                {
                    targetPosition = new Vector3(x, y, transform.localPosition.z);
                    lastDetectionTime = Time.time;
                }
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 100f);
                lastPosition = transform.localPosition;
            }


        }

        //}
    }
}


