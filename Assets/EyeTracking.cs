using System.Collections.Generic;
using UnityEngine;

public class EyeTracking : MonoBehaviour
{
    public WebCamTexture webcamTexture;
    public Color32[] pixelData;

    public Detector detector;
    public Target target;

    public List<Vector2> calibrationZones;
    public int calibrateIndex = 0;

    private Color backgroundColor = Color.black;

    private void Start()
    {
        int imageWidth = 640; // Placeholder value, adjust to your needs
        int imageHeight = 480; // Placeholder value, adjust to your needs

        float targetRadius = 10f; // Hedef yarıçapı
        float targetSpeed = 10f; // Hedef hızı

        detector = new Detector(imageWidth, imageHeight); // Placeholder for your Detector class

        webcamTexture = new WebCamTexture();
        webcamTexture.Play();


        Vector2 center = Vector2.zero; // Başlangıç merkez pozisyonu

        target = new Target(center, targetSpeed, targetRadius, Color.white); // Hedefi oluşturun


        calibrationZones = GetCalibrationZones(imageWidth, imageHeight, targetRadius);

    }

    private void Update()
    {
        pixelData = webcamTexture.GetPixels32();

        Vector2 lEye, rEye, face, faceAlign, headPos;
        float angle;

        // Placeholder for your detector's GetFrame method
        detector.GetFrame(pixelData, out lEye, out rEye, out face, out faceAlign, out headPos, out angle);

        // ... process eye tracking data ...

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (calibrateIndex < calibrationZones.Count)
            {
                target.position = calibrationZones[calibrateIndex];
                target.Render();
            }

            calibrateIndex++;
        }
       

        target.Move((lEye + rEye) * 0.5f, Time.deltaTime); // Assuming the average eye position represents gaze point

        // ... update target movement and rendering ...

        UpdateBackgroundColor();
    }

    private List<Vector2> GetCalibrationZones(int width, int height, float targetRadius)
    {
        List<Vector2> zones = new List<Vector2>();

        float[] xs = { 0 + targetRadius, width / 2f, width - targetRadius };
        float[] ys = { 0 + targetRadius, height / 2f, height - targetRadius };

        foreach (float x in xs)
        {
            foreach (float y in ys)
            {
                zones.Add(new Vector2(x, y));
            }
        }

        // Shuffle the zones (you need to implement this part)
        ShuffleList(zones);

        return zones;
    }

    private void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    private void UpdateBackgroundColor()
    {
        // Placeholder for your background color manipulation logic
        // Modify backgroundColor based on gaze direction or other factors

        // Set background color
        Camera.main.backgroundColor = backgroundColor;
    }
}
