using UnityEngine;
using System.Collections;

public class Dust : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //particleEmitter.emit = true;
        StartCoroutine("DustShow");
    }

    IEnumerator DustShow()
    {
        yield return new WaitForSeconds(3.0f);
    }
}