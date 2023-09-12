using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(FallTimer());
        }
    }

    IEnumerator FallTimer()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(.25f);
        GetComponent<CircleCollider2D>().enabled = true;
    }

}
