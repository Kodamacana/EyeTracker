using UnityEngine;

public class BoundedObjectMovement : MonoBehaviour
{
    public Transform objectInCanvasA; // Canvas A'deki objenin referansını buraya atayın
    public Camera mainCamera; // Kamerayı buraya sürükleyerek atayın

    public Vector2 padding = new Vector2(50f, 50f); // Ekran kenarından olan boşluk

    void Update()
    {
        if (objectInCanvasA != null && mainCamera != null)
        {
            // Canvas A'deki objenin dünya pozisyonunu al
            Vector3 worldPosition = objectInCanvasA.position;

            // Dünya pozisyonunu ekran koordinatlarına dönüştür
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

            // Ekran kenarlarına olan sınırları belirle
            float minX = padding.x;
            float maxX = Screen.width - padding.x;
            float minY = padding.y;
            float maxY = Screen.height - padding.y;

            // Pozisyonu sınırla
            float clampedX = Mathf.Clamp(screenPosition.x, minX, maxX);
            float clampedY = Mathf.Clamp(screenPosition.y, minY, maxY);

            // Canvas B'deki objenin yerel pozisyonunu ayarla
            transform.localPosition = new Vector3(clampedX, clampedY, transform.localPosition.z);
        }
        else
        {
            Debug.LogError("Referanslar atanmamış!");
        }
    }
}
