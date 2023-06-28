using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCubeTrigger : MonoBehaviour
{
    [SerializeField] private AddBlockEffect floatingText;
    [Inject] public PlayerBoxStack playerBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CubeToAdd>())
        {
            playerBox.IncreaseTowerSize(gameObject);
        }
        else if (other.gameObject.GetComponent<ObstacleCube>())
        {
            //playerBox.DecreaseTowerSize(gameObject);
            StartCoroutine(playerBox.GameOver());
        }

        if (other.gameObject.GetComponent<Coin>())
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.GetComponent<Finish>())
        {
            StartCoroutine(playerBox.GameOver());
        }
    }
}
