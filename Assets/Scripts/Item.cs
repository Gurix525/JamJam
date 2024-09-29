using UnityEngine;

public class Item : MonoBehaviour
{
    [field: SerializeField]
    public string Name { get; private set; }

    [SerializeField] private string[] _messages;
    [SerializeField] private int _minAmount, _maxAmount;
    public int[] Situations;

    public string[] Messages => _messages;
    public int MinAmount => _minAmount;
    public int MaxAmount => _maxAmount;
}