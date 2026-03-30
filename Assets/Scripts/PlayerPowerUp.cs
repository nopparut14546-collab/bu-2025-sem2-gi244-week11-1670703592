using UnityEngine;
using System.Collections;

public class PlayerPowerUp : MonoBehaviour
{
    public GameObject powerIndicator;
    //public float powerUpDuration = 7f;

    private bool hasPowerUp = false;


    void Start()
    {
        if (powerIndicator != null)
        {
            powerIndicator.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;

            if (powerIndicator != null)
            {
                powerIndicator.SetActive(true);
            }

            Destroy(other.gameObject);

            StopAllCoroutines();
            //StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    //IEnumerator PowerUpCountdownRoutine()
    //{
    //    yield return new WaitForSeconds(powerUpDuration);

    //    hasPowerUp = false;

    //    if (powerIndicator != null)
    //    {
    //        powerIndicator.SetActive(false);
    //    }
    //}
}