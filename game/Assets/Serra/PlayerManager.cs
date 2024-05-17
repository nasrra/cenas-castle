using Unity.VisualScripting;
using UnityEngine;

namespace Serra { public class PlayerManager : MonoBehaviour{




    [Header("Player")]
    [SerializeField] GameObject player;

    void Awake(){
        Managers.player_manager = this;
    }

    void Start(){
        if(Managers.scene_entry_point != null)
            player.transform.position = Managers.scene_info.entry_points[Managers.scene_entry_point].position;
    }

    public GameObject get_player(){
        return player;
    }

    public void set_player(GameObject player){
        this.player = player;
    }




}}