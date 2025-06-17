using UnityEngine;

public class GridPosition : MonoBehaviour
{
    [SerializeField] int x;
    [SerializeField] int y;

    void OnMouseDown()
    {
        GameManager.Instance.ClickedOnGridPosition(x, y);
    }
}
