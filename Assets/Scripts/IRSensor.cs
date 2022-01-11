using UnityEngine;

[RequireComponent(typeof(Camera))]
public class IRSensor : Device
{
    [SerializeField] float sensorRange;
    [SerializeField] RenderTexture renderTexture;
    Camera cameraSensor;

    void Awake() => cameraSensor = GetComponent<Camera>();
    
    void Start() => cameraSensor.farClipPlane = sensorRange;

    protected override void SampledUpdate()
    {
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        texture.Apply(false);
        Graphics.CopyTexture(renderTexture, texture);
        int No = 0;
        float sum = 0;
        foreach (var pixel in texture.GetPixels())
        {
            No++;
            sum += pixel.grayscale;
        }
        sum = sum / No;
        //print("IR Sensor Reading: " + sum);
        DigitalWrite(sum);
    }
}