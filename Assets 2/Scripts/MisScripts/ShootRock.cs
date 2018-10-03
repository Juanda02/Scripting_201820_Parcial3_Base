using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRock : MonoBehaviour {

    private bool isReloaded;

    public GameObject prefabBala;

    public Transform shootPosition;

    private Transform target;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bala")
        {
            isReloaded = true;
            other.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&isReloaded)
        {

            isReloaded = false;
            target = GameManager.Instance.transformActors[GameManager.Instance.actualTagged];
            GameObject tempBala = Instantiate(prefabBala, shootPosition.position, Quaternion.LookRotation(target.position));
            tempBala.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*20f, ForceMode.Impulse);

        }
    }

}
