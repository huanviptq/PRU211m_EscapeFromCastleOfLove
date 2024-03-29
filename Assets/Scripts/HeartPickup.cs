using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper; //khong dung
    [SerializeField] int heal = 20;
    bool wasCollected = false;
    void Start(){
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>(); //khong can check score
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !wasCollected){
            wasCollected = true;
            audioPlayer.PlayHealClip();
            gameObject.SetActive(false);
            Destroy(gameObject);
            other.GetComponent<Health>().Heal(heal); //tang mau
        }
    }
}
