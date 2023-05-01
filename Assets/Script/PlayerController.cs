using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;
public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private NetworkCharacterControllerPrototype networkCharacterController = null;
    [SerializeField]
    private Bullet bulletPrefab;
    [SerializeField]
    private float moveSpeed = 15f;
    [SerializeField]
    private Image hpBar = null;
    [SerializeField]
    private int maxHp = 100;
    [Networked(OnChanged = nameof(OnHpChanged))]
    public int Hp { get; set; }
    [Networked(OnChanged = nameof(OnNameChanged))]
    public NetworkString<_16> PlayerName { get; set; }
    [Networked]
    public NetworkButtons ButtonsPrevious { get; set; }
    [SerializeField]
    private MeshRenderer meshRenderer = null;
    public override void Spawned()
    {
        if(Object.HasInputAuthority)
        {
            SetPlayerName_RPC(PlayerPrefs.GetString("PlayerName"));
        }
        else
        {

        }
        if (Object.HasStateAuthority)
            Hp = maxHp;
    }
    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            NetworkButtons buttons = data.buttons;
            var pressed = buttons.GetPressed(ButtonsPrevious);
            ButtonsPrevious = buttons;
            if (pressed.IsSet(InputButtons.JUMP))
            {
                networkCharacterController.Jump();
            }
            if (pressed.IsSet(InputButtons.FIRE))
            {
                Runner.Spawn(
                    bulletPrefab,
                    transform.position + transform.TransformDirection(Vector3.forward),
                    Quaternion.LookRotation(transform.TransformDirection(Vector3.forward)),
                    Object.InputAuthority);
            }
            Vector3 moveVector = data.movementInput.normalized;
            networkCharacterController.Move(moveSpeed * moveVector * Runner.DeltaTime);
        }
        if (Hp <= 0 || networkCharacterController.transform.position.y <= -5f)
        {
            Respawn();
        }
    }
    private void Respawn()
    {
        networkCharacterController.transform.position = Vector3.up * 2;
        Hp = maxHp;
    }
    public void SetNameAfterSpawned(string name)
    {
        PlayerName = name;
        print("PlayerName is: "+ PlayerName);
    }
    static void OnNameChanged(Changed<PlayerController> changed)
    {
        Debug.Log($"Name changed for player to {changed.Behaviour.PlayerName}");
    }
    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void SetPlayerName_RPC(string name,RpcInfo info=default)
    {
        Debug.Log($"[RPC] SetName {name}");
        this.PlayerName= name;
    }

    public void TakeDamage(int damage)
    {
        if (Object.HasStateAuthority)
        {
            Hp -= damage;
        }
    }
    private static void OnHpChanged(Changed<PlayerController> changed)
    {
        changed.Behaviour.hpBar.fillAmount = (float)changed.Behaviour.Hp / changed.Behaviour.maxHp;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeColor_RPC(Color.red);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeColor_RPC(Color.green);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeColor_RPC(Color.blue);
        }
    }
    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    private void ChangeColor_RPC(Color newColor)
    {
        meshRenderer.material.color = newColor;
    }
    

}