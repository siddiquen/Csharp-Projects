using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Linq;

public class Player : MonoBehaviour
{
    //creates a variable to count how many coins you have collected
    public int coins = 0;

    //This sets the speed of the player
    public float speed = 2.0f;

    //this helps you create text that you can display in the game
    //to tell you how many coins you have collected
    //later on in the code, you can change the message this variable holds
    public Text coinAmount;

    //this helps you create text that you can display in the game
    //to tell you that you finished the game and won.
    //later on in the code, you can change the message this variable holds
    public Text youWin;

    //this helps you create text that you can display in the game
    //to tell you answered the question incorrectly
    //later on in the code, you can change the message this variable holds
    public Text wrong;

    //this creates the game object door
    //which is the final door to the end coin
    public GameObject Door;

    //this creates the game object MiniDoor
    //which are the 5 other doors that popup in the game when you need
    //to answer a question. these doors keep you from going anywhere
    //so that you are forced to complete the question.
    //the 'serialized field' allows you select assets/prefabs in unity
    //to associate with the code for MiniDoor
    [SerializeField] private GameObject MiniDoor;

    //I don't remember exactly, but there was a problem where if you collided
    //with a wall and a coin at the same time, then it would not only
    //destroy the coin, but it would also destroy the wall you collided with.
    //this code gets associated with the wall you collided with.
    //later on in the game, this code is used to makes sure that wall
    //does not get destroyed
    [SerializeField] private GameObject go;

    //creates a bool for stopwatch where it only start and stops when told to
    //do so in specific place in the code
    bool stopwatchActive = true;
    //this develops a variable that will contain that time value
    float currentTime;
    //IDK what this does. this is not even used in the rest of the code
    //but I will not delete it because I dont want to break anything
    public int startMinutes;
    //this helps you create text that you can display in the game
    //to tell you that time in the stopwatch
    //later on in the code, you can change the message this variable holds
    public Text currentTimeText;

    //this calls upon the 'Question' script and sets it to a variable
    public Question[] questions;
    //this turns the questions into a list called unansweredQuestions
    private static List<Question> unansweredQuestions;

    //this uses the code from the 'Question' script to create a
    // 'currentQuestion' variable
    private Question currentQuestion;

    //this is the code for developing the question box
    //this develops the game object 'questionBox'
    [SerializeField] private GameObject questionBox;
    //this helps you create text that you can display in the game
    //to present you with the question
    //later on in the code, you can change the message this variable holds
    [SerializeField] private Text factText;
    //this helps you create text that you can display in the game
    //to tell you what button 1 is assigned to (true or false)
    //later on in the code, you can change the message this variable holds
    [SerializeField] private Text button1Text;
    //this helps you create text that you can display in the game
    //to tell you what button 2 is assigned to (true or false)
    //later on in the code, you can change the message this variable holds
    [SerializeField] private Text button2Text;
    //this allows you to set the time between each question
    [SerializeField] private float timeBetweenQuestions = 3f;
    //this develops the game object 'button1' as its own object
    [SerializeField] Button _button1;
    //this develops the game object 'button2' as its own object
    [SerializeField] Button _button2;

    // Start is called before the first frame update
    void Start()
    {
        //sets currentTime to 0, because that is where the stopwatch starts
        currentTime = 0;
        //this disables the question box because you have not triggered it yet
        questionBox.SetActive(false);
        //this disables the miniDoors because you are not answering a question right now
        MiniDoor.SetActive(false);
    }

    //this is the code to pick the current question to display in the question box
    void SetCurrentQuestion()
    {
        int randomQuestionIndex = UnityEngine.Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;

        //this sets up what eash button will say based on whether the statement in the
        //'currentQuestion' is true or false
        //but I made it so that button1 always says true and button2 always says false
        //irrespective of the truth or falsity of the 'currentQuestion'. I did this because,
        //later on in the code, it allows me to run different code based on whether you pressed
        //button1 or button2
        if (currentQuestion.isTrue)
        {
            button1Text.text = "True";
            button2Text.text = "False";
        }
        else
        {
            button1Text.text = "True";
            button2Text.text = "False";
        }
    }
    
