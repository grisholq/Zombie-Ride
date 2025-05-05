using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInput
{
    public float Turn => Input.GetAxis("Horizontal");
}