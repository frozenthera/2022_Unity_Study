using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    float timeLimit;
    [SerializeField]
    ParticleSystem particle;
    
    float timeCnt = 0;
    Collider coll;
    Renderer ren;

    private void Start()
    {
        particle.gameObject.SetActive(false);
        coll = GetComponent<Collider>();
        ren = GetComponent<Renderer>();
    }
    private void Update()
    {
        timeCnt += Time.deltaTime;
        if (timeCnt > timeLimit) Destroy(gameObject);
    }

    public float Shooted() {
        coll.enabled = false;
        ren.enabled = false;
        particle.gameObject.SetActive(true);
        StartCoroutine(destroyRoutine());
        return timeLimit - timeCnt;
    }

    IEnumerator destroyRoutine(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
