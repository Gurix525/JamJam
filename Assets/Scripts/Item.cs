using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string[] _messages;
    [SerializeField] private int _minAmount, _maxAmount;
    public int[] Situations;

    public string Name 
    {
        get { return gameObject.name; }
        
        private set { }
    }

    public string[] Messages => _messages;
    public int MinAmount => _minAmount;
    public int MaxAmount => _maxAmount;
}
