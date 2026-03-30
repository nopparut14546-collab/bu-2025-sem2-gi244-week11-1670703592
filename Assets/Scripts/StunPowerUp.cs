using UnityEngine;

public class StuntPowerUp : MonoBehaviour
{
    public float stunDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StunPowerUp"))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemyObj in enemies)
            {
                Enemy enemyScript = enemyObj.GetComponent<Enemy>();

                if (enemyScript != null)
                {
                    enemyScript.StunEnemy(stunDuration);
                }
            }
            Destroy(other.gameObject);
        }
    }
}