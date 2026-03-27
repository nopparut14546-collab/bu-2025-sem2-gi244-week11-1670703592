using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    public Rigidbody box;

    private Coroutine goodByeRoutine;

    void Start()
    {
        StartCoroutine(SpawnRoutine());

        //InvokeRepeating(nameof(RandomSpawn), 0, 5);


        //StartCoroutine(Hello());
        //StartCoroutine(GoodBye());
        //goodByeRoutine = StartCoroutine(GoodBye());
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(5);

        while (true)
        {
            RandomSpawn();
            yield return new WaitForSeconds(3);
        }
    }

    void RandomSpawn()
    {
        var index = Random.Range(0, spawnPoints.Length);
        var spawnPoint = spawnPoints[index];    
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }


    private void Update()
    {
        if (Time.time > 5)
        {
            if (goodByeRoutine != null)
            {
                StopCoroutine(goodByeRoutine);
            }

        }
    }

    IEnumerator MoveBox()
    {
        while (true)
        {
            box.linearVelocity = 10 * Vector3.up;
            yield return new WaitForSeconds(3);
            box.linearVelocity = 10 * Vector3.right;
            yield return new WaitForSeconds(3);
            box.linearVelocity = 10 * Vector3.down;
            yield return new WaitForSeconds(3);
            box.linearVelocity = 10 * Vector3.left;
            yield return new WaitForSeconds(3);
        }
    }

    IEnumerator GoodBye()
    {
        while (true)
        {
            Debug.Log("Bye " + Time.frameCount + " " + Time.time);
            yield return null;

            //if (Time.time > 5)
            //{
            //    yield return Hello();
            //}
            yield return Hello();
        }
    }

    IEnumerator Hello()
    {
        Debug.Log("Hello" + Time.frameCount);
        yield return null;
    }
}
