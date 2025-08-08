using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reflection;

namespace thhylR.Helper
{
    [Obfuscation(Exclude = false)]
    public abstract class TreeNode<T, TNode> where TNode : TreeNode<T, TNode>
    {
        protected TNode parent = null;
        protected ObservableCollection<TNode> children;
        protected int nodeIndex = -1;
        protected bool replaceToNullOnChildRemove = false;

        protected bool isNodeChanging = false;

        public virtual TNode Parent
        {
            get => parent;
            set
            {
                if (parent == value) return;
                if (parent != null)
                {
                    if (replaceToNullOnChildRemove)
                    {
                        parent.children[nodeIndex] = null;
                    }
                    else
                    {
                        parent.children.RemoveAt(nodeIndex);
                    }
                }
                if (value == null)
                {
                    parent = null;
                }
                else
                {
                    if (value.children == null)
                    {
                        value.Children = [];
                    }
                    value.children.Add((TNode)this);
                }
            }
        }

        public virtual int NodeIndex
        {
            get => nodeIndex;
            set
            {
                if (nodeIndex == value) return;
                if (parent == null) throw new InvalidOperationException();
                if (value < 0 || value >= parent.children.Count) throw new IndexOutOfRangeException();
                parent.children.Move(nodeIndex, value);
            }
        }

        public T Value { get; set; }

        public virtual ObservableCollection<TNode> Children
        {
            get => children;
            set
            {
                if (value == children) return;
                children = value;
                if (children == null) return;
                if (children.Count > 0)
                {
                    for (int i = 0; i < children.Count; i++)
                    {
                        TNode item = children[i];
                        if (item != null)
                        {
                            item.parent = (TNode)this;
                            item.nodeIndex = i;
                        }
                    }
                }
                children.CollectionChanged += Children_CollectionChanged;
            }
        }

        protected void Children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                for (int i = 0; i < e.OldItems.Count; i++)
                {
                    TNode item = (TNode)e.OldItems[i];
                    if (item != null)
                    {
                        if (item.parent == this)
                        {
                            item.parent = null;
                            item.nodeIndex = -1;
                        }
                    }
                }

                for (int i = e.OldStartingIndex; i < children.Count; i++)
                {
                    TNode item = children[i];
                    if (item != null)
                    {
                        item.nodeIndex = i;
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Move)
            {
                int start = e.OldStartingIndex;
                int end = e.NewStartingIndex;
                if (start > end)
                {
                    start = e.NewStartingIndex;
                    end = e.OldStartingIndex;
                }

                for (int i = start; i <= end; i++)
                {
                    TNode item = children[i];
                    if (item != null)
                    {
                        item.nodeIndex = i;
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                for (int i = 0; i < e.NewItems.Count; i++)
                {
                    TNode item = (TNode)e.NewItems[i];
                    if (item != null)
                    {
                        if (item.parent != null)
                        {
                            if (replaceToNullOnChildRemove)
                            {
                                item.parent.children[item.nodeIndex] = null;
                            }
                            else
                            {
                                item.parent.children.RemoveAt(item.nodeIndex);
                            }
                        }
                        item.parent = (TNode)this;
                        item.nodeIndex = i + e.NewStartingIndex;
                    }
                }

                for (int i = e.NewStartingIndex + e.NewItems.Count; i < children.Count; i++)
                {
                    TNode item = children[i];
                    if (item != null)
                    {
                        item.parent = (TNode)this;
                        item.nodeIndex = i;
                    }
                }
            }
            else
            {
                if (e.OldItems != null && e.OldItems.Count > 0)
                {
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        TNode item = (TNode)e.OldItems[i];
                        if (item != null)
                        {
                            if (item.parent == this)
                            {
                                item.parent = null;
                                item.nodeIndex = -1;
                            }
                        }
                    }
                }

                if (e.NewItems != null && e.NewItems.Count > 0)
                {
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        TNode item = (TNode)e.NewItems[i];
                        if (item != null)
                        {
                            if (item.parent != null)
                            {
                                if (replaceToNullOnChildRemove)
                                {
                                    item.parent.children[item.nodeIndex] = null;
                                }
                                else
                                {
                                    item.parent.children.RemoveAt(item.nodeIndex);
                                }
                            }
                            item.parent = (TNode)this;
                            item.nodeIndex = i + e.NewStartingIndex;
                        }
                    }
                }
            }
        }

