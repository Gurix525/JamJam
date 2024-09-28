using UnityEngine;

public class ItemSource : Interactable
{
    [SerializeField]
    private Item _item;

    [SerializeField]
    private int _maxAmount = 2;

    [SerializeField]
    private int _currentAmount;

    private Inventory _inventory;

    private void Start()
    {
        _currentAmount = _maxAmount;
        _inventory = Object.FindObjectOfType<Inventory>();
    }

    public override void Interact()
    {
        if (_currentAmount == 0)
        {
            return;
        }
        if (!_inventory.CanTakeAdditionalIten)
        {
            return;
        }
        _currentAmount--;
        _inventory.AddItemToStack(Instantiate(_item, _inventory.transform).gameObject);
    }
}