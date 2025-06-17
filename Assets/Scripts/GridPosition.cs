using UnityEngine;

public class GridPosition : MonoBehaviour
{
    [SerializeField] int x;
    [SerializeField] int y;

    void OnMouseDown()
    {
        Debug.Log($"Clicked! {x} - {y}");
    }
}
