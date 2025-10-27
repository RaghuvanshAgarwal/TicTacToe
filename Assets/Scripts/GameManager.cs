using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public event EventHandler<OnClickedOnGridPositionEventArgs> OnClickedOnGridPosition;

    public class OnClickedOnGridPositionEventArgs : EventArgs {
        public int X;
        public int Y;
        public OnClickedOnGridPositionEventArgs(int x, int y) {
            X = x;
            Y = y;
        }
    }
    private void Awake() {
        if (Instance != null) {
            Debug.LogError("GameManager already exists");
        }
        Instance = this;
    }
    
    public void ClickedOnGridPosition(int x, int y) {
        Debug.Log($"{x}, {y}");
        OnClickedOnGridPosition?.Invoke(this, new OnClickedOnGridPositionEventArgs(x, y));
    }
}
