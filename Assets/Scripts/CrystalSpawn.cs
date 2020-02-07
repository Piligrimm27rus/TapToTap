using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawn : MonoBehaviour
{
    [SerializeField] Transform crystalPrefab;

    private void OnEnable()
    {
        if (Random.Range(0, 100) < 20)
        {
            Instantiate(crystalPrefab, transform.position, Quaternion.identity);
        }
    }
}
