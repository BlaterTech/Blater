using System.ComponentModel;
using NetEscapades.EnumGenerators;

namespace Blater.Enumerations;

[EnumExtensions]
public enum ClusterSetupAction
{
    Null,
    [Description("enable_single_node")]
    EnableSingleNode,
    [Description("enable_cluster")]
    EnableCluster,
    [Description("add_node")]
    AddNode,
    [Description("finish_cluster")]
    FinishCluster
}