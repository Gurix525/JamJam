using UnityEngine;

public class Item : MonoBehaviour
{
    [field: SerializeField]
    public string Name { get; private set; }

    [SerializeField] private string[] _messages;
    [SerializeField] private int _minAmount, _maxAmount;

    [field: SerializeField]
    public GameObject ViewPrefab { get; private set; }

    public string[] Messages => _messages;
    public int MinAmount => _minAmount;
    public int MaxAmount => _maxAmount;
}