using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Purpose: Slicing logic for cooking puzzle knife

Author: Jared Israel

 */

public class KnifeSlice : MonoBehaviour
{

    [SerializeField]
    private GameObject _tip = null;

    [SerializeField]
    private GameObject _base = null;

    [SerializeField]
    private float _forceAppliedToCut = 3f;
    private Vector3 _previousTipPosition;
    private Vector3 _previousBasePosition;
    private Vector3 _triggerEnterTipPosition;
    private Vector3 _triggerEnterBasePosition;
    private Vector3 _triggerExitTipPosition;

    void Start()
    {
        _previousTipPosition = _tip.transform.position;
        _previousBasePosition = _base.transform.position;
    }

    void LateUpdate()
    {
        //Track the previous base and tip positions for the next frame
        _previousTipPosition = _tip.transform.position;
        _previousBasePosition = _base.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            _triggerEnterTipPosition = _tip.transform.position;
            _triggerEnterBasePosition = _base.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Food")
        {
            _triggerExitTipPosition = _tip.transform.position;

            //Create a triangle between the tip and base so that we can get the normal
            Vector3 side1 = _triggerExitTipPosition - _triggerEnterTipPosition;
            Vector3 side2 = _triggerExitTipPosition - _triggerEnterBasePosition;

            //Get the point perpendicular to the triangle above which is the normal
            //https://docs.unity3d.com/Manual/ComputingNormalPerpendicularVector.html
            Vector3 normal = Vector3.Cross(side1, side2).normalized;

            //Transform the normal so that it is aligned with the object we are slicing's transform.
            Vector3 transformedNormal = ((Vector3)(other.gameObject.transform.localToWorldMatrix.transpose * normal)).normalized;

            //Get the enter position relative to the object we're cutting's local transform
            Vector3 transformedStartingPoint = other.gameObject.transform.InverseTransformPoint(_triggerEnterTipPosition);

            Plane plane = new Plane();

            plane.SetNormalAndPosition(
                    transformedNormal,
                    transformedStartingPoint);

            var direction = Vector3.Dot(Vector3.up, transformedNormal);

            //Flip the plane so that we always know which side the positive mesh is on
            if (direction < 0)
            {
                plane = plane.flipped;
            }

            GameObject[] slices = Slicer.Slice(plane, other.gameObject);
            Destroy(other.gameObject);

            if (slices[1].GetComponent<Sliceable>().UseGravity)
            {
                Rigidbody rigidbody = slices[1].GetComponent<Rigidbody>();
                Vector3 newNormal = transformedNormal + Vector3.up * _forceAppliedToCut;
                rigidbody.AddForce(newNormal, ForceMode.Impulse);
            }
        }
    }

}
