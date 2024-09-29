using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BalancingSystem : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private RectTransform _balancePointer;

    [SerializeField]
    private float _maxPointerDistanceFromOrigin = 100F;

    [SerializeField]
    private float _unbalancingSpeed = 0.01F;

    [SerializeField]
    private float _balancingSpeed = 0.01F;

    [SerializeField]
    private float _unbalanceMultiplierPerItem;

    private Vector2 _balanceDelta;

    public void OnMouseDelta(InputValue value)
    {
        _balanceDelta = value.Get<Vector2>() * _balancingSpeed;
    }

    private void Update()
    {
        if (_inventory.ItemsCount > 0)
        {
            MoveFromZero();
            AddOffset();
            TryThrowOutInventory();
            AddBalance();
            ResetFarAwayPointer();
        }
    }

    private void TryThrowOutInventory()
    {
        if (Vector2.Distance(Vector2.zero, _balancePointer.anchoredPosition) > 100F)
        {
            _inventory.ClearStack();
            _balancePointer.anchoredPosition = Vector2.zero;
        }
    }

    private void MoveFromZero()
    {
        if (_balancePointer.anchoredPosition == Vector2.zero)
        {
            float x = new System.Random().Next(-10, 10);
            float y = new System.Random().Next(-10, 10);
            _balancePointer.anchoredPosition = new Vector2(x, y).normalized;
        }
    }

    private void ResetFarAwayPointer()
    {
        Vector2 position = _balancePointer.anchoredPosition;
        if (Vector2.Distance(position, Vector2.zero) > 100F)
        {
            position = position.normalized * 100F;
        }
        _balancePointer.anchoredPosition = position;
    }

    private void AddOffset()
    {
        _balancePointer.anchoredPosition += _balancePointer.anchoredPosition * _unbalancingSpeed * Time.deltaTime
        *(1 + _unbalanceMultiplierPerItem * _inventory.GetStackLength());
    }

    private void AddBalance()
    {
        _balancePointer.anchoredPosition += _balanceDelta * Time.deltaTime;
    }
}