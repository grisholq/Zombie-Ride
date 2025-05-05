using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class CarMonos 
{
    public Transform MainTranform;
    [FormerlySerializedAs("ViewTransform")] [FormerlySerializedAs("ViewHolderTransform")] public Transform viewHolderTransform;
    public Rigidbody Rigidbody;
}
