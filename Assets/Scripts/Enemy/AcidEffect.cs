using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    private void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();
            if(hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
