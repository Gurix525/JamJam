using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroppingAllItems : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    public void OnDropAll(InputValue value)
    {
        _inventory.ClearStack();
    }
}