using System;

namespace Prometheus.Controls
{
  public class NodeStateSubscriber
  {
    private NodeState state;
    private NodeInfo parentInfo;
    private bool active = false;

    public NodeState State
    {
      get { return state; }
    }

    public MultiSourceTreeNode Node
    {
      get { return parentInfo.Node; }
    }

    /// <summary>
    /// Gets or sets a value indicating if the state is currently active.
    /// </summary>
    public bool Active
    {
      get { return active; }
      set
      {
        if (active != value)
        {
          active = value;
          if (StateChanged != null)
            StateChanged(this, new NodeStateChangedArgs(parentInfo.Identifier, value));
        }
      }
    }

    /// <summary>
    /// Gets the identifier of the NodeInfo that has subscribed to this state.
    /// </summary>
    public string Identifier
    {
      get { return parentInfo.Identifier; }
    }

    public NodeStateSubscriber(NodeState state, NodeInfo parentInfo)
    {
      this.state = state;
      this.parentInfo = parentInfo;
    }

    /// <summary>
    /// Indicates that the subscribed-to NodeState has changed..
    /// </summary>
    public event EventHandler<NodeStateChangedArgs> StateChanged;
  }

  /// <summary>
  /// Provides data for an event that is generated when a NodeState changes state.
  /// </summary>
  public class NodeStateChangedArgs : EventArgs
  {
    private string identifier;
    private bool stateActive;

    /// <summary>
    /// Gets the identifier of the node that will be effected by the state change.
    /// </summary>
    public string Identifier
    {
      get { return identifier; }
    }

    /// <summary>
    /// The a value indicating if the state is currently active.
    /// </summary>
    public bool StateActive
    {
      get { return stateActive; }
    }

    /// <summary>
    /// Creates an instance of the NodeStateChangedArgs class with the specified values.
    /// </summary>
    public NodeStateChangedArgs(string identifier, bool stateActive)
    {
      this.identifier = identifier;
      this.stateActive = stateActive;
    }
  }
}