        public virtual bool IsLeaf
        {
            get
            {
                return children == null || children.Count == 0;
            }
        }

        public virtual TNode PreviousSibling
        {
            get
            {
                if (nodeIndex == 0)
                {
                    return null;
                }
                return parent.children[nodeIndex - 1];
            }
        }

        public virtual TNode NextSibling
        {
            get
            {
                if (nodeIndex == parent.children.Count - 1)
                {
                    return null;
                }
                return parent.children[nodeIndex + 1];
            }
        }

        public virtual TNode PreviousSiblingLooping
        {
            get
            {
                if (nodeIndex == 0)
                {
                    return parent.children[^1];
                }
                return parent.children[nodeIndex - 1];
            }
        }

        public virtual TNode NextSiblingLooping
        {
            get
            {
                if (nodeIndex == parent.children.Count - 1)
                {
                    return parent.children[0];
                }
                return parent.children[nodeIndex + 1];
            }
        }
    }

    [Obfuscation(Exclude = false)]
    public class ExpressionTreeNode<T> : TreeNode<T, ExpressionTreeNode<T>>
    {
        public ExpressionTreeNode(bool initializeChildren = false)
        {
            replaceToNullOnChildRemove = true;
            if (initializeChildren)
            {
                Children = [null, null, null];
            }
        }

        public ExpressionTreeNode(T value, bool initializeChildren = false) : this(initializeChildren)
        {
            Value = value;
        }

        public ExpressionTreeNode(T value, int currentIndex) : this(value, true)
        {
            CurrentChildrenIndex = currentIndex;
        }

        public int CurrentChildrenIndex { get; set; }
    }

    [Obfuscation(Exclude = false)]
    public class BinaryTreeNode<T> : TreeNode<T, BinaryTreeNode<T>>
    {
        public override ObservableCollection<BinaryTreeNode<T>> Children
        {
            get
            {
                throw new InvalidOperationException();
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public BinaryTreeNode()
        {
            replaceToNullOnChildRemove = true;
            children = [null, null];
            children.CollectionChanged += Children_CollectionChanged;
        }

        public override BinaryTreeNode<T> Parent
        {
            get => parent;
            set
            {
                if (value != null)
                {
                    throw new InvalidOperationException();
                }
                if (parent == null) return;
                parent.children[nodeIndex] = null;
                parent = null;
            }
        }

        public BinaryTreeNode(T value) : this()
        {
            Value = value;
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                return children[0];
            }
            set
            {
                children[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                return children[1];
            }
            set
            {
                children[1] = value;
            }
        }

        public override bool IsLeaf
        {
            get
            {
                return Left == null && Right == null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns>is root node</returns>
        public bool ReplaceNode(BinaryTreeNode<T> target)
        {
            Left = target.Left;
            Right = target.Right;
            if (target.parent == null)
            {
                parent = null;
                return true;
            }
            else
            {
                if (parent != null)
                {
                    parent.children[nodeIndex] = null;
                }
                target.parent.children[target.nodeIndex] = this;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns>is root node</returns>
        public bool MoveToNode(BinaryTreeNode<T> target)
        {
            if (target.parent == null)
            {
                parent = null;
                return true;
            }
            else
            {
                if (parent != null)
                {
                    parent.children[nodeIndex] = null;
                }
                target.parent.children[target.nodeIndex] = this;
                return false;
            }
        }

        public enum NodePosition
        {
            Left = 0,
            Right = 1
        }
    }
}
