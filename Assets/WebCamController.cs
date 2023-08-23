using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WebCamController : MonoBehaviour
{
    public RawImage webcamImage;
    public RectTransform gazeIndicator;

    private WebCamTexture webcamTexture;
    private Vector2 gazePoint;

    private void Start()
    {
        webcamTexture = new WebCamTexture();
        webcamImage.texture = webcamTexture;
        webcamTexture.Play();
    }

    private void Update()
    {
        Vector2 gazePosition = DetectGazePosition();
        UpdateGazeIndicator(gazePosition);
    }

    private Vector2 DetectGazePosition()
    {
        // Simülasyon: Rastgele pozisyon tespiti (Gerçek göz takibi algoritması kullanılmalıdır)
        float x = Random.Range(0, webcamTexture.width);
        float y = Random.Range(0, webcamTexture.height);
        gazePoint = new Vector2(x, y);

        return gazePoint;
    }

    private void UpdateGazeIndicator(Vector2 gazePosition)
    {
        gazeIndicator.anchoredPosition = gazePosition;
    }
}
