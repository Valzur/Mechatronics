using UnityEngine;

public class Motor : Device
{
    [SerializeField] Wheel[] connectedWheels;
    [SerializeField] float Kt;
    [SerializeField] float noLoadSpeed;
    [SerializeField] float effeciency;
    [SerializeField] float loadArm;
    [SerializeField] Transform rotationDirection;
    float load;
    MotorGND ground;
    float dataStream
    {
        get{return _dataStream - ground.DigitalRead();}
    }
    [SerializeField] bool printStuff;
    void Awake()
    {
        foreach (var wheel in connectedWheels)
            wheel.rigidbody.maxAngularVelocity= Mathf.Infinity;

        ground = gameObject.AddComponent<MotorGND>();
    }
    
    public MotorGND ConnectMotor()
    {
        if(!ground)
            ground = gameObject.AddComponent<MotorGND>();
        return ground;
    }
    
    public override float DigitalRead() => dataStream;

    public override void DigitalWrite(float data) => _dataStream = data;
    
    protected override void SampledUpdate()
    {
        int num = 0;
        load = 0f;
        foreach (var wheel in connectedWheels)
        {
            num++;
            load += wheel.CurrentLoad;
        }
        load = load / num;

        foreach (var wheel in connectedWheels)
        {
            float Pout, Pin, M, I;
            M = load * loadArm;
            I = M / Kt;
            Pin = I * dataStream;
            Pout = effeciency * Pin;
            if(printStuff)
            {
                print("Moment: " + M);
                print("I: " + I);
                print("V: " + dataStream);
                print("Power In: " + Pin);
                print("Power Out: " + Pout);
            }
            if(M == 0f)
            {
                wheel.rigidbody.angularVelocity = noLoadSpeed * (dataStream / 12) * rotationDirection.forward;
                if(printStuff)
                    print("Rotation Speed: " + wheel.rigidbody.angularVelocity);
            }
            else
            {
                wheel.rigidbody.angularVelocity = Pout / M * rotationDirection.forward;
                wheel.rigidbody.angularVelocity = Vector3.ClampMagnitude(wheel.rigidbody.angularVelocity, noLoadSpeed);
                if(printStuff)
                    print("Rotation Speed: " + wheel.rigidbody.angularVelocity);
            }
        }
    }
}