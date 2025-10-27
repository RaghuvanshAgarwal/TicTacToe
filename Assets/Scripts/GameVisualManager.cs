using System;
using Unity.Netcode;
using UnityEngine;

public class GameVisualManager : MonoBehaviour {
    private const float GridSize = 3.1f;
    [SerializeField] private Transform crossPrefab;
    [SerializeField] private Transform circlePrefab;

    private void Start() {
        GameManager.Instance.OnClickedOnGridPosition += GameManager_OnClickedOnGridPosition;
    }
    
    private void OnDestroy() {
        GameManager.Instance.OnClickedOnGridPosition -= GameManager_OnClickedOnGridPosition;
    }

    private void GameManager_OnClickedOnGridPosition(object sender, GameManager.OnClickedOnGridPositionEventArgs e) {
        Transform spawnedCrossTransform = Instantiate(crossPrefab);
        spawnedCrossTransform.GetComponent<NetworkObject>().Spawn(true);
        spawnedCrossTransform.position = GetGridWorldPosition(e.X,e.Y);
    }

    private Vector2 GetGridWorldPosition(int x, int y) {
        
        return new Vector2(-GridSize + x * GridSize, -GridSize + y * GridSize);
    }
}
