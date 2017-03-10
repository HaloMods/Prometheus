using System.Collections.Generic;
using System.Drawing;

namespace Prometheus.Controls
{
  /// <summary>
  /// Provides a base for creating classes that describe and handle changes in
  /// state for MultiSourceTreeNodes.
  /// </summary>
  public abstract class NodeState
  {
    private Dictionary<MenuDefinition, bool> menuDefinitions = new Dictionary<MenuDefinition, bool>();
    private NodeType parentType;
    private string name;
    private Bitmap collapsedIcon;
    private Bitmap expandedIcon;
    private int collapsedIconIndex;
    private int expandedIconIndex;
    private Color foregroundColor = Color.Black;
    private Color backgroundColor = Color.White;
    
    protected List<NodeStateSubscriber> subscriptions = new List<NodeStateSubscriber>();

    /// <summary>
    /// Gets the menu definitions associated with this NodeState.
    /// </summary>
    public Dictionary<MenuDefinition, bool> MenuDefinitions
    {
      get { return menuDefinitions; }
    }

    /// <summary>
    /// Gets or sets the parent NodeType that this NodeState belongs to.
    /// </summary>
    public NodeType ParentType
    {
      get { return parentType; }
      set { parentType = value; }
    }

    /// <summary>
    /// Gets the name used to identify the NodeState.
    /// </summary>
    public string Name
    {
      get { return name; }
    }

    /// <summary>
    /// The icon that will be used to represent collapsed MultiSourceTreeNodes
    /// in which this NodeState is active.
    /// </summary>
    public Bitmap CollapsedIcon
    {
      get { return collapsedIcon; }
      set { collapsedIcon = value; }
    }

    /// <summary>
    /// The icon that will be used to represent expanded MultiSourceTreeNodes
    /// in which this NodeState is active.
    /// </summary>
    public Bitmap ExpandedIcon
    {
      get { return expandedIcon; }
      set { expandedIcon = value; }
    }

    /// <summary>
    /// Gets or sets the image index of the CollapsedIcon within an ImageList.
    /// </summary>
    public int CollapsedIconIndex
    {
      get { return collapsedIconIndex; }
      set { collapsedIconIndex = value; }
    }

    /// <summary>
    /// Gets or sets the image index of the ExpandedIcon within an ImageList.
    /// </summary>
    public int ExpandedIconIndex
    {
      get { return expandedIconIndex; }
      set { expandedIconIndex = value; }
    }

    /// <summary>
    /// Gets or sets the foreground color that represents this node state.
    /// </summary>
    public Color ForegroundColor
    {
      get { return foregroundColor; }
      set { foregroundColor = value; }
    }

    /// <summary>
    /// Gets or sets the background color that represents this node state.
    /// </summary>
    public Color BackgroundColor
    {
      get { return backgroundColor; }
      set { backgroundColor = value; }
    }

    /// <summary>
    /// Default base constructor.
    /// </summary>
    protected NodeState(string name, Bitmap expandedIcon, Bitmap collapsedIcon,
      Color foregroundColor, Color backgroundColor)
    {
      this.name = name;
      this.collapsedIcon = collapsedIcon;
      this.expandedIcon = expandedIcon;
      this.foregroundColor = foregroundColor;
      this.backgroundColor = backgroundColor;
    }

    /// <summary>
    /// Adds the specified collection of MenuDefinitions to this NodeState.
    /// </summary>
    /// <param name="definitions">The definitions to add.</param>
    public void AddMenuDefinitions(params MenuDefinition[] definitions)
    {
      foreach (MenuDefinition def in definitions)
        if (!menuDefinitions.ContainsKey(def))
          menuDefinitions.Add(def, false);
    }

    /// <summary>
    /// Adds the specified MenuDefinition to this NodeState.
    /// </summary>
    /// <param name="definition">The definition to add.</param>
    /// <param name="additionalDefinitions">Additional non-default definitions to add.</param>
    public void AddDefaultMenuDefinition(MenuDefinition definition, params MenuDefinition[] additionalDefinitions)
    {
      menuDefinitions.Add(definition, true);
      foreach (MenuDefinition def in additionalDefinitions)
        menuDefinitions.Add(def, false);
    }

    /// <summary>
    /// Updates all subscribers that match the specified identifier.
    /// </summary>
    protected void UpdateSubscribers(string identifier, bool state)
    {
      foreach (NodeStateSubscriber subscriber in subscriptions.ToArray())
        if (subscriber.Identifier == identifier)
          if (subscriber.Node != null)
            subscriber.Active = state;
    }

    public void SetState(string identifier, bool state)
    {
      UpdateSubscribers(identifier, state);
    }

    /// <summary>
    /// Returns a value indicating if the specified NodeInfo has already subscribed to this state.
    /// </summary>
    protected bool SubscriptionExists(NodeInfo info)
    {
      foreach (NodeStateSubscriber subscriber in subscriptions)
        if (subscriber.Identifier == info.Identifier)
          return true;
      return false;
    }

    /// <summary>
    /// Gets a subscription to this NodeType.
    /// </summary>
    public NodeStateSubscriber GetSubscription(NodeInfo info)
    {
      NodeStateSubscriber subscriber = new NodeStateSubscriber(this, info);
      subscriber.Active = DetermineState(info);
      subscriptions.Add(subscriber);
      return subscriber;
    }

    /// <summary>
    /// Determines the current state of the specified node.
    /// </summary>
    protected abstract bool DetermineState(NodeInfo info);
  }
}