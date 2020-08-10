using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalBody: MonoBehaviour
{
    Transform selfTransform;
    Transform centerTransform;
    LineRenderer rendererL;
    float ro, fi, num;
    public int type;
    // Start is called before the first frame update
    protected void Start()
    {
        selfTransform = this.transform;
        fi = 0f;
    }
    void Update()
    {
        Vector3 vector = new Vector3(Mathf.Sin(fi) * ro + centerTransform.position.x, centerTransform.position.y, Mathf.Cos(fi) * ro + centerTransform.position.z);
        transform.position = vector;
        fi += 5f * Time.deltaTime / (ro*3.14f);
    }

    public void SetParam(Transform centerTransform, int num)
    {
        rendererL = this.gameObject.GetComponent<LineRenderer>();
        rendererL.startWidth = 0.01f;
        rendererL.endWidth = 0.01f;
        this.centerTransform = centerTransform;
        this.num = num;
        ro = this.num * 0.5f + 0.5f;
        for (float i = 0, ind = 0; ind < 900; i+=0.1f, ind++)
        {
            Vector3 vector = new Vector3(Mathf.Sin(i) * ro + centerTransform.position.x, centerTransform.position.y, Mathf.Cos(i) * ro + centerTransform.position.z);
            rendererL.SetPosition((int)ind, vector); 
        }
    }
}
