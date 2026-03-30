using UnityEngine;

public class StuntPowerUp : MonoBehaviour
{
    public float stunDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StunPowerUp"))
        {
            // ?? Enemy ????????? Tag
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // ????????????????? 5 ??
            foreach (GameObject enemyObj in enemies)
            {
                Enemy enemyScript = enemyObj.GetComponent<Enemy>();

                if (enemyScript != null)
                {
                    enemyScript.StunEnemy(stunDuration);
                }
            }

            // ?? PowerUp ????????
            Destroy(other.gameObject);
        }
    }
}