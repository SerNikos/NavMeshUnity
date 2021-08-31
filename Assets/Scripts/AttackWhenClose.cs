using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWhenClose : MonoBehaviour
{

    private Transform enemy;
    private float dist;

    public float howClose = 10;


    public GameObject target;
    public Transform spawnPos;
    public GameObject bullet;
    private float SpeedBullet = 10f;

    public bool canFire = true;



    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;

        StartCoroutine(AttackRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(enemy.position, transform.position);

        if (dist <= howClose)
        {
            transform.LookAt(enemy);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            StartCoroutine(WaitForBullets());




        }
    }

    public void Shoot()
    {
        if (canFire)
        {
            GameObject Spawner = Instantiate(bullet, spawnPos.position, spawnPos.transform.rotation);
            Spawner.GetComponent<Rigidbody>().velocity += transform.forward * SpeedBullet;
        }

    }

    IEnumerator WaitForBullets()
    {

        print("NIKOS");
        Shoot();
        canFire = false;


        yield return new WaitForSeconds(5);
        canFire = true;
        WaitForBullets();
    }



    public IEnumerator AttackRoutine()
    {
        while (true)
        {
            Debug.Log("Attack");

            yield return new WaitForSeconds(2);

        }
    }
}
