using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{

    public int  Hp { get; private set; } = 3;

    public void DealDamage(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
