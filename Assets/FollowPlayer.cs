using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 _originalOffset;

    [SerializeField]
    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _originalOffset = transform.position - _player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _player.position + _originalOffset;
    }
}