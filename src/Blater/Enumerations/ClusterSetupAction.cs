using System.ComponentModel;

namespace Blater.Enumerations;

public enum ClusterSetupAction
{
    [Description("enable_single_node")]
    EnableSingleNode,
    [Description("enable_cluster")]
    EnableCluster,
    [Description("add_node")]
    AddNode,
    [Description("finish_cluster")]
    FinishCluster
}