using UnityEngine;

public class Demo : MonoBehaviour
{
    public RadarMapHandler radar;

    private float[][] values = {
        new float[] { 1, 1, 1, 1, 1, 0.5f },
        new float[] { 0.5f, 0.7f, 1, 0.2f, 0.9f, 1 },
        new float[] { 0.2f, 0.6f, 0.8f, 1.0f, 0.9f, 1 },
        new float[] { 1f, 0.8f, 0.6f, 0.9f, 0.2f, 0.4f},
    };

    private float[][] values1 = {
        new float[] { 1, 1, 1, 1, 0.5f },
        new float[] {  0.7f, 1, 0.2f, 0.9f, 1 },
        new float[] {  0.6f, 0.8f, 1.0f, 0.9f, 1 },
        new float[] {  0.8f, 0.6f, 0.9f, 0.2f, 0.4f},
    };

    private int index = 0;

    float time = 0;

    private void Start()
    {
        //radar.SetData(values[index], true);
        //radar.SetData(values1[index], true);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 1.2f)
        {
            radar.SetData(values1[index], true);
            index = (index + 1) % values1.Length;
            //radar.SetData(values[index], true);
            //index = (index + 1) % values.Length;
           
            time = 0;
        }
    }
}