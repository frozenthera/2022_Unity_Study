using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    float timeLimit;
    float timeCnt = 0;

    private void Update()
    {
        timeCnt += Time.deltaTime;
        if (timeCnt > timeLimit) Destroy(gameObject);
    }

    public void Shooted() {
        Destroy(gameObject);
    }
}
