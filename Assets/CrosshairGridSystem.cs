using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairGridSystem : MonoBehaviour
{
    public GridLayoutGroup gridLayout;  // GridLayoutGroup bileşeni

    private void Update()
    {
        // Hareket yönünü hesapla
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.W)) moveDirection = Vector3.up;
        else if (Input.GetKeyDown(KeyCode.S)) moveDirection = Vector3.down;
        else if (Input.GetKeyDown(KeyCode.A)) moveDirection = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.D)) moveDirection = Vector3.right;

        // Eğer bir hareket yönü belirlendi ise objeyi hareket ettir
        if (moveDirection != Vector3.zero)
        {
            MoveToNearestCell(moveDirection);
        }
    }

    private void MoveToNearestCell(Vector3 moveDirection)
    {
        Vector3 currentPosition = transform.position;

        Vector3[] cellPositions = new Vector3[gridLayout.transform.childCount];
        for (int i = 0; i < gridLayout.transform.childCount; i++)
        {
            RectTransform cell = gridLayout.transform.GetChild(i) as RectTransform;
            cellPositions[i] = cell.position;
        }

        Vector3 newTargetPosition = currentPosition + moveDirection * gridLayout.cellSize.x / 4;

        Vector3 newClosestCellPosition = cellPositions[0];
        float newClosestDistance = Vector3.Distance(newTargetPosition, newClosestCellPosition);

        for (int i = 1; i < cellPositions.Length; i++)
        {
            float distance = Vector3.Distance(newTargetPosition, cellPositions[i]);
            if (distance < newClosestDistance)
            {
                newClosestDistance = distance;
                newClosestCellPosition = cellPositions[i];
            }
        }

        transform.position = newClosestCellPosition;
    }
}
