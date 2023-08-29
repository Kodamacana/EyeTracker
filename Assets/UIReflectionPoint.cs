using UnityEngine;

public class UIReflectionPoint : MonoBehaviour
{
    public GameObject target3DObject; // 3D nesneyi buraya sürükleyin
    public RectTransform uiImageRectTransform; // Image'in RectTransform bileşenini buraya sürükleyin

    void Update()
    {
        // 3D nesnenin pozisyonunu al
        Vector3 targetPosition = target3DObject.transform.position;

        // 3D nesnenin pozisyonuna dayalı olarak Image'in dünya pozisyonunu hesapla
        Vector3 imageWorldPosition = Camera.main.WorldToScreenPoint(targetPosition);

        // Image'in RectTransform'inin dünya konumunu güncelle
        uiImageRectTransform.position = imageWorldPosition;
    }
}
