using UnityEngine;

public class Phone : Interactable
{
    [SerializeField]
    private TrucksManager _trucksManager;

    [SerializeField]
    private EmergencyMessageGenerator _emergencyMessageGenerator;

    [SerializeField] private float _minCooldownTime, _maxCooldownTime;

    [SerializeField] private float _cooldown, _elapsedWaitForAnswerTime, _maxWaitForAnswerTime;
    
    [SerializeField] private HealthSystem _healthSystem;

    private bool _isCalling;

    private void Start()
    {
        _cooldown = 3F;
    }

    private void FixedUpdate()
    {
        if (_trucksManager.IsAnyTruckFree)
            if (!_isCalling)
            {
                _cooldown -= Time.fixedDeltaTime;
            }
        if (_cooldown <= 0F && !_isCalling)
        {
            Call();
        }
        if (_isCalling)
        {
            _elapsedWaitForAnswerTime += Time.fixedDeltaTime;
            if (_elapsedWaitForAnswerTime >= _maxWaitForAnswerTime)
            {
                StopCallingWithoutAnswer();
            }
        }
    }

    private void Call()
    {
        Debug.Log("Calling...");
        _elapsedWaitForAnswerTime = 0F;
        _isCalling = true;
    }

    private void StopCallingWithoutAnswer()
    {
        _isCalling = false;
        RandomizeCooldown();
        _healthSystem.Damage(1);
    }

    private void RandomizeCooldown()
    {
        _cooldown = UnityEngine.Random.Range(_minCooldownTime, _maxCooldownTime);
    }

    public override void Interact()
    {
        if (_isCalling)
        {
            AnswerPhone();
        }
    }

    private void AnswerPhone()
    {
        _isCalling = false;
        RandomizeCooldown();
        _trucksManager.TakeTruck(_emergencyMessageGenerator.GenerateMessage());
    }
}