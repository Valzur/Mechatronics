using UnityEngine;

public abstract class Device: MonoBehaviour
{
    readonly float samplingTime = 0.1f;
    float samplingTimeLeft;
    protected float _dataStream;

    void Update() 
    {
        samplingTimeLeft -= Time.deltaTime;
        if(samplingTimeLeft <= 0)
        {
            samplingTimeLeft = samplingTime;
            SampledUpdate();
        }
    }
    
    protected abstract void SampledUpdate();
    
    public virtual void DigitalWrite(float data) => _dataStream = data;
    
    public virtual float DigitalRead() => _dataStream;
}