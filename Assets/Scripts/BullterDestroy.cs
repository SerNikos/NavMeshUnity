using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullterDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision col)
    {
       if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
        }
    }
}
