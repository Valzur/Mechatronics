using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorGND : Device
{
    public override float DigitalRead() => _dataStream;

    public override void DigitalWrite(float data) => _dataStream = data;

    protected override void SampledUpdate(){}
}