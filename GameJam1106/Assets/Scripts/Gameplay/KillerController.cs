using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillerController : MonoBehaviour{


    void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Cabeza")){

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        }


    }


}
