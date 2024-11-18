using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiemTontai : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Square" || other.tag == "Triangle")
        {
            Destroy(other.gameObject);
        }
    }
}
