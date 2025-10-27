using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("GameManager already exists");
        }
        Instance = this;
    }
    
    public void ClickedOnGridPosition(int x, int y) {
        Debug.Log($"{x}, {y}");
    }
}
