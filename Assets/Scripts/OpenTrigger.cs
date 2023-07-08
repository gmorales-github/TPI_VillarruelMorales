using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] _unblocks;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            UnLock(false);
            GetComponent<Collider2D>().enabled = true;
            Debug.Log("---Salida desbloqueada---");
        }
    }

    private void UnLock(bool value)
    {
        for (int i = 0; i < _unblocks.Length; i++)
        {
            _unblocks[i].SetActive(value);
        }
    }
}