    //this code transitions to the next question
    //it is only called when you get the question wrong
    IEnumerator TransitionToNextQuestion()
    {
        //this removes the current question from the list so that it does not get asked again
        unansweredQuestions.Remove(currentQuestion);
        //im not sure what this does...
        yield return new WaitForSeconds(timeBetweenQuestions);
        //this resets the list to contain the original questions after every question has
        //been removed from it
        //this ensures that the game does not run out of questions to ask
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        //this brings up a new question by calling upon the 'currentQuestion'
        //method coded above
        SetCurrentQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        //each frame checks to see if you have a certan key pressed and moves you accordingly
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        //each frame checks if have collect 5 coins
        //if you have, then it destroys the main door so you
        //can finish the game
        if (coins == 5)
        {
            Destroy(Door);
        }

        //this code makes sure that the stopwatch is active and running in each frame
        //the continually calculates the time passed and
        //converts the time to a string format and associates it with the 'currentTimeText'
        //so you can use that variable to display the time passed in the game
        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = "Time: " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
        }

        //this reference 'go' game object coded above
        //this purpose is so that walls you have collided with dont get destoryed
        DontDestroyOnLoad(go);
    }

    //this is the code that runs when you have collided with assets with certain tags
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this is the code that runs when you collide with an asset with the tag 'key'
        if (collision.gameObject.tag == "Key")
        {
            //the question box is turned on so you can see the question
            questionBox.SetActive(true);
            //the minidoors turn on so that you dont attempt to finish the game
            //without answering the question
            MiniDoor.SetActive(true);
            //IDK what this does here, but when I tried to run the game with out it
            //the game crashed, so I left it alone.
            if (unansweredQuestions == null || unansweredQuestions.Count == 0)
            {
                unansweredQuestions = questions.ToList<Question>();
            }
            //presents you with a question by calling upon the 'currentQuestion' method
            SetCurrentQuestion();

            //this is the code that runs if you press 'button1' or 'true'
            _button1.onClick.AddListener(() =>
            {
                //this first part of the if statement runs if the statement was 
                //actually true
                if (currentQuestion.isTrue)
                {
                    //the question box gets turned off so you can continue with the game
                    questionBox.SetActive(false);
                    //the minidoors gets turned off so you can continue with the game
                    MiniDoor.SetActive(false);
                    //you got the question right so there is no need to tell you that you
                    //go the question wrong, so the message it left empty
                    wrong.text = "";
                    //this removed the current question you just answered so it does not show up again
                    unansweredQuestions.Remove(currentQuestion);
                }
                //this second part of the if statement runs if the statement was 
                //actually false
                else
                {
                    //the question box stays on because you got the previous question wrong and as
                    //a penalty you need to answer another question
                    questionBox.SetActive(true);
                    // the miniDoors stay on because you got the previous question wrong and as
                    //a penalty you need ot be kept in the same place you you can answer the next question
                    MiniDoor.SetActive(true);
                    //this text informs the player that they got the previous question wrong and must
                    //try again with a new question
                    wrong.text = "Incorrect! Try Again";
                    //this transitions to a new question
                    StartCoroutine(TransitionToNextQuestion());
                }
            });

            //this is the code that runs if you press 'button12' or 'false'
            _button2.onClick.AddListener(() =>
            {
                //this first part of the if statement runs if the statement was 
                //actually true
                if (currentQuestion.isTrue)
                {
                    //the question box stays on because you got the previous question wrong and as
                    //a penalty you need to answer another question
                    questionBox.SetActive(true);
                    // the miniDoors stay on because you got the previous question wrong and as
                    //a penalty you need ot be kept in the same place you you can answer the next question
                    MiniDoor.SetActive(true);
                    //this text informs the player that they got the previous question wrong and must
                    //try again with a new question
                    wrong.text = "Incorrect! Try Again";
                    //this transitions to a new question
                    StartCoroutine(TransitionToNextQuestion());
                }
                //this second part of the if statement runs if the statement was 
                //actually false
                else
                {
                    //the question box gets turned off so you can continue with the game
                    questionBox.SetActive(false);
                    //the minidoors gets turned off so you can continue with the game
                    MiniDoor.SetActive(false);
                    //you got the question right so there is no need to tell you that you
                    //go the question wrong, so the message it left empty
                    wrong.text = "";
                    //this removed the current question you just answered so it does not show up again
                    unansweredQuestions.Remove(currentQuestion);
                }

            });

            //this destroys the coin to let the player know that it has been collected
            Destroy(collision.gameObject);
            //this adds a single value to the variable that counts how many coins you have collected
            coins++;
            //this displays how many coins you have collected
            coinAmount.text = "Coins:" + coins;

        }

        //this code runs when you hit the big 'goal' coin in the end
        if (collision.gameObject.tag == "Goal")
        {
            //this displays a message to let you know you won
            youWin.text = "You Win!";
            //this stops the stopwatch as soon as you hit the goal to let you know
            //how long you took to get there
            stopwatchActive = false;
        }


        //has player bounce off wall with as much force as he collided into them with
        if (collision.gameObject.tag == "Walls")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
    }
}
