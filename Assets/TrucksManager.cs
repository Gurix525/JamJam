using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrucksManager : MonoBehaviour
{
    [SerializeField]
    private List<Truck> _trucks = new();

    [SerializeField]
    private MessagePanel _messagePanel;

    private HealthSystem _healthSystem;

  


    public IEnumerable<Truck> FreeTrucks
    {
        get
        {
            return _trucks
                .Where(truck => !truck.IsTaken);
        }
    }

    public IEnumerable<Truck> TakenTrucks
    {
        get
        {
            return _trucks
                .Where(truck => truck.IsTaken);
        }
    }

    private void Start()
    {
        _healthSystem = FindObjectOfType<HealthSystem>();
        foreach (var truck in _trucks)
        {
            truck.TruckSentOff += Truck_TruckSentOff;
        }
    }

    private void Truck_TruckSentOff(object sender, bool e)
    {
        if (!e)
        {
            _healthSystem.DealDamage(1);
        }
        
        (sender as Truck).UnTake();
        _messagePanel.UpdateMessageViews(TakenTrucks);
    }

    public bool IsAnyTruckFree => FreeTrucks.Count() > 0;

    public void TakeTruck(Message message)
    {
        FreeTrucks.First().Take(message);
        _messagePanel.UpdateMessageViews(TakenTrucks);
    }
}