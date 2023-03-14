using System;
using UnityEngine;

internal interface IGrassStorage
{
    public Transform Transform { get; }
    public bool IsEmpty { get; }
    public bool IsFull { get; }

    public event Action<float> GrassCountChanged;

    void CollectGrass();

    void SellGrass();
}
