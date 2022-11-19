using System;
using System.Collections.Generic;
using UnityEngine;

public class CarSuspension : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Rigidbody m_RigidBody;
        [SerializeField] List<Transform> m_SuspensionTargets;
        [Header("Parameters")]
        [SerializeField] float m_ForceAmount;
        [SerializeField] float m_SuspensionLength;
        public bool isGrounded { get; private set; }

        void FixedUpdate()
        {
            isGrounded = false;
            foreach (var target in m_SuspensionTargets)
            {
                RaycastHit hit;
                if (Physics.Raycast(target.position, -target.up, out hit, m_SuspensionLength))
                {
                    isGrounded = true;
                    Debug.DrawLine(target.position, hit.point, Color.green);
                    //Calculate the compression ratio
                    var distance = Vector3.Distance(target.position, hit.point);
                    var compressionRatio = (m_SuspensionLength - distance) / m_SuspensionLength;
                    m_RigidBody.AddForceAtPosition(target.up * m_ForceAmount * compressionRatio, target.position, ForceMode.Acceleration);
                }
                else
                {
                    Debug.DrawLine(target.position, target.position + (-target.up * m_SuspensionLength), Color.red);
                }
            }
            
        }
    }
