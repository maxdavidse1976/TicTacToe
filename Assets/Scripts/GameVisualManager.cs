using System;
using UnityEngine;

public class GameVisualManager : MonoBehaviour
{
    const float GRID_SIZE = 3.1f;

    [SerializeField] Transform _crossPrefab;
    [SerializeField] Transform _circlePrefab;

    void Start()
    {
        GameManager.Instance.OnClickedOnGridPosition += GameManager_OnClickedOnGridPosition;
    }

    private void GameManager_OnClickedOnGridPosition(object sender, GameManager.OnClickedOnGridPositionEventArgs e)
    {
        Instantiate(_crossPrefab, GetGridWorldPosition(e.x, e.y), Quaternion.identity);

    }

    Vector2 GetGridWorldPosition(int x, int y)
    {
        return new Vector2(-GRID_SIZE + x * GRID_SIZE, -GRID_SIZE + y * GRID_SIZE);
    }
}
