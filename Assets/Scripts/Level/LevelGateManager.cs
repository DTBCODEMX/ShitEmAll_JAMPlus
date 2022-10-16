using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGateManager : MonoBehaviour
{
    private class EnemyMaskAndBool
    {
        public EnemyMaskAndBool(EnemyMask _enemy_mask, bool isAlreadyDead)
        {
            enemy_mask = _enemy_mask;
            is_already_dead = isAlreadyDead;
        }

        public EnemyMask enemy_mask;
        public bool is_already_dead;
    } // EnemyMaskAndBool

    [SerializeField] private List<LevelGate> _gates = null;
    [SerializeField] private List<EnemyMaskAndBool> _enemies_refs = null;
    public GameObject pre_fab_gate = null;
    public int current_index = 0;

    // Start is called before the first frame update
    void Start()
    {
        _gates ??= new List<LevelGate>();
        _enemies_refs ??= new List<EnemyMaskAndBool>();
        Debug.Assert(pre_fab_gate != null, "needs a pre fab for the LevelGate");
        current_index = 0;

        get_enemies_masks();
    }

    void Update()
    {
        var current_gate = _gates[current_index];
        bool has_processed_all_gates = current_index >= _gates.Count;
        if (has_processed_all_gates)
        {
            return;
        }

        if (current_gate.score_for_deactivation <= current_gate.current_score)
        {
            if ((current_index + 1) < _gates.Count)
            {
                current_gate.reset_score();
                current_index += 1;
            }
        }

        if (current_gate.score_for_deactivation > _enemies_refs.Count)
        {
        }

        handle_keeping_score();
    }

    private void handle_keeping_score()
    {
        List<int> marked_for_removal = new List<int>();
        int counter = 0;
        foreach (var enemy in _enemies_refs)
        {
            if (enemy.enemy_mask.is_dead && !enemy.is_already_dead)
            {
                marked_for_removal.Add(counter);
                _gates[current_index].increase_score(1);
                enemy.is_already_dead = true;
            }

            counter += 1;
        }
    }

    void get_enemies_masks()
    {
        var temp = GameObject.FindObjectsOfType<EnemyMask>();

        foreach (EnemyMask enemy in temp)
        {
            _enemies_refs.Add(new EnemyMaskAndBool(enemy, false));
        }
    }
}
        