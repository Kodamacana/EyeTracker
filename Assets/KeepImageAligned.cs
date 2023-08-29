using UnityEngine;

public class KeepImageAligned : MonoBehaviour
{
    public Transform targetObject; // 3 boyutlu obje
    public Transform imageObject; // 2 boyutlu image objesi

    private void Update()
    {
        // 3 boyutlu objenin z pozisyonunu al
        float targetZ = targetObject.position.z;

        // Image objesinin pozisyonunu güncelle
        Vector3 imagePosition = imageObject.position;
        imagePosition.z = targetZ;
        imageObject.position = imagePosition;
    }
}
