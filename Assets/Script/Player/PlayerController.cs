using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    public GameObject itemPopUp;

    private Animator anim; //acesso ao animator

    private float horizontal;
    private float vertical;

    [Header("Config Player")]
    public float movementSpeed = 3f;
    private Vector3 direction;

    private bool isWalk; // Recomendado o mesmo nome no Animator
    private bool isFreeze;

    /*
    [Header("Config Attack")]
    public ParticleSystem fxAttack;
    private bool isAttack;
    */

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        anim = GetComponent<Animator>(); //Vai precisar mudar a animação

        Time.timeScale = 1.0f;
    }


    void Update()
    {
        CheckFreeze();

        Inputs();

        MoveCharacter();

        UpdateAnimator();
    }

    //CONGELAR MOVIMENTOS DO PLAYER
    public bool CheckFreeze()
    {
        bool freeze;

        if (InventoryManager.instance.inInventory)
        {
            freeze = true;
            //Time.timeScale = 0f;
            isFreeze = true;
        }
        else if (InventoryManager.instance.itemPopUp.InPopUp)
        {
            isFreeze = true;
            freeze = true;
        }
        else
        {
            freeze = false;
            //Time.timeScale = 1.0f;
            isFreeze = false;
        }

        return freeze;
    } 

    #region Métodos

    //ENTRADA DE COMANDOS DO USUÁRIO
    void Inputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        /*
        if (Input.GetButtonDown("Fire1") && isAttack == false) //Atacar
        {
            Attack();
        }
        */
    }

    void Interact()
    {

    }

    //MOVER O PLAYER
    void MoveCharacter()
    {
        direction = new Vector3(horizontal, 0, vertical).normalized; //Movimento do Player

        if (direction.magnitude > 0.1f)
        {
            float targetAgle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAgle, 0);
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }

        characterController.Move(direction * movementSpeed * Time.deltaTime);
    }

    //ATAQUE
    /*
    void Attack()
    {
        isAttack = true;
        anim.SetTrigger("Attack");
        fxAttack.Emit(2);
    }

    void EndAttack()
    {
        isAttack = false;
    }
    */

    //ATUALIZAR O ANIMATOR
    void UpdateAnimator()
    {
        anim.SetBool("isWalk", isWalk); // Sempre no final
        anim.SetBool("isFreeze", isFreeze);
    }

    #endregion
}
