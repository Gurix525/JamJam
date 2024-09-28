using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name 
    {
        get { return gameObject.name; }
        
        private set { }
    }
}
