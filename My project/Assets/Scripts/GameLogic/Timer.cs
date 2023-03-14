using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private List<ITickable> _fixedUpdateTimer = new List<ITickable>();
    private List<ITickable> _updateTimer = new List<ITickable>();


    void Update()
    {
        for(var i=0;i< _updateTimer.Count;i++)
            _updateTimer[i].Tick();
    }

    private void FixedUpdate()
    {
        for (var i = 0; i < _fixedUpdateTimer.Count; i++)
            _fixedUpdateTimer[i].Tick();
    }

    public void AddFixed(ITickable tickable)
    {
        if(!_fixedUpdateTimer.Contains(tickable))
            _fixedUpdateTimer.Add(tickable);
    }
    public void Add(ITickable tickable)
    {
        if(!_updateTimer.Contains(tickable))
            _updateTimer.Add(tickable);
    }
    public void RemoveFixed(ITickable tickable)
    {
        if(!_fixedUpdateTimer.Contains(tickable))
            _fixedUpdateTimer.Remove(tickable);
    }
    public void Remove(ITickable tickable)
    {
        if(!_updateTimer.Contains(tickable))
            _updateTimer.Add(tickable);
    }
}
