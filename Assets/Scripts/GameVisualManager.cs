using System;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class GameVisualManager : NetworkBehaviour
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
        SpawnObjectRpc(e.x, e.y);
    }

    [Rpc(SendTo.Server)]
    void SpawnObjectRpc(int x, int y)
    {
        Transform spawnedCrossTransform = Instantiate(_crossPrefab);
        spawnedCrossTransform.GetComponent<NetworkObject>().Spawn(true);
        spawnedCrossTransform.position = GetGridWorldPosition(x, y);
    }

    Vector2 GetGridWorldPosition(int x, int y)
    {
        return new Vector2(-GRID_SIZE + x * GRID_SIZE, -GRID_SIZE + y * GRID_SIZE);
    }
}
