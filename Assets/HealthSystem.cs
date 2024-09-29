using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{

    public int Hp = 3;

    public void Damage(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
