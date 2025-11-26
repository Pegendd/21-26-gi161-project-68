using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    

    public int damage = 10;
    public float speed = 2f;

    protected Transform Player;

    protected virtual void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public abstract void Move();
    public abstract void Attack();

    void Update()
    {
         Move();
    }

    protected void DealDamage()
    {
        if (Vector2.Distance(transform.position , Player.position) < 1f)
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
