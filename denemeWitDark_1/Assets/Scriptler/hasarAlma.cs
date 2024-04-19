using UnityEngine;

public class hasarAlma : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;


    private Transform playerTransform;
    public float damageAmount = 15;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        
        if(distance <= 2) {
            currentHealth -= damageAmount;
            if (currentHealth <= 0)
            {
                Die();
            }
            
            if (currentHealth >= 0) 
            {
                Debug.Log("Can seviyesi: " + currentHealth);
            }
        }
    }

    void Die()
    {
        // Düþmanýn ölümüyle ilgili iþlemler burada gerçekleþtirilir
        Destroy(gameObject); // Düþmaný yok et
    }
}