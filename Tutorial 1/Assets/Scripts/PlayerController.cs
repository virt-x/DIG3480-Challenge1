using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed;
    private int count, score, lives;
    public UnityEngine.UI.Text scoreUI,winUI,lifeUI;
    private bool win;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        score = 0;
        lives = 3;
        win = false;
        winUI.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        player.AddForce(new Vector2(moveHorizontal * speed, moveVertical * speed));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Pickup"))
        {
            collider.gameObject.SetActive(false);
            count++;
            score++;
            scoreUI.text = "SCORE: " + score.ToString();
        }

        if (collider.gameObject.CompareTag("Enemy") && !win)
        {
            collider.gameObject.SetActive(false);
            score--;
            lives--;
            scoreUI.text = "SCORE: " + score.ToString();
            lifeUI.text = "LIVES: " + lives.ToString();
        }

        if (count == 12)
        {
            gameObject.transform.position = new Vector3(75, 0, 0);
        }

        if (count == 20)
        {
            win = true;
            winUI.text = "Congratulations! You win!\n";
            if (score == 20)
            {
                winUI.text += "-PERFECT SCORE-";
            }
            else
            {
                winUI.text += "Game created by Xavier Virt.";
            }
        }

        if (lives == 0)
        {
            winUI.text = "You LOSE!\n-GAME OVER-";
            gameObject.SetActive(false);
        }
    }
}
