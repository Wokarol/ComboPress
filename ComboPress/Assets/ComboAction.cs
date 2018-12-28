using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wokarol.AdvancedInput;

public class ComboAction : MonoBehaviour
{
    ComboHandler handler;

    private void Start() {
        handler = new ComboHandler(2f, KeyCode.A, KeyCode.S);
    }

    private void Update() {
        handler.Tick();
        if (handler.OnComboDown) {
            Debug.Log($"Combo");
        }
    }
}
