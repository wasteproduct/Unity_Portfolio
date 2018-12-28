using System.Collections.Generic;
using MapDataSet;
using TileDataSet;
using UnityEngine;

namespace AStar
{
    [CreateAssetMenu(fileName = "", menuName = "Calculation/AStar", order = 1)]
    public class Calculation_AStar : ScriptableObject
    {
        private int row, column;
        private Node_AStar currentNode;
        private List<Node_AStar> openList;
        private List<Node_AStar> closedList;

        public Node_AStar[,] Node { get; private set; }
        public List<Node_AStar> FinalTrack { get; private set; }

        public void Initialize(Map_Data mapData)
        {
            row = mapData.MapLength;
            column = mapData.MapLength;

            currentNode = null;

            Node = new Node_AStar[row, column];

            for (int z = 0; z < column; z++)
            {
                for (int x = 0; x < row; x++)
                {
                    Node[x, z] = new Node_AStar(mapData.TileData[x, z]);
                }
            }

            openList = new List<Node_AStar>();
            closedList = new List<Node_AStar>();

            FinalTrack = new List<Node_AStar>();
        }

        public bool FindPath(Map_TileData[,] tileData, Map_TileData startingTile, Map_TileData destinationTile, bool interactorTile = false)
        {
            if (startingTile == destinationTile) return false;

            Refresh(tileData, destinationTile);

            currentNode = Node[startingTile.X, startingTile.Z];

            closedList.Add(currentNode);

            int failureCount = row * column;

            if (interactorTile == true) Node[destinationTile.X, destinationTile.Z].Passable = true;

            while (true)
            {
                for (int z = currentNode.Z - 1; z < currentNode.Z + 2; z++)
                {
                    for (int x = currentNode.X - 1; x < currentNode.X + 2; x++)
                    {
                        if (NodeIndexAvailable(x, z) == false) continue;

                        if (Node[x, z].Passable == false) continue;

                        if (NodeInClosedList(Node[x, z]) == true) continue;

                        if (NodeInOpenList(Node[x, z]) == false)
                        {
                            Node[x, z].Parent = currentNode;
                            Node[x, z].CalculateCostToDestination();
                            openList.Add(Node[x, z]);
                        }
                        else
                        {
                            Node_AStar newData = new Node_AStar(Node[x, z]);
                            newData.Parent = currentNode;
                            newData.CalculateCostToDestination();

                            if (newData.CostToDestination < Node[x, z].CostToDestination)
                            {
                                Node[x, z].Parent = currentNode;
                                Node[x, z].CalculateCostToDestination();
                            }
                        }
                    }
                }

                int lowestCost = 99999999;
                for (int i = 0; i < openList.Count; i++)
                {
                    if (openList[i].CostToDestination < lowestCost)
                    {
                        lowestCost = openList[i].CostToDestination;
                        currentNode = openList[i];
                    }
                }

                if (currentNode == Node[destinationTile.X, destinationTile.Z])
                {
                    int whileBreaker = 64 * 64;

                    if (interactorTile == true) currentNode = currentNode.Parent;

                    while (true)
                    {
                        FinalTrack.Add(currentNode);

                        if (currentNode == Node[startingTile.X, startingTile.Z])
                        {
                            FinalTrack.Reverse();
                            return true;
                        }

                        currentNode = currentNode.Parent;

                        whileBreaker--;
                        if (whileBreaker < 0) return false;
                    }
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                failureCount--;
                if (failureCount < 0) return false;
            }
        }

        private bool NodeInOpenList(Node_AStar checkedNode)
        {
            for (int i = 0; i < openList.Count; i++)
            {
                if (openList[i] == checkedNode) return true;
            }

            return false;
        }

        private void Refresh(Map_TileData[,] tileData, Map_TileData destinationTile)
        {
            openList.Clear();
            closedList.Clear();
            FinalTrack.Clear();
            currentNode = null;

            for (int z = 0; z < column; z++)
            {
                for (int x = 0; x < row; x++)
                {
                    Node[x, z].Initialize(tileData[x, z], destinationTile);
                }
            }
        }

        private bool NodeInClosedList(Node_AStar checkedNode)
        {
            for (int i = 0; i < closedList.Count; i++)
            {
                if (closedList[i] == checkedNode) return true;
            }

            return false;
        }

        private bool NodeIndexAvailable(int x, int z)
        {
            if ((x < 0) || (x >= row) || (z < 0) || (z >= column)) return false;

            return true;
        }
    }

    public class Node_AStar
    {
        public Node_AStar(Map_TileData correspondingTile)
        {
            X = correspondingTile.X;
            Z = correspondingTile.Z;
        }

        public Node_AStar(Node_AStar copiedNode)
        {
            this.X = copiedNode.X;
            this.Z = copiedNode.Z;
            this.Parent = copiedNode.Parent;
            this.Passable = copiedNode.Passable;
            this.DistanceFromStart = copiedNode.DistanceFromStart;
            this.DistanceToDestination = copiedNode.DistanceToDestination;
            this.CostToDestination = copiedNode.CostToDestination;
        }

        // Constructor
        public int X { get; private set; }
        public int Z { get; private set; }

        // Initialize
        public bool Passable { get; set; }
        public int DistanceToDestination { get; private set; }

        public Node_AStar Parent { get; set; }
        public int DistanceFromStart { get; private set; }
        public int CostToDestination { get; private set; }

        public void Initialize(Map_TileData correspondingTile, Map_TileData destinationTile)
        {
            Parent = null;
            Passable = (correspondingTile.Type == TileType.Floor) ? true : false;

            CalculateDistanceToDestination(destinationTile);
        }

        public void CalculateCostToDestination()
        {
            CalculateDistanceFromStart();

            CostToDestination = DistanceFromStart + DistanceToDestination;
        }

        private void CalculateDistanceFromStart()
        {
            if ((this.Parent.X - this.X != 0) && (this.Parent.Z - this.Z != 0))
            {
                this.DistanceFromStart = this.Parent.DistanceFromStart + 14;
            }
            else
            {
                this.DistanceFromStart = this.Parent.DistanceFromStart + 10;
            }
        }

        private void CalculateDistanceToDestination(Map_TileData destinationTile)
        {
            int destinationX = destinationTile.X;
            int destinationZ = destinationTile.Z;

            int xDistance = Mathf.Abs(destinationX - X);
            int zDistance = Mathf.Abs(destinationZ - Z);

            if (xDistance - zDistance == 0)
            {
                DistanceToDestination = 14 * zDistance;
            }
            else
            {
                int linearDistance = Mathf.Abs(xDistance - zDistance);
                int furtherAxis = (xDistance - zDistance > 0) ? xDistance : zDistance;
                int diagonalDistance = furtherAxis - linearDistance;

                DistanceToDestination = linearDistance * 10 + diagonalDistance * 14;
            }
        }
    }
}
