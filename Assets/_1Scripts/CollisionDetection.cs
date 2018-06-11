using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            GameEvents.instance.PlayerDeath(other);
        }
        else if (other.transform.tag == "FinishLine")
        {
            GameEvents.instance.ScoreAdd(other);
        }
        else if (other.transform.tag == "SideCollider")
        {
            GameEvents.instance.ScoreAdd(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag =="FrontCollider")
        {
            GameEvents.instance.ScoreAdd(other);
        }
        else if(other.gameObject.tag == "TopSideTrigger")
        {
            gameObject.GetComponentInParent<PlayerMovement>().RightSide = true;
            gameObject.GetComponentInParent<PlayerMovement>().LeftSide = false;
        }
        else if (other.gameObject.tag == "BottomSideTrigger")
        {
            gameObject.GetComponentInParent<PlayerMovement>().RightSide = false;
            gameObject.GetComponentInParent<PlayerMovement>().LeftSide = true;
        }
    }
}
