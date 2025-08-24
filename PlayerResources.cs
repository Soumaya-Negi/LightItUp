using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public int wood = 0;
    public int stone = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wood"))
        {
            wood++;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Stone"))
        {
            stone++;
            Destroy(other.gameObject);
        }
    }
}
