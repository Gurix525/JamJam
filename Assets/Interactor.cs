using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private float _maxInteractionDistance = 1F;

    private Interactable[] _interactables;
    private Interactable _targetInteractable;

    private void Start()
    {
        _interactables = Object.FindObjectsOfType<Interactable>(true);
    }

    private void FixedUpdate()
    {
        _interactables = _interactables
            .OrderBy(x => Vector3.Distance(x.transform.position, transform.position))
            .ToArray();
        if (_interactables.Length == 0)
        {
            _targetInteractable = null;
            return;
        }
        if (Vector3.Distance(_interactables.First().transform.position, transform.position) < _maxInteractionDistance &&
            _interactables.First().isActiveAndEnabled)
        {
            _targetInteractable = _interactables.First();
        }
        else
        {
            _targetInteractable = null;
        }
    }

    public void OnInteract(InputValue value)
    {
        if (_targetInteractable == null)
            return;
        _targetInteractable.Interact();
    }

    public Interactable GetTargetInteractable()
    {
        if (_interactables.Length == 0)
        {
            return null;
        }
        return _interactables.First();
    }

    public float GetMaxDistance()
    {
        return _maxInteractionDistance;
    }
}