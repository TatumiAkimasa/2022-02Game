using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PL : MonoBehaviour
{
    public float speed; // ��������
    public float jump_power;

    private Rigidbody rb; // Rididbody
    private int score; // �X�R�A
    private bool jump_flag;
    public int jump_now,time,jump_barst,out_p;

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    AudioSource audioSource;

    public float gravitey;

  
    void Start()
    {
        // Rigidbody ��擾
        rb = GetComponent<Rigidbody>();

        //Component��擾
        audioSource = GetComponent<AudioSource>();

        jump_flag = true;
        jump_now = 0;
        time = 0;
        out_p = 0;
        jump_barst = 1;

        gravitey = -9.81f;
    }

    void FixedUpdate()
    {
        Vector3 tmp = transform.position;

        //// �J�[�\���L�[�̓��͂�擾
        //var moveHorizontal = Input.GetAxis("Horizontal");
        //var moveVertical = Input.GetAxis("Vertical");

        // �J�[�\���L�[�̓��͂ɍ��킹�Ĉړ�������ݒ�
        var movement = new Vector3(1.0f, 0, 0.0f);


        var rb = GetComponent<Rigidbody>();
        const float targetVelocity = 9.0f;
        const float power = 20;
        rb.AddForce(Vector3.right * ((targetVelocity - rb.velocity.x) * power), ForceMode.Acceleration);


        if (Input.GetKey(KeyCode.Space))
        {
            if (jump_flag == true&&jump_now<2)
            {
                var jump = new Vector3(0, 1, 0);

                jump_now++;
                time = 0;

                jump_flag = false;

                if (jump_now == 2)
                {
                    var velocity = GetComponent<Rigidbody>().velocity;

                    if (velocity.y < 0.0f)
                    {
                        rb.AddForce(jump * jump_power * jump_barst);

                        StartCoroutine(Jump(jump_barst));
                    }
                    else
                    {
                        jump_now--;
                        time = 0;

                        jump_flag = true;
                    }    
                }
                else
                {
                    rb.AddForce(jump * jump_power * jump_barst);

                    StartCoroutine(Jump(jump_barst));
                }
            }
           
        }
        else if(jump_flag==false)
        {
            jump_flag = true;

        }

        if (tmp.y < -30.0f)
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKey(KeyCode.LeftShift)==true)
        {
            time++;
        }
        else if(Input.GetKey(KeyCode.LeftShift) == false)
        {
            time = 0;
        }

        if(time<29)
        {
            jump_barst = 1;
            if (time == 28)
                audioSource.PlayOneShot(sound1);
        }
        else if(time<59)
        {
            jump_barst = 2;
            if (time == 58)
                audioSource.PlayOneShot(sound2);
        }
        else if(time<89)
        {
            jump_barst = 3;
            if (time % 88 == 0)
            {
                audioSource.PlayOneShot(sound3);
            }

        }
        else if (time > 90)
        {
            jump_barst = 4;
            if(time%30==0)
            {
                audioSource.PlayOneShot(sound3);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            jump_now = 0;
           // time = 0;
        }
           
    }

    void OnTriggerEnter(Collider triger)
    {
        if (triger.gameObject.tag == "OutZone")
        {
            out_p++;
           
        }
        else if (triger.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene("Result");

        }

    }

    public IEnumerator Jump(int a)
    {
        for (int i = 0; i != a+2; i++)
        {
            if (i == 0)
            {
                if (a == 1)
                    yield return new WaitForSeconds(0.1f * a);
                else if (a == 2)
                    yield return new WaitForSeconds(0.38f);
                else if (a == 3)
                    yield return new WaitForSeconds(0.36f);
                else if (a == 4)
                    yield return new WaitForSeconds(0.3f);
            }
            else if (i == a)
            {

                if (a == 1)
                {
                    gravitey = -9.81f;

                    Physics.gravity = new Vector3(0, gravitey, 0);

                    yield return new WaitForSeconds(0.2f);
                }
                else if (a == 2)
                {
                    gravitey = -30.0f;

                    Physics.gravity = new Vector3(0, gravitey, 0);

                    yield return new WaitForSeconds(0.5f);
                }
                else if (a == 3)
                {
                    gravitey = -67.0f;

                    Physics.gravity = new Vector3(0, gravitey, 0);

                    yield return new WaitForSeconds(0.3f);
                }
                else if (a == 4)
                {
                    gravitey = -90.0f;

                    Physics.gravity = new Vector3(0, gravitey, 0);

                    yield return new WaitForSeconds(0.48f);
                }

            }
            else if (i == a + 1)
            {
                gravitey = -9.81f;

                Physics.gravity = new Vector3(0, gravitey, 0);
            }

        }
    }
}