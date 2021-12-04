using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSys : MonoBehaviour
{
    public GameObject particle;

    public float spreadAngle = 0f;
    public float emissionRate = 10f;
    public bool worldSimSpace = true;

    public float lifetime = 10.0f;
    public bool collision = false;

    public float sizeAcc = 0.0f;

    public float initSpeed = 5.0f;
    public float acceleration = 0f;
    public bool killOnStagnant = false;

    private float lastTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            if (child.name == "visuals") child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float timeInt = 1 / emissionRate;
        if (Time.time - lastTime >= timeInt)
        {
            float angle = transform.rotation.eulerAngles.z;
            angle += Random.Range(0, spreadAngle) - spreadAngle / 2;
            angle *= Mathf.Deg2Rad;
            Vector3 dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
            emit(dir);
        }
    }

    void emit(Vector3 dir)
    {
        GameObject p = Instantiate(particle);
        if (!worldSimSpace) p.transform.parent = transform;
        p.GetComponent<ParticleBehavior>().setStats(dir, lifetime, collision, sizeAcc, acceleration, killOnStagnant);
    }
}
