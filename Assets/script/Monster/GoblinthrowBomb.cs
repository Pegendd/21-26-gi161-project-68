using Unity.Mathematics;
using UnityEngine;

public class GoblinthrowBomb : MonoBehaviour
{
    [SerializeField] private GameObject projectileperfab;
    [SerializeField] private Transform Target;



    [SerializeField] private float ThrowRate;

    [SerializeField] private float projectileMoveSpeed;
    private float ThrowTimer;


    private void Update()
    {
         ThrowTimer -= Time.deltaTime;
         if (ThrowTimer <= 0)
        {
            ThrowTimer = ThrowRate;
            Projectile projectile = Instantiate(projectileperfab, transform.position, Quaternion.identity)
                        .GetComponent<Projectile>();
                        projectile.InitializeProjectile(Target , projectileMoveSpeed);



        }
    }
}
