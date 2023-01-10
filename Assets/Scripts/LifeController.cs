using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int lifes_current;
    public int lifes_max;
    public float invencible_time;
    bool invencible;
    public int score = 0;


    public enum DeathMode { Teleport, ReloadScene, Destroy }
    public DeathMode death_mode;
    public Transform respawn;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifes_current = lifes_max;
    }

    public void Damage(int damage = 1, bool ignoreInvencible = false)
    {
        if (!invencible || ignoreInvencible)
        {
            lifes_current -= damage;
            StartCoroutine(Invencible_Corutine());
            if (lifes_current <= 0)
            {
                Muerte();
            }
        }
    }
    public void Muerte()
    {
        Debug.Log("Has muerto");
        switch (death_mode)
        {
            case DeathMode.Teleport:
                rb.velocity = new Vector2(0, 0);
                transform.position = respawn.position;
                lifes_current = lifes_max;
                break;
            case DeathMode.ReloadScene:

                break;
            case DeathMode.Destroy:
                Destroy(gameObject);
                break;
            default:
                break;
        }

    }
    IEnumerator Invencible_Corutine()
    {
        invencible = true;
        yield return new WaitForSeconds(invencible_time);
        invencible = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "melon")
        {
            score++;
            Destroy(other.gameObject);
        }
    }
}
