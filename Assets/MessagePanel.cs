using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MessagePanel : MonoBehaviour
{
    [SerializeField]
    private MessageView[] _messageViews;

    public void UpdateMessageViews(IEnumerable<Truck> trucks)
    {
        Queue<Truck> trucksQueue = new Queue<Truck>(trucks.ToArray());
        for (int i = 0; i < 3; i++)
        {
            Truck truck = trucksQueue.Dequeue();
            if (truck != null)
            {
                _messageViews[i].gameObject.SetActive(true);
                _messageViews[i].UpdateMessage(truck.Number, truck.Message);
            }
            else
            {
                _messageViews[i].gameObject.SetActive(false);
            }
        }
    }
}