using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Checkpoint[] checkpoints;

    private void Start()
    {
        checkpoints = GetComponentsInChildren<Checkpoint>();
    }

    public Checkpoint GetLastCheckpointThatWasPassed()
    {
        // Don't use too much, it's going to cause garbage!
        if(checkpoints.Length > 0)
            return checkpoints.Last(t => t.Passed == true);

        return null;
    }
}
