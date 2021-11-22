using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeChecker : MonoBehaviour
{
    public bool ledge;
    // Start is called before the first frame update
    void Start()
    {
        ledge = false;
    }

    private void Update()
    {
        var hits = Physics2D.RaycastAll(transform.position, new Vector2(0, -1));
        ledge = true;
        foreach (RaycastHit2D hit in hits)
        {
            if(hit.distance <= 1.28 && hit.transform.CompareTag("Platform"))
            {
                ledge = false;
                break;
            }
        }
    }
}
