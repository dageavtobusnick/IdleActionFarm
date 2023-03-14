using EzySlice;
using UnityEngine;

[ExecuteInEditMode]
public class SliceGrass : MonoBehaviour
{
    [SerializeField] 
    private Vector3 _position;
    [SerializeField] 
    private Vector3 _direction;
    [SerializeField] 
    private Material _newObjectsMaterial;

    void Start()
    {
        var result=gameObject.Slice(transform.position+_position, _direction);
        var firstObject = result.CreateLowerHull();
        firstObject.GetComponent<MeshRenderer>().materials[0] = _newObjectsMaterial;
        var secondObject = result.CreateUpperHull();
        secondObject.GetComponent<MeshRenderer>().materials[0]= _newObjectsMaterial;
    }

}
