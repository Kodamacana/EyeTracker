using UnityEngine;

public class CoordinateDetected : MonoBehaviour
{
    public Camera mainCamera; // Kamerayı buraya sürükleyerek atayın

    void Update()
    {
        if (mainCamera != null)
        {
            // 3D objenin dünya pozisyonunu al
            Vector3 worldPosition = transform.position;

            // Dünya koordinatlarını ekran görünüm yüzdesine dönüştür
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(worldPosition);

            // Görünüm yüzdesini yazdır
            Debug.Log("3D Objecin Görünüm Yüzdesi: " + viewportPosition);
        }
        else
        {
            Debug.LogError("Kamera atanmamış!");
        }
    }
}
